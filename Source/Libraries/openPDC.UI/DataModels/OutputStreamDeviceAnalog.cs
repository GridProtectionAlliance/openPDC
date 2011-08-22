//******************************************************************************************************
//  OutputStreamDeviceAnalog.cs - Gbtc
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
//  08/5/2011 - Aniket Salver
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
    /// Represents a record of <see cref="OutputStreamDeviceAnalog"/> information as defined in the database.
    /// </summary>
    public class OutputStreamDeviceAnalog : DataModelBase
    {
        # region[Members]

        private string m_nodeID;
        private int m_outputStreamDeviceID;
        private int m_id;
        private string m_label;
        private int m_type;
        private int m_scalingValue;
        private int m_loadOrder;
        private string m_typeName;
        private DateTime m_createdOn;
        private string m_createdBy;
        private DateTime m_updatedOn;
        private string m_updatedBy;

        #endregion

        #region [properties]

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s NodeID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog NodeID is a required field, please provide value.")]
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
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s OutputStreamDeviceID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog OutputStreamDeviceID is a required field, please provide value.")]
        public int OutputStreamDeviceID
        {
            get
            {
                return m_outputStreamDeviceID;
            }
            set
            {
                m_outputStreamDeviceID = value;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s ID.
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
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s Label.
        /// </summary>
        [StringLength(16, ErrorMessage = "OutputStreamDeviceAnalog Label cannot exceed 16 characters.")]
        public string Label
        {
            get
            {
                return m_label;
            }
            set
            {
                m_label = value;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s Type.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog Type is a required field, please provide value.")]
        public int Type
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s ScalingValue.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog ScalingValue is a required field, please provide value.")]
        public int ScalingValue
        {
            get
            {
                return m_scalingValue;
            }
            set
            {
                m_scalingValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s LoadOrder.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog LoadOrder is a required field, please provide value.")]
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
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s TypeName.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog TypeName is a required field, please provide value.")]
        public string TypeName
        {
            get
            {
                return m_typeName;
            }
            set
            {
                m_typeName = value;
            }
        }

        /// <summary>
        /// Gets or sets the Date or Time the current <see cref="OutputStreamDeviceAnalog"/> was created on.
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
        /// Gets or sets who the current <see cref="OutputStreamDeviceAnalog"/> was created by.
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
        /// Gets or sets the Date or Time when the current <see cref="OutputStreamDeviceAnalog"/> was updated on.
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
        /// Gets or sets who the current <see cref="OutputStreamDeviceAnalog"/> was updated by.
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

        #region[Static]

        // Static Methods

        /// <summary>
        /// Loads <see cref="OutputStreamDeviceAnalog"/> information as an <see cref="ObservableCollection{T}"/> style list.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamDeviceID">ID of the <see cref="OutputStreamDevice"/> to filter data.</param>
        /// <returns>Collection of <see cref="OutputStreamDeviceAnalog"/>.</returns>
        public static ObservableCollection<OutputStreamDeviceAnalog> Load(AdoDataConnection database, int outputStreamDeviceID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<OutputStreamDeviceAnalog> OutputStreamDeviceAnalogList = new ObservableCollection<OutputStreamDeviceAnalog>();
                DataTable OutputStreamDeviceAnalogTable = database.Connection.RetrieveData(database.AdapterType, "SELECT NodeID, OutputStreamDeviceID, ID, Label, " +
                    "Type, ScalingValue, LoadOrder, TypeName  " +
                    "FROM OutputStreamDeviceAnalog ORDER BY LoadOrder");
                // WHERE AdapterID = @outputStreamID // DefaultTimeout, outputStreamID

                foreach (DataRow row in OutputStreamDeviceAnalogTable.Rows)
                {
                    OutputStreamDeviceAnalogList.Add(new OutputStreamDeviceAnalog()
                    {
                        NodeID = row.Field<string>("NodeID"),
                        OutputStreamDeviceID = row.ConvertField<int>("OutputStreamDeviceID"),
                        ID = row.ConvertField<int>("ID"),
                        Label = row.Field<string>("Label"),
                        Type = row.ConvertField<int>("Type"),
                        ScalingValue = row.Field<int>("ScalingValue"),
                        LoadOrder = row.ConvertField<int>("LoadOrder"),
                        TypeName = row.Field<string>("TypeName"),
                    });
                }

                return OutputStreamDeviceAnalogList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="OutputStreamDeviceAnalog"/> information.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of OutputStreamDeviceAnalog defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = false)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> OutputStreamDeviceAnalogList = new Dictionary<int, string>();
                if (isOptional)
                    OutputStreamDeviceAnalogList.Add(0, "Select OutputStreamDeviceAnalog");

                DataTable OutputStreamDeviceAnalogTable = database.Connection.RetrieveData(database.AdapterType, "SELECT ID, Name FROM OutputStreamDeviceAnalog ORDER BY LoadOrder");

                foreach (DataRow row in OutputStreamDeviceAnalogTable.Rows)
                    OutputStreamDeviceAnalogList[row.ConvertField<int>("ID")] = row.Field<string>("Name");

                return OutputStreamDeviceAnalogList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Saves <see cref="OutputStreamDeviceAnalog"/> information to database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="OutputStreamDeviceAnalog">Information about <see cref="OutputStreamDeviceAnalog"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, OutputStreamDeviceAnalog OutputStreamDeviceAnalog)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                if (OutputStreamDeviceAnalog.ID == 0)
                    database.Connection.ExecuteNonQuery("INSERT INTO OutputStreamDeviceAnalog (NodeID, OutputStreamDeviceID, ID, Label, " +
                        "Type, ScalingValue, LoadOrder, TypeName )" +
                        "VALUES (@nodeID, @outputStreamDeviceID, @id, @label, @type, @scalingValue, @loadOrder, @typeName, @updatedBy, @updatedOn, @createdBy, @createdOn)", DefaultTimeout,
                        OutputStreamDeviceAnalog.NodeID, OutputStreamDeviceAnalog.OutputStreamDeviceID, OutputStreamDeviceAnalog.ID, OutputStreamDeviceAnalog.Label, OutputStreamDeviceAnalog.Type,
                        OutputStreamDeviceAnalog.ScalingValue, OutputStreamDeviceAnalog.LoadOrder, OutputStreamDeviceAnalog.TypeName, CommonFunctions.CurrentUser, database.UtcNow(),
                        CommonFunctions.CurrentUser, database.UtcNow());
                else
                    database.Connection.ExecuteNonQuery("UPDATE OutputStreamDeviceAnalog SET NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID , ID = @id, Label = @label, Type = @type, " +
                    " ScalingValue = @scalingValue, LoadOrder = @loadOrder,  TypeName= @typeName, " +
                    "UpdatedBy = @updatedBy, UpdatedOn = @updatedOn, CreatedBy = @createdBy, CreatedOn = @createdOn " +
                     DefaultTimeout, OutputStreamDeviceAnalog.NodeID, OutputStreamDeviceAnalog.OutputStreamDeviceID, OutputStreamDeviceAnalog.ID, OutputStreamDeviceAnalog.Label, OutputStreamDeviceAnalog.Type,
                        OutputStreamDeviceAnalog.ScalingValue, OutputStreamDeviceAnalog.LoadOrder, OutputStreamDeviceAnalog.TypeName, CommonFunctions.CurrentUser, database.UtcNow(), OutputStreamDeviceAnalog.ID);

                return "OutputStreamDeviceAnalog information saved successfully";
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Deletes specified <see cref="OutputStreamDeviceAnalog"/> record from database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="OutputStreamDeviceAnalogID">ID of the record to be deleted.</param>
        /// <returns>String, for display use, indicating success.</returns>
        public static string Delete(AdoDataConnection database, int OutputStreamDeviceAnalogID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                // Setup current user context for any delete triggers
                CommonFunctions.SetCurrentUserContext(database);

                database.Connection.ExecuteNonQuery("DELETE FROM OutputStreamDeviceAnalog WHERE ID = @OutputStreamDeviceAnalogID", DefaultTimeout, OutputStreamDeviceAnalogID);

                return "OutputStreamDeviceAnalog deleted successfully";
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
