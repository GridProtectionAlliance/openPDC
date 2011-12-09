//******************************************************************************************************
//  OutputStreamDeviceDigital.cs - Gbtc
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
//  08/10/2011 - Aniket Salver
//       Generated original version of source code.
//   09/19/2011 - Mehulbhai P Thakkar
//       Added OnPropertyChanged() on all properties to reflect changes on UI.
//       Fixed Load() and GetLookupList() static methods.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using TimeSeriesFramework.UI;
using TVA;
using TVA.Data;

namespace openPDC.UI.DataModels
{
    /// <summary>
    /// Represents a record of <see cref="OutputStreamDeviceDigital"/> information as defined in the database.
    /// </summary>
    public class OutputStreamDeviceDigital : DataModelBase
    {
        #region [Members]

        private Guid m_nodeID;
        private int m_outputStreamDeviceID;
        private int m_id;
        private string m_label;
        private int m_maskValue;
        private int m_loadOrder;
        private DateTime m_createdOn;
        private string m_createdBy;
        private DateTime m_updatedOn;
        private string m_updatedBy;

        #endregion

        #region [Properties]

        /// <summary>
        /// Gets or sets <see cref="OutputStreamDeviceDigital"/> NodeID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceDigital NodeID is a required field, please provide value.")]
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
        /// Gets or sets <see cref="OutputStreamDeviceDigital"/> OutputStreamDeviceID.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceDigital OutputStreamDeviceID is a required field, please provide value.")]
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
        /// Gets or sets <see cref="OutputStreamDeviceDigital"/> ID.
        /// </summary>
        // Field is populated by database via auto-increment and has no screen interaction, so no validation attributes are applied
        [Required(ErrorMessage = "OutputStreamDeviceDigital ID is a required field, please provide value.")]
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
        /// Gets or sets <see cref="OutputStreamDeviceDigital"/> Label.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceDigital Label is a required field, please provide value.")]
        [StringLength(200, ErrorMessage = "OutputStreamDeviceDigital Label cannot exceed 200 characters.")]
        public string Label
        {
            get
            {
                return m_label;
            }
            set
            {
                m_label = string.Empty;
                foreach (string label in value.Replace("\r\n", " ").Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (label.Length > 16)
                    {
                        foreach (string str in label.GetSegments(16))
                            m_label += str.ToUpper() + Environment.NewLine;
                    }
                    else
                        m_label += label.ToUpper() + Environment.NewLine;
                }
                OnPropertyChanged("Label");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStreamDeviceDigital"/> MaskValue.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceDigital MaskValue is a required field, please provide value.")]
        public int MaskValue
        {
            get
            {
                return m_maskValue;
            }
            set
            {
                m_maskValue = value;
                OnPropertyChanged("MaskValue");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStreamDeviceDigital"/> LoadOrder.
        /// </summary>
        [Required(ErrorMessage = "OutputStreamDeviceDigital LoadOrder is a required field, please provide value.")]
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
        /// Gets or sets when the current <see cref="OutputStreamDeviceDigital"/> was created.
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
        /// Gets or sets who the current <see cref="OutputStreamDeviceDigital"/> was created by.
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
        /// Gets or sets when the current <see cref="OutputStreamDeviceDigital"/> was updated.
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
        /// Gets or sets who the current <see cref="OutputStreamDeviceDigital"/> was updated by.
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
        /// Loads <see cref="OutputStreamDeviceDigital"/> information as an <see cref="ObservableCollection{T}"/> style list.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamDeviceID">ID of the output stream device to filter data.</param>
        /// <returns>Collection of <see cref="OutputStreamDeviceDigital"/>.</returns>
        public static ObservableCollection<OutputStreamDeviceDigital> Load(AdoDataConnection database, int outputStreamDeviceID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<OutputStreamDeviceDigital> outputStreamDeviceDigitalList = new ObservableCollection<OutputStreamDeviceDigital>();
                string query = database.ParameterizedQueryString("SELECT NodeID, OutputStreamDeviceID, ID, Label, MaskValue, LoadOrder " +
                    "FROM OutputStreamDeviceDigital WHERE OutputStreamDeviceID = {0} ORDER BY LoadOrder", "id");
                DataTable outputStreamDeviceDigitalTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, outputStreamDeviceID);

                foreach (DataRow row in outputStreamDeviceDigitalTable.Rows)
                {
                    outputStreamDeviceDigitalList.Add(new OutputStreamDeviceDigital()
                    {
                        NodeID = row.ConvertField<Guid>("NodeID"),
                        OutputStreamDeviceID = row.ConvertField<int>("OutputStreamDeviceID"),
                        ID = row.ConvertField<int>("ID"),
                        Label = row.Field<string>("Label"),
                        MaskValue = row.ConvertField<int>("MaskValue"),
                        LoadOrder = row.ConvertField<int>("LoadOrder")
                    });
                }

                return outputStreamDeviceDigitalList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="OutputStreamDeviceDigital"/> information.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamDeviceID">ID of the output stream device to filter data.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Label of OutputStreamDeviceDigitals defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, int outputStreamDeviceID, bool isOptional = false)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> OutputStreamDeviceDigitalList = new Dictionary<int, string>();
                if (isOptional)
                    OutputStreamDeviceDigitalList.Add(0, "Select OutputStreamDeviceDigital");

                string query = database.ParameterizedQueryString("SELECT ID, Label FROM OutputStreamDeviceDigital " +
                    "WHERE OutputStreamDeviceID = {0} ORDER BY LoadOrder", "outputStreamDeviceID");
                DataTable OutputStreamDeviceDigitalTable = database.Connection.RetrieveData(database.AdapterType, query, DefaultTimeout, outputStreamDeviceID);

                foreach (DataRow row in OutputStreamDeviceDigitalTable.Rows)
                    OutputStreamDeviceDigitalList[row.ConvertField<int>("ID")] = row.Field<string>("Label");

                return OutputStreamDeviceDigitalList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Saves <see cref="OutputStreamDeviceDigital"/> information to database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamDeviceDigital">Information about <see cref="OutputStreamDeviceDigital"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, OutputStreamDeviceDigital outputStreamDeviceDigital)
        {
            bool createdConnection = false;
            string query;

            try
            {
                createdConnection = CreateConnection(ref database);

                int i = 0;
                string paddedLabel = string.Empty;
                foreach (string label in outputStreamDeviceDigital.Label.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (i >= 8)
                        break;

                    string temp = label.Replace(" ", "");
                    if (temp.Length > 16)
                        paddedLabel += temp.Substring(0, 16).ToUpper();
                    else
                        paddedLabel += temp.ToUpper().PadRight(16);

                    i++;
                }

                outputStreamDeviceDigital.Label = paddedLabel.PadRight(128);

                if (outputStreamDeviceDigital.ID == 0)
                {
                    query = database.ParameterizedQueryString("INSERT INTO OutputStreamDeviceDigital (NodeID, OutputStreamDeviceID, Label, MaskValue, LoadOrder, " +
                        "UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})", "nodeID", "outputStreamDeviceID", "label",
                        "maskValue", "loadOrder", "updatedBy", "updatedOn", "createdBy", "createdOn");

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, database.CurrentNodeID(), outputStreamDeviceDigital.OutputStreamDeviceID,
                        outputStreamDeviceDigital.Label, outputStreamDeviceDigital.MaskValue, outputStreamDeviceDigital.LoadOrder, CommonFunctions.CurrentUser,
                        database.UtcNow(), CommonFunctions.CurrentUser, database.UtcNow());
                }
                else
                {
                    query = database.ParameterizedQueryString("UPDATE OutputStreamDeviceDigital SET NodeID = {0}, OutputStreamDeviceID = {1}, Label = {2}, MaskValue = {3}, " +
                        "LoadOrder = {4}, UpdatedBy = {5}, UpdatedOn = {6} WHERE ID = {7}", "nodeID", "outputStreamDeviceID", "label", "maskValue", "loadOrder", "updatedBy",
                        "updatedOn", "id");

                    database.Connection.ExecuteNonQuery(query, DefaultTimeout, outputStreamDeviceDigital.NodeID, outputStreamDeviceDigital.OutputStreamDeviceID,
                        outputStreamDeviceDigital.Label, outputStreamDeviceDigital.MaskValue, outputStreamDeviceDigital.LoadOrder, CommonFunctions.CurrentUser,
                        database.UtcNow(), outputStreamDeviceDigital.ID);
                }

                return "OutputStreamDeviceDigital information saved successfully";
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Deletes specified <see cref="OutputStreamDeviceDigital"/> record from database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="OutputStreamDeviceDigitalID">ID of the record to be deleted.</param>
        /// <returns>String, for display use, indicating success.</returns>
        public static string Delete(AdoDataConnection database, int OutputStreamDeviceDigitalID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                // Setup current user context for any delete triggers
                CommonFunctions.SetCurrentUserContext(database);

                database.Connection.ExecuteNonQuery(database.ParameterizedQueryString("DELETE FROM OutputStreamDeviceDigital WHERE ID = {0}", "outputStreamDeviceDigitalID"), DefaultTimeout, OutputStreamDeviceDigitalID);

                return "OutputStreamDeviceDigital deleted successfully";
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
