//******************************************************************************************************
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

using GSF;
using GSF.Data.Model;
using GSF.Identity;
using GSF.Web.Hubs;
using GSF.Web.Model.HubOperations;
using GSF.Web.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using GrafanaAdapters;
using ModbusAdapters;
using ModbusAdapters.Model;
using openPDC.Model;
using Newtonsoft.Json.Linq;
using GSF.Configuration;
using GSF.Net.Smtp;
using GSF.Web.Shared.Model;
using GSF.Historian.Files;
using GSF.Historian;
using GSF.TimeSeries.Statistics;

namespace openPDC
{
    [AuthorizeHubRole]
    public class DataHub : RecordOperationsHub<DataHub>, IDirectoryBrowserOperations, IModbusOperations
    {
        #region [ Members ]

        // Fields
        private readonly ModbusOperations m_modbusOperations;

        #endregion

        #region [ Constructors ]

        public DataHub() : base(Program.Host.LogWebHostStatusMessage, Program.Host.LogException)
        {
            void logStatusMessage(string message, UpdateType updateType) => LogStatusMessage(message, updateType);
            void logException(Exception ex) => LogException(ex);

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
                m_modbusOperations?.EndSession();

                LogStatusMessage($"DataHub disconnect by {Context.User?.Identity?.Name ?? "Undefined User"} [{Context.ConnectionId}] - count = {ConnectionCount}", UpdateType.Information, false);
            }

            return base.OnDisconnected(stopCalled);
        }

        #endregion

        #region [ Static ]

        // Static Fields
        private static int s_modbusProtocolID;

        // Static Constructor
        static DataHub()
        {
            ModbusPoller.ProgressUpdated += (sender, args) => ProgressUpdated(sender, new EventArgs<string, List<ProgressUpdate>>(null, new List<ProgressUpdate>() { args.Argument }));
        }

        private static void ProgressUpdated(object sender, EventArgs<string, List<ProgressUpdate>> e)
        {
            string deviceName = null;

            if (sender is ModbusPoller modbusPoller)
                deviceName = modbusPoller.Name;

            if (deviceName is null)
                return;

            string clientID = e.Argument1;

            List<object> updates = e.Argument2
                .Select(update => update.AsExpandoObject())
                .ToList();

            if (clientID is null)
                GlobalHost.ConnectionManager.GetHubContext<DataHub>().Clients.All.deviceProgressUpdate(deviceName, updates);
            else
                GlobalHost.ConnectionManager.GetHubContext<DataHub>().Clients.Client(clientID).deviceProgressUpdate(deviceName, updates);
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

        public string GetProtocolCategory(int protocolID) =>
            DataContext.Table<Protocol>().QueryRecordWhere("ID = {0}", protocolID)?.Category ?? "Undefined";

        [RecordOperation(typeof(Device), RecordOperation.QueryRecordCount)]
        public int QueryDeviceCount(Guid nodeID, string filterText)
        {
            TableOperations<Device> deviceTable = DataContext.Table<Device>();

            RecordRestriction restriction =
                new RecordRestriction("NodeID = {0}", nodeID) +
                deviceTable.GetSearchRestriction(filterText);

            return deviceTable.QueryRecordCount(restriction);
        }

        [RecordOperation(typeof(Device), RecordOperation.QueryRecords)]
        public IEnumerable<Device> QueryDevices(Guid nodeID, string sortField, bool ascending, int page, int pageSize, string filterText)
        {
            TableOperations<Device> deviceTable = DataContext.Table<Device>();

            RecordRestriction restriction =
                new RecordRestriction("NodeID = {0}", nodeID) +
                deviceTable.GetSearchRestriction(filterText);

            return deviceTable.QueryRecords(sortField, ascending, page, pageSize, restriction);
        }

        public IEnumerable<Device> QueryEnabledDevices(Guid nodeID, int limit, string filterText)
        {
            TableOperations<Device> deviceTable = DataContext.Table<Device>();

            RecordRestriction restriction =
                new RecordRestriction("NodeID = {0}", nodeID) +
                new RecordRestriction("Enabled <> 0") +
                deviceTable.GetSearchRestriction(filterText);

            return deviceTable.QueryRecords("Acronym", restriction, limit);
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
            TableOperations<Device> deviceTable = DataContext.Table<Device>();            
            deviceTable.DeleteRecordWhere("ParentID = {0}", id);
            deviceTable.DeleteRecord(id);
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

        #region [ PhasorDetail Table Operations ]

        [RecordOperation(typeof(PhasorDetail), RecordOperation.QueryRecordCount)]
        public int QueryPhasorCount(int deviceID, string filterText)
        {
            TableOperations<PhasorDetail> phasorDetailTable = DataContext.Table<PhasorDetail>();

            RecordRestriction restriction = (deviceID > 0 ?
                new RecordRestriction("DeviceID = {0}", deviceID) : null) +
                phasorDetailTable.GetSearchRestriction(filterText);

            return phasorDetailTable.QueryRecordCount(restriction);
        }

        [RecordOperation(typeof(PhasorDetail), RecordOperation.QueryRecords)]
        public IEnumerable<PhasorDetail> QueryPhasors(int deviceID, string sortField, bool ascending, int page, int pageSize, string filterText)
        {
            TableOperations<PhasorDetail> phasorDetailTable = DataContext.Table<PhasorDetail>();

            RecordRestriction restriction = (deviceID > 0 ?
                new RecordRestriction("DeviceID = {0}", deviceID) : null) +
                phasorDetailTable.GetSearchRestriction(filterText);

            return DataContext.Table<PhasorDetail>().QueryRecords(sortField, ascending, page, pageSize, restriction);
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
        
        /// <summary>
        /// Gets loaded historian adapter instance names.
        /// </summary>
        /// <returns>Historian adapter instance names.</returns>
        public IEnumerable<string> GetInstanceNames()
        {
            return DataContext.Table<Historian>().QueryRecordsWhere("Enabled != 0").Select(historian => historian.Acronym);
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

        public object GetAlarmState(int id)
        {
            dynamic state = new JObject();
            AlarmDevice alarmDevice = DataContext.Table<AlarmDevice>().QueryRecordWhere("DeviceID = {0}", id);

            if (alarmDevice is null)
                return state;

            AlarmState alarmState = DataContext.Table<AlarmState>().QueryRecordWhere("ID = {0}", alarmDevice.StateID);

            if (!(alarmState is null))
            {
                state.displayData = alarmDevice.DisplayData;
                state.stateName = alarmState.State;
                state.stateColor = alarmState.Color;
            }

            return state;
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public void SetAcknowledge(string acronym)
        {
            Device device = QueryDevice(acronym);
            AlarmState alarmState = DataContext.Table<AlarmState>().QueryRecordWhere("State = {0}", "Acknowledged");

            if (device.ID > 0 && alarmState.ID > 0)
            {
                TableOperations<AlarmDevice> alarmDeviceTable = DataContext.Table<AlarmDevice>();
                AlarmDevice alarmDevice = alarmDeviceTable.QueryRecordWhere("DeviceID = {0}", device.ID);

                if (alarmDevice.ID > 0)
                {
                    alarmDevice.StateID = alarmState.ID;
                    //                         1234567890
                    alarmDevice.DisplayData = "Alarm ACK";
                    alarmDeviceTable.UpdateRecord(alarmDevice);
                }
            }
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public void ResetAcknowledge(string acronym)
        {
            Device device = QueryDevice(acronym);
            AlarmState alarmState = DataContext.Table<AlarmState>().QueryRecordWhere("State = {0}", "Not Available");

            if (device.ID > 0 && alarmState.ID > 0)
            {
                TableOperations<AlarmDevice> alarmDeviceTable = DataContext.Table<AlarmDevice>();
                AlarmDevice alarmDevice = alarmDeviceTable.QueryRecordWhere("DeviceID = {0}", device.ID);

                if (alarmDevice.ID > 0)
                {
                    alarmDevice.StateID = alarmState.ID;
                    //                         1234567890
                    alarmDevice.DisplayData = "ACK Reset";
                    alarmDeviceTable.UpdateRecord(alarmDevice);
                }
            }
        }

        [AuthorizeHubRole("Administrator, Editor")]
        public void SendEmail(string acronym)
        {
            Device device = QueryDevice(acronym);

            // Get Device State and other Information
            AlarmDevice alarmDevice = DataContext.Table<AlarmDevice>().QueryRecordWhere("DeviceID = {0}", device.ID);

            string stateName = "Unknown State";
            string vendorName = "Unspecified";
            string deviceType = "Unspecified";
            string contactList = "None Defined";
            string connectionString = "settings=none";
            string parentAcronym = "";
            decimal longitude = 0.0M, latitude = 0.0M;
            int framesPerSecond = 30;
            int? vendorDeviceID = device.VendorDeviceID;

            if (device.ParentID.HasValue)
            {
                int parentID = device.ParentID.Value;

                // If this is a concentrator child, get connection string of parent
                Device parentDevice = DataContext.Table<Device>().QueryRecordWhere("ID = {0}", parentID);

                if ((object)parentDevice != null)
                {
                    parentAcronym = parentDevice.Acronym;

                    string childConnectionString = connectionString;

                    // Settings in child connection string are not common
                    if (string.IsNullOrWhiteSpace(childConnectionString))
                    {
                        childConnectionString = "";
                    }
                    else
                    {
                        childConnectionString = string.Format("; childDevice={0}; {1}", acronym, childConnectionString);
                    }

                    connectionString = string.Format("parentDevice={0}; {1}{2}", parentDevice.Acronym, parentDevice.ConnectionString, childConnectionString);
                    vendorDeviceID = vendorDeviceID ?? parentDevice.VendorDeviceID;
                }
            }

            if ((object)alarmDevice != null)
            {
                AlarmState alarmState = DataContext.Table<AlarmState>().QueryRecordWhere("ID = {0}", alarmDevice.StateID);
                if (!string.IsNullOrEmpty(alarmState?.State))
                    stateName = alarmState.State;
            }

            if (device.Longitude.HasValue)
                longitude = device.Longitude.Value;

            if (device.Latitude.HasValue)
                latitude = device.Latitude.Value;
         
            if (device.FramesPerSecond.HasValue)
               framesPerSecond = device.FramesPerSecond.Value;

           

            VendorDevice vendorDevice = DataContext.Table<VendorDevice>().QueryRecordWhere("ID = {0}", vendorDeviceID);

            if ((object)vendorDevice != null)
            {
                if (!string.IsNullOrEmpty(vendorDevice?.Name))
                    deviceType = vendorDevice.Name;

                Vendor vendor = DataContext.Table<Vendor>().QueryRecordWhere("ID = {0}", vendorDevice.VendorID);

                if (!string.IsNullOrEmpty(vendor?.Name))
                    vendorName = vendor.Name;
            }

            if (!String.IsNullOrEmpty(device.ContactList))
                contactList = device.ContactList;

            if (!String.IsNullOrEmpty(device.ConnectionString))
                connectionString = device.ConnectionString;

            // ready Email to be send. Load settings from ConfigFile Only
            string emailServer = Mail.DefaultSmtpServer;
            string emailSender = string.Format("{0}@{1}.local", Environment.UserName, Environment.UserDomainName);
            string emailRecipients = "";
            ConfigurationFile config = ConfigurationFile.Current;
            CategorizedSettingsElementCollection settings = config.Settings["deviceStatusNotification"];
            settings.Add("EmailServer", emailServer, "SMTP server to use for sending the email notifications.");
            settings.Add("EmailSender", emailSender, "Email address to be used for sending the email notifications.");
            settings.Add("EmailRecipients", emailRecipients, "Email addresses (comma or semicolon delimited) where the email notifications are to be sent.");
            emailServer = settings["EmailServer"].ValueAs(emailServer);
            emailSender = settings["EmailSender"].ValueAs(emailSender);
            emailRecipients = settings["EmailRecipients"].ValueAs(emailRecipients);

            if (string.IsNullOrEmpty(emailRecipients))
                throw new ArgumentNullException("EmailRecipients");

            Mail briefMessage = new Mail(emailRecipients, emailSender, emailServer);
            Mail detailedMessage = new Mail(emailSender, emailSender, emailServer);

            briefMessage.Subject = $"{acronym} {stateName}";
            detailedMessage.Subject = $"{acronym} {stateName}";
            detailedMessage.Body = $"{acronym} is in {stateName} state. Please issue a field ticket to investigate\r\n\r\n";
            detailedMessage.Body += $"Device Acronym: {acronym}\r\n";
            detailedMessage.Body += $"Device Name: {device?.Name}\r\n";
            detailedMessage.Body += $"Make: {vendorName}\r\n";
            detailedMessage.Body += $"Model: {deviceType}\r\n";
            detailedMessage.Body += $"Latitude: {latitude}\r\n";
            detailedMessage.Body += $"Longitude: {longitude}\r\n";
            detailedMessage.Body += $"Frames per Second: {framesPerSecond}\r\n";
            detailedMessage.Body += $"Contacts: {contactList}\r\n";
            detailedMessage.Body += $"Connection String:\r\n";
            detailedMessage.Body += $"\t{String.Join("\r\n\t", connectionString.Split(';').Select(s => s.Trim()))}\r\n\r\n";
            detailedMessage.Body += $"Last collected Statistics:\r\n";

            detailedMessage.Body += GenerateStatsTable(acronym, parentAcronym);
            foreach (string recipient in emailRecipients.Replace(" ", "").Split(';', ','))
            {
                string[] addressParts = recipient.Split(':');
                if (addressParts.Length > 1)
                {
                    if (string.Compare(addressParts[1], "sms", true) == 0)
                    {
                        // A brief message is to be sent.
                        briefMessage.ToRecipients = addressParts[0];
                        briefMessage.Send();
                    }
                }
                else
                {
                    // A detailed message is to be sent.
                    detailedMessage.ToRecipients = recipient;
                    detailedMessage.Send();
                }
            }

        }

        private string GenerateStatsTable(string deviceAcronym, string parentAcronym)
        {
            string tbl = "ID".PadRight(11) + "Description".PadRight(201) + "Value".PadRight(21) + "Time (UTC)".PadRight(20) + "\r\n";
            tbl += string.Concat(Enumerable.Repeat("-", 253)) + "\r\n";

            // Grab Stat Measurements
            IEnumerable<MeasurementDetail> statmeasurements = DataContext.Table<MeasurementDetail>().QueryRecordsWhere("DeviceAcronym IN ({0},{1}) AND SignalAcronym = 'STAT'", deviceAcronym, parentAcronym);

            // Read Current Values (+ 30 seconds back)
            ConfigurationFile config = ConfigurationFile.Current;
            CategorizedSettingsElementCollection settings = config.Settings["statArchiveFile"];

            ArchiveReader archiveReader = new ArchiveReader();
            archiveReader.Open(settings["FileName"].ValueAsString());

            List<MetadataRecord> metadataRecords = archiveReader.MetadataFile.Read()
                .Where(record => !string.IsNullOrEmpty(record.Name))
                .ToList();

            Dictionary<long,IEnumerable<IDataPoint>> data = statmeasurements.Select(item => item.PointID).ToDictionary(record => record, record => archiveReader.ReadData((int)record, DateTime.UtcNow.Subtract(new TimeSpan(0, 1, 0)), DateTime.UtcNow, false));

            foreach (MeasurementDetail meas in statmeasurements)
            {
                tbl += meas.PointTag.Substring(meas.PointTag.LastIndexOf("!") + 1).Trim().PadRight(10) + " " + meas.Description.Trim().PadRight(200) + " ";
                if (data.ContainsKey(meas.PointID) && data[meas.PointID].Count() > 0)
                { 
                    if (!StatisticsEngine.TryLookupStatisticSource(meas.SignalReference, out string source, out int signalIndex))
                        tbl += "N/A".PadRight(20) + " " + "N/A".PadRight(20) + "\r\n";
                    else
                    {
                        Statistic stat = DataContext.Table<Statistic>().QueryRecordWhere("Source = {0} AND SignalIndex = {1}", source, signalIndex);
                        Type statType = Type.GetType(stat.DataType);
                        if (statType == typeof(DateTime))
                            tbl += String.Format(stat.DisplayFormat, new GSF.UnixTimeTag((decimal)data[meas.PointID].First().Value)).PadRight(20) + " " + data[meas.PointID].First().Time.ToString("HH:mm:ss.fff").PadRight(20) + "\r\n";
                        else
                            tbl += String.Format(stat.DisplayFormat, Convert.ChangeType(data[meas.PointID].First().Value, statType)).PadRight(20) + " " + data[meas.PointID].First().Time.ToString("HH:mm:ss.fff").PadRight(20) + "\r\n";
                    }
                    
                }
                else
                    tbl += "N/A".PadRight(20) + " " + "N/A".PadRight(20) + "\r\n";
            }

            return tbl;
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
