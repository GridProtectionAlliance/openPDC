//******************************************************************************************************
//  OutputStreamDevice.cs - Gbtc
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
//   08/4/2011 - Aniket Salver
//       Generated original version of source code.
//   09/19/2011 - Mehulbhai P Thakkar
//       Added OnPropertyChanged() on all properties to reflect changes on UI.
//       Fixed Load() and GetLookupList() static methods.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using TimeSeriesFramework.UI;
using TVA.Data;

namespace openPDC.UI.DataModels
{
    /// <summary>
    /// Represents a record of <see cref="OutputStreamDevice"/> information as defined in the database.
    /// </summary>
    public class OutputStreamDevice : DataModelBase
    {
        #region[Members]

        private Guid m_nodeID;
        private int m_adapterID;
        private int m_id;
        private int m_idCode;
        private string m_acronym;
        private string m_bpaAcronym;
        private string m_name;
        private string m_phasorDataFormat;
        private string m_frequencyDataFormat;
        private string m_analogDataFormat;
        private string m_coordinateFormat;
        private int m_loadOrder;
        private bool m_enabled;
        private bool m_virtual;
        private DateTime m_createdOn;
        private string m_createdBy;
        private DateTime m_updatedOn;
        private string m_updatedBy;

        #endregion

        #region[properties]

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s NodeID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDevice NodeID is a required field, please provide value.")]
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
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s AdapterID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDevice AdapterID is a required field, please provide value.")]
        public int AdapterID
        {
            get
            {
                return m_adapterID;
            }
            set
            {
                m_adapterID = value;
                OnPropertyChanged("AdapterID");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s ID.
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
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s IDCode.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDevice IdCode is a required field, please provide value.")]
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

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s Acronym.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDevice acronym is a required field, please provide value.")]
        [StringLength(200, ErrorMessage = "OutputStreamDevice acronym cannot exceed 200 characters.")]
        [RegularExpression("^[A-Z0-9-'!'_]+$", ErrorMessage = "Only upper case letters, numbers, '!', '-' and '_' are allowed.")]
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
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s BpaAcronym.
        /// </summary>
        [StringLength(4, ErrorMessage = "OutputStreamDevice BpaAcronym cannot exceed 4 characters.")]
        public string BpaAcronym
        {
            get
            {
                return m_bpaAcronym;
            }
            set
            {
                m_bpaAcronym = value;
                OnPropertyChanged("BpaAcronym");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s Name.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDevice Name is a required field, please provide value.")]
        [StringLength(200, ErrorMessage = "OutputStreamDevice Name cannot exceed 200 characters.")]
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
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s PhasorDataFormat.
        /// </summary>
        [StringLength(15, ErrorMessage = "OutputStreamDevice PhasorDataFormat cannot exceed 15 characters.")]
        public string PhasorDataFormat
        {
            get
            {
                return m_phasorDataFormat;
            }
            set
            {
                m_phasorDataFormat = value;
                OnPropertyChanged("PhasorDataFormat");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s FrequencyDataFormat.
        /// </summary>
        [StringLength(15, ErrorMessage = "OutputStreamDevice FrequencyDataFormat cannot exceed 15 characters.")]
        public string FrequencyDataFormat
        {
            get
            {
                return m_frequencyDataFormat;
            }
            set
            {
                m_frequencyDataFormat = value;
                OnPropertyChanged("FrequencyDataFormat");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s AnalogDataFormat.
        /// </summary>
        [StringLength(15, ErrorMessage = "OutputStreamDevice AnalogDataFormat cannot exceed 15 characters.")]
        public string AnalogDataFormat
        {
            get
            {
                return m_analogDataFormat;
            }
            set
            {
                m_analogDataFormat = value;
                OnPropertyChanged("AnalogDataFormat");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s CoordinateFormat.
        /// </summary>
        [StringLength(15, ErrorMessage = "OutputStreamDevice CoordinateFormat cannot exceed 15 characters.")]
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

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s LoadOrder.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDevice LoadOrder is a required field, please provide value.")]
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
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s Enabled.
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
        /// Gets or sets the current <see cref="OutputStreamDevice"/>'s Virtual.
        /// </summary>
        public bool Virtual
        {
            get
            {
                return m_virtual;
            }
            set
            {
                m_virtual = value;
                OnPropertyChanged("Virtual");
            }
        }

        /// <summary>
        /// Gets or sets the Date or Time the current <see cref="OutputStreamDevice"/> was created on.
        /// </summary>
        // Field is populated by trigger and has no screen interaction, so no validation attributes are applied
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
        /// Gets or sets who the current <see cref="OutputStreamDevice"/> was created by.
        /// </summary>
        // Field is populated by trigger and has no screen interaction, so no validation attributes are applied
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
        /// Gets or sets the Date or Time when the current <see cref="OutputStreamDevice"/> was updated on.
        /// </summary>
        // Field is populated by trigger and has no screen interaction, so no validation attributes are applied
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
        /// Gets or sets who the current <see cref="OutputStreamDevice"/> was updated by.
        /// </summary>
        // Field is populated by trigger and has no screen interaction, so no validation attributes are applied
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

        #endregion

        #region[static]

        // Static Methods

        /// <summary>
        /// Loads <see cref="OutputStreamDevice"/> information as an <see cref="ObservableCollection{T}"/> style list.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamID">ID of the OutputStream to filter data.</param>
        /// <returns>Collection of <see cref="OutputStreamDevice"/>.</returns>
        public static ObservableCollection<OutputStreamDevice> Load(AdoDataConnection database, int outputStreamID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<OutputStreamDevice> OutputStreamDeviceList = new ObservableCollection<OutputStreamDevice>();
                string query = database.ParameterizedQueryString("SELECT NodeID, AdapterID, ID, IDCode, Acronym, BpaAcronym " +
                    "Name, PhasorDataFormat, FrequencyDataFormat, AnalogDataFormat, CoordinateFormat, LoadOrder, Enabled, Virtual  " +
                    "FROM OutputStreamDeviceDetail WHERE AdapterID = {0} ORDER BY LoadOrder", "outputStreamID");
                DataTable OutputStreamDeviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, outputStreamID);

                foreach (DataRow row in OutputStreamDeviceTable.Rows)
                {
                    OutputStreamDeviceList.Add(new OutputStreamDevice()
                    {
                        NodeID = row.Field<Guid>("NodeID"),
                        AdapterID = row.ConvertField<int>("AdapterID"),
                        ID = row.ConvertField<int>("ID"),
                        IDCode = row.ConvertField<int>("IDCode"),
                        Acronym = row.Field<string>("Acronym"),
                        BpaAcronym = row.Field<string>("BpaAcronym"),
                        Name = row.Field<string>("Name"),
                        PhasorDataFormat = row.Field<string>("PhasorDataFormat"),
                        FrequencyDataFormat = row.Field<string>("FrequencyDataFormat"),
                        AnalogDataFormat = row.Field<string>("AnalogDataFormat"),
                        CoordinateFormat = row.Field<string>("CoordinateFormat"),
                        LoadOrder = row.ConvertField<int>("LoadOrder"),
                        Enabled = Convert.ToBoolean(row.Field<object>("Enabled")),
                        Virtual = Convert.ToBoolean(row.Field<object>("Virtual"))
                    });
                }

                return OutputStreamDeviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="OutputStreamDevice"/> information.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamID">ID of the output stream to filter data.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of OutputStreamDevice defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, int outputStreamID, bool isOptional = false)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> OutputStreamDeviceList = new Dictionary<int, string>();
                if (isOptional)
                    OutputStreamDeviceList.Add(0, "Select OutputStreamDevice");

                string query = database.ParameterizedQueryString("SELECT ID, Name FROM OutputStreamDevice WHERE AdapterID = {0} ORDER BY LoadOrder", "adapterID");
                DataTable OutputStreamDeviceTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, outputStreamID);

                foreach (DataRow row in OutputStreamDeviceTable.Rows)
                    OutputStreamDeviceList[row.ConvertField<int>("ID")] = row.Field<string>("Name");

                return OutputStreamDeviceList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Saves <see cref="OutputStreamDevice"/> information to database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamDevice">Information about <see cref="OutputStreamDevice"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, OutputStreamDevice outputStreamDevice)
        {
            bool createdConnection = false;
            string query;

            try
            {
                createdConnection = CreateConnection(ref database);

                if (outputStreamDevice.ID == 0)
                {
                    query = database.ParameterizedQueryString("INSERT INTO OutputStreamDevice (NodeID, AdapterID, IDCode, Acronym, BpaAcronym, Name, " +
                        "PhasorDataFormat, FrequencyDataFormat, AnalogDataFormat, CoordinateFormat, LoadOrder, Enabled, Virtual, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn)" +
                        "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16})", "nodeID", "adapterID", "idCode", "acronym",
                        "bpaAcronym", "name", "phasorDataFormat", "frequencyDataFormat", "analogDataFormat", "coordinateFormat", "loadOrder", "enabled", "virtual",
                        "updatedBy", "updatedOn", "createdBy", "createdOn");

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, outputStreamDevice.NodeID, outputStreamDevice.AdapterID, outputStreamDevice.IDCode,
                        outputStreamDevice.Acronym, outputStreamDevice.BpaAcronym.ToNotNull(), outputStreamDevice.Name, outputStreamDevice.PhasorDataFormat.ToNotNull(),
                        outputStreamDevice.FrequencyDataFormat.ToNotNull(), outputStreamDevice.AnalogDataFormat.ToNotNull(), outputStreamDevice.CoordinateFormat.ToNotNull(),
                        outputStreamDevice.LoadOrder, database.Bool(outputStreamDevice.Enabled), database.Bool(outputStreamDevice.Virtual), CommonFunctions.CurrentUser,
                        database.UtcNow(), CommonFunctions.CurrentUser, database.UtcNow());
                }
                else
                {
                    query = database.ParameterizedQueryString("UPDATE OutputStreamDevice SET NodeID = {0}, AdapterID = {1}, IDCode = {2}, Acronym = {3}, BpaAcronym = {4}, " +
                        "Name = {5}, PhasorDataFormat = {6}, FrequencyDataFormat = {7}, AnalogDataFormat = {8}, CoordinateFormat = {9}, LoadOrder = {10}, Enabled = {11}, " +
                        "Virtual = {12}, UpdatedBy = {13}, UpdatedOn = {14} WHERE ID = {15}", "nodeID", "adapterID", "idCode", "acronym", "bpaAcronym", "name",
                        "phasorDataFormat", "frequencyDataFormat", "analogDataFormat", "coordinateFormat", "loadOrder", "enabled", "virtual", "updatedBy", "updatedOn", "id");

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, outputStreamDevice.NodeID, outputStreamDevice.AdapterID, outputStreamDevice.IDCode,
                        outputStreamDevice.Acronym, outputStreamDevice.BpaAcronym.ToNotNull(), outputStreamDevice.Name, outputStreamDevice.PhasorDataFormat.ToNotNull(),
                        outputStreamDevice.FrequencyDataFormat.ToNotNull(), outputStreamDevice.AnalogDataFormat.ToNotNull(), outputStreamDevice.CoordinateFormat.ToNotNull(),
                        outputStreamDevice.LoadOrder, database.Bool(outputStreamDevice.Enabled), database.Bool(outputStreamDevice.Virtual), CommonFunctions.CurrentUser,
                        database.UtcNow(), outputStreamDevice.ID);
                }

                return "OutputStreamDevice information saved successfully";
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Deletes specified <see cref="OutputStreamDevice"/> record from database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="OutputStreamDeviceID">ID of the record to be deleted.</param>
        /// <returns>String, for display use, indicating success.</returns>
        public static string Delete(AdoDataConnection database, int OutputStreamDeviceID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                // Setup current user context for any delete triggers
                CommonFunctions.SetCurrentUserContext(database);

                database.Connection.ExecuteNonQuery(database.ParameterizedQueryString("DELETE FROM OutputStreamDevice WHERE ID = {0}", "outputStreamDeviceID"), DefaultTimeout, OutputStreamDeviceID);

                return "OutputStreamDevice deleted successfully";
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


