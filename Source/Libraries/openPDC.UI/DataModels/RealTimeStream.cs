//******************************************************************************************************
//  RealTimeData.cs - Gbtc
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
//  07/21/2011 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Media;
using TimeSeriesFramework.UI;
using TVA.Data;

namespace openPDC.UI.DataModels
{
    /// <summary>
    /// Represents a real-time stream of subscribed data.
    /// </summary>
    public class RealTimeStream : DataModelBase
    {
        #region [ Members ]

        // Fields
        private int m_id;
        private string m_acronym;
        private string m_name;
        private string m_companyName;
        private bool m_enabled;
        private bool m_expanded;
        private string m_statusColor;
        private ObservableCollection<RealTimeDevice> m_deviceList;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the ID of the <see cref="RealTimeStream"/>.
        /// </summary>
        public int ID
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets the acronym of the current <see cref="RealTimeStream"/>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the name of the current <see cref="RealTimeStream"/>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the company name of the current <see cref="RealTimeStream"/>.
        /// </summary>
        public string CompanyName
        {
            get
            {
                return m_companyName;
            }
            set
            {
                m_companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        /// <summary>
        /// Gets or sets the Expanded flag for the current <see cref="RealTimeStream"/>.
        /// </summary>
        public bool Expanded
        {
            get
            {
                return m_expanded;
            }
            set
            {
                m_expanded = value;
                OnPropertyChanged("Expanded");
            }
        }

        /// <summary>
        /// Gets or sets the status color of the current <see cref="RealTimeStream"/>.
        /// </summary>
        public string StatusColor
        {
            get
            {
                return m_statusColor;
            }
            set
            {
                m_statusColor = value;
                OnPropertyChanged("StatusColor");
            }
        }

        /// <summary>
        /// Gets or sets whether the current <see cref="RealTimeStream"/> is enabled.
        /// </summary>
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

        /// <summary>
        /// Gets or sets collection of <see cref="RealTimeDevice"/>s for the current <see cref="RealTimeStream"/>.
        /// </summary>
        public ObservableCollection<RealTimeDevice> DeviceList
        {
            get
            {
                return m_deviceList;
            }
            set
            {
                m_deviceList = value;
                OnPropertyChanged("DeviceList");
            }
        }

        #endregion

        #region [ Static ]

        // Static Methods

        /// <summary>
        /// Loads <see cref="RealTimeStream"/> information as an <see cref="ObservableCollection{T}"/> style list.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <returns>Collection of <see cref="RealTimeStream"/>.</returns>
        public static ObservableCollection<RealTimeStream> Load(AdoDataConnection database)
        {
            bool createdConnection = false;
            try
            {
                ObservableCollection<RealTimeStream> realTimeStreamList = null;
                createdConnection = CreateConnection(ref database);

                DataSet resultSet = new DataSet();
                resultSet.EnforceConstraints = false;

                // Get PDCs list.
                resultSet.Tables.Add(database.Connection.RetrieveData(database.AdapterType, database.ParameterizedQueryString("SELECT ID, Acronym, Name, CompanyName, Enabled FROM DeviceDetail " +
                    "WHERE NodeID = {0} AND IsConcentrator = {1} AND Enabled = {2} ORDER BY Acronym", "nodeID", "isConcentrator", "enabled"), DefaultTimeout, database.CurrentNodeID(), database.Bool(true), database.Bool(true)).Copy());

                resultSet.Tables[0].TableName = "PdcTable";

                // Add a dummy device row in PDC table to associate PMUs which are not PDC and connected directly.
                DataRow row = resultSet.Tables["PdcTable"].NewRow();
                row["ID"] = 0;
                row["Acronym"] = string.Empty;
                row["Name"] = "Devices Connected Directly";
                row["CompanyName"] = string.Empty;
                row["Enabled"] = false;
                resultSet.Tables["PdcTable"].Rows.Add(row);

                // Get Non-PDC device list.
                resultSet.Tables.Add(database.Connection.RetrieveData(database.AdapterType, database.ParameterizedQueryString("SELECT ID, Acronym, Name,CompanyName, ProtocolName, VendorDeviceName, " +
                    "ParentAcronym, Enabled FROM DeviceDetail WHERE NodeID = {0} AND IsConcentrator = {1} AND Enabled = {2} ORDER BY Acronym", "nodeID", "isConcentrator", "enabled"),
                    DefaultTimeout, database.CurrentNodeID(), database.Bool(false), database.Bool(true)).Copy());

                resultSet.Tables[1].TableName = "DeviceTable";

                // Get non-statistics Measurements list.
                resultSet.Tables.Add(database.Connection.RetrieveData(database.AdapterType, database.ParameterizedQueryString("SELECT ID, DeviceID, SignalID, PointID, PointTag, SignalReference, " +
                    "SignalAcronym, Description, SignalName, EngineeringUnits, HistorianAcronym FROM MeasurementDetail WHERE NodeID = {0} AND " +
                    "SignalAcronym <> {1} ORDER BY SignalReference", "nodeID", "signalAcronym"), DefaultTimeout, database.CurrentNodeID(), "STAT").Copy());

                resultSet.Tables[2].TableName = "MeasurementTable";

                // If any non-statistic measurement has DeviceID set to NULL, then we will treat it as a calculated measurement.
                // And associate it with a dummy device "CALCULATED" record as defined below.
                if (resultSet.Tables[2].Select("DeviceID IS NULL").GetLength(0) > 0)
                {
                    row = resultSet.Tables["DeviceTable"].NewRow();
                    row["ID"] = DBNull.Value;
                    row["Acronym"] = "CALCULATED";
                    row["Name"] = "CALCULATED MEASUREMENTS";
                    row["CompanyName"] = string.Empty;
                    row["ProtocolName"] = string.Empty;
                    row["VendorDeviceName"] = string.Empty;
                    row["ParentAcronym"] = string.Empty;
                    row["Enabled"] = false;
                    resultSet.Tables["DeviceTable"].Rows.Add(row);
                }

                realTimeStreamList = new ObservableCollection<RealTimeStream>(
                        from pdc in resultSet.Tables["PdcTable"].AsEnumerable()
                        select new RealTimeStream()
                        {
                            ID = pdc.ConvertField<int>("ID"),
                            Acronym = string.IsNullOrEmpty(pdc.Field<string>("Acronym")) ? "DIRECT CONNECTED" : pdc.Field<string>("Acronym"),
                            Name = pdc.Field<string>("Name"),
                            CompanyName = pdc.Field<string>("CompanyName"),
                            StatusColor = string.IsNullOrEmpty(pdc.Field<string>("Acronym")) ? "Transparent" : "Gray",
                            Enabled = Convert.ToBoolean(pdc.Field<object>("Enabled")),
                            Expanded = false,
                            DeviceList = new ObservableCollection<RealTimeDevice>(
                                    from device in resultSet.Tables["DeviceTable"].AsEnumerable()
                                    where device.Field<string>("ParentAcronym") == pdc.Field<string>("Acronym")
                                    select new RealTimeDevice()
                                    {
                                        ID = device.ConvertNullableField<int>("ID"),
                                        Acronym = device.Field<string>("Acronym"),
                                        ProtocolName = device.Field<string>("ProtocolName"),
                                        VendorDeviceName = device.Field<string>("VendorDeviceName"),
                                        ParentAcronym = string.IsNullOrEmpty(device.Field<string>("ParentAcronym")) ? "DIRECT CONNECTED" : device.Field<string>("ParentAcronym"),
                                        Expanded = false,
                                        StatusColor = device.ConvertNullableField<int>("ID") == null ? "Transparent" : "Gray",
                                        Enabled = Convert.ToBoolean(device.Field<object>("Enabled")),
                                        MeasurementList = new ObservableCollection<RealTimeMeasurement>(
                                                from measurement in resultSet.Tables["MeasurementTable"].AsEnumerable()
                                                where measurement.ConvertNullableField<int>("DeviceID") == device.ConvertNullableField<int>("ID")
                                                select new RealTimeMeasurement()
                                                {
                                                    ID = measurement.Field<string>("ID"),
                                                    DeviceID = measurement.ConvertNullableField<int>("DeviceID"),
                                                    SignalID = Guid.Parse(measurement.Field<object>("SignalID").ToString()),
                                                    PointID = measurement.ConvertField<int>("PointID"),
                                                    PointTag = measurement.Field<string>("PointTag"),
                                                    SignalReference = measurement.Field<string>("SignalReference"),
                                                    Description = measurement.Field<string>("description"),
                                                    SignalName = measurement.Field<string>("SignalName"),
                                                    SignalAcronym = measurement.Field<string>("SignalAcronym"),
                                                    EngineeringUnit = measurement.Field<string>("EngineeringUnits"),
                                                    Expanded = false,
                                                    Selected = false,
                                                    TimeTag = "N/A",
                                                    Value = "--",
                                                    Quality = "N/A",
                                                    Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0))
                                                }
                                            )
                                    }
                                )
                        }
                    );

                return realTimeStreamList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Retrieves <see cref="Dictionary{T1,T2}"/> type collection.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> type collection.</returns>
        /// <remarks>This is only a place holder method with no implementation.</remarks>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = false)
        {
            return null;
        }

        /// <summary>
        /// Saves <see cref="RealTimeStream"/> information into the database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="stream">Information about <see cref="RealTimeStream"/></param>
        /// <returns>String, for display use, indicating success.</returns>
        /// <remarks>This is only a place holder method with no implementation.</remarks>
        public static string Save(AdoDataConnection database, RealTimeStream stream)
        {
            return string.Empty;
        }

        /// <summary>
        /// Deletes <see cref="RealTimeStream"/> record from the database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="streamID">ID of the record to be deleted.</param>
        /// <returns>String, for display use, indicating success.</returns>
        /// <remarks>This is only a place holder method with no implementation.</remarks>
        public static string Delete(AdoDataConnection database, int streamID)
        {
            return string.Empty;
        }

        #endregion
    }

    /// <summary>
    /// Represents a real-time stream of device data.
    /// </summary>
    public class RealTimeDevice : DataModelBase
    {
        #region [ Members ]

        // Fields        
        private int? m_id;
        private string m_acronym;
        private string m_protocolName;
        private string m_vendorDeviceName;
        private string m_parentAcronym;
        private bool m_expanded;
        private string m_statusColor;
        private bool m_enabled;
        private ObservableCollection<RealTimeMeasurement> m_measurementList;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets ID of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public int? ID
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets Acronym of the <see cref="RealTimeDevice"/>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets ProtocolName of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public string ProtocolName
        {
            get
            {
                return m_protocolName;
            }
            set
            {
                m_protocolName = value;
                OnPropertyChanged("ProtocolName");
            }
        }

        /// <summary>
        /// Gets or sets VendorDeviceName of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public string VendorDeviceName
        {
            get
            {
                return m_vendorDeviceName;
            }
            set
            {
                m_vendorDeviceName = value;
                OnPropertyChanged("VendorDeviceName");
            }
        }

        /// <summary>
        /// Gets or sets ParentAcronym of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public string ParentAcronym
        {
            get
            {
                return m_parentAcronym;
            }
            set
            {
                m_parentAcronym = value;
                OnPropertyChanged("ParentAcronym");
            }
        }

        /// <summary>
        /// Gets or sets Expanded flag of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public bool Expanded
        {
            get
            {
                return m_expanded;
            }
            set
            {
                m_expanded = value;
                OnPropertyChanged("Expanded");
            }
        }

        /// <summary>
        /// Gets or sets StatusColor of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public string StatusColor
        {
            get
            {
                return m_statusColor;
            }
            set
            {
                m_statusColor = value;
                OnPropertyChanged("StatusColor");
            }
        }

        /// <summary>
        /// Gets or sets Enabled flag of the <see cref="RealTimeDevice"/>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets collection of <see cref="RealTimeMeasurement"/>s of the <see cref="RealTimeDevice"/>.
        /// </summary>
        public ObservableCollection<RealTimeMeasurement> MeasurementList
        {
            get
            {
                return m_measurementList;
            }
            set
            {
                m_measurementList = value;
                OnPropertyChanged("MeasurementList");
            }
        }

        #endregion
    }

    /// <summary>
    /// Represents a real-time stream of Measurement data.
    /// </summary>
    public class RealTimeMeasurement : DataModelBase
    {
        #region [ Members ]

        // Fields

        private int? m_deviceID;
        private Guid m_signalID;
        private string m_id;
        private int m_pointID;
        private string m_pointTag;
        private string m_signalReference;
        private string m_description;
        private string m_signalName;
        private string m_signalAcronym;
        private string m_engineeringUnit;
        private bool m_expanded;
        private bool m_selected;
        private string m_timeTag;
        private string m_value;
        private string m_quality;
        private SolidColorBrush m_foreground;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets DeviceID for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public int? DeviceID
        {
            get
            {
                return m_deviceID;
            }
            set
            {
                m_deviceID = value;
                OnPropertyChanged("DeviceID");
            }
        }

        /// <summary>
        /// Gets or sets SignalID for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public Guid SignalID
        {
            get
            {
                return m_signalID;
            }
            set
            {
                m_signalID = value;
                OnPropertyChanged("SignalID");
            }
        }

        /// <summary>
        /// Gets or sets ID for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string ID
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets PointID for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public int PointID
        {
            get
            {
                return m_pointID;
            }
            set
            {
                m_pointID = value;
                OnPropertyChanged("PointID");
            }
        }

        /// <summary>
        /// Gets or sets PointTag for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string PointTag
        {
            get
            {
                return m_pointTag;
            }
            set
            {
                m_pointTag = value;
                OnPropertyChanged("PointTag");
            }
        }

        /// <summary>
        /// Gets or sets SignalReference for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string SignalReference
        {
            get
            {
                return m_signalReference;
            }
            set
            {
                m_signalReference = value;
                OnPropertyChanged("SignalReference");
            }
        }

        /// <summary>
        /// Gets or sets Description for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string Description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets SignalName for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string SignalName
        {
            get
            {
                return m_signalName;
            }
            set
            {
                m_signalName = value;
                OnPropertyChanged("SignalName");
            }
        }

        /// <summary>
        /// Gets or sets SignalAcronym for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string SignalAcronym
        {
            get
            {
                return m_signalAcronym;
            }
            set
            {
                m_signalAcronym = value;
                OnPropertyChanged("SignalAcronym");
            }
        }

        /// <summary>
        /// Gets or sets Engineering Unit for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public string EngineeringUnit
        {
            get
            {
                return m_engineeringUnit;
            }
            set
            {
                m_engineeringUnit = value;
                OnPropertyChanged("EngineeringUnit");
            }
        }

        /// <summary>
        /// Gets or sets Expanded flag for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public bool Expanded
        {
            get
            {
                return m_expanded;
            }
            set
            {
                m_expanded = value;
                OnPropertyChanged("Expanded");
            }
        }

        /// <summary>
        /// Gets or sets Selected flag for <see cref="RealTimeMeasurement"/>.
        /// </summary>
        public bool Selected
        {
            get
            {
                return m_selected;
            }
            set
            {
                m_selected = value;
                OnPropertyChanged("Selected");
            }
        }

        /// <summary>
        /// Gets or sets TimeTag for <see cref="RealTimeMeasurement"/> data.
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
        /// Gets or sets Value for <see cref="RealTimeMeasurement"/> data.
        /// </summary>
        public string Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
                OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// Gets or sets Quality for <see cref="RealTimeMeasurement"/> data.
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

        /// <summary>
        /// Gets or sets Foreground for <see cref="RealTimeMeasurement"/> to display on the screen.
        /// </summary>
        public SolidColorBrush Foreground
        {
            get
            {
                return m_foreground;
            }
            set
            {
                m_foreground = value;
                OnPropertyChanged("Foreground");
            }
        }

        #endregion
    }

}
