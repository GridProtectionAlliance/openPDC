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

        private string m_nodeID;
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
        public string NodeID
        {
            get
            {
                return m_nodeID;
            }
            set
            {
                m_nodeID = value;
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
        /// <param name="outputStreamID">ID of the <see cref="OutputStream"/> to filter data.</param>
        /// <returns>Collection of <see cref="OutputStreamDevice"/>.</returns>
        public static ObservableCollection<OutputStreamDevice> Load(AdoDataConnection database, int outputStreamID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<OutputStreamDevice> OutputStreamDeviceList = new ObservableCollection<OutputStreamDevice>();
                DataTable OutputStreamDeviceTable = database.Connection.RetrieveData(database.AdapterType, "SELECT NodeID, AdapterID, ID, IDCode, Acronym, BpaAcronym " +
                    "Name, PhasorDataFormat, FrequencyDataFormat, AnalogDataFormat, CoordinateFormat, LoadOrder, Enabled, Virtual  " +
                    "FROM OutputStreamDevice WHERE AdapterID = @outputStreamID ORDER BY LoadOrder", DefaultTimeout, outputStreamID);

                foreach (DataRow row in OutputStreamDeviceTable.Rows)
                {
                    OutputStreamDeviceList.Add(new OutputStreamDevice()
                    {
                        NodeID = row.Field<string>("NodeID"),
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
                        Virtual = Convert.ToBoolean(row.Field<object>("Virtual")),
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
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of OutputStreamDevice defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = false)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> OutputStreamDeviceList = new Dictionary<int, string>();
                if (isOptional)
                    OutputStreamDeviceList.Add(0, "Select OutputStreamDevice");

                DataTable OutputStreamDeviceTable = database.Connection.RetrieveData(database.AdapterType, "SELECT ID, Name FROM OutputStreamDevice ORDER BY LoadOrder");

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
        /// <param name="OutputStreamDevice">Information about <see cref="OutputStreamDevice"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, OutputStreamDevice OutputStreamDevice)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                if (OutputStreamDevice.ID == 0)
                    database.Connection.ExecuteNonQuery("INSERT INTO OutputStreamDevice (NodeID, AdapterID, ID, IDCode, Acronym, BpaAcronym, Name, " +
                        "PhasorDataFormat, FrequencyDataFormat, AnalogDataFormat, CoordinateFormat, LoadOrder, Enabled, Virtual, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn)" +
                        "VALUES (@nodeID, @adapterID, @iD, @iDCode, @acronym, @bpaAcronym, @name, @phasorDataFormat, @frequencyDataFormat, @analogDataFormat, @coordinateFormat, @loadOrder, @enabled, @virtual, @updatedBy, @updatedOn, @createdBy, @createdOn)", DefaultTimeout,
                        OutputStreamDevice.NodeID, OutputStreamDevice.AdapterID, OutputStreamDevice.ID, OutputStreamDevice.IDCode, OutputStreamDevice.Acronym,
                        OutputStreamDevice.BpaAcronym.ToNotNull(), OutputStreamDevice.Name, OutputStreamDevice.PhasorDataFormat.ToNotNull(), OutputStreamDevice.FrequencyDataFormat.ToNotNull(),
                        OutputStreamDevice.AnalogDataFormat.ToNotNull(), OutputStreamDevice.CoordinateFormat.ToNotNull(), OutputStreamDevice.LoadOrder,
                        OutputStreamDevice.Enabled, OutputStreamDevice.Virtual, CommonFunctions.CurrentUser, database.UtcNow(),
                        CommonFunctions.CurrentUser, database.UtcNow());
                else
                    database.Connection.ExecuteNonQuery("UPDATE OutputStreamDevice SET NodeID = @nodeID, AdapterID = @adapterID , ID = @iD, IDCode = @iDCode, Acronym = @acronym, BpaAcronym = @bpaAcronym, Name = @name, " +
                    "PhasorDataFormat = @phasorDataFormat, FrequencyDataFormat = @frequencyDataFormat, AnalogDataFormat = @analogDataFormat, CoordinateFormat = @coordinateFormat , LoadOrder = @loadOrder, " +
                    "Enabled = @enabled, Virtual = @virtual, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn, CreatedBy = @createdBy, CreatedOn = @createdOn " +
                     DefaultTimeout, OutputStreamDevice.NodeID, OutputStreamDevice.AdapterID, OutputStreamDevice.ID, OutputStreamDevice.IDCode, OutputStreamDevice.Acronym,
                     OutputStreamDevice.BpaAcronym.ToNotNull(), OutputStreamDevice.Name, OutputStreamDevice.PhasorDataFormat.ToNotNull(), OutputStreamDevice.FrequencyDataFormat.ToNotNull(),
                     OutputStreamDevice.AnalogDataFormat.ToNotNull(), OutputStreamDevice.CoordinateFormat.ToNotNull(), OutputStreamDevice.LoadOrder,
                     OutputStreamDevice.Enabled, OutputStreamDevice.Virtual, CommonFunctions.CurrentUser, database.UtcNow(), OutputStreamDevice.ID);

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

                database.Connection.ExecuteNonQuery("DELETE FROM OutputStreamDevice WHERE ID = @OutputStreamDeviceID", DefaultTimeout, OutputStreamDeviceID);

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


