//******************************************************************************************************
//  Device.cs - Gbtc
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
//  04/11/2011 - Aniket Salver
//       Generated original version of source code.
//  04/21/2011 - Mehulbhai P Thakkar
//       Added static methods for database operations.
//  05/02/2011 - J. Ritchie Carroll
//       Updated for coding consistency.
//  05/03/2011 - Mehulbhai P Thakkar
//       Guid field related changes as well as static functions update.
//  05/05/2011 - Mehulbhai P Thakkar
//       Added NULL value and Guid parameter handling for Save() operation.
//  05/12/2011 - Aniket Salver
//                  Modified the way Guid is retrived from the Data Base.
//  05/13/2011 - Mehulbhai P Thakkar
//       Added regular expression validator for Acronym.
//  05/21/2011 - Mehulbhai P Thakkar
//       Modified Save method to create or update associated measurements.
//  09/23/2011 - Mehulbhai P Thakkar
//       Added static method to retrieve new devices for output stream.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using TimeSeriesFramework.UI;
using TimeSeriesFramework.UI.DataModels;
using TVA;
using TVA.Data;

namespace openPDC.UI.DataModels
{
    #region [ Enumerations ]

    /// <summary>
    /// Device type enumeration.
    /// </summary>
    public enum DeviceType
    {
        /// <summary>
        /// All types of devices
        /// </summary>
        /// <remarks>
        /// Use this option to return all types of devices.
        /// </remarks>
        All,
        /// <summary>
        /// Concentrator devices such as PDC.
        /// </summary>
        /// <remarks>
        /// Use this option just to return concentrating devices.
        /// </remarks>
        Concentrator,
        /// <summary>
        /// Direct connected devices such as field PMUs.
        /// </summary>
        /// <remarks>
        /// Use this option to return directly connected devices.
        /// </remarks>
        DirectConnected
    }

    #endregion

    /// <summary>
    /// Represents a record of <see cref="Device"/> information as defined in the database.
    /// </summary>
    public class Device : DataModelBase
    {
        #region [ Members ]

        // Fields
        private Guid m_nodeID;
        private int m_id;
        private int? m_parentID;
        private Guid m_uniqueID;
        private string m_acronym;
        private string m_name;
        private string m_originalSource;
        private bool m_isConcentrator;
        private int? m_companyID;
        private int? m_historianID;
        private int m_accessID;
        private int? m_vendorDeviceID;
        private int? m_protocolID;
        private decimal? m_longitude;
        private decimal? m_latitude;
        private int? m_interconnectionID;
        private string m_connectionString;
        private string m_timeZone;
        private int? m_framesPerSecond;
        private long m_timeAdjustmentTicks;
        private double m_dataLossInterval;
        private bool m_connectOnDemand;
        private string m_contactList;
        private int? m_measuredLines;
        private int m_loadOrder;
        private bool m_enabled;
        private int m_allowedParsingExceptions;
        private double m_parsingExceptionWindow;
        private double m_delayedConnectionInterval;
        private bool m_allowUseOfCachedConfiguration;
        private bool m_autoStartDataParsingSequence;
        private bool m_skipDisableRealTimeData;
        private int m_measurementReportingInterval;
        private string m_companyName;
        private string m_companyAcronym;
        private string m_historianAcronym;
        private string m_vendorDeviceName;
        private string m_vendorAcronym;
        private string m_protocolName;
        private string m_interconnectionName;
        private string m_nodeName;
        private string m_parentAcronym;
        private DateTime m_createdOn;
        private string m_createdBy;
        private DateTime m_updatedOn;
        private string m_updatedBy;
        private string m_alternateCommandChannel;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets <see cref="Device"/> NodeID.
        /// </summary>
        [Required(ErrorMessage = "Device node ID is a required field, please provide value.")]
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

        /// <summary>
        /// Gets or sets <see cref="Device"/> ID.
        /// </summary>
        // Field is populated by database via auto-increment and has no screen interaction, so no validation attributes are applied
        public int ID
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> ParentID.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? ParentID
        {
            get
            {
                return m_parentID;
            }
            set
            {
                m_parentID = value;
                OnPropertyChanged("ParentID");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> UniqueID.
        /// </summary>
        public Guid UniqueID
        {
            get
            {
                return m_uniqueID;
            }
            set
            {
                m_uniqueID = value;
                OnPropertyChanged("UniqueID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> Acronym.
        /// </summary>
        [Required(ErrorMessage = "Device acronym is a required field, please provide value.")]
        [StringLength(200, ErrorMessage = "Device Acronym cannot exceed 200 characters.")]
        [RegularExpression("^[A-Z0-9-'!'_@#]+$", ErrorMessage = "Only upper case letters, numbers, '!', '-', '@', '#' and '_' are allowed.")]
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
        /// Gets or sets <see cref="Device"/>  Name.
        /// </summary>
        [StringLength(200, ErrorMessage = "Device Name cannot exceed 200 characters.")]
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
        /// Gets <see cref="Device"/> Original Source.
        /// </summary>        
        public string OriginalSource
        {
            get
            {
                return m_originalSource;
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> IsConcenttrator.
        /// </summary>
        [DefaultValue(false)]
        public bool IsConcentrator
        {
            get
            {
                return m_isConcentrator;
            }
            set
            {
                m_isConcentrator = value;
                OnPropertyChanged("IsConcentrator");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> CompanyID.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? CompanyID
        {
            get
            {
                return m_companyID;
            }
            set
            {
                m_companyID = value;
                OnPropertyChanged("CompanyID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> HistrianID.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? HistorianID
        {
            get
            {
                return m_historianID;
            }
            set
            {
                m_historianID = value;
                OnPropertyChanged("HistorianID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> AccessID.
        /// </summary>
        [Required(ErrorMessage = "Device access ID is a required field, please provide value.")]
        [DefaultValue(0)]
        public int AccessID
        {
            get
            {
                return m_accessID;
            }
            set
            {
                m_accessID = value;
                OnPropertyChanged("AccessID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> VendorDeviceID.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? VendorDeviceID
        {
            get
            {
                return m_vendorDeviceID;
            }
            set
            {
                m_vendorDeviceID = value;
                OnPropertyChanged("VendorDeviceID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> protocolID.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? ProtocolID
        {
            get
            {
                return m_protocolID;
            }
            set
            {
                m_protocolID = value;
                OnPropertyChanged("ProtocolID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> Longitude.
        /// </summary>
        // Because of database design, no validation attributes are applied.        
        [RegularExpression(@"^[-]?([0-9]{1,3})?([.][0-9]{1,6})?$", ErrorMessage = "Invalid value. Please provide value in decimal(9,6) format.")]
        public decimal? Longitude
        {
            get
            {
                return m_longitude;
            }
            set
            {
                m_longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> Latitude.
        /// </summary>
        // Because of database design, no validation attributes are applied.        
        [RegularExpression(@"^[-]?([0-9]{1,3})?([.][0-9]{1,6})?$", ErrorMessage = "Invalid value. Please provide value in decimal(9,6) format.")]
        public decimal? Latitude
        {
            get
            {
                return m_latitude;
            }
            set
            {
                m_latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> InterconnectionID.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? InterconnectionID
        {
            get
            {
                return m_interconnectionID;
            }
            set
            {
                m_interconnectionID = value;
                OnPropertyChanged("InterconnectionID");
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> ConnectionString.
        /// </summary>
        // Because of database design, no validation attributes are applied.
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

        /// <summary>
        /// Gets or sets <see cref="Device"/> TimeZone.
        /// </summary>
        [StringLength(200, ErrorMessage = "Device Time Zone cannot exceed 200 characters.")]
        public string TimeZone
        {
            get
            {
                return m_timeZone;
            }
            set
            {
                m_timeZone = value;
                OnPropertyChanged("TimeZone");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> FramesPerSecond.
        /// </summary>
        [DefaultValue(30)]
        public int? FramesPerSecond
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

        /// <summary>
        /// Gets or sets <see cref="Device"/> TimeAdjustmentTicks.
        /// </summary>
        [Required(ErrorMessage = "Device time adjustment ticks is a required field, please provide value.")]
        [DefaultValue(0L)]
        public long TimeAdjustmentTicks
        {
            get
            {
                return m_timeAdjustmentTicks;
            }
            set
            {
                m_timeAdjustmentTicks = value;
                OnPropertyChanged("TimeAdjustmentTicks");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> DataLossInterval.
        /// </summary>
        [Required(ErrorMessage = "Device data loss interval is a required field, please provide value.")]
        [DefaultValue(typeof(double), "5")]
        public double DataLossInterval
        {
            get
            {
                return m_dataLossInterval;
            }
            set
            {
                m_dataLossInterval = value;
                OnPropertyChanged("DataLossInterval");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/>ConnectOnDemand.
        /// </summary>
        [Required(ErrorMessage = "ConnectOnDemand is a required field, please provide value.")]
        [DefaultValue(false)]
        public bool ConnectOnDemand
        {
            get
            {
                return m_connectOnDemand;
            }
            set
            {
                m_connectOnDemand = value;
                OnPropertyChanged("ConnectOnDemand");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> ContactList.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public string ContactList
        {
            get
            {
                return m_contactList;
            }
            set
            {
                m_contactList = value;
                OnPropertyChanged("ContactList");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> MeasuredLines.
        /// </summary>
        // Because of database design, no validation attributes are applied.
        public int? MeasuredLines
        {
            get
            {
                return m_measuredLines;
            }
            set
            {
                m_measuredLines = value;
                OnPropertyChanged("MeasuredLines");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> LoadOrder.
        /// </summary>
        [Required(ErrorMessage = "Device load order is a required field, please provide value.")]
        [DefaultValue(0)]
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

        /// <summary>
        /// Gets or sets <see cref="Device"/> Enabled.
        /// </summary>
        [DefaultValue(false)]
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
        /// Gets or sets <see cref="Device"/> AllowedParsingExceptions.
        /// </summary>
        [Required(ErrorMessage = "Device allowed parsing exceptions is a required field, please provide value.")]
        [DefaultValue(10)]
        public int AllowedParsingExceptions
        {
            get
            {
                return m_allowedParsingExceptions;
            }
            set
            {
                m_allowedParsingExceptions = value;
                OnPropertyChanged("AllowedParsingExceptions");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> ParsingExceptionWindow.
        /// </summary>
        [Required(ErrorMessage = "Device parsing exception window is a required field, please provide value.")]
        [DefaultValue(5.0D)]
        public double ParsingExceptionWindow
        {
            get
            {
                return m_parsingExceptionWindow;
            }
            set
            {
                m_parsingExceptionWindow = value;
                OnPropertyChanged("ParsingExceptionWindow");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> DelayedConnectionInterval.
        /// </summary>
        [Required(ErrorMessage = "Device delayed connection interval is a required field, please provide value.")]
        [DefaultValue(5.0D)]
        public double DelayedConnectionInterval
        {
            get
            {
                return m_delayedConnectionInterval;
            }
            set
            {
                m_delayedConnectionInterval = value;
                OnPropertyChanged("DelayedConnectionInterval");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> AllowUseOfCachedConfiguration.
        /// </summary>
        [DefaultValue(true)]
        public bool AllowUseOfCachedConfiguration
        {
            get
            {
                return m_allowUseOfCachedConfiguration;
            }
            set
            {
                m_allowUseOfCachedConfiguration = value;
                OnPropertyChanged("AllowUseOfCachedConfiguration");

            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> AutoStartDataParsingSequence.
        /// </summary>
        [DefaultValue(true)]
        public bool AutoStartDataParsingSequence
        {
            get
            {
                return m_autoStartDataParsingSequence;
            }
            set
            {
                m_autoStartDataParsingSequence = value;
                OnPropertyChanged("AutoStartDataParsingSequence");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> SkipDisableRealTimeData.
        /// </summary>
        [DefaultValue(false)]
        public bool SkipDisableRealTimeData
        {
            get
            {
                return m_skipDisableRealTimeData;
            }
            set
            {
                m_skipDisableRealTimeData = value;
                OnPropertyChanged("SkipDisableRealTimeData");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> MeasurementReportingInterval.
        /// </summary>
        [Required(ErrorMessage = "Device measurement reporting interval is a required field, please provide value.")]
        [DefaultValue(100000)]
        public int MeasurementReportingInterval
        {
            get
            {
                return m_measurementReportingInterval;
            }
            set
            {
                m_measurementReportingInterval = value;
                OnPropertyChanged("MeasurementReportingInterval");
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> CompanyName.
        /// </summary>
        public string CompanyName
        {
            get
            {
                return m_companyName;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> CompanyAcronym.
        /// </summary>
        public string CompanyAcronym
        {
            get
            {
                return m_companyAcronym;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> HistorianAcronym.
        /// </summary>
        public string HistorianAcronym
        {
            get
            {
                return m_historianAcronym;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> VendorDeviceName.
        /// </summary>
        public string VendorDeviceName
        {
            get
            {
                return m_vendorDeviceName;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> VendorAcronym.
        /// </summary>
        public string VendorAcronym
        {
            get
            {
                return m_vendorAcronym;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> ProtocolName.
        /// </summary>
        public string ProtocolName
        {
            get
            {
                return m_protocolName;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> InterconnectionName.
        /// </summary>
        public string InterconnectionName
        {
            get
            {
                return m_interconnectionName;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> NodeName.
        /// </summary>
        public string NodeName
        {
            get
            {
                return m_nodeName;
            }
        }

        /// <summary>
        /// Gets <see cref="Device"/> ParentAcronym.
        /// </summary>
        public string ParentAcronym
        {
            get
            {
                return m_parentAcronym;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> CreatedOn.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
        public DateTime CreatedOn
        {
            get
            {
                return m_createdOn;
            }
            set
            {
                m_createdOn = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> CreatedBy.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
        public string CreatedBy
        {
            get
            {
                return m_createdBy;
            }
            set
            {
                m_createdBy = value;
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> UpdatedOn.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
        public DateTime UpdatedOn
        {
            get
            {
                return m_updatedOn;
            }
            set
            {
                m_updatedOn = value;
            }
        }

        /// <summary>
        ///  Gets or sets <see cref="Device"/> UpdatedBy.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
        public string UpdatedBy
        {
            get
            {
                return m_updatedBy;
            }
            set
            {
                m_updatedBy = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="Device"/> alternate command channel.
        /// </summary>
        // Field is not saved in database so no validation applied.
        public string AlternateCommandChannel
        {
            get
            {
                return m_alternateCommandChannel;
            }
            set
            {
                m_alternateCommandChannel = value;
                OnPropertyChanged("AlternateCommandChannel");
            }
        }

        #endregion

        #region [ Static ]

        // Static Methods

        /// <summary>
        /// Loads <see cref="Device"/> information as an <see cref="ObservableCollection{T}"/> style list.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>        
        /// <param name="parentID">ID of the parent device to filter data.</param>
        /// <returns>Collection of <see cref="Device"/>.</returns>
        public static ObservableCollection<Device> Load(AdoDataConnection database, int parentID = 0)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<Device> deviceList = new ObservableCollection<Device>();
                DataTable deviceTable;
                string query;

                if (parentID > 0)
                {
                    query = database.ParameterizedQueryString("SELECT * FROM DeviceDetail WHERE NodeID = {0} AND ParentID = {1} ORDER BY Acronym", "nodeID", "parentID");
                    deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.CurrentNodeID(), parentID);
                }
                else
                {
                    query = database.ParameterizedQueryString("SELECT * FROM DeviceDetail WHERE NodeID = {0} ORDER BY Acronym", "nodeID");
                    deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.CurrentNodeID());
                }

                foreach (DataRow row in deviceTable.Rows)
                {
                    deviceList.Add(new Device()
                    {
                        NodeID = database.Guid(row, "NodeID"),
                        ID = row.ConvertField<int>("ID"),
                        ParentID = row.ConvertNullableField<int>("ParentID"),
                        UniqueID = database.Guid(row, "UniqueID"),
                        Acronym = row.Field<string>("Acronym"),
                        Name = row.Field<string>("Name"),
                        IsConcentrator = Convert.ToBoolean(row.Field<object>("IsConcentrator")),
                        CompanyID = row.ConvertNullableField<int>("CompanyID"),
                        HistorianID = row.ConvertNullableField<int>("HistorianID"),
                        AccessID = row.ConvertField<int>("AccessID"),
                        VendorDeviceID = row.ConvertNullableField<int>("VendorDeviceID"),
                        ProtocolID = row.ConvertNullableField<int>("ProtocolID"),
                        Longitude = row.ConvertNullableField<decimal>("Longitude"),
                        Latitude = row.ConvertNullableField<decimal>("Latitude"),
                        InterconnectionID = row.ConvertNullableField<int>("InterconnectionID"),
                        ConnectionString = ParseConnectionString(row.Field<string>("ConnectionString")),
                        AlternateCommandChannel = ParseAlternateCommand(row.Field<string>("ConnectionString")),
                        TimeZone = row.Field<string>("TimeZone"),
                        FramesPerSecond = Convert.ToInt32(row.Field<object>("FramesPerSecond") ?? 30),
                        TimeAdjustmentTicks = Convert.ToInt64(row.Field<object>("TimeAdjustmentTicks")),
                        DataLossInterval = row.ConvertField<double>("DataLossInterval"),
                        ContactList = row.Field<string>("ContactList"),
                        MeasuredLines = row.ConvertNullableField<int>("MeasuredLines"),
                        LoadOrder = row.ConvertField<int>("LoadOrder"),
                        Enabled = Convert.ToBoolean(row.Field<object>("Enabled")),
                        CreatedOn = row.Field<DateTime>("CreatedOn"),
                        AllowedParsingExceptions = Convert.ToInt32(row.Field<object>("AllowedParsingExceptions")),
                        ParsingExceptionWindow = row.ConvertField<double>("ParsingExceptionWindow"),
                        DelayedConnectionInterval = row.ConvertField<double>("DelayedConnectionInterval"),
                        AllowUseOfCachedConfiguration = Convert.ToBoolean(row.Field<object>("AllowUseOfCachedConfiguration")),
                        AutoStartDataParsingSequence = Convert.ToBoolean(row.Field<object>("AutoStartDataParsingSequence")),
                        SkipDisableRealTimeData = Convert.ToBoolean(row.Field<object>("SkipDisableRealTimeData")),
                        MeasurementReportingInterval = Convert.ToInt32(row.Field<object>("MeasurementReportingInterval")),
                        ConnectOnDemand = Convert.ToBoolean(row.Field<object>("ConnectOnDemand")),
                        m_companyName = row.Field<string>("CompanyName"),
                        m_companyAcronym = row.Field<string>("CompanyAcronym"),
                        m_historianAcronym = row.Field<string>("HistorianAcronym"),
                        m_vendorDeviceName = row.Field<string>("VendorDeviceName"),
                        m_vendorAcronym = row.Field<string>("VendorAcronym"),
                        m_protocolName = row.Field<string>("ProtocolName"),
                        m_interconnectionName = row.Field<string>("InterconnectionName"),
                        m_nodeName = row.Field<string>("NodeName"),
                        m_parentAcronym = row.Field<string>("ParentAcronym"),
                        m_originalSource = row.Field<string>("OriginalSource")
                    });
                }

                return deviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="Device"/> information.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>        
        /// <param name="deviceType"><see cref="DeviceType"/> to filter data.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>        
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of devices defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, DeviceType deviceType = DeviceType.DirectConnected, bool isOptional = false)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> deviceList = new Dictionary<int, string>();
                DataTable deviceTable;
                string query;

                if (isOptional)
                    deviceList.Add(0, "Select Device");

                if (deviceType == DeviceType.Concentrator)
                {
                    query = database.ParameterizedQueryString("SELECT ID, Acronym FROM Device WHERE IsConcentrator = {0} AND NodeID = {1} ORDER BY LoadOrder",
                        "isConcentrator", "nodeID");

                    deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.Bool(true), database.CurrentNodeID());
                }
                else if (deviceType == DeviceType.DirectConnected)
                {
                    query = database.ParameterizedQueryString("SELECT ID, Acronym FROM Device WHERE IsConcentrator = {0} AND NodeID = {1} ORDER BY LoadOrder",
                        "isConcentrator", "nodeID");

                    deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.Bool(false), database.CurrentNodeID());
                }
                else
                {
                    query = database.ParameterizedQueryString("SELECT ID, Acronym FROM Device WHERE NodeID = {0} ORDER BY LoadOrder", "nodeID");
                    deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.CurrentNodeID());
                }

                foreach (DataRow row in deviceTable.Rows)
                    deviceList[row.ConvertField<int>("ID")] = row.Field<string>("Acronym");

                return deviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="Device"/> information.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="protocolType">Type of protocol to filter data.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of devices defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, string protocolType, bool isOptional)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> deviceList = new Dictionary<int, string>();
                DataTable deviceTable;
                string query;

                if (isOptional)
                    deviceList.Add(0, "All Device");

                query = database.ParameterizedQueryString("SELECT ID, Acronym FROM DeviceDetail WHERE NodeID = {0} AND ProtocolType = {1} ORDER BY LoadOrder",
                    "nodeID", "protocolType");

                deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.CurrentNodeID(), protocolType);

                foreach (DataRow row in deviceTable.Rows)
                    deviceList[row.ConvertField<int>("ID")] = row.Field<string>("Acronym");

                return deviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Saves <see cref="Device"/> information to database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="device">Information about <see cref="Device"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, Device device)
        {
            return SaveWithAnalogsDigitals(database, device, true, 0, 0);
        }

        /// <summary>
        /// Saves <see cref="Device"/> information to database along with analogs and digital measurements if requested..
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="device">Information about <see cref="Device"/>.</param>
        /// <param name="digitalCount">Number of digital measurements to add.</param>
        /// <param name="analogCount">Number of analog measurements to add.</param>
        /// <returns>String, for display use, indicating success.</returns>
        public static string SaveWithAnalogsDigitals(AdoDataConnection database, Device device, bool notifyService, int digitalCount, int analogCount)
        {
            bool createdConnection = false;
            string query;

            try
            {
                Device oldDevice = null;

                createdConnection = CreateConnection(ref database);

                object nodeID;
                if (device.NodeID == null || device.NodeID == Guid.Empty)
                    nodeID = database.CurrentNodeID();
                else
                    nodeID = database.Guid(device.NodeID);

                if (device.ID == 0)
                {
                    query = database.ParameterizedQueryString("INSERT INTO Device (NodeID, ParentID, UniqueID, Acronym, Name, IsConcentrator, CompanyID, HistorianID, AccessID, VendorDeviceID, " +
                        "ProtocolID, Longitude, Latitude, InterconnectionID, ConnectionString, TimeZone, FramesPerSecond, TimeAdjustmentTicks, DataLossInterval, ContactList, " +
                        "MeasuredLines, LoadOrder, Enabled, AllowedParsingExceptions, ParsingExceptionWindow, DelayedConnectionInterval, AllowUseOfCachedConfiguration, " +
                        "AutoStartDataParsingSequence, SkipDisableRealTimeData, MeasurementReportingInterval, ConnectOndemand, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) Values " +
                        "({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, " +
                        "{26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34})", "nodeID", "parentID", "uniqueID", "acronym", "name", "isConcentrator", "companyID",
                        "historianID", "accessID", "vendorDeviceID", "protocolID", "longitude", "latitude", "interconnectionID", "connectionString", "timezone",
                        "framesPerSecond", "timeAdjustmentTicks", "dataLossInterval", "contactList", "measuredLines", "loadOrder", "enabled", "allowedParsingExceptions",
                        "parsingExceptionWindow", "delayedConnectionInterval", "allowUseOfCachedConfiguration", "autoStartDataParsingSequence", "skipDisableRealTimeData",
                        "measurementReportingInterval", "connectOndemand", "updatedBy", "updatedOn", "createdBy", "createdOn");

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, nodeID,
                        device.ParentID.ToNotNull(), database.Guid(Guid.NewGuid()), device.Acronym.Replace(" ", "").ToUpper(), device.Name.ToNotNull(), database.Bool(device.IsConcentrator), device.CompanyID.ToNotNull(),
                        device.HistorianID.ToNotNull(), device.AccessID, device.VendorDeviceID.ToNotNull(),
                        device.ProtocolID.ToNotNull(), device.Longitude.ToNotNull(), device.Latitude.ToNotNull(), device.InterconnectionID.ToNotNull(),
                        BuildConnectionString(device), device.TimeZone.ToNotNull(), device.FramesPerSecond ?? 30, device.TimeAdjustmentTicks, device.DataLossInterval, device.ContactList.ToNotNull(), device.MeasuredLines.ToNotNull(),
                        device.LoadOrder, database.Bool(device.Enabled), device.AllowedParsingExceptions, device.ParsingExceptionWindow, device.DelayedConnectionInterval, database.Bool(device.AllowUseOfCachedConfiguration),
                        database.Bool(device.AutoStartDataParsingSequence), database.Bool(device.SkipDisableRealTimeData), device.MeasurementReportingInterval, database.Bool(device.ConnectOnDemand), TimeSeriesFramework.UI.CommonFunctions.CurrentUser,
                        database.UtcNow(), TimeSeriesFramework.UI.CommonFunctions.CurrentUser, database.UtcNow());
                }
                else
                {
                    oldDevice = GetDevice(database, " WHERE ID = " + device.ID);

                    query = database.ParameterizedQueryString("UPDATE Device SET NodeID = {0}, ParentID = {1}, UniqueID = {2}, Acronym = {3}, Name = {4}, " +
                        "IsConcentrator = {5}, CompanyID = {6}, HistorianID = {7}, AccessID = {8}, VendorDeviceID = {9}, ProtocolID = {10}, Longitude = {11}, " +
                        "Latitude = {12}, InterconnectionID = {13}, ConnectionString = {14}, TimeZone = {15}, FramesPerSecond = {16}, TimeAdjustmentTicks = {17}, " +
                        "DataLossInterval = {18}, ContactList = {19}, MeasuredLines = {20}, LoadOrder = {21}, Enabled = {22}, AllowedParsingExceptions = {23}, " +
                        "ParsingExceptionWindow = {24}, DelayedConnectionInterval = {25}, AllowUseOfCachedConfiguration = {26}, AutoStartDataParsingSequence = {27}, " +
                        "SkipDisableRealTimeData = {28}, MeasurementReportingInterval = {29}, ConnectOnDemand = {30}, UpdatedBy = {31}, UpdatedOn = {32} WHERE ID = {33}",
                        "nodeID", "parentID", "uniqueID", "acronym", "name", "isConcentrator", "companyID", "historianID", "accessID", "vendorDeviceID", "protocolID",
                        "longitude", "latitude", "interconnectionID", "connectionString", "timezone", "framesPerSecond", "timeAdjustmentTicks", "dataLossInterval",
                        "contactList", "measuredLines", "loadOrder", "enabled", "allowedParsingExceptions", "parsingExceptionWindow", "delayedConnectionInterval",
                        "allowUseOfCachedConfiguration", "autoStartDataParsingSequence", "skipDisableRealTimeData", "measurementReportingInterval", "connectOnDemand",
                        "updatedBy", "updatedOn", "id");

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, nodeID,
                        device.ParentID.ToNotNull(), database.Guid(device.UniqueID), device.Acronym.Replace(" ", "").ToUpper(), device.Name.ToNotNull(), database.Bool(device.IsConcentrator), device.CompanyID.ToNotNull(),
                        device.HistorianID.ToNotNull(), device.AccessID, device.VendorDeviceID.ToNotNull(),
                        device.ProtocolID.ToNotNull(), device.Longitude.ToNotNull(), device.Latitude.ToNotNull(), device.InterconnectionID.ToNotNull(),
                        BuildConnectionString(device), device.TimeZone.ToNotNull(), device.FramesPerSecond ?? 30, device.TimeAdjustmentTicks, device.DataLossInterval, device.ContactList.ToNotNull(), device.MeasuredLines.ToNotNull(),
                        device.LoadOrder, database.Bool(device.Enabled), device.AllowedParsingExceptions, device.ParsingExceptionWindow, device.DelayedConnectionInterval, database.Bool(device.AllowUseOfCachedConfiguration),
                        database.Bool(device.AutoStartDataParsingSequence), database.Bool(device.SkipDisableRealTimeData), device.MeasurementReportingInterval, database.Bool(device.ConnectOnDemand), TimeSeriesFramework.UI.CommonFunctions.CurrentUser,
                        database.UtcNow(), device.ID);
                }


                Device savedDevice = GetDevice(database, "WHERE Acronym = '" + device.Acronym.Replace(" ", "").ToUpper() + "'");

                // If device is concentrator then we do not want to create default measurements for it. So exit function.                                
                if (device.IsConcentrator)
                {
                    if (notifyService)
                        NotifyService(savedDevice);

                    return "Device information saved successfully";
                }

                if (savedDevice == null)
                    return "Device information saved successfully but failed to create measurements";

                foreach (SignalType signal in SignalType.GetPmuSignalTypes())
                {
                    if (signal.Suffix != "CV")
                    {
                        Measurement measurement;

                        if (signal.Suffix == "AV" && analogCount > 0)
                        {
                            for (int i = 1; i <= analogCount; i++)
                            {
                                measurement = Measurement.GetMeasurement(database, "WHERE DeviceID = " + savedDevice.ID + " AND SignalReference = '" +
                                    savedDevice.Acronym + "-AV" + i.ToString() + "'");

                                if (measurement == null)
                                    measurement = new Measurement();

                                measurement.HistorianID = savedDevice.HistorianID;
                                measurement.DeviceID = savedDevice.ID;
                                measurement.PointTag = savedDevice.CompanyAcronym + "_" + savedDevice.Acronym + ":" + savedDevice.VendorAcronym + "A" + i.ToString();
                                measurement.AlternateTag = string.Empty;
                                measurement.SignalReference = savedDevice.Acronym + "-AV" + i.ToString();
                                measurement.SignalTypeID = signal.ID;
                                measurement.PhasorSourceIndex = (int?)null;
                                measurement.Description = savedDevice.Name + " " + savedDevice.VendorDeviceName + " Analog Value " + i.ToString();
                                measurement.Enabled = true;
                                Measurement.Save(database, measurement);
                            }
                        }
                        else if (signal.Suffix == "DV" && digitalCount > 0)
                        {
                            for (int i = 1; i <= digitalCount; i++)
                            {
                                measurement = Measurement.GetMeasurement(database, "WHERE DeviceID = " + savedDevice.ID + " AND SignalReference = '" +
                                    savedDevice.Acronym + "-DV" + i.ToString() + "'");

                                if (measurement == null)
                                    measurement = new Measurement();

                                measurement.HistorianID = savedDevice.HistorianID;
                                measurement.DeviceID = savedDevice.ID;
                                measurement.PointTag = savedDevice.CompanyAcronym + "_" + savedDevice.Acronym + ":" + savedDevice.VendorAcronym + "D" + i.ToString();
                                measurement.AlternateTag = string.Empty;
                                measurement.SignalReference = savedDevice.Acronym + "-DV" + i.ToString();
                                measurement.SignalTypeID = signal.ID;
                                measurement.PhasorSourceIndex = (int?)null;
                                measurement.Description = savedDevice.Name + " " + savedDevice.VendorDeviceName + " Digital Value " + i.ToString();
                                measurement.Enabled = true;
                                Measurement.Save(database, measurement);
                            }
                        }
                        else if (signal.Suffix == "FQ" || signal.Suffix == "DF" || signal.Suffix == "SF")
                        {
                            measurement = Measurement.GetMeasurement(database, "WHERE DeviceID = " + savedDevice.ID + " AND SignalTypeSuffix = '" + signal.Suffix + "'");

                            if (measurement == null)
                                measurement = new Measurement();

                            measurement.HistorianID = savedDevice.HistorianID;
                            measurement.DeviceID = savedDevice.ID;
                            measurement.PointTag = savedDevice.CompanyAcronym + "_" + savedDevice.Acronym + ":" + savedDevice.VendorAcronym + signal.Abbreviation;
                            measurement.AlternateTag = string.Empty;
                            measurement.SignalReference = savedDevice.Acronym + "-" + signal.Suffix;
                            measurement.SignalTypeID = signal.ID;
                            measurement.PhasorSourceIndex = (int?)null;
                            measurement.Description = savedDevice.Name + " " + savedDevice.VendorDeviceName + " " + signal.Name;
                            measurement.Enabled = true;

                            Measurement.Save(database, measurement);
                        }
                    }
                }

                // For existing devices, just call Save on each phasors so that measurements related to those phasor will reflect changes made to device.
                // Nothing will change in phasor itself.
                if (device.ID > 0)
                {
                    foreach (Phasor phasor in Phasor.Load(database, device.ID))
                    {
                        Phasor.Save(database, phasor);
                    }

                    // Also update statistic measurements to reflect any changes in the acronym of the device.
                    if (oldDevice != null && savedDevice.Acronym != oldDevice.Acronym)
                    {
                        foreach (Measurement measurement in Measurement.GetInputStatisticMeasurements(database, oldDevice.ID))
                        {
                            measurement.SignalReference = measurement.SignalReference.Replace(oldDevice.Acronym, savedDevice.Acronym);
                            measurement.PointTag = measurement.PointTag.Replace(oldDevice.Acronym, savedDevice.Acronym);
                            measurement.Description = System.Text.RegularExpressions.Regex.Replace(measurement.Description, oldDevice.Name, savedDevice.Name, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            Measurement.Save(database, measurement);
                        }

                        // Also make sure if any digital or analogs are left out from update then update them now.
                        foreach (Measurement measurement in Measurement.GetMeasurements(database, " WHERE SignalTypeSuffix IN ('DV', 'AV', 'CV')"))
                        {
                            measurement.SignalReference = measurement.SignalReference.Replace(oldDevice.Acronym, savedDevice.Acronym);
                            measurement.PointTag = measurement.PointTag.Replace(oldDevice.Acronym, savedDevice.Acronym);
                            measurement.Description = System.Text.RegularExpressions.Regex.Replace(measurement.Description, oldDevice.Name, savedDevice.Name, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            Measurement.Save(database, measurement);
                        }
                    }
                }

                try
                {
                    // Notify service about configuration changes made here.              
                    if (notifyService)
                        NotifyService(savedDevice);
                }
                catch (Exception ex)
                {
                    return "Device information saved successfully. Failed to send Initialize command to backend service." + Environment.NewLine + ex.Message;
                }

                return "Device information saved successfully";
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Deletes specified <see cref="Device"/> record from database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="deviceID">ID of the record to be deleted.</param>
        /// <returns>String, for display use, indicating success.</returns>
        public static string Delete(AdoDataConnection database, int deviceID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                // Setup current user context for any delete triggers
                TimeSeriesFramework.UI.CommonFunctions.SetCurrentUserContext(database);

                database.Connection.ExecuteNonQuery(database.ParameterizedQueryString("DELETE FROM Device WHERE ID = {0}", "deviceID"), DefaultTimeout, deviceID);

                return "Device deleted successfully";
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Retrieve a <see cref="Device"/> infomration from the database based on query string filter.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="whereClause">query string to filter data.</param>
        /// <returns><see cref="Device"/> information.</returns>
        public static Device GetDevice(AdoDataConnection database, string whereClause)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);
                DataTable deviceTable = database.Connection.RetrieveData(database.AdapterType, "SELECT * FROM DeviceDetail " + whereClause);

                if (deviceTable.Rows.Count == 0)
                    return null;

                DataRow row = deviceTable.Rows[0];
                Device device = new Device()
                {
                    NodeID = database.Guid(row, "NodeID"),
                    ID = row.ConvertField<int>("ID"),
                    ParentID = row.ConvertNullableField<int>("ParentID"),
                    UniqueID = database.Guid(row, "UniqueID"),
                    Acronym = row.Field<string>("Acronym"),
                    Name = row.Field<string>("Name"),
                    IsConcentrator = Convert.ToBoolean(row.Field<object>("IsConcentrator")),
                    CompanyID = row.ConvertNullableField<int>("CompanyID"),
                    HistorianID = row.ConvertNullableField<int>("HistorianID"),
                    AccessID = row.ConvertField<int>("AccessID"),
                    VendorDeviceID = row.ConvertNullableField<int>("VendorDeviceID"),
                    ProtocolID = row.ConvertNullableField<int>("ProtocolID"),
                    Longitude = row.ConvertNullableField<decimal>("Longitude"),
                    Latitude = row.ConvertNullableField<decimal>("Latitude"),
                    InterconnectionID = row.ConvertNullableField<int>("InterconnectionID"),
                    ConnectionString = ParseConnectionString(row.Field<string>("ConnectionString")),
                    AlternateCommandChannel = ParseAlternateCommand(row.Field<string>("ConnectionString")),
                    TimeZone = row.Field<string>("TimeZone"),
                    FramesPerSecond = Convert.ToInt32(row.Field<object>("FramesPerSecond") ?? 30),
                    TimeAdjustmentTicks = Convert.ToInt64(row.Field<object>("TimeAdjustmentTicks")),
                    DataLossInterval = row.ConvertField<double>("DataLossInterval"),
                    ContactList = row.Field<string>("ContactList"),
                    MeasuredLines = row.ConvertNullableField<int>("MeasuredLines"),
                    LoadOrder = row.ConvertField<int>("LoadOrder"),
                    Enabled = Convert.ToBoolean(row.Field<object>("Enabled")),
                    CreatedOn = row.Field<DateTime>("CreatedOn"),
                    AllowedParsingExceptions = Convert.ToInt32(row.Field<object>("AllowedParsingExceptions")),
                    ParsingExceptionWindow = row.ConvertField<double>("ParsingExceptionWindow"),
                    DelayedConnectionInterval = row.ConvertField<double>("DelayedConnectionInterval"),
                    AllowUseOfCachedConfiguration = Convert.ToBoolean(row.Field<object>("AllowUseOfCachedConfiguration")),
                    AutoStartDataParsingSequence = Convert.ToBoolean(row.Field<object>("AutoStartDataParsingSequence")),
                    SkipDisableRealTimeData = Convert.ToBoolean(row.Field<object>("SkipDisableRealTimeData")),
                    MeasurementReportingInterval = Convert.ToInt32(row.Field<object>("MeasurementReportingInterval")),
                    ConnectOnDemand = Convert.ToBoolean(row.Field<object>("ConnectOnDemand")),
                    m_companyName = row.Field<string>("CompanyName"),
                    m_companyAcronym = row.Field<string>("CompanyAcronym"),
                    m_historianAcronym = row.Field<string>("HistorianAcronym"),
                    m_vendorDeviceName = row.Field<string>("VendorDeviceName"),
                    m_vendorAcronym = row.Field<string>("VendorAcronym"),
                    m_protocolName = row.Field<string>("ProtocolName"),
                    m_interconnectionName = row.Field<string>("InterconnectionName"),
                    m_nodeName = row.Field<string>("NodeName"),
                    m_parentAcronym = row.Field<string>("ParentAcronym"),
                    m_originalSource = row.Field<string>("OriginalSource")
                };

                return device;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Retrieves <see cref="ObservableCollection{T}"/> type list of <see cref="Device"/> infomration from the database based on query string filter.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        public static ObservableCollection<Device> GetDevices(AdoDataConnection database, string whereClause)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);
                DataTable deviceTable = database.Connection.RetrieveData(database.AdapterType, "SELECT * FROM DeviceDetail " + whereClause);

                if (deviceTable.Rows.Count == 0)
                    return null;

                ObservableCollection<Device> deviceList = new ObservableCollection<Device>();
                foreach (DataRow row in deviceTable.Rows)
                {
                    deviceList.Add(new Device()
                    {
                        NodeID = database.Guid(row, "NodeID"),
                        ID = row.ConvertField<int>("ID"),
                        ParentID = row.ConvertNullableField<int>("ParentID"),
                        UniqueID = database.Guid(row, "UniqueID"),
                        Acronym = row.Field<string>("Acronym"),
                        Name = row.Field<string>("Name"),
                        IsConcentrator = Convert.ToBoolean(row.Field<object>("IsConcentrator")),
                        CompanyID = row.ConvertNullableField<int>("CompanyID"),
                        HistorianID = row.ConvertNullableField<int>("HistorianID"),
                        AccessID = row.ConvertField<int>("AccessID"),
                        VendorDeviceID = row.ConvertNullableField<int>("VendorDeviceID"),
                        ProtocolID = row.ConvertNullableField<int>("ProtocolID"),
                        Longitude = row.ConvertNullableField<decimal>("Longitude"),
                        Latitude = row.ConvertNullableField<decimal>("Latitude"),
                        InterconnectionID = row.ConvertNullableField<int>("InterconnectionID"),
                        ConnectionString = ParseConnectionString(row.Field<string>("ConnectionString")),
                        AlternateCommandChannel = ParseAlternateCommand(row.Field<string>("ConnectionString")),
                        TimeZone = row.Field<string>("TimeZone"),
                        FramesPerSecond = Convert.ToInt32(row.Field<object>("FramesPerSecond") ?? 30),
                        TimeAdjustmentTicks = Convert.ToInt64(row.Field<object>("TimeAdjustmentTicks")),
                        DataLossInterval = row.ConvertField<double>("DataLossInterval"),
                        ContactList = row.Field<string>("ContactList"),
                        MeasuredLines = row.ConvertNullableField<int>("MeasuredLines"),
                        LoadOrder = row.ConvertField<int>("LoadOrder"),
                        Enabled = Convert.ToBoolean(row.Field<object>("Enabled")),
                        CreatedOn = row.Field<DateTime>("CreatedOn"),
                        AllowedParsingExceptions = Convert.ToInt32(row.Field<object>("AllowedParsingExceptions")),
                        ParsingExceptionWindow = row.ConvertField<double>("ParsingExceptionWindow"),
                        DelayedConnectionInterval = row.ConvertField<double>("DelayedConnectionInterval"),
                        AllowUseOfCachedConfiguration = Convert.ToBoolean(row.Field<object>("AllowUseOfCachedConfiguration")),
                        AutoStartDataParsingSequence = Convert.ToBoolean(row.Field<object>("AutoStartDataParsingSequence")),
                        SkipDisableRealTimeData = Convert.ToBoolean(row.Field<object>("SkipDisableRealTimeData")),
                        MeasurementReportingInterval = Convert.ToInt32(row.Field<object>("MeasurementReportingInterval")),
                        ConnectOnDemand = Convert.ToBoolean(row.Field<object>("ConnectOnDemand")),
                        m_companyName = row.Field<string>("CompanyName"),
                        m_companyAcronym = row.Field<string>("CompanyAcronym"),
                        m_historianAcronym = row.Field<string>("HistorianAcronym"),
                        m_vendorDeviceName = row.Field<string>("VendorDeviceName"),
                        m_vendorAcronym = row.Field<string>("VendorAcronym"),
                        m_protocolName = row.Field<string>("ProtocolName"),
                        m_interconnectionName = row.Field<string>("InterconnectionName"),
                        m_nodeName = row.Field<string>("NodeName"),
                        m_parentAcronym = row.Field<string>("ParentAcronym"),
                        m_originalSource = row.Field<string>("OriginalSource")
                    });
                }

                return deviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Sends required commands to backend service to notify that <see cref="Device"/> configuration has changed.
        /// </summary>
        /// <param name="device"><see cref="Device"/> whose configuration has changed.</param>
        public static void NotifyService(Device device)
        {
            if (device != null)
            {
                if (device.Enabled)
                {
                    if (device.ParentID == null)
                        TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("Initialize " + TimeSeriesFramework.UI.CommonFunctions.GetRuntimeID("Device", device.ID));
                    else
                        TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("Initialize " + TimeSeriesFramework.UI.CommonFunctions.GetRuntimeID("Device", (int)device.ParentID));
                }
                else
                {
                    //we do this to make sure all statistical measurements are in the system.
                    TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("ReloadConfig");
                }

                if (device.HistorianID != null)
                    TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("Invoke " + TimeSeriesFramework.UI.CommonFunctions.GetRuntimeID("Historian", (int)device.HistorianID) + " RefreshMetadata");

                Historian statHistorian = Historian.GetHistorian(null, "WHERE Acronym = 'STAT'");
                if (statHistorian != null)
                    TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("Invoke " + TimeSeriesFramework.UI.CommonFunctions.GetRuntimeID("Historian", statHistorian.ID) + " RefreshMetadata");

                TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("Invoke 0 ReloadStatistics");
                TimeSeriesFramework.UI.CommonFunctions.SendCommandToService("RefreshRoutes");
            }
        }

        private static string ParseConnectionString(string connectionString)
        {
            Dictionary<string, string> settings = connectionString.ToLower().ParseKeyValuePairs();
            if (settings.ContainsKey("commandchannel"))
            {
                settings.Remove("commandchannel");
                return settings.JoinKeyValuePairs();
            }

            return connectionString;
        }

        private static string ParseAlternateCommand(string connectionString)
        {
            Dictionary<string, string> settings = connectionString.ToLower().ParseKeyValuePairs();
            if (settings.ContainsKey("commandchannel"))
                return settings["commandchannel"].Replace("{", "").Replace("}", "");

            return string.Empty;
        }

        private static string BuildConnectionString(Device device)
        {
            if (device.ConnectionString == null)
                return string.Empty;

            string connectionString = device.ConnectionString;
            if (!string.IsNullOrEmpty(device.AlternateCommandChannel))
            {
                if (!connectionString.EndsWith(";"))
                    connectionString += ";";

                connectionString += "commandchannel={" + device.AlternateCommandChannel + "}";
            }

            return connectionString;
        }

        /// <summary>
        /// Retrieves devices for output stream.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamID">ID of the output stream to filter out devices that already exist.</param>
        /// <returns>Collection of <see cref="Device"/>.</returns>
        public static ObservableCollection<Device> GetNewDevicesForOutputStream(AdoDataConnection database, int outputStreamID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<Device> deviceList = new ObservableCollection<Device>();
                DataTable deviceTable;
                string query;

                query = database.ParameterizedQueryString("SELECT * FROM DeviceDetail WHERE NodeID = {0} AND IsConcentrator = {1} AND Acronym NOT IN "
                    + "(SELECT Acronym FROM OutputStreamDevice WHERE AdapterID = {2}) ORDER BY Acronym", "nodeID", "isConcentrator", "adapterID");
                deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.CurrentNodeID(), database.Bool(false), outputStreamID);

                foreach (DataRow row in deviceTable.Rows)
                {
                    deviceList.Add(new Device()
                    {
                        NodeID = database.Guid(row, "NodeID"),
                        ID = row.ConvertField<int>("ID"),
                        ParentID = row.ConvertNullableField<int>("ParentID"),
                        UniqueID = database.Guid(row, "UniqueID"),
                        Acronym = row.Field<string>("Acronym"),
                        Name = row.Field<string>("Name"),
                        IsConcentrator = Convert.ToBoolean(row.Field<object>("IsConcentrator")),
                        CompanyID = row.ConvertNullableField<int>("CompanyID"),
                        HistorianID = row.ConvertNullableField<int>("HistorianID"),
                        AccessID = row.ConvertField<int>("AccessID"),
                        VendorDeviceID = row.ConvertNullableField<int>("VendorDeviceID"),
                        ProtocolID = row.ConvertNullableField<int>("ProtocolID"),
                        Longitude = row.ConvertNullableField<decimal>("Longitude"),
                        Latitude = row.ConvertNullableField<decimal>("Latitude"),
                        InterconnectionID = row.ConvertNullableField<int>("InterconnectionID"),
                        ConnectionString = ParseConnectionString(row.Field<string>("ConnectionString")),
                        AlternateCommandChannel = ParseAlternateCommand(row.Field<string>("ConnectionString")),
                        TimeZone = row.Field<string>("TimeZone"),
                        FramesPerSecond = Convert.ToInt32(row.Field<object>("FramesPerSecond") ?? 30),
                        TimeAdjustmentTicks = Convert.ToInt64(row.Field<object>("TimeAdjustmentTicks")),
                        DataLossInterval = row.ConvertField<double>("DataLossInterval"),
                        ContactList = row.Field<string>("ContactList"),
                        MeasuredLines = row.ConvertNullableField<int>("MeasuredLines"),
                        LoadOrder = row.ConvertField<int>("LoadOrder"),
                        Enabled = false, // We will use enable flag for check boxes on output stream device wizard so that we do not need to add selected flag.
                        CreatedOn = row.Field<DateTime>("CreatedOn"),
                        AllowedParsingExceptions = Convert.ToInt32(row.Field<object>("AllowedParsingExceptions")),
                        ParsingExceptionWindow = row.ConvertField<double>("ParsingExceptionWindow"),
                        DelayedConnectionInterval = row.ConvertField<double>("DelayedConnectionInterval"),
                        AllowUseOfCachedConfiguration = Convert.ToBoolean(row.Field<object>("AllowUseOfCachedConfiguration")),
                        AutoStartDataParsingSequence = Convert.ToBoolean(row.Field<object>("AutoStartDataParsingSequence")),
                        SkipDisableRealTimeData = Convert.ToBoolean(row.Field<object>("SkipDisableRealTimeData")),
                        MeasurementReportingInterval = Convert.ToInt32(row.Field<object>("MeasurementReportingInterval")),
                        ConnectOnDemand = Convert.ToBoolean(row.Field<object>("ConnectOnDemand")),
                        m_companyName = row.Field<string>("CompanyName"),
                        m_companyAcronym = row.Field<string>("CompanyAcronym"),
                        m_historianAcronym = row.Field<string>("HistorianAcronym"),
                        m_vendorDeviceName = row.Field<string>("VendorDeviceName"),
                        m_vendorAcronym = row.Field<string>("VendorAcronym"),
                        m_protocolName = row.Field<string>("ProtocolName"),
                        m_interconnectionName = row.Field<string>("InterconnectionName"),
                        m_nodeName = row.Field<string>("NodeName"),
                        m_parentAcronym = row.Field<string>("ParentAcronym"),
                        m_originalSource = row.Field<string>("OriginalSource")
                    });
                }

                return deviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Retrieves a collection of devices where original source is not null for mirroring output stream.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="isOptional">Boolean flag indicating if selection is optional on the UI.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> type collection of Devices.</returns>
        public static Dictionary<string, string> GetDevicesForMirroringOutputStream(AdoDataConnection database, bool isOptional = true)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<string, string> deviceList = new Dictionary<string, string>();

                if (isOptional)
                    deviceList.Add("", "Select Mirroring Source");

                DataTable deviceTable;
                string query;

                query = database.ParameterizedQueryString("SELECT DISTINCT OriginalSource FROM Device WHERE NodeID = {0} AND OriginalSource IS NOT NULL ORDER BY OriginalSource", "nodeID");
                deviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, database.CurrentNodeID());

                foreach (DataRow row in deviceTable.Rows)
                    deviceList[row.ConvertField<string>("OriginalSource")] = row.Field<string>("OriginalSource");

                return deviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        #endregion
    }
}
