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
//  09/16/2011 - Mehulbhai P Thakkar
//       Fixed load method to filter data correctly.
//   09/19/2011 - Mehulbhai P Thakkar
//       Added OnPropertyChanged() on all properties to reflect changes on UI.
//       Fixed database queries and collection population.
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
    /// Represents a record of <see cref="OutputStreamDeviceAnalog"/> information as defined in the database.
    /// </summary>
    public class OutputStreamDeviceAnalog : DataModelBase
    {
        #region [ Members ]

        private Guid m_nodeID;
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

        #region [ Properties ]

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s NodeID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog NodeID is a required field, please provide value.")]
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
                OnPropertyChanged("OutputStreamDeviceID");
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
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="OutputStreamDeviceAnalog"/>'s Label.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceAnalog Lable is a required field, please provide value.")]
        [StringLength(16, ErrorMessage = "OutputStreamDeviceAnalog Label cannot exceed 16 characters.")]
        public string Label
        {
            get
            {
                return m_label;
            }
            set
            {
                if (value.Length > 16)
                    m_label = value.Substring(0, 16);
                else
                    m_label = value;
                OnPropertyChanged("Label");
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
                OnPropertyChanged("Type");
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
                OnPropertyChanged("ScalingValue");
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
                OnPropertyChanged("LoadOrder");
            }
        }

        /// <summary>
        /// Gets the current <see cref="OutputStreamDeviceAnalog"/>'s TypeName.
        /// </summary>
        public string TypeName
        {
            get
            {
                return m_typeName;
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

        #region [ Static ]

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
                string query = database.ParameterizedQueryString("SELECT NodeID, OutputStreamDeviceID, ID, Label, Type, ScalingValue, LoadOrder " +
                    "FROM OutputStreamDeviceAnalog WHERE OutputStreamDeviceID = {0} ORDER BY LoadOrder", "id");
                DataTable OutputStreamDeviceAnalogTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, outputStreamDeviceID);

                foreach (DataRow row in OutputStreamDeviceAnalogTable.Rows)
                {
                    OutputStreamDeviceAnalogList.Add(new OutputStreamDeviceAnalog()
                    {
                        NodeID = database.Guid(row, "NodeID"),
                        OutputStreamDeviceID = row.ConvertField<int>("OutputStreamDeviceID"),
                        ID = row.ConvertField<int>("ID"),
                        Label = row.Field<string>("Label"),
                        Type = row.ConvertField<int>("Type"),
                        ScalingValue = row.ConvertField<int>("ScalingValue"),
                        LoadOrder = row.ConvertField<int>("LoadOrder"),
                        m_typeName = row.ConvertField<int>("Type") == 0 ? "Single point-on-wave" : row.ConvertField<int>("Type") == 1 ? "RMS of analog input" : "Peak of analog input"
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
        /// <param name="outputStreamDeviceID">ID of the output stream device to filter data.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of OutputStreamDeviceAnalog defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, int outputStreamDeviceID, bool isOptional = false)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> OutputStreamDeviceAnalogList = new Dictionary<int, string>();
                if (isOptional)
                    OutputStreamDeviceAnalogList.Add(0, "Select OutputStreamDeviceAnalog");

                string query = database.ParameterizedQueryString("SELECT ID, Label FROM OutputStreamDeviceAnalog WHERE OutputStreamDeviceID = {0} ORDER BY LoadOrder", "outputStreamDeviceID");
                DataTable OutputStreamDeviceAnalogTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, outputStreamDeviceID);

                foreach (DataRow row in OutputStreamDeviceAnalogTable.Rows)
                    OutputStreamDeviceAnalogList[row.ConvertField<int>("ID")] = row.Field<string>("Label");

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
        /// <param name="outputStreamDeviceAnalog">Information about <see cref="OutputStreamDeviceAnalog"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, OutputStreamDeviceAnalog outputStreamDeviceAnalog)
        {
            bool createdConnection = false;
            string query;

            try
            {
                createdConnection = CreateConnection(ref database);

                if (outputStreamDeviceAnalog.ID == 0)
                {
                    query = database.ParameterizedQueryString("INSERT INTO OutputStreamDeviceAnalog (NodeID, OutputStreamDeviceID, Label, Type, ScalingValue, LoadOrder, " +
                        "UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})", "nodeID",
                        "outputStreamDeviceID", "label", "type", "scalingValue", "loadOrder", "updatedBy", "updatedOn", "createdBy", "createdOn");

                    // TypeName, "typeName",

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, database.CurrentNodeID(), outputStreamDeviceAnalog.OutputStreamDeviceID,
                        outputStreamDeviceAnalog.Label, outputStreamDeviceAnalog.Type, outputStreamDeviceAnalog.ScalingValue, outputStreamDeviceAnalog.LoadOrder,
                        CommonFunctions.CurrentUser, database.UtcNow(), CommonFunctions.CurrentUser, database.UtcNow());

                    //outputStreamDeviceAnalog.TypeName,
                }
                else
                {
                    query = database.ParameterizedQueryString("UPDATE OutputStreamDeviceAnalog SET NodeID = {0}, OutputStreamDeviceID = {1}, Label = {2}, Type = {3}, " +
                        "ScalingValue = {4}, LoadOrder = {5}, UpdatedBy = {6}, UpdatedOn = {7} WHERE ID = {8}", "nodeID", "outputStreamDeviceID",
                        "label", "type", "scalingValue", "loadOrder", "updatedBy", "updatedOn", "id");

                    //   TypeName= {6},  "typeName",

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, outputStreamDeviceAnalog.NodeID, outputStreamDeviceAnalog.OutputStreamDeviceID,
                        outputStreamDeviceAnalog.Label, outputStreamDeviceAnalog.Type, outputStreamDeviceAnalog.ScalingValue, outputStreamDeviceAnalog.LoadOrder,
                        CommonFunctions.CurrentUser, database.UtcNow(), outputStreamDeviceAnalog.ID);
                }

                //  OutputStreamDeviceAnalog.TypeName,

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

                database.Connection.ExecuteNonQuery(database.ParameterizedQueryString("DELETE FROM OutputStreamDeviceAnalog WHERE ID = {0}", "outputStreamDeviceAnalogID"), DefaultTimeout, OutputStreamDeviceAnalogID);

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
