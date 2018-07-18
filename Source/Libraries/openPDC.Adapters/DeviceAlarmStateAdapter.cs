//******************************************************************************************************
//  DeviceAlarmStateAdapter.cs - Gbtc
//
//  Copyright © 2018, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may not use this
//  file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  07/18/2018 - J. Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using GSF;
using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.Threading;
using GSF.TimeSeries;
using GSF.TimeSeries.Adapters;
using openPDC.Model;
using AlarmStateRecord = openPDC.Model.AlarmState;
using ConnectionStringParser = GSF.Configuration.ConnectionStringParser<GSF.TimeSeries.Adapters.ConnectionStringParameterAttribute>;

namespace openPDC.Adapters
{
    /// <summary>
    /// Represents an adapter that will monitor and report device alarm states.
    /// </summary>
    [Description("Device Alarm State: Monitors and updates alarm states for devices")]
    public class DeviceAlarmStateAdapter : FacileActionAdapterBase
    {
        #region [ Members ]

        private enum AlarmState
        {
            Good,
            Alarm,
            NotAvailable,
            BadData,
            BadTime,
            OutOfService
        }

        // Constants
        private const int DefaultMonitoringRate = 30000;
        private const double DefaultAlarmTime = 10.0D;

        // Fields
        private Timer m_monitoringTimer;
        private ShortSynchronizedOperation m_monitoringOperation;
        private Dictionary<AlarmState, AlarmStateRecord> m_alarmStates;
        private Dictionary<int, MeasurementKey> m_deviceMeasurementKeys;
        private Dictionary<Guid, Ticks> m_lastDeviceDataUpdates;
        private Ticks m_alarmTime;
        private bool m_disposed;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DeviceAlarmStateAdapter"/>.
        /// </summary>
        public DeviceAlarmStateAdapter()
        {
            m_alarmTime = TimeSpan.FromMinutes(DefaultAlarmTime).Ticks;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets monitoring rate, in milliseconds, for devices.
        /// </summary>
        [ConnectionStringParameter,
         Description("Defines overall monitoring rate, in milliseconds, for devices."),
         DefaultValue(DefaultMonitoringRate)]
        public int MonitoringRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the time, in minutes, for which to change the device state to alarm when no data is received.
        /// </summary>
        [ConnectionStringParameter,
         Description("Defines the time, in minutes, for which to change the device state to alarm when no data is received."),
         DefaultValue(DefaultMonitoringRate)]
        public double AlarmMinutes
        {
            get => m_alarmTime.ToMinutes();
            set => m_alarmTime = TimeSpan.FromMinutes(value).Ticks;
        }

        /// <summary>
        /// Gets or sets primary keys of input measurements the adapter expects, if any.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // Automatically controlled
        public override MeasurementKey[] InputMeasurementKeys
        {
            get => base.InputMeasurementKeys;
            set => base.InputMeasurementKeys = value;
        }

        /// <summary>
        /// Gets or sets output measurements that the adapter will produce, if any.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)] // Automatically controlled
        public override IMeasurement[] OutputMeasurements
        {
            get => base.OutputMeasurements;
            set => base.OutputMeasurements = value;
        }

        /// <summary>
        /// Gets the flag indicating if this adapter supports temporal processing.
        /// </summary>
        public override bool SupportsTemporalProcessing => false;

        /// <summary>
        /// Returns the detailed status of the data input source.
        /// </summary>
        public override string Status
        {
            get
            {
                StringBuilder status = new StringBuilder();

                status.Append(base.Status);
                status.AppendFormat("           Monitoring Rate: {0:N0}ms", MonitoringRate);
                status.AppendLine();
                status.AppendFormat("        Monitoring Enabled: {0}", MonitoringEnabled);
                status.AppendLine();
                status.AppendFormat("    Monitored Device Count: {0:N0}", InputMeasurementKeys?.Length ?? 0);
                status.AppendLine();
                status.AppendFormat("     No Data Alarm Timeout: {0}", m_alarmTime.ToElapsedTimeString(2));
                status.AppendLine();

                return status.ToString();
            }
        }

        private bool MonitoringEnabled => Enabled && (m_monitoringTimer?.Enabled ?? false);

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="DeviceAlarmStateAdapter"/> object and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                try
                {
                    if (disposing)
                    {
                        if ((object)m_monitoringTimer != null)
                        {
                            m_monitoringTimer.Enabled = false;
                            m_monitoringTimer.Elapsed -= m_monitoringTimer_Elapsed;
                            m_monitoringTimer.Dispose();
                        }
                    }
                }
                finally
                {
                    m_disposed = true;          // Prevent duplicate dispose.
                    base.Dispose(disposing);    // Call base class Dispose().
                }
            }
        }

        /// <summary>
        /// Initializes <see cref="DeviceAlarmStateAdapter" />.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            ConnectionStringParser parser = new ConnectionStringParser();
            parser.ParseConnectionString(ConnectionString, this);

            m_alarmStates = new Dictionary<AlarmState, AlarmStateRecord>();
            m_deviceMeasurementKeys = new Dictionary<int, MeasurementKey>();
            m_lastDeviceDataUpdates = new Dictionary<Guid, Ticks>();

            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                // Load alarm state map - this defines database state ID and custom color for each alarm state
                TableOperations<AlarmStateRecord> alarmStateTable = new TableOperations<AlarmStateRecord>(connection);
                AlarmStateRecord[] alarmStateRecords = alarmStateTable.QueryRecords().ToArray();

                foreach (AlarmState alarmState in Enum.GetValues(typeof(AlarmState)))
                {
                    AlarmStateRecord alarmStateRecord = alarmStateRecords.FirstOrDefault(record => record.State.RemoveWhiteSpace().Equals(alarmState.ToString(), StringComparison.OrdinalIgnoreCase));

                    if (alarmStateRecord == null)
                    {
                        alarmStateRecord = alarmStateTable.NewRecord();
                        alarmStateRecord.State = alarmState.ToString();
                        alarmStateRecord.Color = "white";
                    }

                    m_alarmStates[alarmState] = alarmStateRecord;
                }

                // Load any newly defined devices into the alarm device table
                TableOperations<AlarmDevice> alarmDeviceTable = new TableOperations<AlarmDevice>(connection);
                DataRow[] newDevices = connection.RetrieveData("SELECT ID FROM Device WHERE NOT ID IN (SELECT DeviceID FROM AlarmDevice)").Select();

                foreach (DataRow newDevice in newDevices)
                {
                    AlarmDevice alarmDevice = alarmDeviceTable.NewRecord();

                    alarmDevice.DeviceID = newDevice.Field<int>("ID");
                    alarmDevice.StateID = newDevice.Field<bool>("Enabled") ? m_alarmStates[AlarmState.NotAvailable].ID : m_alarmStates[AlarmState.OutOfService].ID;
                    alarmDevice.DisplayData = GetRootDeviceName(newDevice.Field<string>("Acronym")).Substring(0, 10);

                    alarmDeviceTable.AddNewRecord(alarmDevice);
                }

                List<MeasurementKey> inputMeasurementKeys = new List<MeasurementKey>();

                // Load measurement signal ID to alarm device map
                foreach (AlarmDevice alarmDevice in alarmDeviceTable.QueryRecords())
                {
                    MeasurementKey[] keys = ParseInputMeasurementKeys(DataSource, false, $"FILTER ActiveMeasurements WHERE DeviceID = {alarmDevice.DeviceID} AND SignalType = 'FREQ'");

                    if (keys.Length > 0)
                    {
                        MeasurementKey key = keys[0];
                        inputMeasurementKeys.Add(key);
                        m_deviceMeasurementKeys[alarmDevice.DeviceID] = key;
                        m_lastDeviceDataUpdates[key.SignalID] = DateTime.UtcNow.Ticks;
                    }
                    else
                    {
                        // Mark alarm record as unavailable if no frequency measurement is available for device
                        alarmDevice.StateID = m_alarmStates[AlarmState.NotAvailable].ID;
                        alarmDeviceTable.UpdateRecord(alarmDevice);
                    }
                }

                // Load desired input measurements
                InputMeasurementKeys = inputMeasurementKeys.ToArray();
                TrackLatestMeasurements = true;
            }

            // Define synchronized polling operation
            m_monitoringOperation = new ShortSynchronizedOperation(MonitoringOperation, exception => OnProcessException(MessageLevel.Warning, exception));

            // Define polling timer
            m_monitoringTimer = new Timer(MonitoringRate);
            m_monitoringTimer.AutoReset = true;
            m_monitoringTimer.Elapsed += m_monitoringTimer_Elapsed;
        }

        /// <summary>
        /// monitoring operation to update alarm state for immediate execution.
        /// </summary>
        [AdapterCommand("Queues monitoring operation to update alarm state for immediate execution.", "Administrator", "Editor")]
        public void QueueStateUpdate()
        {
            m_monitoringOperation?.RunOnceAsync();
        }

        /// <summary>
        /// Gets a short one-line status of this adapter.
        /// </summary>
        /// <param name="maxLength">Maximum number of available characters for display.</param>
        /// <returns>A short one-line summary of the current status of this adapter.</returns>
        public override string GetShortStatus(int maxLength)
        {
            if (MonitoringEnabled)
                return $"Monitoring enabled for every {MonitoringRate:N0}ms".CenterText(maxLength);

            return "Monitoring is disabled...".CenterText(maxLength);            
        }

        private void MonitoringOperation()
        {
            ImmediateMeasurements measurements = LatestMeasurements;

            using (AdoDataConnection connection = new AdoDataConnection("systemSettings"))
            {
                TableOperations<AlarmDevice> alarmDeviceTable = new TableOperations<AlarmDevice>(connection);

                foreach (AlarmDevice alarmDevice in alarmDeviceTable.QueryRecords())
                {
                    if (m_deviceMeasurementKeys.TryGetValue(alarmDevice.DeviceID, out MeasurementKey key))
                    {
                        TemporalMeasurement measurement = measurements.Measurement(key);

                        // Determine and update state

                        alarmDeviceTable.UpdateRecord(alarmDevice);
                    }
                }
            }
        }

        private void m_monitoringTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            m_monitoringOperation?.RunOnce();
        }

        private static string GetRootDeviceName(string deviceName)
        {
            if (string.IsNullOrWhiteSpace(deviceName))
                return "UNDEFINED";

            int prefixIndex = deviceName.LastIndexOf('!');

            if (prefixIndex > -1 && prefixIndex + 1 < deviceName.Length)
                deviceName = deviceName.Substring(prefixIndex + 1);

            return deviceName.Trim();
        }

        #endregion
    }
}
