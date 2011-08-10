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
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TVA.Data;
using TimeSeriesFramework.UI;
using System.Collections.ObjectModel;
using System.Data;

namespace openPDCManager.UI.DataModels
{
	/// <summary>
	/// Represents a record of <see cref="OutputStreamDeviceDigital"/> information as defined in the database.
	/// </summary>
	public class OutputStreamDeviceDigital : DataModelBase 
	{
		#region[Members]

		public string m_nodeID ;
		public int m_outputStreamDeviceID ;
		public int m_id; 
		public string m_label ;
		public int m_maskValue ;
		public int m_loadOrder ;
		public DateTime m_createdOn ;
		public string m_createdBy ;
		public DateTime m_updatedOn ;
		public string m_updatedBy;

		#endregion

		#region[properties]
		/// <summary>
		/// Gets or sets <see cref="OutputStreamDeviceDigital"/> NodeID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDeviceDigital NodeID is a required field, please provide value.")]
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
				m_label = value;
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
		/// <returns>Collection of <see cref="OutputStreamDeviceDigital"/>.</returns>
		public static ObservableCollection<OutputStreamDeviceDigital> Load(AdoDataConnection database)
		{
			bool createdConnection = false;

			try
			{
				createdConnection = CreateConnection(ref database);

				ObservableCollection<OutputStreamDeviceDigital> OutputStreamDeviceDigitalList = new ObservableCollection<OutputStreamDeviceDigital>();
				DataTable OutputStreamDeviceDigitalTable = database.Connection.RetrieveData(database.AdapterType, "SELECT NodeID, OutputStreamDeviceID, ID, Label, MaskValue, LoadOrder " +
					"FROM OutputStreamDeviceDigital ORDER BY LoadOrder");

				foreach (DataRow row in OutputStreamDeviceDigitalTable.Rows)
				{
					OutputStreamDeviceDigitalList.Add(new OutputStreamDeviceDigital()
					{
						NodeID = row.ConvertField<String>("NodeID"),
						OutputStreamDeviceID = row.ConvertField<int>("OutputStreamDeviceID"),
						ID = row.ConvertField<int>("ID"),
						Label = row.Field<string>("Label"),
						MaskValue = row.ConvertField<int>("MaskValue"),
						LoadOrder = row.ConvertField<int>("LoadOrder")
					});
				}

				return OutputStreamDeviceDigitalList;
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
		/// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
		/// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Label of OutputStreamDeviceDigitals defined in the database.</returns>
		public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = false)
		{
			bool createdConnection = false;
			try
			{
				createdConnection = CreateConnection(ref database);

				Dictionary<int, string> OutputStreamDeviceDigitalList = new Dictionary<int, string>();
				if (isOptional)
					OutputStreamDeviceDigitalList.Add(0, "Select OutputStreamDeviceDigital");

				DataTable OutputStreamDeviceDigitalTable = database.Connection.RetrieveData(database.AdapterType, "SELECT ID, Label FROM OutputStreamDeviceDigital ORDER BY LoadOrder");

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

		// <summary>
		/// Saves <see cref="OutputStreamDeviceDigital"/> information to database.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="OutputStreamDeviceDigital">Information about <see cref="OutputStreamDeviceDigital"/>.</param>        
		/// <returns>String, for display use, indicating success.</returns>
		public static string Save(AdoDataConnection database, OutputStreamDeviceDigital OutputStreamDeviceDigital)
		{
			bool createdConnection = false;
			try
			{
				createdConnection = CreateConnection(ref database);

				if (OutputStreamDeviceDigital.ID == 0)
					database.Connection.ExecuteNonQuery("INSERT INTO OutputStreamDeviceDigital (NodeID, OutputStreamDeviceID, ID, Label, MaskValue, LoadOrder, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn) " +
						"VALUES (@nodeID, @outputStreamDeviceID, @id, @Label, @maskValue, @loadOrder, @updatedBy, @updatedOn, @createdBy, @createdOn)", DefaultTimeout,
						OutputStreamDeviceDigital.NodeID, OutputStreamDeviceDigital.OutputStreamDeviceID, OutputStreamDeviceDigital.ID, OutputStreamDeviceDigital.Label, OutputStreamDeviceDigital.MaskValue,
						OutputStreamDeviceDigital.LoadOrder, CommonFunctions.CurrentUser, database.UtcNow(), CommonFunctions.CurrentUser, database.UtcNow());

				else
					database.Connection.ExecuteNonQuery("UPDATE OutputStreamDeviceDigital SET NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID , ID = @id, Label = @label, MaskValue = @maskValue, " +
					"LoadOrder = @loadOrder, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn, CreatedBy = @createdBy, CreatedOn = @createdOn " +
					 DefaultTimeout, OutputStreamDeviceDigital.NodeID, OutputStreamDeviceDigital.OutputStreamDeviceID, OutputStreamDeviceDigital.ID, OutputStreamDeviceDigital.Label, OutputStreamDeviceDigital.MaskValue,
					 OutputStreamDeviceDigital.LoadOrder, CommonFunctions.CurrentUser, database.UtcNow(), OutputStreamDeviceDigital.ID);

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

				database.Connection.ExecuteNonQuery("DELETE FROM OutputStreamDeviceDigital WHERE ID = @outputStreamDeviceDigitalID", DefaultTimeout, OutputStreamDeviceDigitalID);

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
