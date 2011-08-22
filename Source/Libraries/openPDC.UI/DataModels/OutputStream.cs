//******************************************************************************************************
//  OutputStream.cs - Gbtc
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
//  07/26/2011 - Magdiel Lorenzo
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSeriesFramework.UI;
using System.Collections.ObjectModel;
using TVA.Data;
using System.Data;
using System.IO;
using openPDCManager.UI.SqlScripts;
using TimeSeriesFramework.UI.DataModels;

namespace openPDCManager.UI.DataModels
{
    public class OutputStream : DataModelBase
    {
        #region [ Members ]

        private Guid m_nodeID;
        private int m_ID;
        private string m_acronym;        
        private string m_name;
        private int m_type;
        private string m_connectionString;
        private int m_idCode;
        private string m_commandChannel;
        private string m_dataChannel;
        private bool m_autoPublishConfigFrame;
        private bool m_autoStartDataChannel;
        private int m_nominalFrequency;
        private int m_framesPerSecond;
        private double m_lagTime;
        private double m_leadTime;
        private bool m_useLocalClockAsRealTime;
        private bool m_allowSortsByArrival;
        private int m_loadOrder;
        private bool m_enabled;
        private bool m_ignoreBadTimeStamps;
        private int m_timeResolution;
        private bool m_allowPreemptivePublishing;
        private string m_downsamplingMethod;
        private string m_dataFormat;
        private string m_coordinateFormat;
        private int m_currentScalingValue;
        private int m_voltageScalingValue;
        private int m_analogScalingValue;
        private int m_digitalMaskValue;
        private string m_nodeName;
        private string m_typeName;
        private bool m_performTimestampReasonabilityCheck;
        private DateTime m_createdOn;
        private string m_createdBy;
        private DateTime m_updatedOn;
        private string m_updatedBy;
        
        
        #endregion

        #region [ Properties ]
        
        public Guid NodeID
        {
            get
            {
                return m_nodeID;
            }
            set
            {
                m_nodeID = value;
                OnPropertyChanged("NodeID");
            }
        }

        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
                OnPropertyChanged("ID");
            }
        }

        public string Acronym
        {
            get 
            { 
                return m_acronym; 
            }
            set 
            { 
                m_acronym = value;
                OnPropertyChanged("Acronym");
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
                OnPropertyChanged("Type");
            }
        }

        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;
                OnPropertyChanged("ConnectionString");
            }
        }

        public int IDCode
        {
            get
            {
                return m_idCode;
            }
            set
            {
                m_idCode = value;
                OnPropertyChanged("IDCode");
            }
        }

        public string CommandChannel
        {
            get
            {
                return m_commandChannel;
            }
            set
            {
                m_commandChannel = value;
                OnPropertyChanged("CommandChannel");
            }
        }

        public string DataChannel
        {
            get
            {
                return m_dataChannel;
            }
            set
            {
                m_dataChannel = value;
                OnPropertyChanged("DataChannel");
            }
        }

        public bool AutoPublishConfigFrame
        {
            get
            {
                return m_autoPublishConfigFrame;
            }
            set
            {
                m_autoPublishConfigFrame = value;
                OnPropertyChanged("AutoPublishConfigFrame");
            }
        }

        public bool AutoStartDataChannel
        {
            get
            {
                return m_autoStartDataChannel;
            }
            set
            {
                m_autoStartDataChannel = value;
                OnPropertyChanged("AutoStartDataChannel");
            }
        }

        public int NominalFrequency
        {
            get
            {
                return m_nominalFrequency;
            }
            set
            {
                m_nominalFrequency = value;
                OnPropertyChanged("NominalFrequency");
            }
        }

        public int FramesPerSecond
        {
            get
            {
                return m_framesPerSecond;
            }
            set
            {
                m_framesPerSecond = value;
                OnPropertyChanged("FramesPerSecond");
            }
        }

        public double LagTime
        {
            get
            {
                return m_lagTime;
            }
            set
            {
                m_lagTime = value;
                OnPropertyChanged("LagTime");
            }
        }

        public double LeadTime
        {
            get
            {
                return m_leadTime;
            }
            set
            {
                m_leadTime = value;
                OnPropertyChanged("LeadTime");
            }
        }

        public bool UseLocalClockAsRealTime
        {
            get
            {
                return m_useLocalClockAsRealTime;
            }
            set
            {
                m_useLocalClockAsRealTime = value;
                OnPropertyChanged("UseLocalClockAsRealTime");
            }
        }

        public bool AllowSortsByArrival
        {
            get
            {
                return m_allowSortsByArrival;
            }
            set
            {
                m_allowSortsByArrival = value;
                OnPropertyChanged("AllowSortsByArrival");
            }
        }

        public int LoadOrder
        {
            get
            {
                return m_loadOrder;
            }
            set
            {
                m_loadOrder = value;
                OnPropertyChanged("LoadOrder");
            }
        }

        public bool Enabled
        {
            get
            {
                return m_enabled;
            }
            set
            {
                m_enabled = value;
                OnPropertyChanged("Enabled");
            }
        }

        public bool IgnoreBadTimeStamps
        {
            get
            {
                return m_ignoreBadTimeStamps;
            }
            set
            {
                m_ignoreBadTimeStamps = value;
                OnPropertyChanged("IgnoreBadTimeStamps");
            }
        }

        public int TimeResolution
        {
            get
            {
                return m_timeResolution;
            }
            set
            {
                m_timeResolution = value;
                OnPropertyChanged("TimeResolution");
            }
        }

        public bool AllowPreemptivePublishing
        {
            get
            {
                return m_allowPreemptivePublishing;
            }
            set
            {
                m_allowPreemptivePublishing = value;
                OnPropertyChanged("AllowPreemptivePublishing");
            }
        }

        public string DownSamplingMethod
        {
            get
            {
                return m_downsamplingMethod;
            }
            set
            {
                m_downsamplingMethod = value;
                OnPropertyChanged("DownSamplingMethod");
            }
        }

        public string DataFormat
        {
            get
            {
                return m_dataFormat;
            }
            set
            {
                m_dataFormat = value;
                OnPropertyChanged("DataFormat");
            }
        }

        public string CoordinateFormat
        {
            get
            {
                return m_coordinateFormat;
            }
            set
            {
                m_coordinateFormat = value;
                OnPropertyChanged("CoordinateFormat");
            }
        }

        public int CurrentScalingValue
        {
            get
            {
                return m_currentScalingValue;
            }
            set
            {
                m_currentScalingValue = value;
                OnPropertyChanged("CurrentScalingValue");
            }
        }

        public int VoltageScalingValue
        {
            get
            {
                return m_voltageScalingValue;
            }
            set
            {
                m_voltageScalingValue = value;
                OnPropertyChanged("VoltageScalingValue");
            }
        }

        public int AnalogScalingValue
        {
            get
            {
                return m_analogScalingValue;
            }
            set
            {
                m_analogScalingValue = value;
                OnPropertyChanged("AnalogScalingValue");
            }
        }

        public int DigitalMaskValue
        {
            get
            {
                return m_digitalMaskValue;
            }
            set
            {
                m_digitalMaskValue = value;
                OnPropertyChanged("DigitalMaskValue");
            }
        }

        public string NodeName
        {
            get
            {
                return m_nodeName;
            }
            set
            {
                m_nodeName = value;
                OnPropertyChanged("NodeName");
            }
        }

        public string TypeName
        {
            get
            {
                return m_typeName;
            }
            set
            {
                m_typeName = value;
                OnPropertyChanged("TypeName");
            }
        }

        public bool PerformTimestampReasonabilityCheck
        {
            get
            {
                return m_performTimestampReasonabilityCheck;
            }
            set
            {
                m_performTimestampReasonabilityCheck = value;
                OnPropertyChanged("PerformTimestampReasonabilityCheck");
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return m_createdOn;
            }
            set
            {
                m_createdOn = value;
                OnPropertyChanged("CreatedOn");
            }
        }

        public string CreatedBy
        {
            get
            {
                return m_createdBy;
            }
            set
            {
                m_createdBy = value;
                OnPropertyChanged("CreatedBy");
            }
        }

        public DateTime UpdatedOn
        {
            get
            {
                return m_updatedOn;
            }
            set
            {
                m_updatedOn = value;
                OnPropertyChanged("UpdatedOn");
            }
        }

        public string UpdatedBy
        {
            get
            {
                return m_updatedBy;
            }
            set
            {
                m_updatedBy = value;
                OnPropertyChanged("UpdatedBy");
            }
        }

        #endregion

        #region [ Static ]

        public static ObservableCollection<OutputStream> Load(AdoDataConnection connection, bool enabledOnly, Guid nodeID)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref connection);

                ObservableCollection<OutputStream> outputStreamList;

                DataTable resultTable;

                if (enabledOnly)
                {
                    resultTable = connection.Connection.RetrieveData(connection.AdapterType, "SELECT * FROM OuputStreamDetail WHERE NodeID = @nodeID AND Enabled = @enabled ORDER BY Load Order", connection.Guid(nodeID), true);
                }
                else
                {
                    resultTable = connection.Connection.RetrieveData(connection.AdapterType, "SELECT * FROM OutputStreamdetail WHERE NodeID = @nodeID ORDER BY LoadOrder", connection.Guid(nodeID));
                }

                outputStreamList = new ObservableCollection<OutputStream>(from item in resultTable.AsEnumerable()
                                                                          select new OutputStream()
                                                                          {
                                                                              NodeID = connection.Guid(item, "NodeID"),
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
                                                                              DownSamplingMethod = item.Field<string>("DownsamplingMethod"),
                                                                              DataFormat = item.Field<string>("DataFormat"),
                                                                              CoordinateFormat = item.Field<string>("CoordinateFormat"),
                                                                              CurrentScalingValue = Convert.ToInt32(item.Field<object>("CurrentScalingValue")),
                                                                              VoltageScalingValue = Convert.ToInt32(item.Field<object>("VoltageScalingValue")),
                                                                              AnalogScalingValue = Convert.ToInt32(item.Field<object>("AnalogScalingValue")),
                                                                              DigitalMaskValue = Convert.ToInt32(item.Field<object>("DigitalMaskValue")),
                                                                              PerformTimestampReasonabilityCheck = Convert.ToBoolean(item.Field<object>("PerformTimestampReasonabilityCheck"))
                                                                          });
                return outputStreamList;

            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string Save(AdoDataConnection connection, OutputStream outputStream, bool isNew)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref connection);

                if (isNew)
                {
                    connection.Connection.ExecuteNonQuery(Scripts.SaveOutputStreamIfNew, connection.Guid(outputStream.NodeID), outputStream.Acronym.Replace(" ", "").ToUpper(), outputStream.Name, outputStream.Type, outputStream.ConnectionString, outputStream.IDCode, outputStream.CommandChannel,
                        outputStream.DataChannel, outputStream.AutoPublishConfigFrame, outputStream.AutoStartDataChannel, outputStream.NominalFrequency, outputStream.FramesPerSecond, outputStream.LagTime, outputStream.LeadTime, outputStream.UseLocalClockAsRealTime,
                        outputStream.AllowSortsByArrival, outputStream.LoadOrder, outputStream.Enabled, outputStream.IgnoreBadTimeStamps, outputStream.TimeResolution, outputStream.AllowPreemptivePublishing, outputStream.DownSamplingMethod, outputStream.DataFormat,
                        outputStream.CoordinateFormat, outputStream.CurrentScalingValue, outputStream.VoltageScalingValue, outputStream.AnalogScalingValue, outputStream.DigitalMaskValue, outputStream.PerformTimestampReasonabilityCheck, CommonFunctions.CurrentUser, connection.UtcNow(), CommonFunctions.CurrentUser, connection.UtcNow());
                }
                else
                {
                    connection.Connection.ExecuteNonQuery(Scripts.SaveOutputStream, connection.Guid(outputStream.NodeID), outputStream.Acronym.Replace(" ", "").ToUpper(), outputStream.Name, outputStream.Type, outputStream.ConnectionString, outputStream.IDCode, outputStream.CommandChannel,
                        outputStream.DataChannel, outputStream.AutoPublishConfigFrame, outputStream.AutoStartDataChannel, outputStream.NominalFrequency, outputStream.FramesPerSecond, outputStream.LagTime, outputStream.LeadTime, outputStream.UseLocalClockAsRealTime,
                        outputStream.AllowSortsByArrival, outputStream.LoadOrder, outputStream.Enabled, outputStream.IgnoreBadTimeStamps, outputStream.TimeResolution, outputStream.AllowPreemptivePublishing, outputStream.DownSamplingMethod, outputStream.DataFormat,
                        outputStream.CoordinateFormat, outputStream.CurrentScalingValue, outputStream.VoltageScalingValue, outputStream.AnalogScalingValue, outputStream.DigitalMaskValue, outputStream.PerformTimestampReasonabilityCheck, CommonFunctions.CurrentUser, connection.UtcNow(), CommonFunctions.CurrentUser, connection.UtcNow());
                }
                return "Output Stream Information Saved Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static Dictionary<int, string> GetLookupList(AdoDataConnection connection, bool isOptional = true)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref connection);

                Dictionary<int, string> osList = new Dictionary<int, string>();

                DataTable results = connection.Connection.RetrieveData(connection.AdapterType, Scripts.LoadOSLookupList, connection.CurrentNodeID());

                foreach (DataRow row in results.Rows)
                    osList[row.ConvertField<int>("ID")] = row.Field<string>("Name");

                return osList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static string DeleteOutputStream(AdoDataConnection connection, int outputStreamID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref connection);

                connection.Connection.ExecuteNonQuery(Scripts.DeleteOutputStream, outputStreamID);

                return "Output Stream Deleted Successfully";
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static OutputStream GetOutputStreamByAcronym(AdoDataConnection connection, string acronym, Guid nodeID)
        {
            try
            {
                List<OutputStream> outputStreamList = new List<OutputStream>();
                outputStreamList = (from item in Load(connection, false, nodeID)
                                    where item.Acronym.ToUpper() == acronym.ToUpper()
                                    select item).ToList();

                if (outputStreamList.Count > 0)
                    return outputStreamList[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(connection, "GetOutputStreamByAcronym", ex);
                return null;
            }
        }

        public static List<Measurement> GetOutputStreamStatistics(AdoDataConnection connection, string outputStreamAcronym)
        {
            try
            {
                List<Measurement> measurementList = new List<Measurement>();
                measurementList = (from item in Measurement.Load(connection)
                                   where item.SignalReference.StartsWith(outputStreamAcronym + "!OS")
                                   select item).ToList();
                return measurementList;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(connection, "GetOutputStreamStatistics", ex);
                return null;
            }
        }

        public static string UpdateOutputStreamStatistics(AdoDataConnection connection, string oldAcronym, string newAcronym, string oldName, string newName)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref connection);

                if (!string.IsNullOrEmpty(oldAcronym) && oldAcronym != newAcronym)
                {
                    List<Measurement> measurementList = GetOutputStreamStatistics(connection, oldAcronym);
                    foreach (Measurement measurement in measurementList)
                    {
                        measurement.SignalReference = measurement.SignalReference.Replace(oldAcronym, newAcronym);
                        measurement.PointTag = measurement.PointTag.Replace(oldAcronym, newAcronym);
                        measurement.Description = System.Text.RegularExpressions.Regex.Replace(measurement.Description, oldName, newName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);      //measurement.Description.Replace(oldAcronym, newAcronym);
                        Measurement.Save(connection, measurement);
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
    }
}
