﻿//******************************************************************************************************
//  DataHub.cs - Gbtc
//
//  Copyright © 2016, Grid Protection Alliance.  All Rights Reserved.
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
//  01/14/2016 - Ritchie Carroll
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using GSF;
using GSF.Data.Model;
using GSF.Configuration;
using GSF.Identity;
using GSF.IO;
using GSF.Web.Hubs;
using GSF.Web.Model.HubOperations;
using GSF.Web.Security;
using ModbusAdapters;
using ModbusAdapters.Model;
using openPDC.Model;

namespace openPDC
{
    [AuthorizeHubRole]
    public class DataHub : RecordOperationsHub<DataHub>, IDataSubscriptionOperations, IDirectoryBrowserOperations, IModbusOperations
    {
        #region [ Members ]

        // Fields
        private readonly DataSubscriptionOperations m_dataSubscriptionOperations;
        private readonly ModbusOperations m_modbusOperations;

        #endregion

        #region [ Constructors ]

        public DataHub() : base(Program.Host.LogWebHostStatusMessage, Program.Host.LogException)
        {
            Action<string, UpdateType> logStatusMessage = (message, updateType) => LogStatusMessage(message, updateType);
            Action<Exception> logException = ex => LogException(ex);

            m_dataSubscriptionOperations = new DataSubscriptionOperations(this, logStatusMessage, logException);
            m_modbusOperations = new ModbusOperations(this, logStatusMessage, logException);
        }

        #endregion

        #region [ Methods ]

        public override Task OnConnected()
        {
            LogStatusMessage($"DataHub connect by {Context.User?.Identity?.Name ?? "Undefined User"} [{Context.ConnectionId}] - count = {ConnectionCount}", UpdateType.Information, false);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                // Dispose any associated hub operations associated with current SignalR client
                m_dataSubscriptionOperations?.EndSession();
                m_modbusOperations?.EndSession();

                LogStatusMessage($"DataHub disconnect by {Context.User?.Identity?.Name ?? "Undefined User"} [{Context.ConnectionId}] - count = {ConnectionCount}", UpdateType.Information, false);
            }

            return base.OnDisconnected(stopCalled);
        }

        #endregion

        #region [ Static ]

        // Static Fields
        private static int s_modbusProtocolID;
        private static string s_configurationCachePath;

        // Static Constructor
        static DataHub()
        {
            ModbusPoller.ProgressUpdated += (sender, args) => ProgressUpdated(sender, new EventArgs<string, List<ProgressUpdate>>(null, new List<ProgressUpdate>() { args.Argument }));
        }

        private static void ProgressUpdated(object sender, EventArgs<string, List<ProgressUpdate>> e)
        {
            string deviceName = null;

            ModbusPoller modbusPoller = sender as ModbusPoller;

            if ((object)modbusPoller != null)
                deviceName = modbusPoller.Name;

            if ((object)deviceName == null)
                return;

            string clientID = e.Argument1;

            List<object> updates = e.Argument2
                .Select(update => update.AsExpandoObject())
                .ToList();

            if ((object)clientID != null)
                GlobalHost.ConnectionManager.GetHubContext<DataHub>().Clients.Client(clientID).deviceProgressUpdate(deviceName, updates);
            else
                GlobalHost.ConnectionManager.GetHubContext<DataHub>().Clients.All.deviceProgressUpdate(deviceName, updates);
        }

        #endregion

        // Client-side script functionality

        #region [ ActiveMeasurement View Operations ]

        [RecordOperation(typeof(ActiveMeasurement), RecordOperation.QueryRecordCount)]
        public int QueryActiveMeasurementCount(string filterText)
        {
            TableOperations<ActiveMeasurement> tableOperations = DataContext.Table<ActiveMeasurement>();
            return tableOperations.QueryRecordCount(filterText);
        }

        [RecordOperation(typeof(ActiveMeasurement), RecordOperation.QueryRecords)]
        public IEnumerable<ActiveMeasurement> QueryActiveMeasurements(string sortField, bool ascending, int page, int pageSize, string filterText)
        {
            TableOperations<ActiveMeasurement> tableOperations = DataContext.Table<ActiveMeasurement>();
            return tableOperations.QueryRecords(sortField, ascending, page, pageSize, filterText);
        }

        [RecordOperation(typeof(ActiveMeasurement), RecordOperation.CreateNewRecord)]
        public ActiveMeasurement NewActiveMeasurement()
        {
            return DataContext.Table<ActiveMeasurement>().NewRecord();
        }

        #endregion

        #region [ Device Table Operations ]

        private int ModbusProtocolID => s_modbusProtocolID != 0 ? s_modbusProtocolID : (s_modbusProtocolID = DataContext.Connection.ExecuteScalar<int>("SELECT ID FROM Protocol WHERE Acronym='Modbus'"));

        /// <summary>
        /// Gets protocol ID for "ModbusPoller" protocol.
        /// </summary>
        public int GetModbusProtocolID() => ModbusProtocolID;
        [RecordOperation(typeof(Device), RecordOperation.QueryRecordCount)]

        public int QueryDeviceCount(string filterText)
        {
            return DataContext.Table<Device>().QueryRecordCount(filterText);
        }

        [RecordOperation(typeof(Device), RecordOperation.QueryRecords)]
        public IEnumerable<Device> QueryDevices(string sortField, bool ascending, int page, int pageSize, string filterText)
        {
            return DataContext.Table<Device>().QueryRecords(sortField, ascending, page, pageSize, filterText);
        }

        public IEnumerable<Device> QueryEnabledDevices(int limit, string filterText)
        {
            TableOperations<Device> deviceTable = DataContext.Table<Device>();
            return deviceTable.QueryRecords("Acronym", "Enabled <> 0" + deviceTable.GetSearchRestriction(filterText), limit);
        }

        public Device QueryDevice(string acronym)
        {
            return DataContext.Table<Device>().QueryRecordWhere("Acronym = {0}", acronym) ?? NewDevice();
        }

        public Device QueryDeviceByID(int deviceID)
        {
            return DataContext.Table<Device>().QueryRecordWhere("ID = {0}", deviceID) ?? NewDevice();
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Device), RecordOperation.DeleteRecord)]
        public void DeleteDevice(int id)
        {
            DataContext.Table<Device>().DeleteRecord(id);
        }

        [RecordOperation(typeof(Device), RecordOperation.CreateNewRecord)]
        public Device NewDevice()
        {
            return DataContext.Table<Device>().NewRecord();
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Device), RecordOperation.AddNewRecord)]
        public void AddNewDevice(Device device)
        {
            if ((device.ProtocolID ?? 0) == 0)
                device.ProtocolID = ModbusProtocolID;

            DataContext.Table<Device>().AddNewRecord(device);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Device), RecordOperation.UpdateRecord)]
        public void UpdateDevice(Device device)
        {
            if ((device.ProtocolID ?? 0) == 0)
                device.ProtocolID = ModbusProtocolID;

            DataContext.Table<Device>().UpdateRecord(device);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public void AddNewOrUpdateDevice(Device device)
        {
            DataContext.Table<Device>().AddNewOrUpdateRecord(device);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public void SaveDeviceConfiguration(string acronym, string configuration)
        {
            File.WriteAllText(GetConfigurationCacheFileName(acronym), configuration);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public string LoadDeviceConfiguration(string acronym)
        {
            string fileName = GetConfigurationCacheFileName(acronym);
            return File.Exists(fileName) ? File.ReadAllText(fileName) : "";
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public string GetConfigurationCacheFileName(string acronym)
        {
            return Path.Combine(ConfigurationCachePath, $"{acronym}.configuration.json");
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public string GetConfigurationCachePath()
        {
            return ConfigurationCachePath;
        }

        private static string ConfigurationCachePath
        {
            get
            {
                // This property will not change during system life-cycle so we cache if for future use
                if (string.IsNullOrEmpty(s_configurationCachePath))
                {
                    // Define default configuration cache directory relative to path of host application
                    s_configurationCachePath = string.Format("{0}{1}ConfigurationCache{1}", FilePath.GetAbsolutePath(""), Path.DirectorySeparatorChar);

                    // Make sure configuration cache path setting exists within system settings section of config file
                    ConfigurationFile configFile = ConfigurationFile.Current;
                    CategorizedSettingsElementCollection systemSettings = configFile.Settings["systemSettings"];
                    systemSettings.Add("ConfigurationCachePath", s_configurationCachePath, "Defines the path used to cache serialized phasor protocol configurations");

                    // Retrieve configuration cache directory as defined in the config file
                    s_configurationCachePath = FilePath.AddPathSuffix(systemSettings["ConfigurationCachePath"].Value);

                    // Make sure configuration cache directory exists
                    if (!Directory.Exists(s_configurationCachePath))
                        Directory.CreateDirectory(s_configurationCachePath);
                }

                return s_configurationCachePath;
            }
        }

        #endregion

        #region [ Measurement Table Operations ]

        [RecordOperation(typeof(Measurement), RecordOperation.QueryRecordCount)]
        public int QueryMeasurementCount(string filterText)
        {
            return DataContext.Table<Measurement>().QueryRecordCount(filterText);
        }

        [RecordOperation(typeof(Measurement), RecordOperation.QueryRecords)]
        public IEnumerable<Measurement> QueryMeasurements(string sortField, bool ascending, int page, int pageSize, string filterText)
        {
            return DataContext.Table<Measurement>().QueryRecords(sortField, ascending, page, pageSize, filterText);
        }

        public Measurement QueryMeasurement(string signalReference)
        {
            return DataContext.Table<Measurement>().QueryRecordWhere("SignalReference = {0}", signalReference) ?? NewMeasurement();
        }

        public Measurement QueryMeasurementByPointTag(string pointTag)
        {
            return DataContext.Table<Measurement>().QueryRecordWhere("PointTag = {0}", pointTag) ?? NewMeasurement();
        }

        public Measurement QueryMeasurementBySignalID(Guid signalID)
        {
            return DataContext.Table<Measurement>().QueryRecordWhere("SignalID = {0}", signalID) ?? NewMeasurement();
        }

        public IEnumerable<Measurement> QueryDeviceMeasurements(int deviceID)
        {
            return DataContext.Table<Measurement>().QueryRecordsWhere("DeviceID = {0}", deviceID);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Measurement), RecordOperation.DeleteRecord)]
        public void DeleteMeasurement(int id)
        {
            DataContext.Table<Measurement>().DeleteRecord(id);
        }

        [RecordOperation(typeof(Measurement), RecordOperation.CreateNewRecord)]
        public Measurement NewMeasurement()
        {
            return DataContext.Table<Measurement>().NewRecord();
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Measurement), RecordOperation.AddNewRecord)]
        public void AddNewMeasurement(Measurement measurement)
        {
            DataContext.Table<Measurement>().AddNewRecord(measurement);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Measurement), RecordOperation.UpdateRecord)]
        public void UpdateMeasurement(Measurement measurement)
        {
            DataContext.Table<Measurement>().UpdateRecord(measurement);
        }

        public void AddNewOrUpdateMeasurement(Measurement measurement)
        {
            DataContext.Table<Measurement>().AddNewOrUpdateRecord(measurement);
        }

        #endregion

        #region [ Historian Table Operations ]

        [RecordOperation(typeof(Historian), RecordOperation.QueryRecordCount)]
        public int QueryHistorianCount(string filterText)
        {
            return DataContext.Table<Historian>().QueryRecordCount(filterText);
        }

        [RecordOperation(typeof(Historian), RecordOperation.QueryRecords)]
        public IEnumerable<Historian> QueryHistorians(string sortField, bool ascending, int page, int pageSize, string filterText)
        {
            return DataContext.Table<Historian>().QueryRecords(sortField, ascending, page, pageSize, filterText);
        }

        public Historian QueryHistorian(string acronym)
        {
            return DataContext.Table<Historian>().QueryRecordWhere("Acronym = {0}", acronym);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Historian), RecordOperation.DeleteRecord)]
        public void DeleteHistorian(int id)
        {
            DataContext.Table<Historian>().DeleteRecord(id);
        }

        [RecordOperation(typeof(Historian), RecordOperation.CreateNewRecord)]
        public Historian NewHistorian()
        {
            return DataContext.Table<Historian>().NewRecord();
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Historian), RecordOperation.AddNewRecord)]
        public void AddNewHistorian(Historian historian)
        {
            DataContext.Table<Historian>().AddNewRecord(historian);
        }

        [AuthorizeHubRole("Administrator, Editor")]
        [RecordOperation(typeof(Historian), RecordOperation.UpdateRecord)]
        public void UpdateHistorian(Historian historian)
        {
            DataContext.Table<Historian>().UpdateRecord(historian);
        }

        #endregion

        #region [ Data Subscription Operations ]

        // These functions are dependent on subscriptions to data where each client connection can customize the subscriptions, so an instance
        // of the DataHubSubscriptionClient is created per SignalR DataHub client connection to manage the subscription life-cycles.

        public IEnumerable<MeasurementValue> GetMeasurements()
        {
            return m_dataSubscriptionOperations.GetMeasurements();
        }

        public IEnumerable<DeviceDetail> GetDeviceDetails()
        {
            return m_dataSubscriptionOperations.GetDeviceDetails();
        }

        public IEnumerable<MeasurementDetail> GetMeasurementDetails()
        {
            return m_dataSubscriptionOperations.GetMeasurementDetails();
        }

        public IEnumerable<PhasorDetail> GetPhasorDetails()
        {
            return m_dataSubscriptionOperations.GetPhasorDetails();
        }

        public IEnumerable<SchemaVersion> GetSchemaVersion()
        {
            return m_dataSubscriptionOperations.GetSchemaVersion();
        }

        public IEnumerable<MeasurementValue> GetStats()
        {
            return m_dataSubscriptionOperations.GetStats();
        }

        public IEnumerable<StatusLight> GetLights()
        {
            return m_dataSubscriptionOperations.GetLights();
        }

        public void InitializeSubscriptions()
        {
            m_dataSubscriptionOperations.InitializeSubscriptions();
        }

        public void TerminateSubscriptions()
        {
            m_dataSubscriptionOperations.TerminateSubscriptions();
        }

        public void UpdateFilters(string filterExpression)
        {
            m_dataSubscriptionOperations.UpdateFilters(filterExpression);
        }

        public void StatSubscribe(string filterExpression)
        {
            m_dataSubscriptionOperations.StatSubscribe(filterExpression);
        }

        #endregion

        #region [ DirectoryBrowser Operations ]

        public IEnumerable<string> LoadDirectories(string rootFolder, bool showHidden)
        {
            return DirectoryBrowserOperations.LoadDirectories(rootFolder, showHidden);
        }

        public bool IsLogicalDrive(string path)
        {
            return DirectoryBrowserOperations.IsLogicalDrive(path);
        }

        public string ResolvePath(string path)
        {
            return DirectoryBrowserOperations.ResolvePath(path);
        }

        public string CombinePath(string path1, string path2)
        {
            return DirectoryBrowserOperations.CombinePath(path1, path2);
        }

        public void CreatePath(string path)
        {
            DirectoryBrowserOperations.CreatePath(path);
        }

        #endregion

        #region [ DeviceStatus Operations ]
		
        public void SetOutOfService(int id)
        {
            DataContext.Connection.ExecuteNonQuery("UPDATE AlarmDevice SET StateID = (SELECT ID FROM AlarmState WHERE State = 'Out of Service'), TimeStamp = {0}, DisplayData = 'OoS' WHERE ID = {1}", DateTime.UtcNow, id);
        }

        public void SetInService(int id)
        {
            DataContext.Connection.ExecuteNonQuery("UPDATE AlarmDevice SET StateID = (SELECT ID FROM AlarmState WHERE State = 'Good'), TimeStamp = {0}, DisplayData = 'Good' WHERE ID = {1}", DateTime.UtcNow, id);
        }

        #endregion
		
        #region [ Modbus Operations ]

        public Task<bool> ModbusConnect(string connectionString)
        {
            return m_modbusOperations.ModbusConnect(connectionString);
        }

        public void ModbusDisconnect()
        {
            m_modbusOperations.ModbusDisconnect();
        }

        public async Task<bool[]> ReadDiscreteInputs(ushort startAddress, ushort pointCount)
        {
            try
            {
                return await m_modbusOperations.ReadDiscreteInputs(startAddress, pointCount);
            }
            catch (Exception ex)
            {
                LogException(new InvalidOperationException($"Exception while reading discrete inputs starting @ {startAddress}: {ex.Message}", ex));
                return new bool[0];
            }
        }

        public async Task<bool[]> ReadCoils(ushort startAddress, ushort pointCount)
        {
            try
            {
                return await m_modbusOperations.ReadCoils(startAddress, pointCount);
            }
            catch (Exception ex)
            {
                LogException(new InvalidOperationException($"Exception while reading coil values starting @ {startAddress}: {ex.Message}", ex));
                return new bool[0];
            }
        }

        public async Task<ushort[]> ReadInputRegisters(ushort startAddress, ushort pointCount)
        {
            try
            {
                return await m_modbusOperations.ReadInputRegisters(startAddress, pointCount);
            }
            catch (Exception ex)
            {
                LogException(new InvalidOperationException($"Exception while reading input registers starting @ {startAddress}: {ex.Message}", ex));
                return new ushort[0];
            }
        }

        public async Task<ushort[]> ReadHoldingRegisters(ushort startAddress, ushort pointCount)
        {
            try
            {
                return await m_modbusOperations.ReadHoldingRegisters(startAddress, pointCount);
            }
            catch (Exception ex)
            {
                LogException(new InvalidOperationException($"Exception while reading holding registers starting @ {startAddress}: {ex.Message}", ex));
                return new ushort[0];
            }
        }

        public async Task WriteCoils(ushort startAddress, bool[] data)
        {
            try
            {
                await m_modbusOperations.WriteCoils(startAddress, data);
            }
            catch (Exception ex)
            {
                LogException(new InvalidOperationException($"Exception while writing coil values starting @ {startAddress}: {ex.Message}", ex));
            }
        }

        public async Task WriteHoldingRegisters(ushort startAddress, ushort[] data)
        {
            try
            {
                await m_modbusOperations.WriteHoldingRegisters(startAddress, data);
            }
            catch (Exception ex)
            {
                LogException(new InvalidOperationException($"Exception while writing holding registers starting @ {startAddress}: {ex.Message}", ex));
            }
        }

        public string DeriveString(ushort[] values)
        {
            return m_modbusOperations.DeriveString(values);
        }

        public float DeriveSingle(ushort highValue, ushort lowValue)
        {
            return m_modbusOperations.DeriveSingle(highValue, lowValue);
        }

        public double DeriveDouble(ushort b3, ushort b2, ushort b1, ushort b0)
        {
            return m_modbusOperations.DeriveDouble(b3, b2, b1, b0);
        }

        public int DeriveInt32(ushort highValue, ushort lowValue)
        {
            return m_modbusOperations.DeriveInt32(highValue, lowValue);
        }

        public uint DeriveUInt32(ushort highValue, ushort lowValue)
        {
            return m_modbusOperations.DeriveUInt32(highValue, lowValue);
        }

        public long DeriveInt64(ushort b3, ushort b2, ushort b1, ushort b0)
        {
            return m_modbusOperations.DeriveInt64(b3, b2, b1, b0);
        }

        public ulong DeriveUInt64(ushort b3, ushort b2, ushort b1, ushort b0)
        {
            return m_modbusOperations.DeriveUInt64(b3, b2, b1, b0);
        }

        #endregion

        #region [ Miscellaneous Functions ]

        /// <summary>
        /// Determines if directory exists from server's perspective.
        /// </summary>
        /// <param name="path">Directory path to test for existence.</param>
        /// <returns><c>true</c> if directory exists; otherwise, <c>false</c>.</returns>
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Determines if file exists from server's perspective.
        /// </summary>
        /// <param name="path">Path and file name to test for existence.</param>
        /// <returns><c>true</c> if file exists; otherwise, <c>false</c>.</returns>
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Requests that the device send the current list of progress updates.
        /// </summary>
        public void QueryDeviceStatus()
        {
            // Typically used with FTP down-loaders...
        }

        /// <summary>
        /// Gets current user ID.
        /// </summary>
        /// <returns>Current user ID.</returns>
        public string GetCurrentUserID()
        {
            return Thread.CurrentPrincipal.Identity?.Name ?? UserInfo.CurrentUserID;
        }

        /// <summary>
        /// Gets elapsed time between two dates as a range.
        /// </summary>
        /// <param name="startTime">Start time of query.</param>
        /// <param name="stopTime">Stop time of query.</param>
        /// <returns>Elapsed time between two dates as a range.</returns>
        public Task<string> GetElapsedTimeString(DateTime startTime, DateTime stopTime)
        {
            return Task.Factory.StartNew(() => new Ticks(stopTime - startTime).ToElapsedTimeString(2));
        }

        #endregion
    }
}
