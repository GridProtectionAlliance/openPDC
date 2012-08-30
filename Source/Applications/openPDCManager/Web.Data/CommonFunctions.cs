//******************************************************************************************************
//  CommonFunctions.cs - Gbtc
//
//  Copyright © 2010, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using openPDCManager.Data.BusinessObjects;
using openPDCManager.Data.Entities;
using openPDCManager.Data.ServiceCommunication;
using TVA;
using TVA.Data;
using TVA.PhasorProtocols;
using TVA.ServiceProcess;

namespace openPDCManager.Data
{
    /// <summary>
    /// Class that defines common operations on data (retrieval and update)
    /// </summary>
    public static class CommonFunctions
    {
        public static string s_currentUser;

        /// <summary>
        /// Purpose of this method is to supply current user information from the UI to DELETE trigger for change logging.
        /// This method must be called before any delete operation on the database in order to log who deleted this record.
        /// For SQL server it sets user name into CONTEXT_INFO().
        /// For MySQL server it sets user name into session variable @context.
        /// MS Access is not supported for change logging.
        /// For any other database in the future, such as Oracle, this logic must be extended to support change log in the database.
        /// </summary>
        /// <param name="connection">Connection used to set user context before any delete operation.</param>
        public static void SetCurrentUserContext(DataConnection connection)
        {
            bool createdConnection = false;
            try
            {
                if (string.IsNullOrEmpty(s_currentUser))
                    s_currentUser = Thread.CurrentPrincipal.Identity.Name;

                if (!string.IsNullOrEmpty(s_currentUser))
                {
                    if (connection == null)
                    {
                        connection = new DataConnection();
                        createdConnection = true;
                    }
                    IDbCommand command;
                    //First of all set Current User for the database session for this connection.
                    if (connection.Connection.GetType().Name.ToLower() == "sqlconnection")
                    {
                        string contextSql = "DECLARE @context VARBINARY(128)\n SELECT @context = CONVERT(VARBINARY(128), CONVERT(VARCHAR(128), @userName))\n SET CONTEXT_INFO @context";
                        command = connection.Connection.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = contextSql;
                        command.Parameters.Add(AddWithValue(command, "@userName", s_currentUser));
                        command.ExecuteNonQuery();
                    }
                    else if (connection.Connection.GetType().Name.ToLower() == "mysqlconnection")
                    {
                        try
                        {
                            command = connection.Connection.CreateCommand();
                            command.CommandType = CommandType.Text;
                            command.CommandText = "SET @context = '" + s_currentUser + "';";
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        static DataSet GetResultSet(IDbCommand command)		//This function was added because at few places mySQL complained about foreign key constraints which I was not able to figure out.
        {
            //TODO: Find a way to get rid of this function for mySQL.
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            dataSet.EnforceConstraints = false;
            dataSet.Tables.Add(dataTable);
            dataTable.Load(command.ExecuteReader());
            return dataSet;
        }

        public static string GetReturnMessage(string source, string userMessage, string systemMessage, string detail, MessageType userMessageType)
        {
            Message message = new Message();
            message.Source = source;
            message.UserMessage = userMessage;
            message.SystemMessage = systemMessage;
            message.Detail = detail;
            message.UserMessageType = userMessageType;

            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(typeof(Message));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            xs.Serialize(xmlTextWriter, message);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            return (new UTF8Encoding()).GetString(memoryStream.ToArray());
        }

        public static List<ErrorLog> ReadExceptionLog(int numberOfLogs)
        {
            DataConnection connection = new DataConnection();
            try
            {
                List<ErrorLog> errorLogList = new List<ErrorLog>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select Top " + numberOfLogs.ToString() + " * From ErrorLog Order By CreatedOn DESC";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                errorLogList = (from item in resultTable.AsEnumerable()
                                select new ErrorLog()
                                {
                                    ID = Convert.ToInt32(item.Field<object>("ID")),
                                    Source = item.Field<string>("Source"),
                                    Message = item.Field<string>("Message"),
                                    CreatedOn = Convert.ToDateTime(item.Field<object>("CreatedOn")),
                                    Detail = item.Field<string>("Detail")
                                }).ToList();
                return errorLogList;
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }
        }

        public static void LogException(DataConnection connection, string source, Exception ex)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Insert Into ErrorLog (Source, Message, Detail) Values (@source, @message, @detail)";
                command.Parameters.Add(AddWithValue(command, "@source", source));
                command.Parameters.Add(AddWithValue(command, "@message", ex.Message));
                command.Parameters.Add(AddWithValue(command, "@detail", ex.ToString()));
                command.ExecuteNonQuery();
            }
            catch
            {
                //Do nothing. Dont worry about it.
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string GetExecutingAssemblyPath()
        {
            return TVA.IO.FilePath.GetAbsolutePath("Temp");
        }

        public static string SaveIniFile(Stream input)
        {
            string fileName = Guid.NewGuid().ToString() + ".ini";
            using (FileStream fs = File.Create(GetExecutingAssemblyPath() + "\\" + fileName))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                }
            }
            return fileName;
        }

        public static ConnectionSettings GetConnectionSettings(Stream inputStream)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();

            SoapFormatter sf = new SoapFormatter();
            sf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            sf.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
            sf.Binder = new VersionConfigToNamespaceAssemblyObjectBinder();
            connectionSettings = sf.Deserialize(inputStream) as ConnectionSettings;

            if (connectionSettings.ConnectionParameters != null)
            {
                ConnectionSettings cs = new ConnectionSettings();
                cs = (ConnectionSettings)connectionSettings.ConnectionParameters;
                connectionSettings.configurationFileName = cs.configurationFileName;
                connectionSettings.refreshConfigurationFileOnChange = cs.refreshConfigurationFileOnChange;
                connectionSettings.parseWordCountFromByte = cs.parseWordCountFromByte;
            }

            return connectionSettings;
        }

        public static IConfigurationFrame s_configurationFrame;
        public static List<WizardDeviceInfo> GetWizardConfigurationInfo(Stream inputStream)
        {
            SoapFormatter sf = new SoapFormatter();
            sf.AssemblyFormat = FormatterAssemblyStyle.Simple;
            sf.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
            IConfigurationFrame configurationFrame = sf.Deserialize(inputStream) as IConfigurationFrame;
            return ParseConfigurationFrame(configurationFrame);
        }

        public static List<WizardDeviceInfo> ParseConfigurationFrame(IConfigurationFrame configurationFrame)
        {
            //try
            //{
            s_configurationFrame = configurationFrame;

            List<WizardDeviceInfo> wizardDeviceInfoList = new List<WizardDeviceInfo>();
            if (configurationFrame != null)
            {
                int parentAccessID = configurationFrame.IDCode;

                foreach (IConfigurationCell cell in configurationFrame.Cells)
                {
                    Device tempDevice = GetDeviceByAcronym(null, cell.StationName.Replace(" ", "").ToUpper());
                    wizardDeviceInfoList.Add(new WizardDeviceInfo()
                        {
                            Acronym = cell.StationName.Replace(" ", "").ToUpper(),
                            Name = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(cell.StationName.ToLower()),
                            Longitude = tempDevice == null ? -98.6m : tempDevice.Longitude == null ? -98.6m : (decimal)tempDevice.Longitude,
                            Latitude = tempDevice == null ? 37.5m : tempDevice.Latitude == null ? 37.5m : (decimal)tempDevice.Latitude,
                            VendorDeviceID = tempDevice == null ? (int?)null : tempDevice.VendorDeviceID,
                            AccessID = cell.IDCode,
                            ParentAccessID = parentAccessID,
                            Include = true,
                            DigitalCount = cell.DigitalDefinitions.Count(),
                            AnalogCount = cell.AnalogDefinitions.Count(),
                            AddDigitals = false,
                            AddAnalogs = false,
                            IsNew = tempDevice == null ? true : false,
                            PhasorList = new ObservableCollection<PhasorInfo>((from phasor in cell.PhasorDefinitions
                                                                               select new PhasorInfo()
                                                                               {
                                                                                   Label = phasor.Label,  //CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(phasor.Label.Replace("?", " ").Trim().ToLower()),
                                                                                   Type = phasor.PhasorType == PhasorType.Current ? "I" : "V",
                                                                                   Phase = "+",
                                                                                   DestinationLabel = "",
                                                                                   Include = true
                                                                               }).ToList())
                        });
                }
            }

            List<string> nondistinctAcronymList = new List<string>();
            nondistinctAcronymList = (from item in wizardDeviceInfoList
                                      group item by item.Acronym into grouped
                                      where grouped.Count() > 1
                                      select grouped.Key).ToList();

            if (nondistinctAcronymList.Count > 0)
            {
                int i = 0;
                foreach (WizardDeviceInfo deviceInfo in wizardDeviceInfoList)
                {
                    if (deviceInfo.IsNew && nondistinctAcronymList.Contains(deviceInfo.Acronym))
                    {
                        deviceInfo.Acronym = deviceInfo.Acronym.Substring(0, deviceInfo.Acronym.Length - i.ToString().Length) + i.ToString();
                        i++;
                    }
                }
            }

            return wizardDeviceInfoList;
        }

        private static IConfigurationFrame s_responseAttachment;
        public static string s_responseMessage;
        private static ManualResetEvent s_responseWaitHandle;
        public static List<WizardDeviceInfo> RetrieveConfigurationFrame(string nodeConnectionString, string deviceConnectionString, int protocolID)
        {
            s_responseMessage = string.Empty;
            s_responseAttachment = null;

            Dictionary<string, string> settings = nodeConnectionString.ToLower().ParseKeyValuePairs();

            WindowsServiceClient windowsServiceClient = new WindowsServiceClient("server=" + settings["server"].Replace("{", "").Replace("}", ""));
            try
            {
                s_responseWaitHandle = new ManualResetEvent(false);
                windowsServiceClient.Helper.ReceivedServiceResponse += Helper_ReceivedServiceResponse;
                windowsServiceClient.Helper.ReceivedServiceUpdate += Helper_ReceivedServiceUpdate;
                windowsServiceClient.Helper.RemotingClient.MaxConnectionAttempts = 10;
                windowsServiceClient.Helper.Connect();
                if (windowsServiceClient.Helper.RemotingClient.Enabled)
                {
                    if (deviceConnectionString.ToLower().Contains("phasorprotocol"))
                        windowsServiceClient.Helper.SendRequest(string.Format("invoke 0 requestdeviceconfiguration \"{0}\"", deviceConnectionString));
                    else
                        windowsServiceClient.Helper.SendRequest(string.Format("invoke 0 requestdeviceconfiguration \"{0}\"", deviceConnectionString + "; phasorProtocol=" + GetProtocolAcronymByID(null, protocolID)));

                    if (s_responseWaitHandle.WaitOne(65000))
                    {
                        if (s_responseAttachment is ConfigurationErrorFrame)
                            throw new ApplicationException("Received configuration error frame, invocation request for device configuration has failed.\r\n");
                        else if (s_responseAttachment is IConfigurationFrame)
                            return ParseConfigurationFrame(s_responseAttachment as IConfigurationFrame);
                        else
                            throw new ApplicationException("Invalid frame received, invocation for device configuration has failed.");
                    }
                    else
                        throw new ApplicationException("Response timeout occured. Waited 60 seconds for Configuration Frame to arrive.");
                }
                else
                {
                    throw new ApplicationException("Connection timeout occured. Tried 10 times to connect to openPDC windows service.");
                }
            }
            finally
            {
                windowsServiceClient.Helper.Disconnect();
                //windowsServiceClient.Dispose();
            }
        }

        private static void Helper_ReceivedServiceUpdate(object sender, EventArgs<UpdateType, string> e)
        {
            if (e.Argument2.StartsWith("[PHASOR!SERVICES]") && !e.Argument2.Contains("*"))
                s_responseMessage += e.Argument2.Replace("[PHASOR!SERVICES]", "").Replace("\r\n\r\n", "\r\n");
        }

        private static void Helper_ReceivedServiceResponse(object sender, EventArgs<ServiceResponse> e)
        {
            List<object> attachments = e.Argument.Attachments;

            // Handle any special attachments coming in from service
            if (attachments != null)
            {
                foreach (object attachment in attachments)
                {
                    if (attachment is ConfigurationErrorFrame)
                    {
                        Thread.Sleep(1000);
                        s_responseAttachment = attachment as ConfigurationErrorFrame;
                        s_responseWaitHandle.Set();
                        //Console.WriteLine("Received configuration error frame, invocation request for device configuration has failed. See common phasor services response for reason.\r\n");
                    }
                    else if (attachment is IConfigurationFrame)	// If user requested a configuration frame, send it to parsing function to retrieve devices list.
                    {
                        s_responseAttachment = attachment as IConfigurationFrame;
                        s_responseWaitHandle.Set();
                    }
                }
            }
        }

        public static string SaveWizardConfigurationInfo(DataConnection connection, string nodeID, List<WizardDeviceInfo> wizardDeviceInfoList, string connectionString,
                int? protocolID, int? companyID, int? historianID, int? interconnectionID, int? parentID, bool skipDisableRealTimeData)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<string> nondistinctAcronymList = new List<string>();
                nondistinctAcronymList = (from item in wizardDeviceInfoList
                                          where item.Include == true
                                          group item by item.Acronym into grouped
                                          where grouped.Count() > 1
                                          select grouped.Key).ToList();

                if (nondistinctAcronymList.Count > 0)
                {
                    StringBuilder sb = new StringBuilder("Duplicate Acronyms Exist");
                    foreach (string item in nondistinctAcronymList)
                    {
                        sb.AppendLine();
                        sb.Append(item);
                    }
                    throw new ArgumentException(sb.ToString());
                }

                int loadOrder = 1;
                foreach (WizardDeviceInfo info in wizardDeviceInfoList)
                {
                    if (info.Include)
                    {
                        Device device = new Device();
                        device.NodeID = nodeID;
                        device.Acronym = info.Acronym;
                        device.Name = info.Name;
                        device.IsConcentrator = false;
                        device.Longitude = info.Longitude;
                        device.Latitude = info.Latitude;
                        device.ConnectionString = parentID == null ? connectionString : string.Empty;
                        device.ProtocolID = protocolID;
                        device.CompanyID = companyID;
                        device.HistorianID = historianID;
                        device.InterconnectionID = interconnectionID;
                        device.Enabled = true;
                        device.VendorDeviceID = info.VendorDeviceID == null ? (int?)null : info.VendorDeviceID == 0 ? (int?)null : info.VendorDeviceID;
                        device.ParentID = parentID;
                        device.AccessID = info.AccessID;
                        device.LoadOrder = loadOrder;
                        device.SkipDisableRealTimeData = skipDisableRealTimeData;

                        device.TimeZone = string.Empty;
                        device.TimeAdjustmentTicks = 0;
                        device.DataLossInterval = 5;
                        device.MeasuredLines = 1;
                        device.ContactList = string.Empty;
                        device.AllowedParsingExceptions = 10;
                        device.ParsingExceptionWindow = 5;
                        device.DelayedConnectionInterval = 5;
                        device.AllowUseOfCachedConfiguration = true;
                        device.AutoStartDataParsingSequence = true;
                        device.MeasurementReportingInterval = 100000;

                        //If Add Digitals and Add Analogs is checked for the device then, if digitals and analogs are available i.e. count>0 then add them as measurements.		
                        int digitalCount = 0;
                        if (info.AddDigitals && info.DigitalCount > 0)
                        {
                            digitalCount = info.DigitalCount;
                        }
                        int analogCount = 0;
                        if (info.AddAnalogs && info.AnalogCount > 0)
                        {
                            analogCount = info.AnalogCount;
                        }

                        Device existingDevice = GetDeviceByAcronym(connection, info.Acronym);
                        if (existingDevice != null)
                        {
                            device.ID = existingDevice.ID;
                            device.TimeZone = existingDevice.TimeZone;
                            device.TimeAdjustmentTicks = existingDevice.TimeAdjustmentTicks;
                            device.DataLossInterval = existingDevice.DataLossInterval;
                            device.MeasuredLines = existingDevice.MeasuredLines;
                            device.ContactList = existingDevice.ContactList;
                            device.AllowedParsingExceptions = existingDevice.AllowedParsingExceptions;
                            device.ParsingExceptionWindow = existingDevice.ParsingExceptionWindow;
                            device.DelayedConnectionInterval = existingDevice.DelayedConnectionInterval;
                            device.AllowUseOfCachedConfiguration = existingDevice.AllowUseOfCachedConfiguration;
                            device.AutoStartDataParsingSequence = existingDevice.AutoStartDataParsingSequence;
                            device.MeasurementReportingInterval = existingDevice.MeasurementReportingInterval;
                            SaveDevice(connection, device, false, digitalCount, analogCount);
                        }
                        else
                            SaveDevice(connection, device, true, digitalCount, analogCount);

                        Device addedDevice = GetDeviceByAcronym(connection, info.Acronym);
                        int count = 1;
                        foreach (PhasorInfo phasorInfo in info.PhasorList)
                        {
                            if (phasorInfo.Label.ToLower() != "unused")
                            {
                                Phasor phasor = new Phasor();
                                phasor.DeviceID = addedDevice.ID;
                                phasor.Label = phasorInfo.Label;
                                phasor.Type = phasorInfo.Type;
                                phasor.Phase = phasorInfo.Phase;
                                phasor.DestinationPhasorID = null;
                                phasor.SourceIndex = count;

                                Phasor existingPhasor = GetPhasorBySourceIndex(connection, addedDevice.ID, phasor.SourceIndex);
                                if (existingPhasor != null)
                                {
                                    phasor.ID = existingPhasor.ID;
                                    SavePhasor(connection, phasor, false);
                                }
                                else
                                    SavePhasor(connection, phasor, true);
                            }
                            count++;
                        }
                    }
                    loadOrder++;
                }
                return "Configuration Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static IDbDataParameter AddWithValue(IDbCommand command, string name, object value)
        {
            return AddWithValue(command, name, value, ParameterDirection.Input);
        }

        public static IDbDataParameter AddWithValue(IDbCommand command, string name, object value, ParameterDirection direction)
        {
            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            param.Direction = direction;
            return param;
        }

        public static bool MasterNode(DataConnection connection, string nodeID)
        {
            bool isMaster = false;
            bool createdConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select Master From Node Where ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", nodeID));
                isMaster = Convert.ToBoolean(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                isMaster = false;
                LogException(connection, "MasterNode", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return isMaster;
        }

        public static Dictionary<string, string> GetTimeZones(bool isOptional)
        {
            Dictionary<string, string> timeZonesList = new Dictionary<string, string>();
            if (isOptional)
                timeZonesList.Add("", "Select Timezone");

            foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
            {
                if (!timeZonesList.ContainsKey(tzi.StandardName))
                    timeZonesList.Add(tzi.StandardName, tzi.DisplayName);

                System.Diagnostics.Debug.WriteLine(tzi.DisplayName);
            }
            return timeZonesList;
        }

        public static Dictionary<string, int> GetVendorDeviceDistribution(DataConnection connection, string nodeID)
        {
            //DataConnection connection = new DataConnection();
            Dictionary<string, int> deviceDistribution = new Dictionary<string, int>();
            bool createdConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                if (!string.IsNullOrEmpty(nodeID))
                {
                    IDbCommand command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select * From VendorDeviceDistribution WHERE NodeID = @nodeID Order By VendorName";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));

                    DataTable resultTable = new DataTable();
                    resultTable.Load(command.ExecuteReader());

                    foreach (DataRow row in resultTable.Rows)
                    {
                        deviceDistribution.Add(row["VendorName"].ToString(), Convert.ToInt32(row["DeviceCount"]));
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(connection, "GetVendorDeviceDistribution", ex);
                //CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Get Vendor Device Distribution", SystemMessage = ex.Message };
                //throw new FaultException<CustomServiceFault>(fault);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return deviceDistribution;
        }

        public static List<InterconnectionStatus> GetInterconnectionStatus(DataConnection connection, string nodeID)
        {
            //DataConnection connection = new DataConnection();
            List<InterconnectionStatus> interConnectionStatusList = new List<InterconnectionStatus>();
            bool createdConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                if (!string.IsNullOrEmpty(nodeID))
                {
                    //throw new ArgumentException("Invalid value of NodeID.");
                    DataSet resultSet = new DataSet();
                    resultSet.Tables.Add(new DataTable("InterconnectionSummary"));
                    resultSet.Tables.Add(new DataTable("MemberSummary"));

                    IDbCommand command1 = connection.Connection.CreateCommand();
                    command1.CommandType = CommandType.Text;
                    command1.CommandText = "Select InterconnectionName, Count(*) AS DeviceCount From DeviceDetail WHERE NodeID = @nodeID Group By InterconnectionName";
                    if (command1.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command1.Parameters.Add(AddWithValue(command1, "@nodeID", "{" + nodeID + "}"));
                    else
                        command1.Parameters.Add(AddWithValue(command1, "@nodeID", nodeID));
                    resultSet.Tables["InterconnectionSummary"].Load(command1.ExecuteReader());

                    IDbCommand command2 = connection.Connection.CreateCommand();
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = "Select CompanyAcronym, CompanyName, InterconnectionName, Count(*) AS DeviceCount, Sum(MeasuredLines) AS MeasuredLines " +
                                            "From DeviceDetail WHERE NodeID = @nodeID Group By CompanyAcronym, CompanyName, InterconnectionName";
                    if (command2.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command2.Parameters.Add(AddWithValue(command2, "@nodeID", "{" + nodeID + "}"));
                    else
                        command2.Parameters.Add(AddWithValue(command2, "@nodeID", nodeID));
                    resultSet.Tables["MemberSummary"].Load(command2.ExecuteReader());

                    interConnectionStatusList = (from item in resultSet.Tables["InterconnectionSummary"].AsEnumerable()
                                                 select new InterconnectionStatus()
                                                 {
                                                     InterConnection = item.Field<string>("InterconnectionName"),
                                                     TotalDevices = "Total " + item.Field<object>("DeviceCount").ToString() + " Devices",
                                                     MemberStatusList = (from cs in resultSet.Tables["MemberSummary"].AsEnumerable()
                                                                         where cs.Field<string>("InterconnectionName") == item.Field<string>("InterconnectionName")
                                                                         select new MemberStatus()
                                                                         {
                                                                             CompanyAcronym = cs.Field<string>("CompanyAcronym"),
                                                                             CompanyName = cs.Field<string>("CompanyName"),
                                                                             MeasuredLines = Convert.ToInt32(cs.Field<object>("MeasuredLines")),
                                                                             TotalDevices = Convert.ToInt32(cs.Field<object>("DeviceCount"))
                                                                         }).ToList()
                                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogException(connection, "GetInterconnectionStatus", ex);
                //CustomServiceFault fault = new CustomServiceFault() { UserMessage = "Failed to Get Interconnection Status", SystemMessage = ex.Message };
                //throw new FaultException<CustomServiceFault>(fault);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return interConnectionStatusList;
        }

        public static List<TimeSeriesDataPoint> GetTimeSeriesData(string timeSeriesDataUrl)
        {
            List<TimeSeriesDataPoint> timeSeriesData = new List<TimeSeriesDataPoint>();
            try
            {
                HttpWebRequest request = WebRequest.Create(timeSeriesDataUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        XElement timeSeriesDataPoints = XElement.Parse(reader.ReadToEnd());
                        long index = 0;

                        foreach (XElement element in timeSeriesDataPoints.Element("TimeSeriesDataPoints").Elements("TimeSeriesDataPoint"))
                        {
                            timeSeriesData.Add(new TimeSeriesDataPoint()
                                {
                                    Index = index,
                                    Value = Convert.ToDouble(element.Element("Value").Value)
                                });
                            index = index + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(null, "GetRealTimeData", ex);
                //throw ex;
            }

            return timeSeriesData;
        }

        public static List<TimeSeriesDataPointDetail> GetTimeSeriesDataDetail(string timeSeriesDataUrl)
        {
            List<TimeSeriesDataPointDetail> timeSeriesData = new List<TimeSeriesDataPointDetail>();
            try
            {
                HttpWebRequest request = WebRequest.Create(timeSeriesDataUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        XElement timeSeriesDataPoints = XElement.Parse(reader.ReadToEnd());

                        foreach (XElement element in timeSeriesDataPoints.Element("TimeSeriesDataPoints").Elements("TimeSeriesDataPoint"))
                        {
                            DateTime sourceDateTime;
                            string quality;
                            //if timestamp is older than 30 seconds, report unknown quality.
                            if (DateTime.TryParseExact(element.Element("Time").Value, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sourceDateTime) && DateTime.UtcNow.Subtract(sourceDateTime).TotalSeconds > 30)
                                quality = "Unknown";
                            else
                                quality = element.Element("Quality").Value;

                            timeSeriesData.Add(new TimeSeriesDataPointDetail()
                            {
                                TimeStamp = element.Element("Time").Value,
                                Value = Convert.ToDouble(element.Element("Value").Value),
                                Quality = quality
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(null, "GetRealTimeDataDetail", ex);
                throw ex;
            }

            return timeSeriesData;
        }

        public static Dictionary<int, TimeTaggedMeasurement> GetTimeTaggedMeasurements(string timeSeriesDataUrl)
        {
            Dictionary<int, TimeTaggedMeasurement> timeTaggedMeasurementList = new Dictionary<int, TimeTaggedMeasurement>();

            try
            {
                HttpWebRequest request = WebRequest.Create(timeSeriesDataUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        XElement timeSeriesDataPoints = XElement.Parse(reader.ReadToEnd());

                        foreach (XElement element in timeSeriesDataPoints.Element("TimeSeriesDataPoints").Elements("TimeSeriesDataPoint"))
                        {
                            DateTime sourceDateTime;
                            string quality;
                            //if timestamp is older than 30 seconds, report unknown quality.
                            if (DateTime.TryParseExact(element.Element("Time").Value, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sourceDateTime) && DateTime.UtcNow.Subtract(sourceDateTime).TotalSeconds > 30)
                                quality = "Unknown";
                            else
                                quality = element.Element("Quality").Value;

                            timeTaggedMeasurementList.Add(Convert.ToInt32(element.Element("HistorianID").Value), new TimeTaggedMeasurement()
                            {
                                //PointID = Convert.ToInt32(element.Element("HistorianID").Value),
                                TimeTag = element.Element("Time").Value,
                                CurrentValue = element.Element("Value").Value,
                                Quality = quality
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(null, "GetTimeTaggedMeasurements", ex);
            }

            return timeTaggedMeasurementList;
        }

        public static Dictionary<int, TimeTaggedMeasurement> GetStatisticMeasurements(string statisticDataUrl, string nodeID)
        {
            Dictionary<int, TimeTaggedMeasurement> statisticMeasurementList = new Dictionary<int, TimeTaggedMeasurement>();
            Dictionary<int, BasicStatisticInfo> basicStatisticList = new Dictionary<int, BasicStatisticInfo>(GetBasicStatisticInfoList(null, nodeID));

            try
            {
                HttpWebRequest request = WebRequest.Create(statisticDataUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        XElement timeSeriesDataPoints = XElement.Parse(reader.ReadToEnd());

                        foreach (XElement element in timeSeriesDataPoints.Element("TimeSeriesDataPoints").Elements("TimeSeriesDataPoint"))
                        {
                            BasicStatisticInfo basicStatisticInfo;
                            if (basicStatisticList.TryGetValue(Convert.ToInt32(element.Element("HistorianID").Value), out basicStatisticInfo))
                            {
                                //System.Diagnostics.Debug.WriteLine(element.Element("HistorianID").Value);
                                DateTime sourceDateTime;
                                string quality;
                                if (DateTime.TryParseExact(element.Element("Time").Value, "yyyy-MM-dd HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sourceDateTime) && DateTime.UtcNow.Subtract(sourceDateTime).TotalSeconds > 30)
                                    quality = "Unknown";
                                else
                                    quality = element.Element("Quality").Value;

                                statisticMeasurementList.Add(Convert.ToInt32(element.Element("HistorianID").Value), new TimeTaggedMeasurement()
                                {
                                    //PointID = Convert.ToInt32(element.Element("HistorianID").Value),
                                    TimeTag = element.Element("Time").Value,
                                    CurrentValue = string.Format(basicStatisticInfo.DisplayFormat, ConvertValueToType(element.Element("Value").Value, basicStatisticInfo.DataType)),
                                    Quality = quality
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(null, "GetTimeTaggedMeasurements", ex);
            }

            return statisticMeasurementList;
        }

        static object ConvertValueToType(string xmlValue, string xmlDataType)
        {
            Type dataType = Type.GetType(xmlDataType);
            float value;

            if (float.TryParse(xmlValue, out value))
            {
                switch (xmlDataType)
                {
                    case "System.DateTime":
                        return new DateTime((long)value);
                    default:
                        return Convert.ChangeType(value, dataType);
                }
            }

            return "".ConvertToType<object>(dataType);
        }

        public static KeyValuePair<int, int> GetMinMaxPointIDs(DataConnection connection, string nodeID)
        {
            KeyValuePair<int, int> minMaxPointIDs = new KeyValuePair<int, int>(1, 5000);
            bool createdConnection = false;

            //DataConnection connection = new DataConnection();
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select MIN(PointID) AS MinPointID, MAX(PointID) AS MaxPointID From MeasurementDetail Where NodeID = @nodeID";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    minMaxPointIDs = new KeyValuePair<int, int>(reader["MinPointID"] == System.DBNull.Value ? 0 : reader.GetInt32(0), reader["MaxPointID"] == System.DBNull.Value ? 0 : reader.GetInt32(1));
                }
            }
            catch (Exception ex)
            {
                LogException(connection, "GetMinMaxPointIDs", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }

            return minMaxPointIDs;
        }

        public static List<string> GetStopBits()
        {
            List<string> stopBitsList = new List<string>();

            foreach (string stopBit in Enum.GetNames(typeof(System.IO.Ports.StopBits)))
                stopBitsList.Add(stopBit);

            return stopBitsList;
        }

        public static List<string> GetParities()
        {
            List<string> parityList = new List<string>();

            foreach (string parity in Enum.GetNames(typeof(System.IO.Ports.Parity)))
                parityList.Add(parity);

            return parityList;
        }

        public static string GetRuntimeID(DataConnection connection, string sourceTable, int sourceID)
        {
            string returnValue = string.Empty;
            bool createdConnection = false;
            //DataConnection connection = new DataConnection();
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID From Runtime Where SourceID = @sourceID AND SourceTable = @sourceTable";
                command.Parameters.Add(AddWithValue(command, "@sourceID", sourceID));
                command.Parameters.Add(AddWithValue(command, "@sourceTable", sourceTable));
                object temp = command.ExecuteScalar();

                if (temp != null)
                    returnValue = temp.ToString();
            }
            catch (Exception ex)
            {
                LogException(connection, "GetRuntimeID", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return returnValue;
        }

        public static string SendCommandToWindowsService(WindowsServiceClient serviceClient, string command)
        {
            //WindowsServiceClient serviceClient = new WindowsServiceClient(connectionString);
            try
            {
                //serviceClient.Helper.RemotingClient.MaxConnectionAttempts = connectionAttempts;
                //serviceClient.Helper.Connect();

                if (serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                    serviceClient.Helper.SendRequest(command);
                else
                    throw new Exception("Failed to Connect to openPDC Windows Service (" + serviceClient.Helper.RemotingClient.ConnectionString + ").");

                return "Successfully sent " + command + " command.";
            }
            finally
            {
                //try
                //{
                //    if (serviceClient.Helper.RemotingClient.CurrentState == TVA.Communication.ClientState.Connected)
                //        serviceClient.Helper.Disconnect();
                //}
                //catch { }
            }
        }

        #region " Manage Companies Code"

        public static List<Company> GetCompanyList(DataConnection connection)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<Company> companyList = new List<Company>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, Acronym, MapAcronym, Name, URL, LoadOrder FROM Company ORDER BY LoadOrder";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                companyList = (from item in resultTable.AsEnumerable()
                               select new Company()
                               {
                                   ID = Convert.ToInt32(item.Field<object>("ID")),
                                   Acronym = item.Field<string>("Acronym"),
                                   MapAcronym = item.Field<string>("MapAcronym"),
                                   Name = item.Field<string>("Name"),
                                   URL = item.Field<string>("URL"),
                                   LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder"))
                               }).ToList();
                return companyList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetCompanies(DataConnection connection, bool isOptional)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                Dictionary<int, string> companyList = new Dictionary<int, string>();
                if (isOptional)
                    companyList.Add(0, "Select Company");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT ID, Name FROM Company ORDER BY LoadOrder";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                int id;
                foreach (DataRow row in resultTable.Rows)
                {
                    id = int.Parse(row["ID"].ToString());

                    if (!companyList.ContainsKey(id))
                        companyList.Add(id, row["Name"].ToString());
                }
                return companyList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveCompany(DataConnection connection, Company company, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "INSERT INTO Company (Acronym, MapAcronym, Name, URL, LoadOrder, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) VALUES (@acronym, @mapAcronym, @name, @url, @loadOrder, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "UPDATE Company SET Acronym = @acronym, MapAcronym = @mapAcronym, Name = @name, URL = @url, LoadOrder = @loadOrder, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn WHERE ID = @id";

                command.Parameters.Add(AddWithValue(command, "@acronym", company.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@mapAcronym", company.MapAcronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", company.Name));
                command.Parameters.Add(AddWithValue(command, "@url", company.URL));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", company.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", company.ID));
                }

                command.ExecuteNonQuery();
                return "Company Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Output Streams Code"

        public static List<OutputStream> GetOutputStreamList(DataConnection connection, bool enabledOnly, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<OutputStream> outputStreamList = new List<OutputStream>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (enabledOnly)
                {
                    command.CommandText = "SELECT * FROM OutputStreamDetail Where NodeID = @nodeID AND Enabled = @enabled ORDER BY LoadOrder";
                    command.Parameters.Add(AddWithValue(command, "@enabled", true));
                }
                else
                    command.CommandText = "SELECT * FROM OutputStreamDetail Where NodeID = @nodeID ORDER BY LoadOrder";

                //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                outputStreamList = (from item in resultTable.AsEnumerable()
                                    select new OutputStream()
                                    {
                                        NodeID = item.Field<object>("NodeID").ToString(),
                                        ID = Convert.ToInt32(item.Field<object>("ID")),
                                        Acronym = item.Field<string>("Acronym"),
                                        Name = item.Field<string>("Name"),
                                        Type = Convert.ToInt32(item.Field<object>("Type")),
                                        ConnectionString = item.Field<string>("ConnectionString"),
                                        IDCode = Convert.ToInt32(item.Field<object>("IDCode")),
                                        CommandChannel = item.Field<string>("CommandChannel"),
                                        DataChannel = item.Field<string>("DataChannel"),
                                        AutoPublishConfigFrame = Convert.ToBoolean(item.Field<object>("AutoPublishConfigFrame")),
                                        AutoStartDataChannel = Convert.ToBoolean(item.Field<object>("AutoStartDataChannel")),
                                        NominalFrequency = Convert.ToInt32(item.Field<object>("NominalFrequency")),
                                        FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                        LagTime = item.Field<double>("LagTime"),
                                        LeadTime = item.Field<double>("LeadTime"),
                                        UseLocalClockAsRealTime = Convert.ToBoolean(item.Field<object>("UseLocalClockAsRealTime")),
                                        AllowSortsByArrival = Convert.ToBoolean(item.Field<object>("AllowSortsByArrival")),
                                        LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                        Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                        NodeName = item.Field<string>("NodeName"),
                                        TypeName = Convert.ToInt32(item.Field<object>("Type")) == 0 ? "IEEE C37.118" : "BPA",
                                        IgnoreBadTimeStamps = Convert.ToBoolean(item.Field<object>("IgnoreBadTimeStamps")),
                                        TimeResolution = Convert.ToInt32(item.Field<object>("TimeResolution")),
                                        AllowPreemptivePublishing = Convert.ToBoolean(item.Field<object>("AllowPreemptivePublishing")),
                                        DownsamplingMethod = item.Field<string>("DownsamplingMethod"),
                                        DataFormat = item.Field<string>("DataFormat"),
                                        CoordinateFormat = item.Field<string>("CoordinateFormat"),
                                        CurrentScalingValue = Convert.ToInt32(item.Field<object>("CurrentScalingValue")),
                                        VoltageScalingValue = Convert.ToInt32(item.Field<object>("VoltageScalingValue")),
                                        AnalogScalingValue = Convert.ToInt32(item.Field<object>("AnalogScalingValue")),
                                        DigitalMaskValue = Convert.ToInt32(item.Field<object>("DigitalMaskValue")),
                                        PerformTimestampReasonabilityCheck = Convert.ToBoolean(item.Field<object>("PerformTimestampReasonabilityCheck"))
                                    }).ToList();
                return outputStreamList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOutputStream(DataConnection connection, OutputStream outputStream, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "INSERT INTO OutputStream (NodeID, Acronym, Name, Type, ConnectionString, IDCode, CommandChannel, DataChannel, AutoPublishConfigFrame, AutoStartDataChannel, NominalFrequency, FramesPerSecond, LagTime, LeadTime, " +
                                        "UseLocalClockAsRealTime, AllowSortsByArrival, LoadOrder, Enabled, IgnoreBadTimeStamps, TimeResolution, AllowPreemptivePublishing, DownsamplingMethod, DataFormat, CoordinateFormat, CurrentScalingValue, VoltageScalingValue, " +
                                        "AnalogScalingValue, DigitalMaskValue, PerformTimestampReasonabilityCheck, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) VALUES (@nodeID, @acronym, @name, @type, @connectionString, @idCode, @commandChannel, @dataChannel, @autoPublishConfigFrame, @autoStartDataChannel, @nominalFrequency, @framesPerSecond, " +
                                        "@lagTime, @leadTime, @useLocalClockAsRealTime, @allowSortsByArrival, @loadOrder, @enabled, @ignoreBadTimeStamps, @timeResolution, @allowPreemptivePublishing, @downsamplingMethod, @dataFormat, @coordinateFormat, " +
                                        "@currentScalingValue, @voltageScalingValue, @analogScalingValue, @digitalMaskValue, @performTimestampReasonabilityCheck, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "UPDATE OutputStream SET NodeID = @nodeID, Acronym = @acronym, Name = @name, Type = @type, ConnectionString = @connectionString, IDCode = @idCode, CommandChannel = @commandChannel, DataChannel = @dataChannel, AutoPublishConfigFrame = @autoPublishConfigFrame, " +
                                        "AutoStartDataChannel = @autoStartDataChannel, NominalFrequency = @nominalFrequency, FramesPerSecond = @framesPerSecond, LagTime = @lagTime, LeadTime = @leadTime, UseLocalClockAsRealTime = @useLocalClockAsRealTime, " +
                                        "AllowSortsByArrival = @allowSortsByArrival, LoadOrder = @loadOrder, Enabled = @enabled, IgnoreBadTimeStamps = @ignoreBadTimeStamps, TimeResolution = @timeResolution, AllowPreemptivePublishing = @allowPreemptivePublishing, " +
                                        "DownsamplingMethod = @downsamplingMethod, DataFormat = @dataFormat, CoordinateFormat = @coordinateFormat, CurrentScalingValue = @currentScalingValue, VoltageScalingValue = @voltageScalingValue, " +
                                        "AnalogScalingValue = @analogScalingValue, DigitalMaskValue = @digitalMaskValue, PerformTimestampReasonabilityCheck = @performTimestampReasonabilityCheck, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn WHERE ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", outputStream.NodeID));
                command.Parameters.Add(AddWithValue(command, "@acronym", outputStream.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", outputStream.Name));
                command.Parameters.Add(AddWithValue(command, "@type", outputStream.Type));
                command.Parameters.Add(AddWithValue(command, "@connectionString", outputStream.ConnectionString));
                command.Parameters.Add(AddWithValue(command, "@idCode", outputStream.IDCode));
                command.Parameters.Add(AddWithValue(command, "@commandChannel", outputStream.CommandChannel));
                command.Parameters.Add(AddWithValue(command, "@dataChannel", outputStream.DataChannel));
                command.Parameters.Add(AddWithValue(command, "@autoPublishConfigFrame", outputStream.AutoPublishConfigFrame));
                command.Parameters.Add(AddWithValue(command, "@autoStartDataChannel", outputStream.AutoStartDataChannel));
                command.Parameters.Add(AddWithValue(command, "@nominalFrequency", outputStream.NominalFrequency));
                command.Parameters.Add(AddWithValue(command, "@framesPerSecond", outputStream.FramesPerSecond));
                command.Parameters.Add(AddWithValue(command, "@lagTime", outputStream.LagTime));
                command.Parameters.Add(AddWithValue(command, "@leadTime", outputStream.LeadTime));
                command.Parameters.Add(AddWithValue(command, "@useLocalClockAsRealTime", outputStream.UseLocalClockAsRealTime));
                command.Parameters.Add(AddWithValue(command, "@allowSortsByArrival", outputStream.AllowSortsByArrival));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStream.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", outputStream.Enabled));
                command.Parameters.Add(AddWithValue(command, "@ignoreBadTimeStamps", outputStream.IgnoreBadTimeStamps));
                command.Parameters.Add(AddWithValue(command, "@timeResolution", outputStream.TimeResolution));
                command.Parameters.Add(AddWithValue(command, "@allowPreemptivePublishing", outputStream.AllowPreemptivePublishing));
                command.Parameters.Add(AddWithValue(command, "@downsamplingMethod", outputStream.DownsamplingMethod));
                command.Parameters.Add(AddWithValue(command, "@dataFormat", outputStream.DataFormat));
                command.Parameters.Add(AddWithValue(command, "@coordinateFormat", outputStream.CoordinateFormat));
                command.Parameters.Add(AddWithValue(command, "@currentScalingValue", outputStream.CurrentScalingValue));
                command.Parameters.Add(AddWithValue(command, "@voltageScalingValue", outputStream.VoltageScalingValue));
                command.Parameters.Add(AddWithValue(command, "@analogScalingValue", outputStream.AnalogScalingValue));
                command.Parameters.Add(AddWithValue(command, "@digitalMaskValue", outputStream.DigitalMaskValue));
                command.Parameters.Add(AddWithValue(command, "@performTimestampReasonabilityCheck", outputStream.PerformTimestampReasonabilityCheck));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", outputStream.ID));
                }

                command.ExecuteNonQuery();

                try
                {
                    // Generate Statistical Measurements for the device.
                    //CommonPhasorServices.ValidateStatistics(connection.Connection, connection.AdapterType, "'" + outputStream.NodeID + "'", new Action<object, EventArgs<string>>(StatusMessageHandler), new Action<object, EventArgs<Exception>>(ProcessExceptionHandler));
                }
                catch (Exception ex)
                {
                    //Do not do anything. If this fails then we dont want to interrupt save operation.
                    LogException(connection, "SaveOutputStream: PhasorDataSourceValidation", ex);
                }

                return "Output Stream Information Saved Successfully";
            }

            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStream(DataConnection connection, int outputStreamID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From OutputStream Where ID = @outputStreamID";
                command.Parameters.Add(AddWithValue(command, "@outputStreamID", outputStreamID));
                command.ExecuteNonQuery();

                return "Output Stream Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static OutputStream GetOutputStreamByAcronym(DataConnection connection, string acronym, string nodeID)
        {
            try
            {
                List<OutputStream> outputStreamList = new List<OutputStream>();
                outputStreamList = (from item in GetOutputStreamList(connection, false, nodeID)
                                    where item.Acronym.ToUpper() == acronym.ToUpper()
                                    select item).ToList();
                if (outputStreamList.Count > 0)
                    return outputStreamList[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetOutputStreamByAcronym", ex);
                return null;
            }
        }

        public static string UpdateOutputStreamStatistics(DataConnection connection, string nodeID, string oldAcronym, string newAcronym, string oldName, string newName)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                ////If device is updated then make sure all the statistical measurements get updated too to reflect any change in acronym.
                if (!string.IsNullOrEmpty(oldAcronym) && oldAcronym != newAcronym)
                {
                    List<Measurement> measurementList = GetOutputStreamStatistics(connection, nodeID, oldAcronym);
                    foreach (Measurement measurement in measurementList)
                    {
                        measurement.SignalReference = measurement.SignalReference.Replace(oldAcronym, newAcronym);
                        measurement.PointTag = measurement.PointTag.Replace(oldAcronym, newAcronym);
                        measurement.Description = System.Text.RegularExpressions.Regex.Replace(measurement.Description, oldName, newName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);      //measurement.Description.Replace(oldAcronym, newAcronym);
                        SaveMeasurement(connection, measurement, false);
                    }
                }

                return "";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Output Stream Measurements Code"

        public static List<OutputStreamMeasurement> GetOutputStreamMeasurementList(DataConnection connection, int outputStreamID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<OutputStreamMeasurement> outputStreamMeasurementList = new List<OutputStreamMeasurement>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OutputStreamMeasurementDetail Where AdapterID = @adapterID";
                command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                outputStreamMeasurementList = (from item in resultTable.AsEnumerable()
                                               select new OutputStreamMeasurement()
                                               {
                                                   NodeID = item.Field<object>("NodeID").ToString(),
                                                   AdapterID = Convert.ToInt32(item.Field<object>("AdapterID")),
                                                   ID = Convert.ToInt32(item.Field<object>("ID")),
                                                   PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                                   HistorianID = item.NullableInt("HistorianID"),
                                                   SignalReference = item.Field<string>("SignalReference"),
                                                   SourcePointTag = item.Field<string>("SourcePointTag"),
                                                   HistorianAcronym = item.Field<string>("HistorianAcronym")
                                               }).ToList();
                return outputStreamMeasurementList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOutputStreamMeasurement(DataConnection connection, OutputStreamMeasurement outputStreamMeasurement, bool isNew)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into OutputStreamMeasurement (NodeID, AdapterID, HistorianID, PointID, SignalReference, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@nodeID, @adapterID, @historianID, @pointID, @signalReference, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update OutputStreamMeasurement Set NodeID = @nodeID, AdapterID = @adapterID, HistorianID = @historianID, " +
                        "PointID = @pointID, SignalReference = @signalReference, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn WHERE ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamMeasurement.NodeID));
                command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamMeasurement.AdapterID));
                command.Parameters.Add(AddWithValue(command, "@historianID", outputStreamMeasurement.HistorianID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@pointID", outputStreamMeasurement.PointID));
                command.Parameters.Add(AddWithValue(command, "@signalReference", outputStreamMeasurement.SignalReference));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", outputStreamMeasurement.ID));
                }

                command.ExecuteNonQuery();
                return "Output Stream Measurement Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStreamMeasurement(DataConnection connection, int outputStreamMeasurementID)	// we can just use ID column in the database for delete as it is auto increament.
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From OutputStreamMeasurement Where ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", outputStreamMeasurementID));
                command.ExecuteNonQuery();

                return "Output Stream Measurement Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Output Stream Devices Code"

        public static List<OutputStreamDevice> GetOutputStreamDeviceList(DataConnection connection, int outputStreamID, bool enabledOnly)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<OutputStreamDevice> outputStreamDeviceList = new List<OutputStreamDevice>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (!enabledOnly)
                    command.CommandText = "Select * From OutputStreamDeviceDetail Where AdapterID = @adapterID Order By LoadOrder";
                else
                    command.CommandText = "Select * From OutputStreamDeviceDetail Where AdapterID = @adapterID AND Enabled = @enabled Order By LoadOrder";

                command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));
                if (enabledOnly)
                    command.Parameters.Add(AddWithValue(command, "@enabled", true));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                outputStreamDeviceList = (from item in resultTable.AsEnumerable()
                                          select new OutputStreamDevice()
                                          {
                                              NodeID = item.Field<object>("NodeID").ToString(),
                                              AdapterID = Convert.ToInt32(item.Field<object>("AdapterID")),
                                              ID = Convert.ToInt32(item.Field<object>("ID")),
                                              IdCode = Convert.ToInt32(item.Field<object>("IDCode")),
                                              Acronym = item.Field<string>("Acronym"),
                                              Name = item.Field<string>("Name"),
                                              BpaAcronym = item.Field<string>("BpaAcronym"),
                                              LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                              Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                              PhasorDataFormat = item.Field<string>("PhasorDataFormat"),
                                              FrequencyDataFormat = item.Field<string>("FrequencyDataFormat"),
                                              AnalogDataFormat = item.Field<string>("AnalogDataFormat"),
                                              CoordinateFormat = item.Field<string>("CoordinateFormat"),
                                              Virtual = Convert.ToBoolean(item.Field<object>("Virtual"))
                                          }).ToList();
                return outputStreamDeviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static OutputStreamDevice GetOutputStreamDevice(DataConnection connection, int outputStreamID, string acronym)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OutputStreamDeviceDetail Where AdapterID = @adapterID AND Acronym = @acronym";
                command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));
                command.Parameters.Add(AddWithValue(command, "@acronym", acronym));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                if (resultTable.Rows.Count == 0)
                    return null;

                OutputStreamDevice outputStreamDevice = (from item in resultTable.AsEnumerable()
                                                         select new OutputStreamDevice()
                                                         {
                                                             NodeID = item.Field<object>("NodeID").ToString(),
                                                             AdapterID = Convert.ToInt32(item.Field<object>("AdapterID")),
                                                             ID = Convert.ToInt32(item.Field<object>("ID")),
                                                             IdCode = Convert.ToInt32(item.Field<object>("IDCode")),
                                                             Acronym = item.Field<string>("Acronym"),
                                                             Name = item.Field<string>("Name"),
                                                             BpaAcronym = item.Field<string>("BpaAcronym"),
                                                             LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                                             Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                                             PhasorDataFormat = item.Field<string>("PhasorDataFormat"),
                                                             FrequencyDataFormat = item.Field<string>("FrequencyDataFormat"),
                                                             AnalogDataFormat = item.Field<string>("AnalogDataFormat"),
                                                             CoordinateFormat = item.Field<string>("CoordinateFormat"),
                                                             Virtual = Convert.ToBoolean(item.Field<object>("Virtual"))
                                                         }).First();
                return outputStreamDevice;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetOutputStreamDevice", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOutputStreamDevice(DataConnection connection, OutputStreamDevice outputStreamDevice, bool isNew, string originalAcronym)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;

            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into OutputStreamDevice (NodeID, AdapterID, IDCode, Acronym, BpaAcronym, Name, LoadOrder, Enabled, PhasorDataFormat, FrequencyDataFormat, AnalogDataFormat, CoordinateFormat, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@nodeID, @adapterID, @idCode, @acronym, @bpaAcronym, @name, @loadOrder, @enabled, @phasorDataFormat, @frequencyDataFormat, @analogDataFormat, @coordinateFormat, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update OutputStreamDevice Set NodeID = @nodeID, AdapterID = @adapterID, IDCode = @idCode, Acronym = @acronym, " +
                        "BpaAcronym = @bpaAcronym, Name = @name, LoadOrder = @loadOrder, Enabled = @enabled, PhasorDataFormat = @phasorDataFormat, " +
                        "FrequencyDataFormat = @frequencyDataFormat, AnalogDataFormat = @analogDataFormat, CoordinateFormat = @coordinateFormat, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDevice.NodeID));
                command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamDevice.AdapterID));
                command.Parameters.Add(AddWithValue(command, "@idCode", outputStreamDevice.IdCode));
                command.Parameters.Add(AddWithValue(command, "@acronym", outputStreamDevice.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@bpaAcronym", outputStreamDevice.BpaAcronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", outputStreamDevice.Name));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDevice.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", outputStreamDevice.Enabled));
                command.Parameters.Add(AddWithValue(command, "@phasorDataFormat", outputStreamDevice.PhasorDataFormat));
                command.Parameters.Add(AddWithValue(command, "@frequencyDataFormat", outputStreamDevice.FrequencyDataFormat));
                command.Parameters.Add(AddWithValue(command, "@analogDataFormat", outputStreamDevice.AnalogDataFormat));
                command.Parameters.Add(AddWithValue(command, "@coordinateFormat", outputStreamDevice.CoordinateFormat));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", outputStreamDevice.ID));

                    //if output stream device is updated then modify signal references in the measurement table
                    //to reflect changes in the acronym of the device. Do this only if new and original acronyms are different.
                    if (!string.IsNullOrEmpty(originalAcronym) && originalAcronym != outputStreamDevice.Acronym)
                    {
                        //Microsoft Access does not support REPLACE function in SQL statement.
                        if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        {
                            List<OutputStreamMeasurement> outputStreamMeasurements = GetOutputStreamMeasurementList(connection, outputStreamDevice.AdapterID);
                            foreach (OutputStreamMeasurement osm in outputStreamMeasurements)
                            {
                                if (osm.SignalReference.StartsWith(originalAcronym + "-"))
                                {
                                    osm.SignalReference = osm.SignalReference.Replace(originalAcronym, outputStreamDevice.Acronym);
                                    SaveOutputStreamMeasurement(connection, osm, false);
                                }
                            }
                        }
                        else
                        {
                            IDbCommand command1 = connection.Connection.CreateCommand();
                            command1.CommandType = CommandType.Text;
                            command1.CommandText = "Update OutputStreamMeasurement Set SignalReference = Replace(SignalReference, @originalAcronym, @newAcronym) Where AdapterID = @adapterID";	// and SignalReference LIKE @signalReference";
                            command1.Parameters.Add(AddWithValue(command1, "@originalAcronym", originalAcronym));
                            command1.Parameters.Add(AddWithValue(command1, "@newAcronym", outputStreamDevice.Acronym));
                            command1.Parameters.Add(AddWithValue(command1, "@adapterID", outputStreamDevice.AdapterID));
                            command1.ExecuteNonQuery();
                        }
                    }
                }

                command.ExecuteNonQuery();

                if (isNew && outputStreamDevice.IdCode == 0)
                {
                    //TODO: update IDCode to auto generated ID value.      
                    OutputStreamDevice deviceJustAdded = GetOutputStreamDevice(connection, outputStreamDevice.AdapterID, outputStreamDevice.Acronym.Replace(" ", "").ToUpper());
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Update OutputStreamDevice SET IDCode = @idCode Where ID = @id";
                    command.Parameters.Add(AddWithValue(command, "@idCode", deviceJustAdded.ID));
                    command.Parameters.Add(AddWithValue(command, "@id", deviceJustAdded.ID));
                    command.ExecuteNonQuery();
                }

                return "Output Stream Device Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStreamDevice(DataConnection connection, int outputStreamID, List<string> devicesToBeDeleted)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                foreach (string acronym in devicesToBeDeleted)
                {
                    IDbCommand command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Delete From OutputStreamMeasurement Where AdapterID = @outputStreamID And SignalReference LIKE @signalReference";
                    command.Parameters.Add(AddWithValue(command, "@outputStreamID", outputStreamID));
                    command.Parameters.Add(AddWithValue(command, "@signalReference", "%" + acronym + "%"));
                    command.ExecuteNonQuery();

                    IDbCommand command1 = connection.Connection.CreateCommand();
                    command1.CommandType = CommandType.Text;
                    command1.CommandText = "Delete From OutputStreamDevice Where Acronym = @acronym And AdapterID = @adapterID";
                    command1.Parameters.Add(AddWithValue(command1, "@acronym", acronym));
                    command1.Parameters.Add(AddWithValue(command1, "@adapterID", outputStreamID));
                    command1.ExecuteNonQuery();
                }

                return "Output Stream Device Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string digitalLabel = "DIGITAL0        DIGITAL1        DIGITAL2        DIGITAL3        DIGITAL4        DIGITAL5        DIGITAL6        DIGITAL7        DIGITAL8        DIGITAL9        DIGITAL10       DIGITAL11       DIGITAL12       DIGITAL13       DIGITAL14       DIGITAL15       ";
        public static string AddDevices(DataConnection connection, int outputStreamID, Dictionary<int, string> devicesToBeAdded, bool addDigitals, bool addAnalogs)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                foreach (KeyValuePair<int, string> deviceInfo in devicesToBeAdded)	//loop through all the devices that needs to be added.
                {
                    Device device = new Device();
                    device = GetDeviceByDeviceID(connection, deviceInfo.Key);	//Get all the information about the device to be added.
                    OutputStreamDevice outputStreamDevice = new OutputStreamDevice();
                    outputStreamDevice.NodeID = device.NodeID;
                    outputStreamDevice.AdapterID = outputStreamID;
                    outputStreamDevice.Acronym = device.Acronym;
                    outputStreamDevice.BpaAcronym = string.Empty;
                    outputStreamDevice.Name = device.Name;
                    outputStreamDevice.LoadOrder = device.LoadOrder;
                    outputStreamDevice.Enabled = true;
                    outputStreamDevice.PhasorDataFormat = string.Empty;
                    outputStreamDevice.FrequencyDataFormat = string.Empty;
                    outputStreamDevice.AnalogDataFormat = string.Empty;
                    outputStreamDevice.CoordinateFormat = string.Empty;
                    outputStreamDevice.IdCode = device.AccessID;
                    SaveOutputStreamDevice(connection, outputStreamDevice, true, string.Empty);	//save in to OutputStreamDevice Table.

                    int savedOutputStreamDeviceID = GetOutputStreamDevice(connection, outputStreamID, device.Acronym).ID;


                    //********************************************
                    List<Phasor> phasorList = new List<Phasor>();
                    phasorList = GetPhasorList(connection, deviceInfo.Key);			//Get all the phasor information for the device to be added.

                    foreach (Phasor phasor in phasorList)
                    {
                        OutputStreamDevicePhasor outputStreamDevicePhasor = new OutputStreamDevicePhasor(); //Add all phasors one by one into OutputStreamDevicePhasor table.
                        outputStreamDevicePhasor.NodeID = device.NodeID;
                        outputStreamDevicePhasor.OutputStreamDeviceID = savedOutputStreamDeviceID;
                        outputStreamDevicePhasor.Label = phasor.Label;
                        outputStreamDevicePhasor.Type = phasor.Type;
                        outputStreamDevicePhasor.Phase = phasor.Phase;
                        outputStreamDevicePhasor.LoadOrder = phasor.SourceIndex;
                        outputStreamDevicePhasor.ScalingValue = 0;
                        SaveOutputStreamDevicePhasor(connection, outputStreamDevicePhasor, true);
                    }
                    //********************************************

                    //********************************************
                    List<Measurement> measurementList = new List<Measurement>();
                    measurementList = GetMeasurementsByDevice(connection, deviceInfo.Key);

                    int analogIndex = 0;
                    foreach (Measurement measurement in measurementList)
                    {
                        if (measurement.SignalAcronym != "STAT")
                        {
                            OutputStreamMeasurement outputStreamMeasurement = new OutputStreamMeasurement();
                            outputStreamMeasurement.NodeID = device.NodeID;
                            outputStreamMeasurement.AdapterID = outputStreamID;
                            outputStreamMeasurement.HistorianID = measurement.HistorianID;
                            outputStreamMeasurement.PointID = measurement.PointID;
                            outputStreamMeasurement.SignalReference = measurement.SignalReference;

                            if (measurement.SignalAcronym == "ALOG")
                            {
                                if (addAnalogs)
                                {
                                    SaveOutputStreamMeasurement(connection, outputStreamMeasurement, true);

                                    OutputStreamDeviceAnalog outputStreamDeviceAnalog = new OutputStreamDeviceAnalog();
                                    outputStreamDeviceAnalog.NodeID = device.NodeID;
                                    outputStreamDeviceAnalog.OutputStreamDeviceID = savedOutputStreamDeviceID;
                                    outputStreamDeviceAnalog.Label = device.Acronym.Length > 12 ? device.Acronym.Substring(0, 12) + ":A" + analogIndex.ToString() : device.Acronym + ":A" + analogIndex.ToString(); // measurement.PointTag;
                                    outputStreamDeviceAnalog.Type = 0;	//default
                                    outputStreamDeviceAnalog.LoadOrder = Convert.ToInt32(measurement.SignalReference.Substring((measurement.SignalReference.LastIndexOf("-") + 3)));
                                    outputStreamDeviceAnalog.ScalingValue = 0;
                                    SaveOutputStreamDeviceAnalog(connection, outputStreamDeviceAnalog, true);
                                    analogIndex += 1;
                                }
                            }
                            else if (measurement.SignalAcronym == "DIGI")
                            {
                                if (addDigitals)
                                {
                                    SaveOutputStreamMeasurement(connection, outputStreamMeasurement, true);

                                    OutputStreamDeviceDigital outputStreamDeviceDigital = new OutputStreamDeviceDigital();
                                    outputStreamDeviceDigital.NodeID = device.NodeID;
                                    outputStreamDeviceDigital.OutputStreamDeviceID = savedOutputStreamDeviceID;
                                    outputStreamDeviceDigital.Label = digitalLabel;     // measurement.PointTag;
                                    outputStreamDeviceDigital.LoadOrder = Convert.ToInt32(measurement.SignalReference.Substring((measurement.SignalReference.LastIndexOf("-") + 3)));
                                    outputStreamDeviceDigital.MaskValue = 0;
                                    SaveOutputStreamDeviceDigital(connection, outputStreamDeviceDigital, true);
                                }
                            }
                            else
                                SaveOutputStreamMeasurement(connection, outputStreamMeasurement, true);

                        }
                    }
                    //********************************************
                }

                return "Output Stream Device(s) Added Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Output Stream Device Phasor Code"

        public static List<OutputStreamDevicePhasor> GetOutputStreamDevicePhasorList(DataConnection connection, int outputStreamDeviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<OutputStreamDevicePhasor> outputStreamDevicePhasorList = new List<OutputStreamDevicePhasor>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OutputStreamDevicePhasor Where OutputStreamDeviceID = @outputStreamDeviceID Order By LoadOrder";
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceID));
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                outputStreamDevicePhasorList = (from item in resultTable.AsEnumerable()
                                                select new OutputStreamDevicePhasor()
                                                {
                                                    NodeID = item.Field<object>("NodeID").ToString(),
                                                    OutputStreamDeviceID = Convert.ToInt32(item.Field<object>("OutputStreamDeviceID")),
                                                    ID = Convert.ToInt32(item.Field<object>("ID")),
                                                    Label = item.Field<string>("Label"),
                                                    Type = item.Field<string>("Type"),
                                                    Phase = item.Field<string>("Phase"),
                                                    LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                                    ScalingValue = Convert.ToInt32(item.Field<object>("ScalingValue")),
                                                    PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
                                                    PhaseType = item.Field<string>("Phase") == "+" ? "Positive Sequence" : item.Field<string>("Phase") == "-" ? "Negative Sequence" :
                                                                item.Field<string>("Phase") == "0" ? "Zero Sequence" : item.Field<string>("Phase") == "A" ? "Phase A" :
                                                                item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
                                                }).ToList();
                return outputStreamDevicePhasorList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOutputStreamDevicePhasor(DataConnection connection, OutputStreamDevicePhasor outputStreamDevicePhasor, bool isNew)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into OutputStreamDevicePhasor (NodeID, OutputStreamDeviceID, Label, Type, Phase, LoadOrder, ScalingValue, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@nodeID, @outputStreamDeviceID, @label, @type, @phase, @loadOrder, @scalingValue, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update OutputStreamDevicePhasor Set NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID, Label = @label, " +
                        "Type = @type, Phase = @phase, LoadOrder = @loadOrder, ScalingValue = @scalingValue, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDevicePhasor.NodeID));
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDevicePhasor.OutputStreamDeviceID));
                command.Parameters.Add(AddWithValue(command, "@label", outputStreamDevicePhasor.Label));
                command.Parameters.Add(AddWithValue(command, "@type", outputStreamDevicePhasor.Type));
                command.Parameters.Add(AddWithValue(command, "@phase", outputStreamDevicePhasor.Phase));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDevicePhasor.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@scalingValue", outputStreamDevicePhasor.ScalingValue));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", outputStreamDevicePhasor.ID));
                }

                command.ExecuteNonQuery();
                return "Output Stream Device Phasor Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStreamDevicePhasor(DataConnection connection, int outputStreamDevicePhasorID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From OutputStreamDevicePhasor Where ID = @outputStreamDevicePhasorID";
                command.Parameters.Add(AddWithValue(command, "@outputStreamDevicePhasorID", outputStreamDevicePhasorID));
                command.ExecuteNonQuery();

                return "Output Stream Device Phasor Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Output Stream Device Analogs Code"

        public static List<OutputStreamDeviceAnalog> GetOutputStreamDeviceAnalogList(DataConnection connection, int outputStreamDeviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<OutputStreamDeviceAnalog> outputStreamDeviceAnalogList = new List<OutputStreamDeviceAnalog>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OutputStreamDeviceAnalog Where OutputStreamDeviceID = @outputStreamDeviceID Order By LoadOrder";
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                outputStreamDeviceAnalogList = (from item in resultTable.AsEnumerable()
                                                select new OutputStreamDeviceAnalog()
                                                {
                                                    NodeID = item.Field<object>("NodeID").ToString(),
                                                    OutputStreamDeviceID = Convert.ToInt32(item.Field<object>("OutputStreamDeviceID")),
                                                    ID = Convert.ToInt32(item.Field<object>("ID")),
                                                    Label = item.Field<string>("Label"),
                                                    Type = Convert.ToInt32(item.Field<object>("Type")),
                                                    LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                                    ScalingValue = Convert.ToInt32(item.Field<object>("ScalingValue")),
                                                    TypeName = Convert.ToInt32(item.Field<object>("Type")) == 0 ? "Single point-on-wave" : Convert.ToInt32(item.Field<object>("Type")) == 1 ? "RMS of analog input" : "Peak of analog input"
                                                }).ToList();
                return outputStreamDeviceAnalogList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOutputStreamDeviceAnalog(DataConnection connection, OutputStreamDeviceAnalog outputStreamDeviceAnalog, bool isNew)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into OutputStreamDeviceAnalog (NodeID, OutputStreamDeviceID, Label, Type, LoadOrder, ScalingValue, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@nodeID, @outputStreamDeviceID, @label, @type, @loadOrder, @scalingValue, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update OutputStreamDeviceAnalog Set NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID, Label = @label, " +
                        "Type = @type, LoadOrder = @loadOrder, ScalingValue = @scalingValue, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDeviceAnalog.NodeID));
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceAnalog.OutputStreamDeviceID));
                command.Parameters.Add(AddWithValue(command, "@label", outputStreamDeviceAnalog.Label));
                command.Parameters.Add(AddWithValue(command, "@type", outputStreamDeviceAnalog.Type));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDeviceAnalog.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@scalingValue", outputStreamDeviceAnalog.ScalingValue));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", outputStreamDeviceAnalog.ID));
                }

                command.ExecuteNonQuery();
                return "Output Stream Device Analog Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStreamDeviceAnalog(DataConnection connection, int outputStreamDeviceAnalogID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From OutputStreamDeviceAnalog Where ID = @outputStreamDeviceAnalogID";
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceAnalogID", outputStreamDeviceAnalogID));
                command.ExecuteNonQuery();

                return "Output Stream Device Analog Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Output Stream Device Digitals Code"

        public static List<OutputStreamDeviceDigital> GetOutputStreamDeviceDigitalList(DataConnection connection, int outputStreamDeviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<OutputStreamDeviceDigital> outputStreamDeviceDigitalList = new List<OutputStreamDeviceDigital>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OutputStreamDeviceDigital Where OutputStreamDeviceID = @outputStreamDeviceID Order By LoadOrder";
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                outputStreamDeviceDigitalList = (from item in resultTable.AsEnumerable()
                                                 select new OutputStreamDeviceDigital()
                                                 {
                                                     NodeID = item.Field<object>("NodeID").ToString(),
                                                     OutputStreamDeviceID = Convert.ToInt32(item.Field<object>("OutputStreamDeviceID")),
                                                     ID = Convert.ToInt32(item.Field<object>("ID")),
                                                     Label = item.Field<string>("Label"),
                                                     LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                                     MaskValue = Convert.ToInt32(item.Field<object>("MaskValue"))
                                                 }).ToList();
                return outputStreamDeviceDigitalList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOutputStreamDeviceDigital(DataConnection connection, OutputStreamDeviceDigital outputStreamDeviceDigital, bool isNew)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into OutputStreamDeviceDigital (NodeID, OutputStreamDeviceID, Label, LoadOrder, MaskValue, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@nodeID, @outputStreamDeviceID, @label, @loadOrder, @maskValue, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update OutputStreamDeviceDigital Set NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID, Label = @label, " +
                        "LoadOrder = @loadOrder, MaskValue = @maskValue, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", outputStreamDeviceDigital.NodeID));
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceID", outputStreamDeviceDigital.OutputStreamDeviceID));
                command.Parameters.Add(AddWithValue(command, "@label", outputStreamDeviceDigital.Label));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", outputStreamDeviceDigital.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@maskValue", outputStreamDeviceDigital.MaskValue));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    command.Parameters.Add(AddWithValue(command, "@id", outputStreamDeviceDigital.ID));
                }

                command.ExecuteNonQuery();
                return "Output Stream Device Digital Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStreamDeviceDigital(DataConnection connection, int outputStreamDeviceDigitalID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From OutputStreamDeviceDigital Where ID = @outputStreamDeviceDigitalID";
                command.Parameters.Add(AddWithValue(command, "@outputStreamDeviceDigitalID", outputStreamDeviceDigitalID));
                command.ExecuteNonQuery();

                return "Output Stream Device Digital Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Historians Code"

        public static List<Historian> GetHistorianList(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<Historian> historianList = new List<Historian>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select * From HistorianDetail Order By LoadOrder";
                else
                {
                    command.CommandText = "Select * From HistorianDetail Where NodeID = @nodeID Order By LoadOrder";
                    //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                historianList = (from item in resultTable.AsEnumerable()
                                 select new Historian()
                                 {
                                     NodeID = item.Field<object>("NodeID").ToString(),
                                     ID = Convert.ToInt32(item.Field<object>("ID")),
                                     Acronym = item.Field<string>("Acronym"),
                                     Name = item.Field<string>("Name"),
                                     ConnectionString = item.Field<string>("ConnectionString"),
                                     Description = item.Field<string>("Description"),
                                     IsLocal = Convert.ToBoolean(item.Field<object>("IsLocal")),
                                     Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                     LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                     TypeName = item.Field<string>("TypeName"),
                                     AssemblyName = item.Field<string>("AssemblyName"),
                                     MeasurementReportingInterval = Convert.ToInt32(item.Field<object>("MeasurementReportingInterval")),
                                     NodeName = item.Field<string>("NodeName")
                                 }).ToList();
                return historianList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetHistorians(DataConnection connection, bool enabledOnly, bool isOptional, bool includeSTAT)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                Dictionary<int, string> historianList = new Dictionary<int, string>();
                if (isOptional)
                    historianList.Add(0, "Select Historian");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (enabledOnly)
                {
                    command.CommandText = "Select ID, Acronym From Historian Where Enabled = @enabled Order By LoadOrder";
                    command.Parameters.Add(AddWithValue(command, "@enabled", true));
                }
                else
                    command.CommandText = "Select ID, Acronym From Historian Order By LoadOrder";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                foreach (DataRow row in resultTable.Rows)
                {
                    if (!includeSTAT && row["Acronym"].ToString().ToUpper().StartsWith("STAT"))
                    {
                        //do not add
                    }
                    else
                    {
                        if (!historianList.ContainsKey(Convert.ToInt32(row["ID"])))
                            historianList.Add(Convert.ToInt32(row["ID"]), row["Acronym"].ToString());
                    }
                }
                return historianList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveHistorian(DataConnection connection, Historian historian, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (isNew)
                    command.CommandText = "Insert Into Historian (NodeID, Acronym, Name, AssemblyName, TypeName, ConnectionString, IsLocal, MeasurementReportingInterval, Description, LoadOrder, Enabled, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values " +
                        "(@nodeID, @acronym, @name, @assemblyName, @typeName, @connectionString, @isLocal, @measurementReportingInterval, @description, @loadOrder, @enabled, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update Historian Set NodeID = @nodeID, Acronym = @acronym, Name = @name, AssemblyName = @assemblyName, TypeName = @typeName, " +
                        "ConnectionString = @connectionString, IsLocal = @isLocal, MeasurementReportingInterval = @measurementReportingInterval, Description = @description, LoadOrder = @loadOrder, Enabled = @enabled, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", historian.NodeID));
                command.Parameters.Add(AddWithValue(command, "@acronym", historian.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", historian.Name));
                command.Parameters.Add(AddWithValue(command, "@assemblyName", historian.AssemblyName));
                command.Parameters.Add(AddWithValue(command, "@typeName", historian.TypeName));
                command.Parameters.Add(AddWithValue(command, "@connectionString", historian.ConnectionString));
                command.Parameters.Add(AddWithValue(command, "@isLocal", historian.IsLocal));
                command.Parameters.Add(AddWithValue(command, "@measurementReportingInterval", historian.MeasurementReportingInterval));
                command.Parameters.Add(AddWithValue(command, "@description", historian.Description));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", historian.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", historian.Enabled));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", historian.ID));

                command.ExecuteNonQuery();
                return "Historian Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Historian GetHistorianByAcronym(DataConnection connection, string acronym)
        {
            try
            {
                List<Historian> historianList = new List<Historian>();
                historianList = (from item in GetHistorianList(connection, string.Empty)
                                 where item.Acronym.ToUpper() == acronym.ToUpper()
                                 select item).ToList();
                if (historianList.Count > 0)
                    return historianList[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetDeviceByAcronym", ex);
                return null;
            }
        }

        #endregion

        #region " Manage Nodes Code"

        public static List<Node> GetNodeList(DataConnection connection, bool enabledOnly)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<Node> nodeList = new List<Node>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (enabledOnly)
                {
                    command.CommandText = "Select * From NodeDetail Where Enabled = @enabled Order By LoadOrder";
                    command.Parameters.Add(AddWithValue(command, "@enabled", true));
                }
                else
                    command.CommandText = "Select * From NodeDetail Order By LoadOrder";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                nodeList = (from item in resultTable.AsEnumerable()
                            select new Node()
                            {
                                ID = item.Field<object>("ID").ToString(),
                                Name = item.Field<string>("Name"),
                                CompanyID = item.NullableInt("CompanyID"),
                                Longitude = item.NullableDecimal("Longitude"),
                                Latitude = item.NullableDecimal("Latitude"),
                                Description = item.Field<string>("Description"),
                                Image = item.Field<string>("ImagePath"),
                                Master = Convert.ToBoolean(item.Field<object>("Master")),
                                LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                TimeSeriesDataServiceUrl = item.Field<string>("TimeSeriesDataServiceUrl"),
                                RemoteStatusServiceUrl = item.Field<string>("RemoteStatusServiceUrl"),
                                RealTimeStatisticServiceUrl = item.Field<string>("RealTimeStatisticServiceUrl"),
                                CompanyName = item.Field<string>("CompanyName")
                            }).ToList();
                return nodeList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static decimal? NullableDecimal(this DataRow row, string field)
        {
            object value = row.Field<object>(field);
            return (value == null) ? (decimal?)null : Convert.ToDecimal(value);
        }

        public static int? NullableInt(this DataRow row, string field)
        {
            object value = row.Field<object>(field);
            return (value == null) ? (int?)null : Convert.ToInt32(value);
        }

        public static Dictionary<string, string> GetNodes(DataConnection connection, bool enabledOnly, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                Dictionary<string, string> nodeList = new Dictionary<string, string>();
                if (isOptional)
                    nodeList.Add(string.Empty, "Select Node");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (enabledOnly)
                {
                    command.CommandText = "Select ID, Name From Node Where Enabled = @enabled Order By LoadOrder";
                    command.Parameters.Add(AddWithValue(command, "@enabled", true));
                }
                else
                    command.CommandText = "Select ID, Name From Node Order By LoadOrder";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!nodeList.ContainsKey(row["ID"].ToString()))
                        nodeList.Add(row["ID"].ToString(), row["Name"].ToString());
                }
                return nodeList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveNode(DataConnection connection, Node node, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into Node (Name, CompanyID, Longitude, Latitude, Description, ImagePath, Master, LoadOrder, Enabled, TimeSeriesDataServiceUrl, RemoteStatusServiceUrl, RealTimeStatisticServiceUrl, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@name, @companyID, @longitude, @latitude, @description, @image, @master, @loadOrder, @enabled, @timeSeriesDataServiceUrl, @remoteStatusServiceUrl, @realTimeStatisticServiceUrl, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update Node Set Name = @name, CompanyID = @companyID, Longitude = @longitude, Latitude = @latitude, Description = @description, ImagePath = @image, " +
                        "Master = @master, LoadOrder = @loadOrder, Enabled = @enabled, TimeSeriesDataServiceUrl = @timeSeriesDataServiceUrl, RemoteStatusServiceUrl = @remoteStatusServiceUrl, " +
                        "RealTimeStatisticServiceUrl = @realTimeStatisticServiceUrl, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@name", node.Name));
                command.Parameters.Add(AddWithValue(command, "@companyID", node.CompanyID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@longitude", node.Longitude ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@latitude", node.Latitude ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@description", node.Description));
                command.Parameters.Add(AddWithValue(command, "@image", node.Image));
                command.Parameters.Add(AddWithValue(command, "@master", node.Master));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", node.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", node.Enabled));
                command.Parameters.Add(AddWithValue(command, "@timeSeriesDataServiceUrl", node.TimeSeriesDataServiceUrl));
                command.Parameters.Add(AddWithValue(command, "@remoteStatusServiceUrl", node.RemoteStatusServiceUrl));
                command.Parameters.Add(AddWithValue(command, "@realTimeStatisticServiceUrl", node.RealTimeStatisticServiceUrl));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {

                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@id", "{" + node.ID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@id", node.ID));
                }

                command.ExecuteNonQuery();
                return "Node Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Node GetNodeByName(DataConnection connection, string name)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From NodeDetail WHERE Name = @name";
                command.Parameters.Add(AddWithValue(command, "@name", name));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                if (resultTable.Rows.Count == 0)
                    return null;

                Node node = (from item in resultTable.AsEnumerable()
                             select new Node()
                             {
                                 ID = item.Field<object>("ID").ToString(),
                                 Name = item.Field<string>("Name"),
                                 CompanyID = item.NullableInt("CompanyID"),
                                 Longitude = item.NullableDecimal("Longitude"),
                                 Latitude = item.NullableDecimal("Latitude"),
                                 Description = item.Field<string>("Description"),
                                 Image = item.Field<string>("ImagePath"),
                                 Master = Convert.ToBoolean(item.Field<object>("Master")),
                                 LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                 Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                 TimeSeriesDataServiceUrl = item.Field<string>("TimeSeriesDataServiceUrl"),
                                 RemoteStatusServiceUrl = item.Field<string>("RemoteStatusServiceUrl"),
                                 RealTimeStatisticServiceUrl = item.Field<string>("RealTimeStatisticServiceUrl"),
                                 CompanyName = item.Field<string>("CompanyName")
                             }).First();
                return node;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetNodeByName", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Node GetNodeByID(DataConnection connection, string id)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From NodeDetail WHERE ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", id));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                if (resultTable.Rows.Count == 0)
                    return null;

                Node node = (from item in resultTable.AsEnumerable()
                             select new Node()
                             {
                                 ID = item.Field<object>("ID").ToString(),
                                 Name = item.Field<string>("Name"),
                                 CompanyID = item.NullableInt("CompanyID"),
                                 Longitude = item.NullableDecimal("Longitude"),
                                 Latitude = item.NullableDecimal("Latitude"),
                                 Description = item.Field<string>("Description"),
                                 Image = item.Field<string>("ImagePath"),
                                 Master = Convert.ToBoolean(item.Field<object>("Master")),
                                 LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                 Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                 TimeSeriesDataServiceUrl = item.Field<string>("TimeSeriesDataServiceUrl"),
                                 RemoteStatusServiceUrl = item.Field<string>("RemoteStatusServiceUrl"),
                                 RealTimeStatisticServiceUrl = item.Field<string>("RealTimeStatisticServiceUrl"),
                                 CompanyName = item.Field<string>("CompanyName")
                             }).First();
                return node;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetNodeByID", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Vendors Code"

        public static List<Vendor> GetVendorList(DataConnection connection)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<Vendor> vendorList = new List<Vendor>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * FROM VendorDetail Order By Name";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                vendorList = (from item in resultTable.AsEnumerable()
                              select new Vendor()
                              {
                                  ID = Convert.ToInt32(item.Field<object>("ID")),
                                  Acronym = item.Field<string>("Acronym"),
                                  Name = item.Field<string>("Name"),
                                  PhoneNumber = item.Field<string>("PhoneNumber"),
                                  ContactEmail = item.Field<string>("ContactEmail"),
                                  URL = item.Field<string>("URL")
                              }).ToList();
                return vendorList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetVendors(DataConnection connection, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> vendorList = new Dictionary<int, string>();
                if (isOptional)
                    vendorList.Add(0, "Select Vendor");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Name From Vendor Order By Name";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!vendorList.ContainsKey(Convert.ToInt32(row["ID"])))
                        vendorList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
                }
                return vendorList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveVendor(DataConnection connection, Vendor vendor, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (isNew)
                    command.CommandText = "Insert Into Vendor (Acronym, Name, PhoneNumber, ContactEmail, URL, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values (@acronym, @name, @phoneNumber, @contactEmail, @url, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update Vendor Set Acronym = @acronym, Name = @name, PhoneNumber = @phoneNumber, ContactEmail = @contactEmail, URL = @url, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@acronym", vendor.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", vendor.Name));
                command.Parameters.Add(AddWithValue(command, "@phoneNumber", vendor.PhoneNumber));
                command.Parameters.Add(AddWithValue(command, "@contactEmail", vendor.ContactEmail));
                command.Parameters.Add(AddWithValue(command, "@url", vendor.URL));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", vendor.ID));

                command.ExecuteNonQuery();
                return "Vendor Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Vendor Devices Code"

        public static List<VendorDevice> GetVendorDeviceList(DataConnection connection)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<VendorDevice> vendorDeviceList = new List<VendorDevice>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From VendorDeviceDetail Order By Name";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                vendorDeviceList = (from item in resultTable.AsEnumerable()
                                    select new VendorDevice()
                                    {
                                        ID = Convert.ToInt32(item.Field<object>("ID")),
                                        VendorID = Convert.ToInt32(item.Field<object>("VendorID")),
                                        Name = item.Field<string>("Name"),
                                        Description = item.Field<string>("Description"),
                                        URL = item.Field<string>("URL"),
                                        VendorName = item.Field<string>("VendorName")
                                    }).ToList();
                return vendorDeviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveVendorDevice(DataConnection connection, VendorDevice vendorDevice, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (isNew)
                    command.CommandText = "Insert Into VendorDevice (VendorID, Name, Description, URL, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values (@vendorID, @name, @description, @url, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update VendorDevice Set VendorID = @vendorID, Name = @name, Description = @description, URL = @url, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@vendorID", vendorDevice.VendorID));
                command.Parameters.Add(AddWithValue(command, "@name", vendorDevice.Name));
                command.Parameters.Add(AddWithValue(command, "@description", vendorDevice.Description));
                command.Parameters.Add(AddWithValue(command, "@url", vendorDevice.URL));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", vendorDevice.ID));

                command.ExecuteNonQuery();

                return "Vendor Device Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetVendorDevices(DataConnection connection, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> vendorDeviceList = new Dictionary<int, string>();
                if (isOptional)
                    vendorDeviceList.Add(0, "Select Vendor Device");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Name From VendorDevice Order By Name";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!vendorDeviceList.ContainsKey(Convert.ToInt32(row["ID"])))
                        vendorDeviceList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
                }
                return vendorDeviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Device Code"

        public static List<Device> GetDeviceList(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                List<Device> deviceList = new List<Device>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select * From DeviceDetail Order By Acronym";
                else
                {
                    command.CommandText = "Select * From DeviceDetail Where NodeID = @nodeID Order By Acronym";
                    //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                deviceList = (from item in resultTable.AsEnumerable()
                              select new Device()
                              {
                                  NodeID = item.Field<object>("NodeID").ToString(),
                                  ID = Convert.ToInt32(item.Field<object>("ID")),
                                  ParentID = item.NullableInt("ParentID"),
                                  Acronym = item.Field<string>("Acronym"),
                                  Name = item.Field<string>("Name"),
                                  IsConcentrator = Convert.ToBoolean(item.Field<object>("IsConcentrator")),
                                  CompanyID = item.NullableInt("CompanyID"),
                                  HistorianID = item.NullableInt("HistorianID"),
                                  AccessID = Convert.ToInt32(item.Field<object>("AccessID")),
                                  VendorDeviceID = item.NullableInt("VendorDeviceID"),
                                  ProtocolID = item.NullableInt("ProtocolID"),
                                  Longitude = item.NullableDecimal("Longitude"),
                                  Latitude = item.NullableDecimal("Latitude"),
                                  InterconnectionID = item.NullableInt("InterconnectionID"),
                                  ConnectionString = item.Field<string>("ConnectionString"),
                                  TimeZone = item.Field<string>("TimeZone"),
                                  FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                  TimeAdjustmentTicks = Convert.ToInt64(item.Field<object>("TimeAdjustmentTicks")),
                                  DataLossInterval = item.Field<double>("DataLossInterval"),
                                  ContactList = item.Field<string>("ContactList"),
                                  MeasuredLines = item.NullableInt("MeasuredLines"),
                                  LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                  Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                  CreatedOn = item.Field<DateTime>("CreatedOn"),
                                  AllowedParsingExceptions = Convert.ToInt32(item.Field<object>("AllowedParsingExceptions")),
                                  ParsingExceptionWindow = item.Field<double>("ParsingExceptionWindow"),
                                  DelayedConnectionInterval = item.Field<double>("DelayedConnectionInterval"),
                                  AllowUseOfCachedConfiguration = Convert.ToBoolean(item.Field<object>("AllowUseOfCachedConfiguration")),
                                  AutoStartDataParsingSequence = Convert.ToBoolean(item.Field<object>("AutoStartDataParsingSequence")),
                                  SkipDisableRealTimeData = Convert.ToBoolean(item.Field<object>("SkipDisableRealTimeData")),
                                  MeasurementReportingInterval = Convert.ToInt32(item.Field<object>("MeasurementReportingInterval")),
                                  CompanyName = item.Field<string>("CompanyName"),
                                  CompanyAcronym = item.Field<string>("CompanyAcronym"),
                                  HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                  VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                  VendorAcronym = item.Field<string>("VendorAcronym"),
                                  ProtocolName = item.Field<string>("ProtocolName"),
                                  InterconnectionName = item.Field<string>("InterconnectionName"),
                                  NodeName = item.Field<string>("NodeName"),
                                  ParentAcronym = item.Field<string>("ParentAcronym")
                              }).ToList();
                return deviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static List<Device> GetDeviceListByParentID(DataConnection connection, int parentID)
        {
            List<Device> deviceList = new List<Device>();
            try
            {
                deviceList = (from item in GetDeviceList(connection, string.Empty)
                              where item.ParentID == parentID
                              select item).ToList();
            }
            catch (Exception ex)
            {
                LogException(connection, "GetDeviceListByParentID", ex);
            }
            return deviceList;
        }

        static DataTable s_pmuSignalTypes;
        public static string SaveDevice(DataConnection connection, Device device, bool isNew, int digitalCount, int analogCount)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();

                if (isNew)
                    command.CommandText = "Insert Into Device (NodeID, ParentID, Acronym, Name, IsConcentrator, CompanyID, HistorianID, AccessID, VendorDeviceID, ProtocolID, Longitude, Latitude, InterconnectionID, ConnectionString, TimeZone, FramesPerSecond, TimeAdjustmentTicks, " +
                        "DataLossInterval, ContactList, MeasuredLines, LoadOrder, Enabled, AllowedParsingExceptions, ParsingExceptionWindow, DelayedConnectionInterval, AllowUseOfCachedConfiguration, AutoStartDataParsingSequence, SkipDisableRealTimeData, MeasurementReportingInterval, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@nodeID, @parentID, @acronym, @name, @isConcentrator, @companyID, @historianID, @accessID, @vendorDeviceID, @protocolID, @longitude, @latitude, @interconnectionID, " +
                        "@connectionString, @timezone, @framesPerSecond, @timeAdjustmentTicks, @dataLossInterval, @contactList, @measuredLines, @loadOrder, @enabled, @allowedParsingExceptions, " +
                        "@parsingExceptionWindow, @delayedConnectionInterval, @allowUseOfCachedConfiguration, @autoStartDataParsingSequence, @skipDisableRealTimeData, @measurementReportingInterval, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update Device Set NodeID = @nodeID, ParentID = @parentID, Acronym = @acronym, Name = @name, IsConcentrator = @isConcentrator, CompanyID = @companyID, HistorianID = @historianID, AccessID = @accessID, VendorDeviceID = @vendorDeviceID, " +
                        "ProtocolID = @protocolID, Longitude = @longitude, Latitude = @latitude, InterconnectionID = @interconnectionID, ConnectionString = @connectionString, TimeZone = @timezone, FramesPerSecond = @framesPerSecond, TimeAdjustmentTicks = @timeAdjustmentTicks, DataLossInterval = @dataLossInterval, " +
                        "ContactList = @contactList, MeasuredLines = @measuredLines, LoadOrder = @loadOrder, Enabled = @enabled, AllowedParsingExceptions = @allowedParsingExceptions, ParsingExceptionWindow = @parsingExceptionWindow, DelayedConnectionInterval = @delayedConnectionInterval, " +
                        "AllowUseOfCachedConfiguration = @allowUseOfCachedConfiguration, AutoStartDataParsingSequence = @autoStartDataParsingSequence, SkipDisableRealTimeData = @skipDisableRealTimeData, MeasurementReportingInterval = @measurementReportingInterval, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn WHERE ID = @id";

                command.CommandType = CommandType.Text;
                command.Parameters.Add(AddWithValue(command, "@nodeID", device.NodeID));
                command.Parameters.Add(AddWithValue(command, "@parentID", device.ParentID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@acronym", device.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", device.Name));
                command.Parameters.Add(AddWithValue(command, "@isConcentrator", device.IsConcentrator));
                command.Parameters.Add(AddWithValue(command, "@companyID", device.CompanyID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@historianID", device.HistorianID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@accessID", device.AccessID));
                command.Parameters.Add(AddWithValue(command, "@vendorDeviceID", device.VendorDeviceID == null ? (object)DBNull.Value : device.VendorDeviceID == 0 ? (object)DBNull.Value : device.VendorDeviceID));
                command.Parameters.Add(AddWithValue(command, "@protocolID", device.ProtocolID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@longitude", device.Longitude ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@latitude", device.Latitude ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@interconnectionID", device.InterconnectionID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@connectionString", device.ConnectionString));
                command.Parameters.Add(AddWithValue(command, "@timezone", device.TimeZone));
                command.Parameters.Add(AddWithValue(command, "@framesPerSecond", device.FramesPerSecond ?? 30));
                command.Parameters.Add(AddWithValue(command, "@timeAdjustmentTicks", device.TimeAdjustmentTicks));
                command.Parameters.Add(AddWithValue(command, "@dataLossInterval", device.DataLossInterval));
                command.Parameters.Add(AddWithValue(command, "@contactList", device.ContactList));
                command.Parameters.Add(AddWithValue(command, "@measuredLines", device.MeasuredLines ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", device.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", device.Enabled));
                command.Parameters.Add(AddWithValue(command, "@allowedParsingExceptions", device.AllowedParsingExceptions));
                command.Parameters.Add(AddWithValue(command, "@parsingExceptionWindow", device.ParsingExceptionWindow));
                command.Parameters.Add(AddWithValue(command, "@delayedConnectionInterval", device.DelayedConnectionInterval));
                command.Parameters.Add(AddWithValue(command, "@allowUseOfCachedConfiguration", device.AllowUseOfCachedConfiguration));
                command.Parameters.Add(AddWithValue(command, "@autoStartDataParsingSequence", device.AutoStartDataParsingSequence));
                command.Parameters.Add(AddWithValue(command, "@skipDisableRealTimeData", device.SkipDisableRealTimeData));
                command.Parameters.Add(AddWithValue(command, "@measurementReportingInterval", device.MeasurementReportingInterval));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", device.ID));

                command.ExecuteNonQuery();

                if (device.IsConcentrator)
                    return "Concentrator Device Information Saved Successfully";		//As we do not add measurements for PDC device or device which is concentrator.

                //DataTable pmuSignalTypes = new DataTable();
                if (s_pmuSignalTypes == null || s_pmuSignalTypes.Rows.Count == 0)
                    s_pmuSignalTypes = GetPmuSignalTypes(connection);

                Measurement measurement;

                Device addedDevice = new Device();
                addedDevice = GetDeviceByAcronym(connection, device.Acronym);

                //We will try again in a while if addedDevice is NULL. This is done because MS Access is very slow and was returning NULL.
                if (addedDevice == null)
                {
                    System.Threading.Thread.Sleep(500);
                    addedDevice = GetDeviceByAcronym(connection, device.Acronym);
                }

                foreach (DataRow row in s_pmuSignalTypes.Rows)	//This will only create or update PMU related measurements and not phasor related.
                {
                    measurement = new Measurement();
                    measurement.HistorianID = addedDevice.HistorianID;
                    measurement.DeviceID = addedDevice.ID;
                    measurement.PointTag = addedDevice.CompanyAcronym + "_" + addedDevice.Acronym + ":" + addedDevice.VendorAcronym + row["Abbreviation"].ToString();
                    measurement.AlternateTag = string.Empty;
                    measurement.SignalTypeID = Convert.ToInt32(row["ID"]);
                    measurement.PhasorSourceIndex = (int?)null;
                    measurement.SignalReference = addedDevice.Acronym + "-" + row["Suffix"].ToString();
                    measurement.Adder = 0.0d;
                    measurement.Multiplier = 1.0d;
                    measurement.Description = addedDevice.Name + " " + addedDevice.VendorDeviceName + " " + row["Name"].ToString();
                    measurement.Enabled = true;
                    if (isNew)	//if it is a new device then measurements are new too. So don't worry about updating them.
                        SaveMeasurement(connection, measurement, true);
                    else	//if device is existing one, then check and see if its measusremnts exist, if so then update measurements.
                    {
                        Measurement existingMeasurement = new Measurement();
                        existingMeasurement = GetMeasurementInfo(connection, measurement.DeviceID, row["Suffix"].ToString(), measurement.PhasorSourceIndex);

                        if (existingMeasurement == null)	//measurement does not exist for this device and signal type then add as a new measurement otherwise update.
                            SaveMeasurement(connection, measurement, true);
                        else
                        {
                            measurement.SignalID = existingMeasurement.SignalID;
                            SaveMeasurement(connection, measurement, false);
                        }
                    }
                }

                if (digitalCount > 0)
                {
                    for (int i = 1; i <= digitalCount; i++)
                    {
                        measurement = new Measurement();
                        measurement.HistorianID = addedDevice.HistorianID;
                        measurement.DeviceID = addedDevice.ID;
                        measurement.PointTag = addedDevice.CompanyAcronym + "_" + addedDevice.Acronym + ":" + addedDevice.VendorAcronym + "D" + i.ToString();
                        measurement.AlternateTag = string.Empty;
                        measurement.SignalTypeID = GetSignalTypeID(connection, "DV");
                        measurement.PhasorSourceIndex = (int?)null;
                        measurement.SignalReference = addedDevice.Acronym + "-DV" + i.ToString();
                        measurement.Adder = 0.0d;
                        measurement.Multiplier = 1.0d;
                        measurement.Description = addedDevice.Name + " " + addedDevice.VendorDeviceName + " Digital Value " + i.ToString();
                        measurement.Enabled = true;
                        if (isNew)	//if it is a new device then measurements are new too. So don't worry about updating them.
                            SaveMeasurement(connection, measurement, true);
                        else	//if device is existing one, then check and see if its measusremnts exist, if so then update measurements.
                        {
                            Measurement existingMeasurement = new Measurement();
                            //we will compare using signal reference as signal suffix doesn't provide uniqueness.
                            existingMeasurement = GetMeasurementInfoBySignalReference(connection, measurement.DeviceID, measurement.SignalReference, measurement.PhasorSourceIndex);

                            if (existingMeasurement == null)	//measurement does not exist for this device and signal type then add as a new measurement otherwise update.
                                SaveMeasurement(connection, measurement, true);
                            else
                            {
                                measurement.SignalID = existingMeasurement.SignalID;
                                SaveMeasurement(connection, measurement, false);
                            }
                        }
                    }
                }

                if (analogCount > 0)
                {
                    for (int i = 1; i <= analogCount; i++)
                    {
                        measurement = new Measurement();
                        measurement.HistorianID = addedDevice.HistorianID;
                        measurement.DeviceID = addedDevice.ID;
                        measurement.PointTag = addedDevice.CompanyAcronym + "_" + addedDevice.Acronym + ":" + addedDevice.VendorAcronym + "A" + i.ToString();
                        measurement.AlternateTag = string.Empty;
                        measurement.SignalTypeID = GetSignalTypeID(connection, "AV");
                        measurement.PhasorSourceIndex = (int?)null;
                        measurement.SignalReference = addedDevice.Acronym + "-AV" + i.ToString();
                        measurement.Adder = 0.0d;
                        measurement.Multiplier = 1.0d;
                        measurement.Description = addedDevice.Name + " " + addedDevice.VendorDeviceName + " Analog Value " + i.ToString();
                        measurement.Enabled = true;
                        if (isNew)	//if it is a new device then measurements are new too. So don't worry about updating them.
                            SaveMeasurement(connection, measurement, true);
                        else	//if device is existing one, then check and see if its measusremnts exist, if so then update measurements.
                        {
                            Measurement existingMeasurement = new Measurement();
                            existingMeasurement = GetMeasurementInfoBySignalReference(connection, measurement.DeviceID, measurement.SignalReference, measurement.PhasorSourceIndex);

                            if (existingMeasurement == null)	//measurement does not exist for this device and signal type then add as a new measurement otherwise update.
                                SaveMeasurement(connection, measurement, true);
                            else
                            {
                                measurement.SignalID = existingMeasurement.SignalID;
                                SaveMeasurement(connection, measurement, false);
                            }
                        }
                    }
                }

                if (!isNew)
                {
                    //After all the PMU related measurements are updated then lets go through each phasors for the PMU
                    //and update all the phasors and their measurements to reflect changes made to the PMU configuration.
                    //We are not going to make any changes to the Phasor definition itselft but only to reflect PMU related
                    //changes in the measurement.

                    foreach (Phasor phasor in GetPhasorList(connection, addedDevice.ID))
                    {
                        SavePhasor(connection, phasor, false);	//we will save phasor without modifying it so that only measurements will reflect changes related to PMU.
                        //nothing will change in phasor itself.
                    }
                }

                return "Device Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetDevices(DataConnection connection, DeviceType deviceType, string nodeID, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> deviceList = new Dictionary<int, string>();
                if (!string.IsNullOrEmpty(nodeID))
                {
                    //throw new ArgumentException("Invalid value of NodeID.");

                    if (isOptional)
                        deviceList.Add(0, "Select Device");

                    IDbCommand command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    if (deviceType == DeviceType.Concentrator)
                    {
                        command.CommandText = "Select ID, Acronym From Device Where IsConcentrator = @isConcentrator AND NodeID = @nodeID Order By LoadOrder";
                        command.Parameters.Add(AddWithValue(command, "@isConcentrator", true));
                    }
                    else if (deviceType == DeviceType.NonConcentrator)
                    {
                        command.CommandText = "Select ID, Acronym From Device Where IsConcentrator = @isConcentrator AND NodeID = @nodeID Order By LoadOrder";
                        command.Parameters.Add(AddWithValue(command, "@isConcentrator", false));
                    }
                    else
                        command.CommandText = "Select ID, Acronym From Device Where NodeID = @nodeID Order By LoadOrder";


                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));

                    DataTable resultTable = new DataTable();
                    resultTable.Load(command.ExecuteReader());

                    foreach (DataRow row in resultTable.Rows)
                    {
                        if (!deviceList.ContainsKey(Convert.ToInt32(row["ID"])))
                            deviceList.Add(Convert.ToInt32(row["ID"]), row["Acronym"].ToString());
                    }
                }
                return deviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Device GetDeviceByDeviceID(DataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            //            DataConnection connection = new DataConnection();
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From DeviceDetail Where ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", deviceID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                if (resultTable.Rows.Count == 0)
                    return null;

                Device device = (Device)(from item in resultTable.AsEnumerable()
                                         select new Device()
                                         {
                                             NodeID = item.Field<object>("NodeID").ToString(),
                                             ID = Convert.ToInt32(item.Field<object>("ID")),
                                             ParentID = item.NullableInt("ParentID"),
                                             Acronym = item.Field<string>("Acronym"),
                                             Name = item.Field<string>("Name"),
                                             IsConcentrator = Convert.ToBoolean(item.Field<object>("IsConcentrator")),
                                             CompanyID = item.NullableInt("CompanyID"),
                                             HistorianID = item.NullableInt("HistorianID"),
                                             AccessID = Convert.ToInt32(item.Field<object>("AccessID")),
                                             VendorDeviceID = item.NullableInt("VendorDeviceID"),
                                             ProtocolID = item.NullableInt("ProtocolID"),
                                             Longitude = item.NullableDecimal("Longitude"),
                                             Latitude = item.NullableDecimal("Latitude"),
                                             InterconnectionID = item.NullableInt("InterconnectionID"),
                                             ConnectionString = item.Field<string>("ConnectionString"),
                                             TimeZone = item.Field<string>("TimeZone"),
                                             FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                             TimeAdjustmentTicks = Convert.ToInt64(item.Field<object>("TimeAdjustmentTicks")),
                                             DataLossInterval = item.Field<double>("DataLossInterval"),
                                             ContactList = item.Field<string>("ContactList"),
                                             MeasuredLines = item.NullableInt("MeasuredLines"),
                                             LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                             Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                             CreatedOn = item.Field<DateTime>("CreatedOn"),
                                             AllowedParsingExceptions = Convert.ToInt32(item.Field<object>("AllowedParsingExceptions")),
                                             ParsingExceptionWindow = item.Field<double>("ParsingExceptionWindow"),
                                             DelayedConnectionInterval = item.Field<double>("DelayedConnectionInterval"),
                                             AllowUseOfCachedConfiguration = Convert.ToBoolean(item.Field<object>("AllowUseOfCachedConfiguration")),
                                             AutoStartDataParsingSequence = Convert.ToBoolean(item.Field<object>("AutoStartDataParsingSequence")),
                                             SkipDisableRealTimeData = Convert.ToBoolean(item.Field<object>("SkipDisableRealTimeData")),
                                             MeasurementReportingInterval = Convert.ToInt32(item.Field<object>("MeasurementReportingInterval")),
                                             CompanyName = item.Field<string>("CompanyName"),
                                             CompanyAcronym = item.Field<string>("CompanyAcronym"),
                                             HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                             VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                             VendorAcronym = item.Field<string>("VendorAcronym"),
                                             ProtocolName = item.Field<string>("ProtocolName"),
                                             InterconnectionName = item.Field<string>("InterconnectionName"),
                                             NodeName = item.Field<string>("NodeName"),
                                             ParentAcronym = item.Field<string>("ParentAcronym")
                                         }).First();
                return device;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetDeviceByDeviceID", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            //try
            //{
            //    List<Device> deviceList = new List<Device>();
            //    deviceList = (from item in GetDeviceList(connection, string.Empty)
            //                  where item.ID == deviceID
            //                  select item).ToList();
            //    if (deviceList.Count > 0)
            //        return deviceList[0];
            //    else
            //        return null;
            //}
            //catch (Exception ex)
            //{
            //    LogException(connection, "GetDeviceByDeviceID", ex);
            //    return null;
            //}
        }

        public static Device GetDeviceByAcronym(DataConnection connection, string acronym)
        {
            bool createdConnection = false;
            //            DataConnection connection = new DataConnection();
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From DeviceDetail Where Acronym = @acronym";
                command.Parameters.Add(AddWithValue(command, "@acronym", acronym.ToUpper()));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                if (resultTable.Rows.Count == 0)
                    return null;

                Device device = (Device)(from item in resultTable.AsEnumerable()
                                         select new Device()
                                         {
                                             NodeID = item.Field<object>("NodeID").ToString(),
                                             ID = Convert.ToInt32(item.Field<object>("ID")),
                                             ParentID = item.NullableInt("ParentID"),
                                             Acronym = item.Field<string>("Acronym"),
                                             Name = item.Field<string>("Name"),
                                             IsConcentrator = Convert.ToBoolean(item.Field<object>("IsConcentrator")),
                                             CompanyID = item.NullableInt("CompanyID"),
                                             HistorianID = item.NullableInt("HistorianID"),
                                             AccessID = Convert.ToInt32(item.Field<object>("AccessID")),
                                             VendorDeviceID = item.NullableInt("VendorDeviceID"),
                                             ProtocolID = item.NullableInt("ProtocolID"),
                                             Longitude = item.NullableDecimal("Longitude"),
                                             Latitude = item.NullableDecimal("Latitude"),
                                             InterconnectionID = item.NullableInt("InterconnectionID"),
                                             ConnectionString = item.Field<string>("ConnectionString"),
                                             TimeZone = item.Field<string>("TimeZone"),
                                             FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                             TimeAdjustmentTicks = Convert.ToInt64(item.Field<object>("TimeAdjustmentTicks")),
                                             DataLossInterval = item.Field<double>("DataLossInterval"),
                                             ContactList = item.Field<string>("ContactList"),
                                             MeasuredLines = item.NullableInt("MeasuredLines"),
                                             LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                             Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                             CreatedOn = item.Field<DateTime>("CreatedOn"),
                                             AllowedParsingExceptions = Convert.ToInt32(item.Field<object>("AllowedParsingExceptions")),
                                             ParsingExceptionWindow = item.Field<double>("ParsingExceptionWindow"),
                                             DelayedConnectionInterval = item.Field<double>("DelayedConnectionInterval"),
                                             AllowUseOfCachedConfiguration = Convert.ToBoolean(item.Field<object>("AllowUseOfCachedConfiguration")),
                                             AutoStartDataParsingSequence = Convert.ToBoolean(item.Field<object>("AutoStartDataParsingSequence")),
                                             SkipDisableRealTimeData = Convert.ToBoolean(item.Field<object>("SkipDisableRealTimeData")),
                                             MeasurementReportingInterval = Convert.ToInt32(item.Field<object>("MeasurementReportingInterval")),
                                             CompanyName = item.Field<string>("CompanyName"),
                                             CompanyAcronym = item.Field<string>("CompanyAcronym"),
                                             HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                             VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                             VendorAcronym = item.Field<string>("VendorAcronym"),
                                             ProtocolName = item.Field<string>("ProtocolName"),
                                             InterconnectionName = item.Field<string>("InterconnectionName"),
                                             NodeName = item.Field<string>("NodeName"),
                                             ParentAcronym = item.Field<string>("ParentAcronym")
                                         }).First();
                return device;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetDeviceByAcronym", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetDevicesForOutputStream(DataConnection connection, int outputStreamID, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> deviceList = new Dictionary<int, string>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Acronym From Device Where NodeID = @nodeID AND IsConcentrator = @isConcentrator AND Acronym NOT IN (Select Acronym From OutputStreamDevice Where AdapterID = @adapterID)";
                command.Parameters.Add(AddWithValue(command, "@adapterID", outputStreamID));	//this has to be the first paramter for MS Access to succeed because it evaluates subquery first.
                //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                command.Parameters.Add(AddWithValue(command, "@isConcentrator", false));
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!deviceList.ContainsKey(Convert.ToInt32(row["ID"])))
                        deviceList.Add(Convert.ToInt32(row["ID"]), row["Acronym"].ToString());
                }
                return deviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Device GetConcentratorDevice(DataConnection connection, int deviceID)
        {
            try
            {
                Device device = new Device();
                device = GetDeviceByDeviceID(connection, deviceID);
                if (device.IsConcentrator)
                    return device;
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetConcentratorDevice", ex);
                return null;
            }
        }

        public static string DeleteDevice(DataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command;
                Device device = GetDeviceByDeviceID(connection, deviceID);
                string deviceAcronym = device.Acronym;
                command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From Device Where ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", deviceID));
                command.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(deviceAcronym))
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    //we will delete device from output stream if a device is in the same node.
                    command.CommandText = "Delete From OutputStreamDevice Where Acronym = @acronym AND NodeID = @nodeID";
                    command.Parameters.Add(AddWithValue(command, "@acronym", deviceAcronym));
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + device.NodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", device.NodeID));
                    command.ExecuteNonQuery();
                }

                //command = connection.Connection.CreateCommand();
                //command.CommandText = "SELECT UserName From AuditLog";
                //return command.ExecuteScalar().ToString().RemoveNull().Trim();

                return "Device Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string UpdateDeviceStatistics(DataConnection connection, int deviceID, string oldAcronym, string newAcronym, string oldDeviceName, string newDeviceName)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                ////If device is updated then make sure all the statistical measurements get updated too to reflect any change in acronym.
                if (!string.IsNullOrEmpty(oldAcronym) && oldAcronym != newAcronym)
                {
                    List<Measurement> measurementList = GetMeasurementsByDevice(connection, deviceID);
                    foreach (Measurement measurement in measurementList)
                    {
                        //if (measurement.SignalAcronym == "STAT")
                        //{
                        if (measurement.SignalReference.StartsWith(oldAcronym + "!") || measurement.SignalReference.StartsWith(oldAcronym + "-"))
                        {
                            measurement.SignalReference = measurement.SignalReference.Replace(oldAcronym, newAcronym);
                            measurement.PointTag = measurement.PointTag.Replace(oldAcronym, newAcronym);
                            measurement.Description = System.Text.RegularExpressions.Regex.Replace(measurement.Description, oldDeviceName, newDeviceName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);      //measurement.Description.Replace(oldAcronym, newAcronym);
                            SaveMeasurement(connection, measurement, false);
                        }
                        //}
                    }
                }

                return "";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Phasor Code"

        public static List<Phasor> GetPhasorList(DataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Phasor> phasorList = new List<Phasor>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From PhasorDetail Where DeviceID = @deviceID Order By SourceIndex";
                command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));

                phasorList = (from item in GetResultSet(command).Tables[0].AsEnumerable()
                              select new Phasor()
                              {
                                  ID = Convert.ToInt32(item.Field<object>("ID")),
                                  DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                  Label = item.Field<string>("Label"),
                                  Type = item.Field<string>("Type"),
                                  Phase = item.Field<string>("Phase"),
                                  DestinationPhasorID = item.NullableInt("DestinationPhasorID"),
                                  SourceIndex = Convert.ToInt32(item.Field<object>("SourceIndex")),
                                  DestinationPhasorLabel = item.Field<string>("DestinationPhasorLabel"),
                                  DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                  PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
                                  PhaseType = item.Field<string>("Phase") == "+" ? "Positive Sequence" : item.Field<string>("Phase") == "-" ? "Negative Sequence" :
                                    item.Field<string>("Phase") == "0" ? "Zero Sequence" : item.Field<string>("Phase") == "A" ? "Phase A" : item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
                              }).ToList();
                return phasorList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetPhasors(DataConnection connection, int deviceID, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> phasorList = new Dictionary<int, string>();
                if (isOptional)
                    phasorList.Add(0, "Select Phasor");
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Label From Phasor Where DeviceID = @deviceID Order By SourceIndex";
                command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!phasorList.ContainsKey(Convert.ToInt32(row["ID"])))
                        phasorList.Add(Convert.ToInt32(row["ID"]), row["Label"].ToString());
                }
                return phasorList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        static DataTable s_currentPhasorSignalTypes, s_voltagePhasorSignalTypes, s_phasorSignalTypes;
        public static string SavePhasor(DataConnection connection, Phasor phasor, bool isNew)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();

                if (isNew)
                    command.CommandText = "Insert Into Phasor (DeviceID, Label, Type, Phase, DestinationPhasorID, SourceIndex, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values (@deviceID, @label, @type, @phase, " +
                        "@destinationPhasorID, @sourceIndex, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update Phasor Set DeviceID =@deviceID, Label = @label, Type = @type, Phase = @phase, DestinationPhasorID = @destinationPhasorID, " +
                        "SourceIndex = @sourceIndex, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@deviceID", phasor.DeviceID));
                command.Parameters.Add(AddWithValue(command, "@label", phasor.Label));
                command.Parameters.Add(AddWithValue(command, "@type", phasor.Type));
                command.Parameters.Add(AddWithValue(command, "@phase", phasor.Phase));
                command.Parameters.Add(AddWithValue(command, "@destinationPhasorID", phasor.DestinationPhasorID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@sourceIndex", phasor.SourceIndex));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", phasor.ID));

                command.ExecuteNonQuery();

                Device device = new Device();
                device = GetDeviceByDeviceID(connection, phasor.DeviceID);

                Measurement measurement;


                if (s_voltagePhasorSignalTypes == null || s_voltagePhasorSignalTypes.Rows.Count == 0)
                    s_voltagePhasorSignalTypes = GetPhasorSignalTypes(connection, "V");

                if (s_currentPhasorSignalTypes == null || s_currentPhasorSignalTypes.Rows.Count == 0)
                    s_currentPhasorSignalTypes = GetPhasorSignalTypes(connection, "I");

                if (phasor.Type == "V")
                    s_phasorSignalTypes = s_voltagePhasorSignalTypes;
                else
                    s_phasorSignalTypes = s_currentPhasorSignalTypes;

                Phasor addedPhasor = new Phasor();
                //addedPhasor = GetPhasorByLabel(phasor.DeviceID, phasor.Label);
                addedPhasor = GetPhasorBySourceIndex(connection, phasor.DeviceID, phasor.SourceIndex);

                //we will try again just to make sure we get information back about the added phasor. As MS Access is very slow and sometimes fails to retrieve data.
                if (addedPhasor == null)
                {
                    System.Threading.Thread.Sleep(500);
                    //addedPhasor = GetPhasorByLabel(phasor.DeviceID, phasor.Label);
                    addedPhasor = GetPhasorBySourceIndex(connection, phasor.DeviceID, phasor.SourceIndex);
                }

                foreach (DataRow row in s_phasorSignalTypes.Rows)
                {
                    measurement = new Measurement();
                    measurement.HistorianID = device.HistorianID;
                    measurement.DeviceID = device.ID;
                    if (addedPhasor.DestinationPhasorID.HasValue)
                        measurement.PointTag = device.CompanyAcronym + "_" + device.Acronym + "-" + GetPhasorByID(connection, addedPhasor.DeviceID, (int)addedPhasor.DestinationPhasorID).Label + ":" + device.VendorAcronym + row["Abbreviation"].ToString();
                    else
                        measurement.PointTag = device.CompanyAcronym + "_" + device.Acronym + "-" + row["Suffix"].ToString() + addedPhasor.SourceIndex.ToString() + ":" + device.VendorAcronym + row["Abbreviation"].ToString();
                    measurement.AlternateTag = string.Empty;
                    measurement.SignalTypeID = Convert.ToInt32(row["ID"]);
                    measurement.PhasorSourceIndex = addedPhasor.SourceIndex;
                    measurement.SignalReference = device.Acronym + "-" + row["Suffix"].ToString() + addedPhasor.SourceIndex.ToString();
                    measurement.Adder = 0.0d;
                    measurement.Multiplier = 1.0d;
                    measurement.Description = device.Name + " " + addedPhasor.Label + " " + device.VendorDeviceName + " " + addedPhasor.PhaseType + " " + row["Name"].ToString();
                    measurement.Enabled = true;
                    if (isNew)	//if it is a new phasor then add measurements as new.
                        SaveMeasurement(connection, measurement, true);
                    else //Check if measurement exists, if so then update them otherwise add new.
                    {
                        Measurement existingMeasurement = new Measurement();
                        existingMeasurement = GetMeasurementInfo(connection, measurement.DeviceID, row["Suffix"].ToString(), measurement.PhasorSourceIndex);
                        if (existingMeasurement == null)
                            SaveMeasurement(connection, measurement, true);
                        else
                        {
                            measurement.SignalID = existingMeasurement.SignalID;
                            SaveMeasurement(connection, measurement, false);
                        }
                    }
                }

                return "Phasor Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        static Phasor GetPhasorByLabel(DataConnection connection, int deviceID, string label)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From PhasorDetail Where DeviceID = @deviceID and Label = @label";
                command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));
                command.Parameters.Add(AddWithValue(command, "@label", label));

                DataTable resultTable = GetResultSet(command).Tables[0];
                if (resultTable.Rows.Count == 0)
                    return null;

                Phasor phasor = (Phasor)(from item in resultTable.AsEnumerable()
                                         select new Phasor()
                                         {
                                             ID = Convert.ToInt32(item.Field<object>("ID")),
                                             DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                             Label = item.Field<string>("Label"),
                                             Type = item.Field<string>("Type"),
                                             Phase = item.Field<string>("Phase"),
                                             DestinationPhasorID = item.NullableInt("DestinationPhasorID"),
                                             SourceIndex = Convert.ToInt32(item.Field<object>("SourceIndex")),
                                             DestinationPhasorLabel = item.Field<string>("DestinationPhasorLabel"),
                                             DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                             PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
                                             PhaseType = item.Field<string>("Phase") == "+" ? "Positive Sequence" : item.Field<string>("Phase") == "-" ? "Negative Sequence" :
                                               item.Field<string>("Phase") == "0" ? "Zero Sequence" : item.Field<string>("Phase") == "A" ? "Phase A" : item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
                                         }).First();
                return phasor;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetPhasorByLabel", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        static Phasor GetPhasorByID(DataConnection connection, int deviceID, int phasorID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From PhasorDetail Where DeviceID = @deviceID and ID = @id";
                command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));
                command.Parameters.Add(AddWithValue(command, "@id", phasorID));

                DataTable resultTable = GetResultSet(command).Tables[0];
                if (resultTable.Rows.Count == 0)
                    return null;

                Phasor phasor = (Phasor)(from item in resultTable.AsEnumerable()
                                         select new Phasor()
                                         {
                                             ID = Convert.ToInt32(item.Field<object>("ID")),
                                             DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                             Label = item.Field<string>("Label"),
                                             Type = item.Field<string>("Type"),
                                             Phase = item.Field<string>("Phase"),
                                             DestinationPhasorID = item.NullableInt("DestinationPhasorID"),
                                             SourceIndex = Convert.ToInt32(item.Field<object>("SourceIndex")),
                                             DestinationPhasorLabel = item.Field<string>("DestinationPhasorLabel"),
                                             DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                             PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
                                             PhaseType = item.Field<string>("Phase") == "+" ? "Positive Sequence" : item.Field<string>("Phase") == "-" ? "Negative Sequence" :
                                               item.Field<string>("Phase") == "0" ? "Zero Sequence" : item.Field<string>("Phase") == "A" ? "Phase A" : item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
                                         }).First();
                return phasor;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetPhasorByID", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            //try
            //{
            //    List<Phasor> phasorList = new List<Phasor>();
            //    phasorList = (from item in GetPhasorList(connection, deviceID)
            //                  where item.ID == phasorID
            //                  select item).ToList();
            //    if (phasorList.Count > 0)
            //        return phasorList[0];
            //    else
            //        return null;
            //}
            //catch (Exception ex)
            //{
            //    LogException(connection, "GetPhasorByID", ex);
            //    return null;
            //}
        }

        static Phasor GetPhasorBySourceIndex(DataConnection connection, int deviceID, int sourceIndex)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From PhasorDetail Where DeviceID = @deviceID and SourceIndex = @sourceIndex";
                command.Parameters.Add(AddWithValue(command, "@deviceID", deviceID));
                command.Parameters.Add(AddWithValue(command, "@sourceIndex", sourceIndex));

                DataTable resultTable = GetResultSet(command).Tables[0];
                if (resultTable.Rows.Count == 0)
                    return null;

                Phasor phasor = (Phasor)(from item in resultTable.AsEnumerable()
                                         select new Phasor()
                                         {
                                             ID = Convert.ToInt32(item.Field<object>("ID")),
                                             DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                             Label = item.Field<string>("Label"),
                                             Type = item.Field<string>("Type"),
                                             Phase = item.Field<string>("Phase"),
                                             DestinationPhasorID = item.NullableInt("DestinationPhasorID"),
                                             SourceIndex = Convert.ToInt32(item.Field<object>("SourceIndex")),
                                             DestinationPhasorLabel = item.Field<string>("DestinationPhasorLabel"),
                                             DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                             PhasorType = item.Field<string>("Type") == "V" ? "Voltage" : "Current",
                                             PhaseType = item.Field<string>("Phase") == "+" ? "Positive Sequence" : item.Field<string>("Phase") == "-" ? "Negative Sequence" :
                                               item.Field<string>("Phase") == "0" ? "Zero Sequence" : item.Field<string>("Phase") == "A" ? "Phase A" : item.Field<string>("Phase") == "B" ? "Phase B" : "Phase C"
                                         }).First();
                return phasor;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetPhasorBySourceIndex", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Measurements Code"

        public static List<Measurement> GetMeasurementList(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Measurement> measurementList = new List<Measurement>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select SignalID, HistorianID, PointID, DeviceID, PointTag, AlternateTag, SignalTypeID, PhasorSourceIndex, SignalReference, " +
                        "Adder, Multiplier, Description, Enabled, HistorianAcronym, DeviceAcronym, SignalName, SignalAcronym, SignalTypeSuffix, PhasorLabel, ID From MeasurementDetail Order By PointTag";
                else
                {
                    command.CommandText = "Select SignalID, HistorianID, PointID, DeviceID, PointTag, AlternateTag, SignalTypeID, PhasorSourceIndex, SignalReference, " +
                        "Adder, Multiplier, Description, Enabled, HistorianAcronym, DeviceAcronym, SignalName, SignalAcronym, SignalTypeSuffix, PhasorLabel, ID From MeasurementDetail Where NodeID = @nodeID Order By PointTag";
                    //command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));

                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }

                measurementList = (from item in GetResultSet(command).Tables[0].AsEnumerable()
                                   select new Measurement()
                                   {
                                       SignalID = item.Field<object>("SignalID").ToString(),
                                       HistorianID = item.NullableInt("HistorianID"),
                                       PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                       DeviceID = item.NullableInt("DeviceID"),
                                       PointTag = item.Field<string>("PointTag"),
                                       AlternateTag = item.Field<string>("AlternateTag"),
                                       SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                       PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                       SignalReference = item.Field<string>("SignalReference"),
                                       Adder = item.Field<double>("Adder"),
                                       Multiplier = item.Field<double>("Multiplier"),
                                       Description = item.Field<string>("Description"),
                                       Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                       HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                       DeviceAcronym = item.Field<object>("DeviceAcronym") == null ? string.Empty : item.Field<string>("DeviceAcronym"),
                                       SignalName = item.Field<string>("SignalName"),
                                       SignalAcronym = item.Field<string>("SignalAcronym"),
                                       SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                       PhasorLabel = item.Field<string>("PhasorLabel"),
                                       ID = item.Field<string>("ID")
                                   }).ToList();
                return measurementList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static List<Measurement> GetMeasurementsByDevice(DataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Measurement> measurementList = new List<Measurement>();
                IDbCommand commnad = connection.Connection.CreateCommand();
                commnad.CommandType = CommandType.Text;
                commnad.CommandText = "Select * From MeasurementDetail Where DeviceID = @deviceID Order By PointTag";
                commnad.Parameters.Add(AddWithValue(commnad, "@deviceID", deviceID));

                measurementList = (from item in GetResultSet(commnad).Tables[0].AsEnumerable()
                                   select new Measurement()
                                   {
                                       SignalID = item.Field<object>("SignalID").ToString(),
                                       HistorianID = item.NullableInt("HistorianID"),
                                       PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                       DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                       PointTag = item.Field<string>("PointTag"),
                                       AlternateTag = item.Field<string>("AlternateTag"),
                                       SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                       PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                       SignalReference = item.Field<string>("SignalReference"),
                                       Adder = item.Field<double>("Adder"),
                                       Multiplier = item.Field<double>("Multiplier"),
                                       Description = item.Field<string>("Description"),
                                       Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                       HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                       DeviceAcronym = item.Field<object>("DeviceAcronym") == null ? string.Empty : item.Field<string>("DeviceAcronym"),
                                       SignalName = item.Field<string>("SignalName"),
                                       SignalAcronym = item.Field<string>("SignalAcronym"),
                                       SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                       PhasorLabel = item.Field<string>("PhasorLabel"),
                                       ID = item.Field<string>("ID")
                                   }).ToList();
                return measurementList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveMeasurement(DataConnection connection, Measurement measurement, bool isNew)
        {
            //DataConnection connection = new DataConnection();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();

                if (isNew)
                    command.CommandText = "Insert Into Measurement (HistorianID, DeviceID, PointTag, AlternateTag, SignalTypeID, PhasorSourceIndex, SignalReference, Adder, Multiplier, Description, Enabled, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                        "Values (@historianID, @deviceID, @pointTag, @alternateTag, @signalTypeID, @phasorSourceIndex, @signalReference, @adder, @multiplier, @description, @enabled, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update Measurement Set HistorianID = @historianID, DeviceID = @deviceID, PointTag = @pointTag, AlternateTag = @alternateTag, SignalTypeID = @signalTypeID, " +
                        "PhasorSourceIndex = @phasorSourceIndex, SignalReference = @signalReference, Adder = @adder, Multiplier = @multiplier, Description = @description, Enabled = @enabled, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where SignalID = @signalID";

                command.Parameters.Add(AddWithValue(command, "@historianID", measurement.HistorianID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@deviceID", measurement.DeviceID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@pointTag", measurement.PointTag));
                command.Parameters.Add(AddWithValue(command, "@alternateTag", measurement.AlternateTag ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@signalTypeID", measurement.SignalTypeID));
                command.Parameters.Add(AddWithValue(command, "@phasorSourceIndex", measurement.PhasorSourceIndex ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@signalReference", measurement.SignalReference));
                command.Parameters.Add(AddWithValue(command, "@adder", measurement.Adder));
                command.Parameters.Add(AddWithValue(command, "@multiplier", measurement.Multiplier));
                command.Parameters.Add(AddWithValue(command, "@description", measurement.Description.RemoveDuplicateWhiteSpace()));
                command.Parameters.Add(AddWithValue(command, "@enabled", measurement.Enabled));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@signalID", "{" + measurement.SignalID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@signalID", measurement.SignalID));
                }

                command.ExecuteNonQuery();
                return "Measurement Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static List<Measurement> GetMeasurementsForOutputStream(DataConnection connection, string nodeID, int outputStreamID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Measurement> measurementList = new List<Measurement>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select * From MeasurementDetail Where PointID Not In (Select PointID From OutputStreamMeasurement Where AdapterID = @outputStreamID)";
                else
                {
                    command.CommandText = "Select * From MeasurementDetail Where NodeID = @nodeID AND PointID Not In (Select PointID From OutputStreamMeasurement Where AdapterID = @outputStreamID)";
                    //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }
                command.Parameters.Add(AddWithValue(command, "@outputStreamID", outputStreamID));

                measurementList = (from item in GetResultSet(command).Tables[0].AsEnumerable()
                                   where item.Field<string>("SignalAcronym") != "STAT"
                                   select new Measurement()
                                   {
                                       SignalID = item.Field<object>("SignalID").ToString(),
                                       HistorianID = item.NullableInt("HistorianID"),
                                       PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                       DeviceID = item.NullableInt("DeviceID"),
                                       PointTag = item.Field<string>("PointTag"),
                                       AlternateTag = item.Field<string>("AlternateTag"),
                                       SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                       PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                       SignalReference = item.Field<string>("SignalReference"),
                                       Adder = item.Field<double>("Adder"),
                                       Multiplier = item.Field<double>("Multiplier"),
                                       Description = item.Field<string>("Description"),
                                       Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                       HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                       DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                       SignalName = item.Field<string>("SignalName"),
                                       SignalAcronym = item.Field<string>("SignalAcronym"),
                                       SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                       PhasorLabel = item.Field<string>("PhasorLabel")
                                   }).ToList();
                return measurementList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Measurement GetMeasurementInfo(DataConnection connection, int? deviceID, string signalSuffix, int? phasorSourceIndex)	//we are using signal suffix because it remains same if phasor is current or voltage which helps in modifying existing measurement if phasor changes from voltage to current.
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand commnad = connection.Connection.CreateCommand();
                commnad.CommandType = CommandType.Text;
                commnad.CommandText = "Select * From MeasurementDetail Where SignalTypeSuffix = @signalTypeSuffix";
                commnad.Parameters.Add(AddWithValue(commnad, "@signalTypeSuffix", signalSuffix));

                if (deviceID != null)
                {
                    commnad.CommandText += " AND DeviceID = @deviceID";
                    commnad.Parameters.Add(AddWithValue(commnad, "@deviceID", deviceID ?? (object)DBNull.Value));
                }

                if (phasorSourceIndex != null)
                {
                    commnad.CommandText += " AND PhasorSourceIndex = @phasorSourceIndex";
                    commnad.Parameters.Add(AddWithValue(commnad, "@phasorSourceIndex", phasorSourceIndex ?? (object)DBNull.Value));
                }

                DataTable resultTable = GetResultSet(commnad).Tables[0];
                if (resultTable.Rows.Count == 0)
                    return null;

                Measurement measurement = (Measurement)(from item in resultTable.AsEnumerable()
                                                        select new Measurement()
                                                        {
                                                            SignalID = item.Field<object>("SignalID").ToString(),
                                                            HistorianID = item.NullableInt("HistorianID"),
                                                            PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                                            DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                                            PointTag = item.Field<string>("PointTag"),
                                                            AlternateTag = item.Field<string>("AlternateTag"),
                                                            SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                                            PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                                            SignalReference = item.Field<string>("SignalReference"),
                                                            Adder = item.Field<double>("Adder"),
                                                            Multiplier = item.Field<double>("Multiplier"),
                                                            Description = item.Field<string>("Description"),
                                                            Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                                            HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                                            DeviceAcronym = item.Field<object>("DeviceAcronym") == null ? string.Empty : item.Field<string>("DeviceAcronym"),
                                                            SignalName = item.Field<string>("SignalName"),
                                                            SignalAcronym = item.Field<string>("SignalAcronym"),
                                                            SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                                            PhasorLabel = item.Field<string>("PhasorLabel")
                                                        }).First();
                return measurement;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetMeasurementInfo", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        private static Measurement GetMeasurementInfoBySignalReference(DataConnection connection, int? deviceID, string signalReference, int? phasorSourceIndex)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand commnad = connection.Connection.CreateCommand();
                commnad.CommandType = CommandType.Text;
                commnad.CommandText = "Select * From MeasurementDetail Where SignalReference = @signalReference";
                commnad.Parameters.Add(AddWithValue(commnad, "@signalReference", signalReference));
                if (deviceID != null)
                {
                    commnad.CommandText += " AND DeviceID = @deviceID";
                    commnad.Parameters.Add(AddWithValue(commnad, "@deviceID", deviceID ?? (object)DBNull.Value));
                }

                if (phasorSourceIndex != null)
                {
                    commnad.CommandText += " AND PhasorSourceIndex = @phasorSourceIndex";
                    commnad.Parameters.Add(AddWithValue(commnad, "@phasorSourceIndex", phasorSourceIndex ?? (object)DBNull.Value));
                }

                DataTable resultTable = GetResultSet(commnad).Tables[0];
                if (resultTable.Rows.Count == 0)
                    return null;

                Measurement measurement = (Measurement)(from item in resultTable.AsEnumerable()
                                                        select new Measurement()
                                                        {
                                                            SignalID = item.Field<object>("SignalID").ToString(),
                                                            HistorianID = item.NullableInt("HistorianID"),
                                                            PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                                            DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                                            PointTag = item.Field<string>("PointTag"),
                                                            AlternateTag = item.Field<string>("AlternateTag"),
                                                            SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                                            PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                                            SignalReference = item.Field<string>("SignalReference"),
                                                            Adder = item.Field<double>("Adder"),
                                                            Multiplier = item.Field<double>("Multiplier"),
                                                            Description = item.Field<string>("Description"),
                                                            Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                                            HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                                            DeviceAcronym = item.Field<object>("DeviceAcronym") == null ? string.Empty : item.Field<string>("DeviceAcronym"),
                                                            SignalName = item.Field<string>("SignalName"),
                                                            SignalAcronym = item.Field<string>("SignalAcronym"),
                                                            SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                                            PhasorLabel = item.Field<string>("PhasorLabel")
                                                        }).First();
                return measurement;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetMeasurementInfoBySignalReference", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static List<Measurement> GetFilteredMeasurementsByDevice(DataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Measurement> measurementList = new List<Measurement>();
                IDbCommand commnad = connection.Connection.CreateCommand();
                commnad.CommandType = CommandType.Text;
                commnad.CommandText = "Select * From MeasurementDetail Where DeviceID = @deviceID AND SignalTypeSuffix IN ('PA', 'FQ') Order By PointTag";
                commnad.Parameters.Add(AddWithValue(commnad, "@deviceID", deviceID));

                measurementList = (from item in GetResultSet(commnad).Tables[0].AsEnumerable()
                                   select new Measurement()
                                   {
                                       SignalID = item.Field<object>("SignalID").ToString(),
                                       HistorianID = item.NullableInt("HistorianID"),
                                       PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                       DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                       PointTag = item.Field<string>("PointTag"),
                                       AlternateTag = item.Field<string>("AlternateTag"),
                                       SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                       PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                       SignalReference = item.Field<string>("SignalReference"),
                                       Adder = item.Field<double>("Adder"),
                                       Multiplier = item.Field<double>("Multiplier"),
                                       Description = item.Field<string>("Description"),
                                       Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                       HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                       DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                       FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                       SignalName = item.Field<string>("SignalName"),
                                       SignalAcronym = item.Field<string>("SignalAcronym"),
                                       SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                       PhasorLabel = item.Field<string>("PhasorLabel")
                                   }).ToList();
                return measurementList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static List<Measurement> GetOutputStreamStatistics(DataConnection connection, string nodeID, string outputStreamAcronym)
        {
            try
            {
                List<Measurement> measurementList = new List<Measurement>();
                measurementList = (from item in GetMeasurementList(connection, nodeID)
                                   where item.SignalReference.StartsWith(outputStreamAcronym + "!OS")
                                   select item).ToList();

                return measurementList;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetOutputStreamStatistics", ex);
                return null;
            }
        }

        public static Measurement GetMeasurementBySignalID(DataConnection connection, string nodeID, string signalID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select * From MeasurementDetail Where SignalID = @signalID";
                else
                {
                    command.CommandText = "Select * From MeasurementDetail Where NodeID = @nodeID AND SignalID = @signalID";

                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }

                command.Parameters.Add(AddWithValue(command, "@signalID", signalID));

                DataTable resultTable = GetResultSet(command).Tables[0];

                if (resultTable.Rows.Count == 0)
                    return null;

                Measurement measurement = (Measurement)(from item in resultTable.AsEnumerable()
                                                        select new Measurement()
                                                        {
                                                            SignalID = item.Field<object>("SignalID").ToString(),
                                                            HistorianID = item.NullableInt("HistorianID"),
                                                            PointID = Convert.ToInt32(item.Field<object>("PointID")),
                                                            DeviceID = Convert.ToInt32(item.Field<object>("DeviceID")),
                                                            PointTag = item.Field<string>("PointTag"),
                                                            AlternateTag = item.Field<string>("AlternateTag"),
                                                            SignalTypeID = Convert.ToInt32(item.Field<object>("SignalTypeID")),
                                                            PhasorSourceIndex = item.NullableInt("PhasorSourceIndex"),
                                                            SignalReference = item.Field<string>("SignalReference"),
                                                            Adder = item.Field<double>("Adder"),
                                                            Multiplier = item.Field<double>("Multiplier"),
                                                            Description = item.Field<string>("Description"),
                                                            Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                                            HistorianAcronym = item.Field<string>("HistorianAcronym"),
                                                            DeviceAcronym = item.Field<string>("DeviceAcronym"),
                                                            FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                                            SignalName = item.Field<string>("SignalName"),
                                                            SignalAcronym = item.Field<string>("SignalAcronym"),
                                                            SignalSuffix = item.Field<string>("SignalTypeSuffix"),
                                                            PhasorLabel = item.Field<string>("PhasorLabel")
                                                        }).First();
                return measurement;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetMeasurementBySignalID", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Other Devices"

        public static List<OtherDevice> GetOtherDeviceList(DataConnection connection)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<OtherDevice> otherDeviceList = new List<OtherDevice>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OtherDeviceDetail Order By Acronym, Name";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                otherDeviceList = (from item in resultTable.AsEnumerable()
                                   select new OtherDevice()
                                   {
                                       ID = Convert.ToInt32(item.Field<object>("ID")),
                                       Acronym = item.Field<string>("Acronym"),
                                       Name = item.Field<string>("Name"),
                                       IsConcentrator = Convert.ToBoolean(item.Field<object>("IsConcentrator")),
                                       CompanyID = item.NullableInt("CompanyID"),
                                       VendorDeviceID = item.NullableInt("VendorDeviceID"),
                                       Longitude = item.NullableDecimal("Longitude"),
                                       Latitude = item.NullableDecimal("Latitude"),
                                       InterconnectionID = item.NullableInt("InterconnectionID"),
                                       Planned = Convert.ToBoolean(item.Field<object>("Planned")),
                                       Desired = Convert.ToBoolean(item.Field<object>("Desired")),
                                       InProgress = Convert.ToBoolean(item.Field<object>("InProgress")),
                                       CompanyName = item.Field<string>("CompanyName"),
                                       VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                       InterconnectionName = item.Field<string>("InterconnectionName")
                                   }).ToList();
                return otherDeviceList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveOtherDevice(DataConnection connection, OtherDevice otherDevice, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (isNew)
                    command.CommandText = "Insert Into OtherDevice (Acronym, Name, IsConcentrator, CompanyID, VendorDeviceID, Longitude, Latitude, InterconnectionID, Planned, Desired, InProgress, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values " +
                        "(@acronym, @name, @isConcentrator, @companyID, @vendorDeviceID, @longitude, @latitude, @interconnectionID, @planned, @desired, @inProgress, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update OtherDevice Set Acronym = @acronym, Name = @name, IsConcentrator = @isConcentrator, CompanyID = @companyID, VendorDeviceID = @vendorDeviceID, Longitude = @longitude, " +
                        "Latitude = @latitude, InterconnectionID = @interconnectionID, Planned = @planned, Desired = @desired, InProgress = @inProgress, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@acronym", otherDevice.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", otherDevice.Name));
                command.Parameters.Add(AddWithValue(command, "@isConcentrator", otherDevice.IsConcentrator));
                command.Parameters.Add(AddWithValue(command, "@companyID", otherDevice.CompanyID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@vendorDeviceID", otherDevice.VendorDeviceID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@longitude", otherDevice.Longitude ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@latitude", otherDevice.Latitude ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@interconnectionID", otherDevice.InterconnectionID ?? (object)DBNull.Value));
                command.Parameters.Add(AddWithValue(command, "@planned", otherDevice.Planned));
                command.Parameters.Add(AddWithValue(command, "@desired", otherDevice.Desired));
                command.Parameters.Add(AddWithValue(command, "@inProgress", otherDevice.InProgress));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", otherDevice.ID));

                command.ExecuteScalar();
                return "Other Device Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static OtherDevice GetOtherDeviceByDeviceID(DataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From OtherDeviceDetail WHERE ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", deviceID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                if (resultTable.Rows.Count == 0)
                    return null;

                OtherDevice otherDevice = (from item in resultTable.AsEnumerable()
                                           select new OtherDevice()
                                           {
                                               ID = Convert.ToInt32(item.Field<object>("ID")),
                                               Acronym = item.Field<string>("Acronym"),
                                               Name = item.Field<string>("Name"),
                                               IsConcentrator = Convert.ToBoolean(item.Field<object>("IsConcentrator")),
                                               CompanyID = item.NullableInt("CompanyID"),
                                               VendorDeviceID = item.NullableInt("VendorDeviceID"),
                                               Longitude = item.NullableDecimal("Longitude"),
                                               Latitude = item.NullableDecimal("Latitude"),
                                               InterconnectionID = item.NullableInt("InterconnectionID"),
                                               Planned = Convert.ToBoolean(item.Field<object>("Planned")),
                                               Desired = Convert.ToBoolean(item.Field<object>("Desired")),
                                               InProgress = Convert.ToBoolean(item.Field<object>("InProgress")),
                                               CompanyName = item.Field<string>("CompanyName"),
                                               VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                               InterconnectionName = item.Field<string>("InterconnectionName")
                                           }).First();
                return otherDevice;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetOtherDeviceByDeviceID", ex);
                return null;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Interconnections Code"

        public static Dictionary<int, string> GetInterconnections(DataConnection connection, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> interconnectionList = new Dictionary<int, string>();
                if (isOptional)
                    interconnectionList.Add(0, "Select Interconnection");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Name From Interconnection Order By LoadOrder";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!interconnectionList.ContainsKey(Convert.ToInt32(row["ID"])))
                        interconnectionList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
                }
                return interconnectionList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Protocols Code"

        public static Dictionary<int, string> GetProtocols(DataConnection connection, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> protocolList = new Dictionary<int, string>();
                if (isOptional)
                    protocolList.Add(0, "Select Protocol");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Name From Protocol Order By LoadOrder";
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!protocolList.ContainsKey(Convert.ToInt32(row["ID"])))
                        protocolList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
                }
                return protocolList;
            }

            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static int GetProtocolIDByAcronym(DataConnection connection, string acronym)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID From Protocol Where Acronym = @acronym";
                command.Parameters.Add(AddWithValue(command, "@acronym", acronym));
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                if (resultTable.Rows.Count > 0)
                    return Convert.ToInt32(resultTable.Rows[0]["ID"]);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetProtocolIDByAcronym", ex);
                return 0;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        private static string GetProtocolAcronymByID(DataConnection connection, int id)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select Acronym From Protocol Where ID = @id";
                command.Parameters.Add(AddWithValue(command, "@id", id));
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                if (resultTable.Rows.Count > 0)
                    return resultTable.Rows[0]["Acronym"].ToString();
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                LogException(connection, "GetProtocolAcronymByID", ex);
                return string.Empty;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Signal Types Code"

        public static Dictionary<int, string> GetSignalTypes(DataConnection connection, bool isOptional)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                Dictionary<int, string> signalTypeList = new Dictionary<int, string>();
                if (isOptional)
                    signalTypeList.Add(0, "Select Signal Type");

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID, Name From SignalType Order By Name";
                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                foreach (DataRow row in resultTable.Rows)
                {
                    if (!signalTypeList.ContainsKey(Convert.ToInt32(row["ID"])))
                        signalTypeList.Add(Convert.ToInt32(row["ID"]), row["Name"].ToString());
                }

                return signalTypeList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        static DataTable GetPmuSignalTypes(DataConnection connection)	//Do not use this method in WCF call or silverlight. It is for internal use only.
        {
            bool createdConnection = false;
            DataTable resultTable = new DataTable();
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From SignalType Where Source = 'PMU' AND Suffix IN ('FQ', 'DF', 'SF')";

                resultTable.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                LogException(connection, "GetPmuSignalTypes", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return resultTable;
        }

        static DataTable GetPhasorSignalTypes(DataConnection connection, string phasorType)
        {
            DataTable resultTable = new DataTable();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (phasorType == "V")
                    command.CommandText = "Select * From SignalType Where Source = 'Phasor' AND Acronym LIKE 'V%'";
                else
                    command.CommandText = "Select * From SignalType Where Source = 'Phasor' AND Acronym LIKE 'I%'";

                resultTable.Load(command.ExecuteReader());
            }
            catch (Exception ex)
            {
                LogException(connection, "GetPhasorSignalTypes", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return resultTable;
        }

        static int GetSignalTypeID(DataConnection connection, string suffix)
        {
            int signalTypeID = 0;
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select ID From SignalType Where Suffix = @suffix";
                command.Parameters.Add(AddWithValue(command, "@suffix", suffix));
                signalTypeID = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogException(connection, "GetSignalTypeID", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
            return signalTypeID;
        }

        #endregion

        #region " Manage Calculated Measurements"

        public static List<CalculatedMeasurement> GetCalculatedMeasurementList(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<CalculatedMeasurement> calculatedMeasurementList = new List<CalculatedMeasurement>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select * From CalculatedMeasurementDetail Order By LoadOrder";
                else
                {
                    command.CommandText = "Select * From CalculatedMeasurementDetail Where NodeID = @nodeID Order By LoadOrder";
                    //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                calculatedMeasurementList = (from item in resultTable.AsEnumerable()
                                             select new CalculatedMeasurement()
                                             {
                                                 NodeId = item.Field<object>("NodeID").ToString(),
                                                 ID = Convert.ToInt32(item.Field<object>("ID")),
                                                 Acronym = item.Field<string>("Acronym"),
                                                 Name = item.Field<string>("Name"),
                                                 AssemblyName = item.Field<string>("AssemblyName"),
                                                 TypeName = item.Field<string>("TypeName"),
                                                 ConnectionString = item.Field<string>("ConnectionString"),
                                                 ConfigSection = item.Field<string>("ConfigSection"),
                                                 InputMeasurements = item.Field<string>("InputMeasurements"),
                                                 OutputMeasurements = item.Field<string>("OutputMeasurements"),
                                                 MinimumMeasurementsToUse = Convert.ToInt32(item.Field<object>("MinimumMeasurementsToUse")),
                                                 FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                                 LagTime = item.Field<double>("LagTime"),
                                                 LeadTime = item.Field<double>("LeadTime"),
                                                 UseLocalClockAsRealTime = Convert.ToBoolean(item.Field<object>("UseLocalClockAsRealTime")),
                                                 AllowSortsByArrival = Convert.ToBoolean(item.Field<object>("AllowSortsByArrival")),
                                                 LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                                 Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                                 IgnoreBadTimeStamps = Convert.ToBoolean(item.Field<object>("IgnoreBadTimeStamps")),
                                                 TimeResolution = Convert.ToInt32(item.Field<object>("TimeResolution")),
                                                 AllowPreemptivePublishing = Convert.ToBoolean(item.Field<object>("AllowPreemptivePublishing")),
                                                 DownsamplingMethod = item.Field<string>("DownSamplingMethod"),
                                                 NodeName = item.Field<string>("NodeName"),
                                                 PerformTimestampReasonabilityCheck = Convert.ToBoolean(item.Field<object>("PerformTimestampReasonabilityCheck"))
                                             }).ToList();

                return calculatedMeasurementList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveCalculatedMeasurement(DataConnection connection, CalculatedMeasurement calculatedMeasurement, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into CalculatedMeasurement (NodeID, Acronym, Name, AssemblyName, TypeName, ConnectionString, ConfigSection, InputMeasurements, OutputMeasurements, MinimumMeasurementsToUse, FramesPerSecond, LagTime, LeadTime, " +
                        "UseLocalClockAsRealTime, AllowSortsByArrival, LoadOrder, Enabled, IgnoreBadTimeStamps, TimeResolution, AllowPreemptivePublishing, DownsamplingMethod, PerformTimestampReasonabilityCheck, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values (@nodeID, @acronym, @name, @assemblyName, @typeName, @connectionString, @configSection, @inputMeasurements, @outputMeasurements, @minimumMeasurementsToUse, " +
                        "@framesPerSecond, @lagTime, @leadTime, @useLocalClockAsRealTime, @allowSortsByArrival, @loadOrder, @enabled, @ignoreBadTimeStamps, @timeResolution, @allowPreemptivePublishing, @downsamplingMethod, @performTimestampReasonabilityCheck, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update CalculatedMeasurement Set NodeID = @nodeID, Acronym = @acronym, Name = @name, AssemblyName = @assemblyName, TypeName = @typeName, ConnectionString = @connectionString, ConfigSection = @configSection, " +
                        "InputMeasurements = @inputMeasurements, OutputMeasurements = @outputMeasurements, MinimumMeasurementsToUse = @minimumMeasurementsToUse, FramesPerSecond = @framesPerSecond, LagTime = @lagTime, LeadTime = @leadTime, " +
                        "UseLocalClockAsRealTime = @useLocalClockAsRealTime, AllowSortsByArrival = @allowSortsByArrival, LoadOrder = @loadOrder, Enabled = @enabled, IgnoreBadTimeStamps = @ignoreBadTimeStamps, TimeResolution = @timeResolution, " +
                        "AllowPreemptivePublishing = @allowPreemptivePublishing, DownsamplingMethod = @downsamplingMethod, PerformTimestampReasonabilityCheck = @performTimestampReasonabilityCheck, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", calculatedMeasurement.NodeId));
                command.Parameters.Add(AddWithValue(command, "@acronym", calculatedMeasurement.Acronym.Replace(" ", "").ToUpper()));
                command.Parameters.Add(AddWithValue(command, "@name", calculatedMeasurement.Name));
                command.Parameters.Add(AddWithValue(command, "@assemblyName", calculatedMeasurement.AssemblyName));
                command.Parameters.Add(AddWithValue(command, "@typeName", calculatedMeasurement.TypeName));
                command.Parameters.Add(AddWithValue(command, "@connectionString", calculatedMeasurement.ConnectionString));
                command.Parameters.Add(AddWithValue(command, "@configSection", calculatedMeasurement.ConfigSection));
                command.Parameters.Add(AddWithValue(command, "@inputMeasurements", calculatedMeasurement.InputMeasurements));
                command.Parameters.Add(AddWithValue(command, "@outputMeasurements", calculatedMeasurement.OutputMeasurements));
                command.Parameters.Add(AddWithValue(command, "@minimumMeasurementsToUse", calculatedMeasurement.MinimumMeasurementsToUse));
                command.Parameters.Add(AddWithValue(command, "@framesPerSecond", calculatedMeasurement.FramesPerSecond));
                command.Parameters.Add(AddWithValue(command, "@lagTime", calculatedMeasurement.LagTime));
                command.Parameters.Add(AddWithValue(command, "@leadTime", calculatedMeasurement.LeadTime));
                command.Parameters.Add(AddWithValue(command, "@useLocalClockAsRealTime", calculatedMeasurement.UseLocalClockAsRealTime));
                command.Parameters.Add(AddWithValue(command, "@allowSortsByArrival", calculatedMeasurement.AllowSortsByArrival));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", calculatedMeasurement.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", calculatedMeasurement.Enabled));
                command.Parameters.Add(AddWithValue(command, "@ignoreBadTimeStamps", calculatedMeasurement.IgnoreBadTimeStamps));
                command.Parameters.Add(AddWithValue(command, "@timeResolution", calculatedMeasurement.TimeResolution));
                command.Parameters.Add(AddWithValue(command, "@allowPreemptivePublishing", calculatedMeasurement.AllowPreemptivePublishing));
                command.Parameters.Add(AddWithValue(command, "@downsamplingMethod", calculatedMeasurement.DownsamplingMethod));
                command.Parameters.Add(AddWithValue(command, "@performTimestampReasonabilityCheck", calculatedMeasurement.PerformTimestampReasonabilityCheck));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", calculatedMeasurement.ID));

                command.ExecuteNonQuery();

                return "Calculated Measurement Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Custom Adapters Code"

        public static List<Adapter> GetAdapterList(DataConnection connection, bool enabledOnly, AdapterType adapterType, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Adapter> adapterList = new List<Adapter>();
                string viewName;
                if (adapterType == AdapterType.Action)
                    viewName = "CustomActionAdapterDetail";
                else if (adapterType == AdapterType.Input)
                    viewName = "CustomInputAdapterDetail";
                else
                    viewName = "CustomOutputAdapterDetail";

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                if (string.IsNullOrEmpty(nodeID) || MasterNode(connection, nodeID))
                    command.CommandText = "Select * From " + viewName + " Order By LoadOrder";
                else
                {
                    command.CommandText = "Select * From " + viewName + " Where NodeID = @nodeID Order By LoadOrder";
                    //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                }

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                adapterList = (from item in resultTable.AsEnumerable()
                               select new Adapter()
                               {
                                   NodeID = item.Field<object>("NodeID").ToString(),
                                   ID = Convert.ToInt32(item.Field<object>("ID")),
                                   AdapterName = item.Field<string>("AdapterName"),
                                   AssemblyName = item.Field<string>("AssemblyName"),
                                   TypeName = item.Field<string>("TypeName"),
                                   ConnectionString = item.Field<string>("ConnectionString"),
                                   LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                   Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                   NodeName = item.Field<string>("NodeName"),
                                   adapterType = adapterType
                               }).ToList();

                return adapterList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveAdapter(DataConnection connection, Adapter adapter, bool isNew)
        {
            string tableName;
            AdapterType adapterType = adapter.adapterType;

            if (adapterType == AdapterType.Input)
                tableName = "CustomInputAdapter";
            else if (adapterType == AdapterType.Action)
                tableName = "CustomActionAdapter";
            else
                tableName = "CustomOutputAdapter";

            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into " + tableName + " (NodeID, AdapterName, AssemblyName, TypeName, ConnectionString, LoadOrder, Enabled, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values " +
                        "(@nodeID, @adapterName, @assemblyName, @typeName, @connectionString, @loadOrder, @enabled, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update " + tableName + " Set NodeID = @nodeID, AdapterName = @adapterName, AssemblyName = @assemblyName, TypeName = @typeName, " +
                        "ConnectionString = @connectionString, LoadOrder = @loadOrder, Enabled = @enabled, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@nodeID", adapter.NodeID));
                command.Parameters.Add(AddWithValue(command, "@adapterName", adapter.AdapterName));
                command.Parameters.Add(AddWithValue(command, "@assemblyName", adapter.AssemblyName));
                command.Parameters.Add(AddWithValue(command, "@typeName", adapter.TypeName));
                command.Parameters.Add(AddWithValue(command, "@connectionString", adapter.ConnectionString));
                command.Parameters.Add(AddWithValue(command, "@loadOrder", adapter.LoadOrder));
                command.Parameters.Add(AddWithValue(command, "@enabled", adapter.Enabled));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", adapter.ID));

                command.ExecuteNonQuery();

                return "Adapter Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static List<IaonTree> GetIaonTreeData(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<IaonTree> iaonTreeList = new List<IaonTree>();
                DataTable rootNodesTable = new DataTable();
                rootNodesTable.Columns.Add(new DataColumn("AdapterType", Type.GetType("System.String")));

                DataRow row;
                row = rootNodesTable.NewRow();
                row["AdapterType"] = "Input Adapters";
                rootNodesTable.Rows.Add(row);

                row = rootNodesTable.NewRow();
                row["AdapterType"] = "Action Adapters";
                rootNodesTable.Rows.Add(row);

                row = rootNodesTable.NewRow();
                row["AdapterType"] = "Output Adapters";
                rootNodesTable.Rows.Add(row);

                DataSet resultSet = new DataSet();
                resultSet.Tables.Add(rootNodesTable);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From IaonTreeView Where NodeID = @nodeID";
                //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));

                DataTable resultTable = new DataTable();
                resultSet.EnforceConstraints = false;	//this is needed to make it work against mySQL.
                resultSet.Tables.Add(resultTable);
                resultTable.Load(command.ExecuteReader());
                resultSet.Tables[0].TableName = "RootNodesTable";
                resultSet.Tables[1].TableName = "AdapterData";

                iaonTreeList = (from item in resultSet.Tables["RootNodesTable"].AsEnumerable()
                                select new IaonTree()
                                {
                                    AdapterType = item.Field<string>("AdapterType"),
                                    AdapterList = (from obj in resultSet.Tables["AdapterData"].AsEnumerable()
                                                   where obj.Field<string>("AdapterType") == item.Field<string>("AdapterType")
                                                   select new Adapter()
                                                   {
                                                       NodeID = obj.Field<object>("NodeID").ToString(),
                                                       ID = Convert.ToInt32(obj.Field<object>("ID")),
                                                       AdapterName = obj.Field<string>("AdapterName"),
                                                       AssemblyName = obj.Field<string>("AssemblyName"),
                                                       TypeName = obj.Field<string>("TypeName"),
                                                       ConnectionString = obj.Field<string>("ConnectionString")
                                                   }).ToList()
                                }).ToList();

                return iaonTreeList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Manage Map Data"

        public static List<MapData> GetMapData(DataConnection connection, MapType mapType, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<MapData> mapDataList = new List<MapData>();
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (mapType == MapType.Active)
                    command.CommandText = "Select * From MapData Where NodeID = @nodeID and DeviceType = 'Device'";
                else
                    command.CommandText = "Select * From MapData Where NodeID = @nodeID UNION ALL Select * From MapData Where NodeID IS NULL";

                //command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());

                if (mapType == MapType.Active)
                    mapDataList = (from item in resultTable.AsEnumerable()
                                   select new MapData()
                                   {
                                       NodeID = item.Field<object>("NodeID").ToString(),
                                       ID = Convert.ToInt32(item.Field<object>("ID")),
                                       Acronym = item.Field<string>("Acronym"),
                                       Name = item.Field<string>("Name"),
                                       CompanyMapAcronym = item.Field<string>("CompanyMapAcronym"),
                                       CompanyName = item.Field<string>("CompanyName"),
                                       VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                       Longitude = item.NullableDecimal("Longitude"),
                                       Latitude = item.NullableDecimal("Latitude"),
                                       Reporting = Convert.ToBoolean(item.Field<object>("Reporting"))
                                   }).ToList();
                else
                    mapDataList = (from item in resultTable.AsEnumerable()
                                   select new MapData()
                                   {
                                       DeviceType = item.Field<string>("DeviceType"),
                                       ID = Convert.ToInt32(item.Field<object>("ID")),
                                       Acronym = item.Field<string>("Acronym"),
                                       Name = item.Field<string>("Name"),
                                       CompanyMapAcronym = item.Field<string>("CompanyMapAcronym"),
                                       CompanyName = item.Field<string>("CompanyName"),
                                       VendorDeviceName = item.Field<string>("VendorDeviceName"),
                                       Longitude = item.NullableDecimal("Longitude"),
                                       Latitude = item.NullableDecimal("Latitude"),
                                       Reporting = Convert.ToBoolean(item.Field<object>("Reporting")),
                                       InProgress = Convert.ToBoolean(item.Field<object>("InProgress")),
                                       Planned = Convert.ToBoolean(item.Field<object>("Planned")),
                                       Desired = Convert.ToBoolean(item.Field<object>("Desired"))
                                   }).ToList();

                return mapDataList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Current Device Measurements Code"

        public static ObservableCollection<DeviceMeasurementData> GetDeviceMeasurementData(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<DeviceMeasurementData> deviceMeasurementDataList = new List<DeviceMeasurementData>();
                DataSet resultSet = new DataSet();
                resultSet.EnforceConstraints = false;

                DataTable resultTable;

                IDbCommand commandPdc = connection.Connection.CreateCommand();
                commandPdc.CommandType = CommandType.Text;
                //Get PDCs list
                commandPdc.CommandText = "Select ID, Acronym, Name, CompanyName, Enabled From DeviceDetail Where NodeID = @nodeID AND IsConcentrator = @isConcentrator AND Enabled = @enabled Order By Acronym";
                if (commandPdc.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    commandPdc.Parameters.Add(AddWithValue(commandPdc, "@nodeID", "{" + nodeID + "}"));
                else
                    commandPdc.Parameters.Add(AddWithValue(commandPdc, "@nodeID", nodeID));

                commandPdc.Parameters.Add(AddWithValue(commandPdc, "@isConcentrator", true));
                commandPdc.Parameters.Add(AddWithValue(commandPdc, "@enabled", true));

                resultTable = new DataTable();
                resultSet.Tables.Add(resultTable);
                resultTable.Load(commandPdc.ExecuteReader());
                DataRow row = resultTable.NewRow();
                row["ID"] = 0;
                row["Acronym"] = string.Empty;
                row["Name"] = "Devices Connected Directly";
                row["CompanyName"] = string.Empty;
                row["Enabled"] = false;
                resultTable.Rows.Add(row);

                //Get Non PDC Devices
                IDbCommand commandDevices = connection.Connection.CreateCommand();
                commandDevices.CommandType = CommandType.Text;
                commandDevices.CommandText = "Select ID, Acronym, Name,CompanyName, ProtocolName, VendorDeviceName, ParentAcronym, Enabled From DeviceDetail Where NodeID = @nodeID AND IsConcentrator = @isConcentrator AND Enabled = @enabled Order By Acronym";
                if (commandDevices.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    commandDevices.Parameters.Add(AddWithValue(commandDevices, "@nodeID", "{" + nodeID + "}"));
                else
                    commandDevices.Parameters.Add(AddWithValue(commandDevices, "@nodeID", nodeID));

                commandDevices.Parameters.Add(AddWithValue(commandDevices, "@isConcentrator", false));
                commandDevices.Parameters.Add(AddWithValue(commandDevices, "@enabled", true));

                resultTable = new DataTable();
                resultSet.Tables.Add(resultTable);
                resultTable.Load(commandDevices.ExecuteReader());
                row = resultTable.NewRow();
                row["ID"] = DBNull.Value;
                row["Acronym"] = "CALCULATED";
                row["Name"] = "CALCULATED MEASUREMENTS";
                row["CompanyName"] = string.Empty;
                row["ProtocolName"] = string.Empty;
                row["VendorDeviceName"] = string.Empty;
                row["ParentAcronym"] = string.Empty;
                row["Enabled"] = false;
                //We are going to skip adding this row here.
                //First we will see if there is any measurement exists where DeviceID is NULL and is not a statistical measurement.
                //If it does then only we will add this dummy device to the devices table.
                //This new check has been added few line down.
                //resultTable.Rows.Add(row);

                //Get Measurements
                IDbCommand commandMeasurements = connection.Connection.CreateCommand();
                commandMeasurements.CommandType = CommandType.Text;
                commandMeasurements.CommandText = "Select DeviceID, SignalID, PointID, PointTag, SignalReference, SignalAcronym, Description, SignalName, EngineeringUnits, HistorianAcronym From MeasurementDetail Where NodeID = @nodeID AND SignalAcronym <> 'STAT' Order By SignalReference";
                if (commandMeasurements.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    commandMeasurements.Parameters.Add(AddWithValue(commandMeasurements, "@nodeID", "{" + nodeID + "}"));
                else
                    commandMeasurements.Parameters.Add(AddWithValue(commandMeasurements, "@nodeID", nodeID));

                resultTable = new DataTable();
                resultSet.Tables.Add(resultTable);
                resultTable.Load(commandMeasurements.ExecuteReader());

                resultSet.Tables[0].TableName = "PdcTable";
                resultSet.Tables[1].TableName = "DeviceTable";
                resultSet.Tables[2].TableName = "MeasurementTable";

                //Instead of adding row few lines above, we will perform this check and then add it.
                if (resultTable.Select("DeviceID IS NULL").Count() > 0)
                {
                    resultSet.Tables["DeviceTable"].Rows.Add(row);
                }

                deviceMeasurementDataList = (from pdc in resultSet.Tables["PdcTable"].AsEnumerable()
                                             select new DeviceMeasurementData()
                                             {
                                                 ID = pdc.ConvertField<int>("ID"),
                                                 Acronym = string.IsNullOrEmpty(pdc.Field<string>("Acronym")) ? "DIRECT CONNECTED" : pdc.Field<string>("Acronym"),
                                                 Name = pdc.Field<string>("Name"),
                                                 CompanyName = pdc.Field<string>("CompanyName"),
                                                 StatusColor = string.IsNullOrEmpty(pdc.Field<string>("Acronym")) ? "Transparent" : "Gray",
                                                 Enabled = Convert.ToBoolean(pdc.Field<object>("Enabled")),
                                                 IsExpanded = false,
                                                 DeviceList = new ObservableCollection<DeviceInfo>((from device in resultSet.Tables["DeviceTable"].AsEnumerable()
                                                                                                    where device.Field<string>("ParentAcronym") == pdc.Field<string>("Acronym")
                                                                                                    select new DeviceInfo()
                                                                                                    {
                                                                                                        ID = device.ConvertNullableField<int>("ID"),
                                                                                                        Acronym = device.Field<string>("Acronym"),
                                                                                                        Name = device.Field<string>("Name"),
                                                                                                        CompanyName = device.Field<string>("CompanyName"),
                                                                                                        ProtocolName = device.Field<string>("ProtocolName"),
                                                                                                        VendorDeviceName = device.Field<string>("VendorDeviceName"),
                                                                                                        ParentAcronym = string.IsNullOrEmpty(device.Field<string>("ParentAcronym")) ? "DIRECT CONNECTED" : device.Field<string>("ParentAcronym"),
                                                                                                        IsExpanded = false,
                                                                                                        StatusColor = device.ConvertNullableField<int>("ID") == null ? "Transparent" : "Gray",
                                                                                                        Enabled = Convert.ToBoolean(device.Field<object>("Enabled")),
                                                                                                        MeasurementList = new ObservableCollection<MeasurementInfo>((from measurement in resultSet.Tables["MeasurementTable"].AsEnumerable()
                                                                                                                                                                     where measurement.ConvertNullableField<int>("DeviceID") == device.ConvertNullableField<int>("ID")
                                                                                                                                                                     select new MeasurementInfo()
                                                                                                                                                                     {
                                                                                                                                                                         DeviceID = measurement.ConvertNullableField<int>("DeviceID"),
                                                                                                                                                                         SignalID = measurement.Field<object>("SignalID").ToString(),
                                                                                                                                                                         PointID = measurement.ConvertField<int>("PointID"),
                                                                                                                                                                         PointTag = measurement.Field<string>("PointTag"),
                                                                                                                                                                         SignalReference = measurement.Field<string>("SignalReference"),
                                                                                                                                                                         SignalAcronym = measurement.Field<string>("SignalAcronym"),
                                                                                                                                                                         Description = measurement.Field<string>("description"),
                                                                                                                                                                         SignalName = measurement.Field<string>("SignalName"),
                                                                                                                                                                         EngineeringUnits = measurement.Field<string>("EngineeringUnits"),
                                                                                                                                                                         HistorianAcronym = measurement.Field<string>("HistorianAcronym"),
                                                                                                                                                                         IsExpanded = false,
                                                                                                                                                                         CurrentTimeTag = "N/A",
                                                                                                                                                                         CurrentValue = "--",
                                                                                                                                                                         CurrentQuality = "N/A"
                                                                                                                                                                     }).ToList())
                                                                                                    }).ToList())
                                             }).ToList();

                return new ObservableCollection<DeviceMeasurementData>(deviceMeasurementDataList);
            }

            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Statistics Hierarchy Code"

        /// <summary>
        /// Gets the statistic info list used by statistic load functions.
        /// </summary>
        /// <param name="database">The database connection used to retrieve the statistic info list.</param>
        /// <param name="deviceID">The ID of the device to which the statistics are associated.</param>
        /// <returns>A list containing <see cref="DetailStatisticInfo"/> objects that were retrieved from the database.</returns>
        public static List<DetailStatisticInfo> GetStatisticInfoList(DataConnection connection, int deviceID)
        {
            return GetStatisticInfoList(connection, null)
                .Where(statistic => statistic.DeviceID == deviceID)
                .ToList();
        }

        /// <summary>
        /// Gets the statistic info list used by statistic load functions.
        /// </summary>
        /// <param name="database">The database connection used to retrieve the statistic info list.</param>
        /// <param name="nodeID">The ID of the node to which the statistics are associated.</param>
        /// <returns>A list containing <see cref="DetailStatisticInfo"/> objects that were retrieved from the database.</returns>
        public static List<DetailStatisticInfo> GetStatisticInfoList(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;

            try
            {
                DataTable statisticMeasurements;
                DataTable statisticDefinitions;
                Func<DataRow, KeyValuePair<DataRow, string>> mapFunction;
                Func<KeyValuePair<DataRow, string>, DetailStatisticInfo> selectFunction;

                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //****************************************************************************
                //Third, we need to get statistics measurements from Measurement table, statistic definition from Statistic table. Create relationship between those two.
                //Then create parent child relationship to above two datatables.
                IDbCommand commandMeasurements = connection.Connection.CreateCommand();
                commandMeasurements.CommandType = CommandType.Text;
                if (nodeID == null)
                {
                    commandMeasurements.CommandText = "Select DeviceID, PointID, PointTag, SignalReference From StatisticMeasurement Order By SignalReference";
                }
                else
                {
                    commandMeasurements.CommandText = "Select DeviceID, PointID, PointTag, SignalReference From StatisticMeasurement Where NodeID = @nodeID Order By SignalReference";
                    if (commandMeasurements.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        commandMeasurements.Parameters.Add(AddWithValue(commandMeasurements, "@nodeID", "{" + nodeID + "}"));
                    else
                        commandMeasurements.Parameters.Add(AddWithValue(commandMeasurements, "@nodeID", nodeID));
                }

                statisticMeasurements = new DataTable("StatisticMeasurements");
                statisticMeasurements.Load(commandMeasurements.ExecuteReader());
                //****************************************************************************

                //****************************************************************************
                //Get Statistic definitions.
                IDbCommand commandStatistics = connection.Connection.CreateCommand();
                commandStatistics.CommandType = CommandType.Text;
                commandStatistics.CommandText = "Select Source, SignalIndex, Name, Description, DataType, DisplayFormat, IsConnectedState, LoadOrder From Statistic Order By Source, SignalIndex";
                statisticDefinitions = new DataTable("StatisticDefinitions");
                statisticDefinitions.Load(commandStatistics.ExecuteReader());
                //****************************************************************************

                // Map function is used to map statistic measurements to their source.
                mapFunction = measurement =>
                {
                    string signalReference = measurement.Field<string>("SignalReference");
                    string measurementSource = signalReference.Contains("!IS") ? "InputStream" : signalReference.Contains("!OS") ? "OutputStream" : "Device";
                    return new KeyValuePair<DataRow, string>(measurement, measurementSource);
                };

                // Select function is used to create DetailStatisticInfo objects from the DataRows obtained from the database.
                selectFunction = keyValuePair =>
                {
                    DataRow measurement;
                    DataRow statistic;
                    string signalReference;
                    string measurementSource;
                    int measurementIndex;

                    measurement = keyValuePair.Key;
                    measurementSource = keyValuePair.Value;
                    signalReference = measurement.Field<string>("SignalReference");
                    measurementIndex = Convert.ToInt32(signalReference.Substring(signalReference.LastIndexOf("-ST") + 3));

                    statistic = statisticDefinitions.Rows.Cast<DataRow>().Single(row =>
                    {
                        bool sameSource = row.Field<string>("Source") == measurementSource;
                        bool sameIndex = row.ConvertField<int>("SignalIndex") == measurementIndex;
                        return sameSource && sameIndex;
                    });

                    return new DetailStatisticInfo()
                    {
                        DeviceID = Convert.ToInt32(measurement.Field<object>("DeviceID") ?? -1),
                        PointID = Convert.ToInt32(measurement.Field<object>("PointID")),
                        PointTag = measurement.Field<string>("PointTag"),
                        SignalReference = signalReference,
                        Statistics = new BasicStatisticInfo()
                        {
                            Source = measurementSource,
                            Name = statistic.Field<string>("Name"),
                            Description = statistic.Field<string>("Description"),
                            Quality = "N/A",
                            TimeTag = "N/A",
                            Value = "--",
                            DataType = statistic.Field<object>("DataType").ToNonNullString(),
                            DisplayFormat = statistic.Field<object>("DisplayFormat").ToNonNullString(),
                            IsConnectedState = Convert.ToBoolean(statistic.Field<object>("IsConnectedState")),
                            LoadOrder = Convert.ToInt32(statistic.Field<object>("LoadOrder"))
                        }
                    };
                };

                return statisticMeasurements.Rows.Cast<DataRow>()
                    .Select(mapFunction)
                    .OrderBy(pair => pair.Value)
                    .Select(selectFunction)
                    .ToList();
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<StatisticMeasurementData> GetStatisticMeasurementData(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<StatisticMeasurementData> staticMeasurementDataList = new ObservableCollection<StatisticMeasurementData>();
                ObservableCollection<StreamInfo> inputStreamInfoList = new ObservableCollection<StreamInfo>();
                ObservableCollection<StreamInfo> outputStreamInfoList = new ObservableCollection<StreamInfo>();

                DataSet resultSet = new DataSet();
                resultSet.EnforceConstraints = false;
                DataTable resultTable;

                //****************************************************************************
                //First get all the PDC devices and directly connected devices. These are our input stream devices.                
                IDbCommand commandPdc = connection.Connection.CreateCommand();
                commandPdc.CommandType = CommandType.Text;
                commandPdc.CommandText = "Select ID, Acronym, Name From DeviceDetail Where NodeID = @nodeID AND (IsConcentrator = @isConcentrator OR ParentAcronym = @parentAcronym) Order By Acronym";
                if (commandPdc.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    commandPdc.Parameters.Add(AddWithValue(commandPdc, "@nodeID", "{" + nodeID + "}"));
                else
                    commandPdc.Parameters.Add(AddWithValue(commandPdc, "@nodeID", nodeID));
                commandPdc.Parameters.Add(AddWithValue(commandPdc, "@isConcentrator", true));
                commandPdc.Parameters.Add(AddWithValue(commandPdc, "@parentAcronym", string.Empty));

                resultTable = new DataTable("InputStreamDevices");
                resultSet.Tables.Add(resultTable);
                resultTable.Load(commandPdc.ExecuteReader());
                //****************************************************************************

                //****************************************************************************                
                //Second, get all the Devices that are connected to PDC. These devices are part of input stream coming from other PDCs.
                IDbCommand commandDevices = connection.Connection.CreateCommand();
                commandDevices.CommandType = CommandType.Text;
                commandDevices.CommandText = "Select ID, Acronym, Name, ParentID From DeviceDetail Where NodeID = @nodeID AND IsConcentrator = @isConcentrator AND ParentID > 0 Order By Acronym";
                if (commandDevices.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    commandDevices.Parameters.Add(AddWithValue(commandDevices, "@nodeID", "{" + nodeID + "}"));
                else
                    commandDevices.Parameters.Add(AddWithValue(commandDevices, "@nodeID", nodeID));
                commandDevices.Parameters.Add(AddWithValue(commandDevices, "@isConcentrator", false));

                resultTable = new DataTable("PdcDevices");
                resultSet.Tables.Add(resultTable);
                resultTable.Load(commandDevices.ExecuteReader());
                //****************************************************************************

                //****************************************************************************
                //Get Output Stream information.
                IDbCommand commandOutputStream = connection.Connection.CreateCommand();
                commandOutputStream.CommandType = CommandType.Text;
                commandOutputStream.CommandText = "Select ID, Acronym, Name From OutputStream Where NodeID = @nodeID Order By Acronym";
                if (commandOutputStream.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    commandOutputStream.Parameters.Add(AddWithValue(commandOutputStream, "@nodeID", "{" + nodeID + "}"));
                else
                    commandOutputStream.Parameters.Add(AddWithValue(commandOutputStream, "@nodeID", nodeID));

                resultTable = new DataTable("OutputStreams");
                resultSet.Tables.Add(resultTable);
                resultTable.Load(commandOutputStream.ExecuteReader());
                //****************************************************************************

                List<DetailStatisticInfo> statisticInfoList = GetStatisticInfoList(connection, nodeID);

                //****************************************************************************

                inputStreamInfoList = new ObservableCollection<StreamInfo>((from inputDevice in resultSet.Tables["InputStreamDevices"].AsEnumerable()
                                                                            select new StreamInfo()
                                                                            {
                                                                                ID = Convert.ToInt32(inputDevice.Field<object>("ID")),
                                                                                Acronym = inputDevice.Field<string>("Acronym"),
                                                                                Name = inputDevice.Field<string>("Name"),
                                                                                StatusColor = "Gray",
                                                                                StatisticList = new ObservableCollection<DetailStatisticInfo>((from statistic in statisticInfoList
                                                                                                                                               where statistic.DeviceID == Convert.ToInt32(inputDevice.Field<object>("ID"))
                                                                                                                                               select statistic).ToList().OrderBy(o => o.Statistics.Source).ThenBy(o => o.Statistics.LoadOrder).ToList()),
                                                                                DeviceStatisticList = new ObservableCollection<DeviceStatistic>((from pdcDevice in resultSet.Tables["PdcDevices"].AsEnumerable()
                                                                                                                                                 where Convert.ToInt32(pdcDevice.Field<object>("ParentID")) == Convert.ToInt32(inputDevice.Field<object>("ID"))
                                                                                                                                                 select new DeviceStatistic()
                                                                                                                                                 {
                                                                                                                                                     ID = Convert.ToInt32(pdcDevice.Field<object>("ID")),
                                                                                                                                                     Acronym = pdcDevice.Field<string>("Acronym"),
                                                                                                                                                     Name = pdcDevice.Field<string>("Name"),
                                                                                                                                                     StatisticList = new ObservableCollection<DetailStatisticInfo>((from statistic in statisticInfoList
                                                                                                                                                                                                                    where statistic.DeviceID == Convert.ToInt32(pdcDevice.Field<object>("ID"))
                                                                                                                                                                                                                    select statistic
                                                                                                                                                                     ).ToList().OrderBy(o => o.Statistics.LoadOrder).ToList())
                                                                                                                                                 }).ToList())
                                                                            }).ToList());

                foreach (StreamInfo inputStreamDevice in inputStreamInfoList)
                {
                    inputStreamDevice.DeviceStatisticList.Insert(0, new DeviceStatistic()
                    {
                        ID = 0,
                        Acronym = "Run-Time Statistics",
                        Name = "",
                        StatisticList = new ObservableCollection<DetailStatisticInfo>(inputStreamDevice.StatisticList)
                    });
                    inputStreamDevice.StatisticList = null;  //since this is moved to dummy device above "Run-Time Statistics", we don't need it anymore.
                }

                staticMeasurementDataList.Add(new StatisticMeasurementData()
                {
                    SourceType = "Input Streams",
                    SourceStreamInfoList = new ObservableCollection<StreamInfo>(inputStreamInfoList)
                });
                //****************************************************************************

                //****************************************************************************
                //Now create a list for output steams.
                outputStreamInfoList = new ObservableCollection<StreamInfo>((from outputDevice in resultSet.Tables["OutputStreams"].AsEnumerable()
                                                                             select new StreamInfo()
                                                                             {
                                                                                 ID = Convert.ToInt32(outputDevice.Field<object>("ID")),
                                                                                 Acronym = outputDevice.Field<string>("Acronym"),
                                                                                 Name = outputDevice.Field<string>("Name"),
                                                                                 StatusColor = "Gray",
                                                                                 StatisticList = new ObservableCollection<DetailStatisticInfo>((from statistic in statisticInfoList
                                                                                                                                                where statistic.SignalReference.StartsWith(outputDevice.Field<string>("Acronym") + "!")
                                                                                                                                                select statistic).ToList().OrderBy(o => o.Statistics.Source).ThenBy(o => o.Statistics.LoadOrder).ToList()),
                                                                                 DeviceStatisticList = new ObservableCollection<DeviceStatistic>()
                                                                             }).ToList());

                foreach (StreamInfo outputStreamDevice in outputStreamInfoList)
                {
                    outputStreamDevice.DeviceStatisticList.Insert(0, new DeviceStatistic()
                    {
                        ID = 0,
                        Acronym = "Run-Time Statistics",
                        Name = "",
                        StatisticList = new ObservableCollection<DetailStatisticInfo>(outputStreamDevice.StatisticList)
                    });
                    outputStreamDevice.StatisticList = null;
                }
                staticMeasurementDataList.Add(new StatisticMeasurementData()
                {
                    SourceType = "Output Streams",
                    SourceStreamInfoList = outputStreamInfoList
                });

                return staticMeasurementDataList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, BasicStatisticInfo> GetBasicStatisticInfoList(DataConnection connection, string nodeID)
        {
            return GetStatisticInfoList(connection, nodeID).ToDictionary(statistic => statistic.PointID, statistic => statistic.Statistics);
        }

        public static ObservableCollection<DetailStatisticInfo> GetDeviceStatisticMeasurements(DataConnection connection, int deviceID)
        {
            try
            {
                return new ObservableCollection<DetailStatisticInfo>(GetStatisticInfoList(connection, deviceID));
            }
            catch (Exception ex)
            {
                LogException(connection, "GetDeviceStatisticMeasurements", ex);
                return new ObservableCollection<DetailStatisticInfo>();
            }
        }

        //This function returns DeviceID with Statistic Measurement PointID which is used to check device status (green or red).
        public static Dictionary<int, int> GetDeviceIDsWithStatusPointIDs(DataConnection connection, string nodeID)
        {
            Dictionary<int, int> deviceIdsWithStatusPointIDs = new Dictionary<int, int>();
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Device> deviceList = GetDeviceList(connection, nodeID);
                foreach (Device device in deviceList)
                {
                    int deviceIDToLookFor;
                    if (device.ParentID == null)
                        deviceIDToLookFor = device.ID;
                    else
                        deviceIDToLookFor = (int)device.ParentID;
                    ObservableCollection<DetailStatisticInfo> detailStatisticsList = GetDeviceStatisticMeasurements(connection, deviceIDToLookFor);
                    foreach (DetailStatisticInfo detailStatistic in detailStatisticsList)
                    {
                        if (detailStatistic.Statistics.IsConnectedState && !deviceIdsWithStatusPointIDs.ContainsKey(deviceIDToLookFor))
                            deviceIdsWithStatusPointIDs.Add(device.ID, detailStatistic.PointID);
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(connection, "GetDeviceIDsWithStatusPointIDs", ex);
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }

            return deviceIdsWithStatusPointIDs;
        }

        #endregion

        #region " Application Security Code"

        #region " User Management Code"

        public static List<User> GetUsers(DataConnection connection)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<User> users = new List<User>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From UserAccount Order By Name";

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                users = (from item in resultTable.AsEnumerable()
                         select new User()
                         {
                             ID = item.Field<object>("ID").ToString(),
                             Name = item.Field<string>("Name"),
                             Password = item.Field<object>("Password") == null ? string.Empty : item.Field<string>("Password"),
                             FirstName = item.Field<object>("FirstName") == null ? string.Empty : item.Field<string>("FirstName"),
                             LastName = item.Field<object>("LastName") == null ? string.Empty : item.Field<string>("LastName"),
                             DefaultNodeID = item.Field<object>("DefaultNodeID").ToString(),
                             Phone = item.Field<object>("Phone") == null ? string.Empty : item.Field<string>("Phone"),
                             Email = item.Field<object>("Email") == null ? string.Empty : item.Field<string>("Email"),
                             LockedOut = Convert.ToBoolean(item.Field<object>("LockedOut")),
                             UseADAuthentication = Convert.ToBoolean(item.Field<object>("UseADAuthentication")),
                             ChangePasswordOn = item.Field<object>("ChangePasswordOn") == null ? DateTime.MinValue : Convert.ToDateTime(item.Field<object>("ChangePasswordOn")),
                             CreatedOn = Convert.ToDateTime(item.Field<object>("CreatedOn")),
                             CreatedBy = item.Field<string>("CreatedBy"),
                             UpdatedOn = Convert.ToDateTime(item.Field<object>("UpdatedOn")),
                             UpdatedBy = item.Field<string>("UpdatedBy")
                         }).ToList();

                return users;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveUser(DataConnection connection, User user, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.CommandText = "Insert Into UserAccount (Name, [Password], FirstName, LastName, DefaultNodeID, Phone, Email, LockedOut, UseADAuthentication, ChangePasswordOn, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                            "Values (@name, @password, @firstName, @lastName, @defaultNodeID, @phone, @email, @lockedOut, @useADAuthentication, @changePasswordOn, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                    else
                        command.CommandText = "Insert Into UserAccount (Name, Password, FirstName, LastName, DefaultNodeID, Phone, Email, LockedOut, UseADAuthentication, ChangePasswordOn, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
                            "Values (@name, @password, @firstName, @lastName, @defaultNodeID, @phone, @email, @lockedOut, @useADAuthentication, @changePasswordOn, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.CommandText = "Update UserAccount Set Name = @name, [Password] = @password, FirstName = @firstName, LastName = @lastName, DefaultNodeID = @defaultNodeID, Phone = @phone, " +
                            "Email = @email, LockedOut = @lockedOut, UseADAuthentication = @useADAuthentication, ChangePasswordOn = @changePasswordOn, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";
                    else
                        command.CommandText = "Update UserAccount Set Name = @name, Password = @password, FirstName = @firstName, LastName = @lastName, DefaultNodeID = @defaultNodeID, Phone = @phone, Email = @email, " +
                            "LockedOut = @lockedOut, UseADAuthentication = @useADAuthentication, ChangePasswordOn = @changePasswordOn, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@name", user.Name));
                command.Parameters.Add(AddWithValue(command, "@password", user.Password));
                command.Parameters.Add(AddWithValue(command, "@firstName", user.FirstName));
                command.Parameters.Add(AddWithValue(command, "@lastName", user.LastName));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@defaultNodeID", "{" + user.DefaultNodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@defaultNodeID", user.DefaultNodeID));
                command.Parameters.Add(AddWithValue(command, "@phone", user.Phone));
                command.Parameters.Add(AddWithValue(command, "@email", user.Email));
                command.Parameters.Add(AddWithValue(command, "@lockedOut", user.LockedOut));
                command.Parameters.Add(AddWithValue(command, "@useADAuthentication", user.UseADAuthentication));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@changePasswordOn", user.ChangePasswordOn == DateTime.MinValue ? DateTime.UtcNow.Date : user.ChangePasswordOn.Date));
                else
                    command.Parameters.Add(AddWithValue(command, "@changePasswordOn", user.ChangePasswordOn == DateTime.MinValue ? (object)DBNull.Value : user.ChangePasswordOn));

                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                {
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                        command.Parameters.Add(AddWithValue(command, "@id", "{" + user.ID + "}"));
                    else
                        command.Parameters.Add(AddWithValue(command, "@id", user.ID));
                }

                command.ExecuteNonQuery();

                return "User Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteUser(DataConnection connection, string userID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From UserAccount Where ID = @id";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@id", "{" + userID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@id", userID));

                command.ExecuteNonQuery();

                return "User Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Group Management Code"

        public static List<Group> GetGroups(DataConnection connection)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Group> groups = new List<Group>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From SecurityGroup Order By Name";

                DataTable groupsTable = new DataTable();
                groupsTable.Load(command.ExecuteReader());

                groups = (from groupitem in groupsTable.AsEnumerable()
                          select new Group()
                          {
                              ID = groupitem.Field<object>("ID").ToString(),
                              Name = groupitem.Field<string>("Name"),
                              Description = groupitem.Field<object>("Description") == null ? string.Empty : groupitem.Field<string>("Description"),
                              CreatedOn = Convert.ToDateTime(groupitem.Field<object>("CreatedOn")),
                              CreatedBy = groupitem.Field<string>("CreatedBy"),
                              UpdatedOn = Convert.ToDateTime(groupitem.Field<object>("UpdatedOn")),
                              UpdatedBy = groupitem.Field<string>("UpdatedBy")
                          }).ToList();

                return groups;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveGroup(DataConnection connection, Group group, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into SecurityGroup (Name, Description, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values (@name, @description, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update SecurityGroup Set Name = @name, Description = @description, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@name", group.Name));
                command.Parameters.Add(AddWithValue(command, "@description", group.Description));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", group.ID));

                command.ExecuteNonQuery();

                return "Group Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteGroup(DataConnection connection, string groupID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                //Setup current users context for Delete trigger.
                SetCurrentUserContext(connection);

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Delete From SecurityGroup Where ID = @id";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@id", "{" + groupID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@id", groupID));
                command.ExecuteNonQuery();

                return "Group Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static void DeleteGroupUsers(DataConnection connection, string groupID, List<string> userIDsToBeDeleted)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command;
                foreach (string userID in userIDsToBeDeleted)
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Delete From SecurityGroupUserAccount Where SecurityGroupID = @groupID AND UserAccountID = @userID";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    {
                        command.Parameters.Add(AddWithValue(command, "@groupID", "{" + groupID + "}"));
                        command.Parameters.Add(AddWithValue(command, "@userID", "{" + userID + "}"));
                    }
                    else
                    {
                        command.Parameters.Add(AddWithValue(command, "@groupID", groupID));
                        command.Parameters.Add(AddWithValue(command, "@userID", userID));
                    }
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static void AddGroupUsers(DataConnection connection, string groupID, List<string> userIDsToBeAdded)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command;
                foreach (string userID in userIDsToBeAdded)
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Insert Into SecurityGroupUserAccount (SecurityGroupID, UserAccountID) Values (@groupID, @userID)";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    {
                        command.Parameters.Add(AddWithValue(command, "@groupID", "{" + groupID + "}"));
                        command.Parameters.Add(AddWithValue(command, "@userID", "{" + userID + "}"));
                    }
                    else
                    {
                        command.Parameters.Add(AddWithValue(command, "@groupID", groupID));
                        command.Parameters.Add(AddWithValue(command, "@userID", userID));
                    }
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<User> GetPossibleGroupUsers(DataConnection connection, string groupID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<User> users = new ObservableCollection<User>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From UserAccount WHERE ID NOT IN (Select UserAccountID From SecurityGroupUserAccount Where SecurityGroupID = @groupID) Order By Name";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@groupID", "{" + groupID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@groupID", groupID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                users = new ObservableCollection<User>((from item in resultTable.AsEnumerable()
                                                        select new User()
                                                        {
                                                            ID = item.Field<object>("ID").ToString(),
                                                            Name = item.Field<string>("Name"),
                                                            FirstName = item.Field<object>("FirstName") == null ? string.Empty : item.Field<string>("FirstName"),
                                                            LastName = item.Field<object>("LastName") == null ? string.Empty : item.Field<string>("LastName"),
                                                            Email = item.Field<object>("Email") == null ? string.Empty : item.Field<string>("Email")
                                                        }));

                return users;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<User> GetCurrentGroupUsers(DataConnection connection, string groupID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<User> users = new ObservableCollection<User>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From SecurityGroupUserAccountDetail WHERE SecurityGroupID = @groupID Order By UserName";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@groupID", "{" + groupID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@groupID", groupID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                users = new ObservableCollection<User>((from item in resultTable.AsEnumerable()
                                                        select new User()
                                                        {
                                                            ID = item.Field<object>("UserAccountID").ToString(),
                                                            Name = item.Field<string>("UserName"),
                                                            FirstName = item.Field<object>("FirstName") == null ? string.Empty : item.Field<string>("FirstName"),
                                                            LastName = item.Field<object>("LastName") == null ? string.Empty : item.Field<string>("LastName"),
                                                            Email = item.Field<object>("Email") == null ? string.Empty : item.Field<string>("Email")
                                                        }));
                return users;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #region " Role Management Code"

        public static List<Role> GetRoles(DataConnection connection, string nodeID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                List<Role> roles = new List<Role>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From ApplicationRole Where NodeID = @nodeID Order By Name";

                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + nodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", nodeID));

                DataTable rolesTable = new DataTable();
                rolesTable.Load(command.ExecuteReader());

                roles = (from roleitem in rolesTable.AsEnumerable()
                         select new Role()
                         {
                             ID = roleitem.Field<object>("ID").ToString(),
                             Name = roleitem.Field<string>("Name"),
                             Description = roleitem.Field<object>("Description") == null ? string.Empty : roleitem.Field<string>("Description"),
                             NodeID = roleitem.Field<object>("NodeID").ToString(),
                             CreatedOn = Convert.ToDateTime(roleitem.Field<object>("CreatedOn")),
                             CreatedBy = roleitem.Field<string>("CreatedBy"),
                             UpdatedOn = Convert.ToDateTime(roleitem.Field<object>("UpdatedOn")),
                             UpdatedBy = roleitem.Field<string>("UpdatedBy")
                         }).ToList();

                return roles;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string SaveRole(DataConnection connection, Role role, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;

                if (isNew)
                    command.CommandText = "Insert Into ApplicationRole (Name, Description, NodeID, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values (@name, @description, @nodeID, @updatedBy, @updatedOn, @createdBy, @createdOn)";
                else
                    command.CommandText = "Update ApplicationRole Set Name = @name, Description = @description, NodeID = @nodeID, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn Where ID = @id";

                command.Parameters.Add(AddWithValue(command, "@name", role.Name));
                command.Parameters.Add(AddWithValue(command, "@description", role.Description));
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@nodeID", "{" + role.NodeID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@nodeID", role.NodeID));
                command.Parameters.Add(AddWithValue(command, "@updatedBy", s_currentUser));
                command.Parameters.Add(AddWithValue(command, "@updatedOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));

                if (isNew)
                {
                    command.Parameters.Add(AddWithValue(command, "@createdBy", s_currentUser));
                    command.Parameters.Add(AddWithValue(command, "@createdOn", command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB") ? DateTime.UtcNow.Date : DateTime.UtcNow));
                }
                else
                    command.Parameters.Add(AddWithValue(command, "@id", role.ID));

                command.ExecuteNonQuery();

                return "Role Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static void DeleteRoleUsers(DataConnection connection, string applicationRoleID, List<string> userIDsToBeDeleted)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command;
                foreach (string userID in userIDsToBeDeleted)
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Delete From ApplicationRoleUserAccount Where ApplicationRoleID = @applicationRoleID AND UserAccountID = @userID";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                        command.Parameters.Add(AddWithValue(command, "@userID", "{" + userID + "}"));
                    }
                    else
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));
                        command.Parameters.Add(AddWithValue(command, "@userID", userID));
                    }
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static void DeleteRoleGroups(DataConnection connection, string applicationRoleID, List<string> groupIDsToBeDeleted)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command;
                foreach (string groupID in groupIDsToBeDeleted)
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Delete From ApplicationRoleSecurityGroup Where ApplicationRoleID = @applicationRoleID AND SecurityGroupID = @groupID";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                        command.Parameters.Add(AddWithValue(command, "@groupID", "{" + groupID + "}"));
                    }
                    else
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));
                        command.Parameters.Add(AddWithValue(command, "@groupID", groupID));
                    }
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static void AddRoleUsers(DataConnection connection, string applicationRoleID, List<string> userIDsToBeAdded)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command;
                foreach (string userID in userIDsToBeAdded)
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Insert Into ApplicationRoleUserAccount (ApplicationRoleID, UserAccountID) Values (@applicationRoleID, @userID)";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                        command.Parameters.Add(AddWithValue(command, "@userID", "{" + userID + "}"));
                    }
                    else
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));
                        command.Parameters.Add(AddWithValue(command, "@userID", userID));
                    }
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static void AddRoleGroups(DataConnection connection, string applicationRoleID, List<string> groupIDsToBeAdded)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }

                IDbCommand command;
                foreach (string groupID in groupIDsToBeAdded)
                {
                    command = connection.Connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Insert Into ApplicationRoleSecurityGroup (ApplicationRoleID, SecurityGroupID) Values (@applicationRoleID, @groupID)";
                    if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                        command.Parameters.Add(AddWithValue(command, "@groupID", "{" + groupID + "}"));
                    }
                    else
                    {
                        command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));
                        command.Parameters.Add(AddWithValue(command, "@groupID", groupID));
                    }
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<User> GetPossibleRoleUsers(DataConnection connection, string applicationRoleID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<User> users = new ObservableCollection<User>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From UserAccount WHERE ID NOT IN (Select UserAccountID From ApplicationRoleUserAccount Where ApplicationRoleID = @applicationRoleID) Order By Name";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                users = new ObservableCollection<User>((from item in resultTable.AsEnumerable()
                                                        select new User()
                                                        {
                                                            ID = item.Field<object>("ID").ToString(),
                                                            Name = item.Field<string>("Name"),
                                                            FirstName = item.Field<object>("FirstName") == null ? string.Empty : item.Field<string>("FirstName"),
                                                            LastName = item.Field<object>("LastName") == null ? string.Empty : item.Field<string>("LastName"),
                                                            Email = item.Field<object>("Email") == null ? string.Empty : item.Field<string>("Email")
                                                        }));

                return users;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<User> GetCurrentRoleUsers(DataConnection connection, string applicationRoleID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<User> users = new ObservableCollection<User>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From AppRoleUserAccountDetail WHERE ApplicationRoleID = @applicationRoleID Order By UserName";


                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                users = new ObservableCollection<User>((from item in resultTable.AsEnumerable()
                                                        select new User()
                                                        {
                                                            ID = item.Field<object>("UserAccountID").ToString(),
                                                            Name = item.Field<string>("UserName"),
                                                            FirstName = item.Field<object>("FirstName") == null ? string.Empty : item.Field<string>("FirstName"),
                                                            LastName = item.Field<object>("LastName") == null ? string.Empty : item.Field<string>("LastName"),
                                                            Email = item.Field<object>("Email") == null ? string.Empty : item.Field<string>("Email")
                                                        }));
                return users;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<Group> GetPossibleRoleGroups(DataConnection connection, string applicationRoleID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<Group> groups = new ObservableCollection<Group>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From SecurityGroup WHERE ID NOT IN (Select SecurityGroupID From ApplicationRoleSecurityGroup Where ApplicationRoleID = @applicationRoleID) Order By Name";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                groups = new ObservableCollection<Group>((from item in resultTable.AsEnumerable()
                                                          select new Group()
                                                          {
                                                              ID = item.Field<object>("ID").ToString(),
                                                              Name = item.Field<string>("Name")
                                                          }));
                return groups;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<Group> GetCurrentRoleGroups(DataConnection connection, string applicationRoleID)
        {
            bool createdConnection = false;
            try
            {
                if (connection == null)
                {
                    connection = new DataConnection();
                    createdConnection = true;
                }
                ObservableCollection<Group> groups = new ObservableCollection<Group>();

                IDbCommand command = connection.Connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "Select * From AppRoleSecurityGroupDetail WHERE ApplicationRoleID = @applicationRoleID Order By SecurityGroupName";
                if (command.Connection.ConnectionString.Contains("Microsoft.Jet.OLEDB"))
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", "{" + applicationRoleID + "}"));
                else
                    command.Parameters.Add(AddWithValue(command, "@applicationRoleID", applicationRoleID));

                DataTable resultTable = new DataTable();
                resultTable.Load(command.ExecuteReader());
                groups = new ObservableCollection<Group>((from item in resultTable.AsEnumerable()
                                                          select new Group()
                                                          {
                                                              ID = item.Field<object>("SecurityGroupID").ToString(),
                                                              Name = item.Field<string>("SecurityGroupName")
                                                          }));
                return groups;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion

        #endregion
    }
}
