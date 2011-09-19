//******************************************************************************************************
//  TimeTaggedMeasurement.cs - Gbtc
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
//  06/20/2011 - Magdiel Lorenzo
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Data;

namespace openPDC.UI.DataModels
{
    /// <summary>
    /// Represents a time-tagged measurement for real-time statistics.
    /// </summary>
    public class TimeTaggedMeasurement : DataModelBase
    {

        #region [ Members ]

        private string m_timeTag;
        private string m_currentValue;
        private string m_quality;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the current <see cref="TimeTaggedMeasurement"/>'s time tag.
        /// </summary>
        public string TimeTag
        {
            get
            {
                return m_timeTag;
            }
            set
            {
                m_timeTag = value;
                OnPropertyChanged("TimeTag");
            }
        }

        /// <summary>
        /// Gets or sets the current value of the current <see cref="TimeTaggedMeasurement"/>
        /// </summary>
        public string CurrentValue
        {
            get
            {
                return m_currentValue;
            }
            set
            {
                m_currentValue = value;
                OnPropertyChanged("CurrentValue");
            }
        }

        /// <summary>
        /// Gets or sets the quality of the current <see cref="TimeTaggedMeasurement"/>
        /// </summary>
        public string Quality
        {
            get
            {
                return m_quality;
            }
            set
            {
                m_quality = value;
                OnPropertyChanged("Quality");
            }
        }

        #endregion

        #region [ Static ]

        /// <summary>
        /// Retrieves a dictionary of <see cref=" TimeTaggedMeasurement"/> objects
        /// </summary>
        /// <param name="statisticDataUrl">URL that points to the service</param>
        /// <param name="nodeID">Current node ID</param>
        /// <returns>Dictionary of <see cref="TimeTaggedMeasurement"/> objects</returns>
        public static Dictionary<int, TimeTaggedMeasurement> GetStatisticMeasurements(string statisticDataUrl, string nodeID)
        {
            Dictionary<int, TimeTaggedMeasurement> statisticMeasurementList = new Dictionary<int, TimeTaggedMeasurement>();
            Dictionary<int, BasicStatisticInfo> basicStatisticList = new Dictionary<int, BasicStatisticInfo>(BasicStatisticInfo.Load(null, System.Guid.Parse(nodeID)));

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
                                    CurrentValue = string.Format(basicStatisticInfo.DisplayFormat, CommonFunctions.ConvertValueToType(element.Element("Value").Value, basicStatisticInfo.DataType)),
                                    Quality = quality
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TimeSeriesFramework.UI.CommonFunctions.LogException(null, "CommonFunctions.GetStatisticMeasurements", ex);
            }

            return statisticMeasurementList;
        }

        /// <summary>
        /// Gets the statistic info list used by statistic load functions.
        /// </summary>
        /// <param name="database">The database connection used to retrieve the statistic info list.</param>
        /// <param name="nodeID">The ID of the node to which the statistics are associated.</param>
        /// <returns>A list containing <see cref="DetailStatisticInfo"/> objects that were retrieved from the database.</returns>
        public static List<DetailStatisticInfo> GetStatisticInfoList(AdoDataConnection database, Guid nodeID)
        {
            bool createdConnection = false;

            try
            {
                DataTable statisticMeasurements;
                DataTable statisticDefinitions;
                Func<DataRow, KeyValuePair<DataRow, string>> mapFunction;
                Func<KeyValuePair<DataRow, string>, DetailStatisticInfo> selectFunction;

                createdConnection = CreateConnection(ref database);

                // We need to get statistics measurements from Measurement table, statistic definition from Statistic table. Create relationship between those two.
                // Then create parent child relationship to above two datatables.
                statisticMeasurements = database.Connection.RetrieveData(database.AdapterType, database.ParameterizedQueryString("SELECT DeviceID, PointID, PointTag, SignalReference FROM StatisticMeasurement WHERE NodeID = {0} ORDER BY SignalReference", "nodeID"), database.Guid(nodeID));

                // Get Statistic Definitions
                statisticDefinitions = database.Connection.RetrieveData(database.AdapterType, "SELECT Source, SignalIndex, Name, Description, DataType, DisplayFormat, IsConnectedState, LoadOrder FROM Statistic ORDER BY Source, SignalIndex");

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
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        public static ObservableCollection<StatisticMeasurementData> GetStatisticMeasurementData(AdoDataConnection connection, Guid nodeID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref connection);

                ObservableCollection<StatisticMeasurementData> statisticMeasurementDataList = new ObservableCollection<StatisticMeasurementData>();
                ObservableCollection<StreamInfo> inputStreamList = new ObservableCollection<StreamInfo>();
                ObservableCollection<StreamInfo> outputStreamInfoList = new ObservableCollection<StreamInfo>();

                DataSet resultSet = new DataSet();
                resultSet.EnforceConstraints = false;
                DataTable resultTable;


                //-------------------------------------------------------------
                //First get all the PDC devices and directly connected devices.  These are our input stream devices.
                resultTable = connection.Connection.RetrieveData(connection.AdapterType, "SELECT ID, Acronym, Name FROM DeviceDetail");// AND (IsConcentrator = @isConcentrator OR ParentAcronym = @parentAcronym) ORDER BY Acronym", connection.Guid(nodeID), false, string.Empty);
                resultTable.TableName = "InputStreamDevices";
                resultSet.Tables.Add(resultTable.Copy());
                //-------------------------------------------------------------

                //-------------------------------------------------------------
                //Second, get all the Devices that are connected to PDC.  These devices are part of input stream coming from other PDCs.
                resultTable = connection.Connection.RetrieveData(connection.AdapterType, connection.ParameterizedQueryString("SELECT ID, Acronym, Name, ParentID FROM DeviceDetail WHERE NodeID = {0} AND IsConcentrator = {1} AND ParentID > 0 ORDER BY Acronym", "nodeID", "isConcentrator"), connection.Guid(nodeID), connection.Bool(false));
                resultTable.TableName = "PdcDevices";
                resultSet.Tables.Add(resultTable.Copy());
                //-------------------------------------------------------------

                //-------------------------------------------------------------
                //Get Output Stream information.
                resultTable = connection.Connection.RetrieveData(connection.AdapterType, connection.ParameterizedQueryString("SELECT ID, Acronym, Name FROM OutputStream WHERE NodeID = {0} ORDER BY Acronym", "nodeID"), connection.Guid(nodeID));
                resultTable.TableName = "OutputStreams";
                resultSet.Tables.Add(resultTable.Copy());
                //-------------------------------------------------------------

                List<DetailStatisticInfo> statisticInfoList = GetStatisticInfoList(connection, nodeID);

                //-------------------------------------------------------------
                inputStreamList = new ObservableCollection<StreamInfo>((from inputDevice in resultSet.Tables["InputStreamDevices"].AsEnumerable()
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

                foreach (StreamInfo inputStreamDevice in inputStreamList)
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

                statisticMeasurementDataList.Add(new StatisticMeasurementData()
                {
                    SourceType = "Input Streams",
                    SourceStreamInfoList = new ObservableCollection<StreamInfo>(inputStreamList)
                });

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
                statisticMeasurementDataList.Add(new StatisticMeasurementData()
                {
                    SourceType = "Output Streams",
                    SourceStreamInfoList = outputStreamInfoList
                });

                return statisticMeasurementDataList;
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        public static ObservableCollection<DetailStatisticInfo> GetDeviceStatisticMeasurements(AdoDataConnection connection, int deviceID)
        {
            bool createdConnection = false;
            try
            {
                DataTable statisticMeasurements;
                DataTable statisticDefinitions;
                Func<DataRow, KeyValuePair<DataRow, string>> mapFunction;
                Func<KeyValuePair<DataRow, string>, DetailStatisticInfo> selectFunction;

                createdConnection = CreateConnection(ref connection);

                statisticMeasurements = connection.Connection.RetrieveData(connection.AdapterType, "SELECT DeviceID, PointID, PointTag, SignalReference FROM StatisticMeasurement ORDER BY SignalReference");
                statisticDefinitions = connection.Connection.RetrieveData(connection.AdapterType, "SELECT Source, SignalIndex, Name, Description, DataType, DisplayFormat, IsConnectedState, LoadOrder FROM Statistic ORDER BY Source, SignalIndex");

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

                return new ObservableCollection<DetailStatisticInfo>(
                    statisticMeasurements.Rows.Cast<DataRow>()
                    .Select(mapFunction)
                    .OrderBy(pair => pair.Value)
                    .Select(selectFunction)
                    .ToList());
            }
            finally
            {
                if (createdConnection && connection != null)
                    connection.Dispose();
            }
        }

        #endregion
    }

    /// <summary>
    /// Represents a statistic measurement data object.
    /// </summary>
    public class StatisticMeasurementData
    {
        public string SourceType { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<StreamInfo> SourceStreamInfoList { get; set; }
    }

    /// <summary>
    /// Represents a stream info object.
    /// </summary>
    public class StreamInfo
    {
        public int ID { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string StatusColor { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<DeviceStatistic> DeviceStatisticList { get; set; }
        public ObservableCollection<DetailStatisticInfo> StatisticList { get; set; }
    }

    /// <summary>
    /// Class to hold device statistic info.
    /// </summary>
    public class DeviceStatistic
    {
        public int ID { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public bool IsExpanded { get; set; }
        public ObservableCollection<DetailStatisticInfo> StatisticList { get; set; }
    }

    /// <summary>
    /// Class to hold detail statistic info.
    /// </summary>
    public class DetailStatisticInfo
    {
        public int DeviceID { get; set; }
        public int PointID { get; set; }
        public string PointTag { get; set; }
        public string SignalReference { get; set; }
        public bool IsExpanded { get; set; }
        public BasicStatisticInfo Statistics { get; set; }
    }

    /// <summary>
    /// Class to bind statistic measurement data to view.
    /// </summary>
    public class StatisticMeasurementDataForBinding
    {
        public ObservableCollection<StatisticMeasurementData> StatisticMeasurementDataList { get; set; }
        public bool IsExpanded { get; set; }
    }


}
