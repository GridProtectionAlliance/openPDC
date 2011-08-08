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
using System.Collections.ObjectModel;
using TimeSeriesFramework.UI;
using TVA.Data;

namespace openPDCManager.UI.DataModels
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

        public static ObservableCollection<RealTimeStream> Load(AdoDataConnection database, Guid nodeID)
        {
            bool createdConnection = false;
            try
            {
                ObservableCollection<RealTimeStream> realTimeStreamList = new ObservableCollection<RealTimeStream>();
                createdConnection = CreateConnection(ref database);



                return realTimeStreamList;
            }
            finally
            {

            }
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
        private string m_description;
        private string m_signalName;
        private string m_engineeringUnit;
        private bool m_expanded;
        private bool m_selected;
        private string m_timeTag;
        private string m_value;
        private string m_quality;

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

        #endregion
    }

}
