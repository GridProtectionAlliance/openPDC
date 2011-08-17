//******************************************************************************************************
//  OutputStreamDevicePhasor.cs - Gbtc
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
//  08/15/2011 - Aniket Salver
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using TimeSeriesFramework.UI;
using TVA.Data;

namespace openPDC.UI.DataModels
{
	/// <summary>
	/// Represents a record of <see cref="OutputStreamDevicePhasor"/> information as defined in the database.
	/// </summary>
   public class OutputStreamDevicePhasor : DataModelBase 
	{
	   #region[Members]

	   public string m_nodeID ;
		public int m_outputStreamDeviceID ;
		public int m_id;
		public string m_label ;
		public string m_type ;
		public string m_phase ;
		public int m_scalingValue ;
		public int m_loadOrder ;
		public string m_phasorType ;
		public string m_phaseType ;
		public DateTime m_createdOn ;
		public string m_createdBy ;
		public DateTime m_updatedOn ;
		public string m_updatedBy ;

		#endregion

		#region[Properties]

		/// <summary>
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> NodeID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor NodeID is a required field, please provide value.")]
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> OutputStreamDeviceID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor OutputStreamDeviceID is a required field, please provide value.")]
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> ID.
		/// </summary>
		// Field is populated by database via auto-increment and has no screen interaction, so no validation attributes are applied
		[Required(ErrorMessage = "OutputStreamDevicePhasor ID is a required field, please provide value.")]
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> Label.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor Label is a required field, please provide value.")]
		[StringLength(200, ErrorMessage = "OutputStreamDevicePhasor Label cannot exceed 200 characters.")]
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> Type.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor Type is a required field, please provide value.")]
		public string Type
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> Phase.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor Phase is a required field, please provide value.")]
		public string Phase
		{
			get
			{
				return m_phase;
			}
			set
			{
				m_phase = value;
			}
		}

		/// <summary>
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> ScalingValue .
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor ScalingValue  is a required field, please provide value.")]
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> LoadOrder .
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor LoadOrder  is a required field, please provide value.")]
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
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> PhasorType.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor PhasorType is a required field, please provide value.")]
		public string PhasorType
		{
			get
			{
				return m_phasorType;
			}
			set
			{
				m_phasorType = value;
			}
		}

		/// <summary>
		/// Gets or sets <see cref="OutputStreamDevicePhasor"/> PhaseType.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamDevicePhasor PhaseType is a required field, please provide value.")]
		public string PhaseType
		{
			get
			{
				return m_phaseType;
			}
			set
			{
				m_phaseType = value;
			}
		}

		/// <summary>
		/// Gets or sets when the current <see cref="OutputStreamDevicePhasor"/> was created.
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
		/// Gets or sets who the current <see cref="OutputStreamDevicePhasor"/> was created by.
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
		/// Gets or sets when the current <see cref="OutputStreamDevicePhasor"/> was updated.
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
		/// Gets or sets who the current <see cref="OutputStreamDevicePhasor"/> was updated by.
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

		#region [Static]
		// Static Methods      

		/// <summary>
		/// Loads <see cref="OutputStreamDevicePhasor"/> information as an <see cref="ObservableCollection{T}"/> style list.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <returns>Collection of <see cref="OutputStreamDevicePhasor"/>.</returns>
		public static ObservableCollection<OutputStreamDevicePhasor> Load(AdoDataConnection database)
		{
			bool createdConnection = false;

			try
			{
				createdConnection = CreateConnection(ref database);

				ObservableCollection<OutputStreamDevicePhasor> OutputStreamDevicePhasorList = new ObservableCollection<OutputStreamDevicePhasor>();
				DataTable OutputStreamDevicePhasorTable = database.Connection.RetrieveData(database.AdapterType, "SELECT NodeID, OutputStreamDeviceID, ID, Label, Phase, ScalingValue, LoadOrder, PhasorType, PhaseType " +
					"FROM OutputStreamDevicePhasor ORDER BY LoadOrder");


				foreach (DataRow row in OutputStreamDevicePhasorTable.Rows)
				{
					OutputStreamDevicePhasorList.Add(new OutputStreamDevicePhasor()
					{
						NodeID = row.ConvertField<String>("NodeID"),
						OutputStreamDeviceID = row.ConvertField<int>("OutputStreamDeviceID"),
						ID = row.ConvertField<int>("ID"),
						Label = row.Field<string>("Label"),
						Type = row.Field<string>("Type"),
						Phase = row.Field<string>("Phase"),
						ScalingValue = row.ConvertField<int>("ScalingValue"),
						LoadOrder = row.ConvertField<int>("LoadOrder"),
						PhasorType = row.Field<string>("PhasorType"),
						PhaseType = row.Field<string>("PhaseType"),
					});
				}

				return OutputStreamDevicePhasorList;
			}
			finally
			{
				if (createdConnection && database != null)
					database.Dispose();
			}
		}

		/// <summary>
		/// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="OutputStreamDevicePhasor"/> information.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
		/// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Label of OutputStreamDevicePhasors defined in the database.</returns>
		public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = false)
		{
			bool createdConnection = false;
			try
			{
				createdConnection = CreateConnection(ref database);

				Dictionary<int, string> OutputStreamDevicePhasorList = new Dictionary<int, string>();
				if (isOptional)
					OutputStreamDevicePhasorList.Add(0, "Select OutputStreamDevicePhasor");

				DataTable OutputStreamDevicePhasorTable = database.Connection.RetrieveData(database.AdapterType, "SELECT ID, Label FROM OutputStreamDevicePhasor ORDER BY LoadOrder");

				foreach (DataRow row in OutputStreamDevicePhasorTable.Rows)
					OutputStreamDevicePhasorList[row.ConvertField<int>("ID")] = row.Field<string>("Label");

				return OutputStreamDevicePhasorList;
			}
			finally
			{
				if (createdConnection && database != null)
					database.Dispose();
			}
		}

		/// <summary>
		/// Saves <see cref="OutputStreamDevicePhasor"/> information to database.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="OutputStreamDevicePhasor">Information about <see cref="OutputStreamDevicePhasor"/>.</param>        
		/// <returns>String, for display use, indicating success.</returns>
		public static string Save(AdoDataConnection database, OutputStreamDevicePhasor OutputStreamDevicePhasor)
		{
			bool createdConnection = false;
			try
			{
				createdConnection = CreateConnection(ref database);

				if (OutputStreamDevicePhasor.ID == 0)
					database.Connection.ExecuteNonQuery("INSERT INTO OutputStreamDevicePhasor (NodeID, OutputStreamDeviceID, ID, Label, Type, Phase " +
						" ScalingValue, LoadOrder, TypeName, PhasorType, PhaseType )" +
						"VALUES (@nodeID, @outputStreamDeviceID, @id, @label, @type, @type, @phase, @scalingValue, @loadOrder, @phasorName, @phaseType, @updatedBy, @updatedOn, @createdBy, @createdOn)", DefaultTimeout,
						OutputStreamDevicePhasor.NodeID, OutputStreamDevicePhasor.OutputStreamDeviceID, OutputStreamDevicePhasor.ID, OutputStreamDevicePhasor.Label, OutputStreamDevicePhasor.Type,
						OutputStreamDevicePhasor.Phase, OutputStreamDevicePhasor.ScalingValue, OutputStreamDevicePhasor.LoadOrder, OutputStreamDevicePhasor.PhasorType, OutputStreamDevicePhasor.PhaseType, CommonFunctions.CurrentUser, database.UtcNow(),
						CommonFunctions.CurrentUser, database.UtcNow());
				else
					database.Connection.ExecuteNonQuery("UPDATE OutputStreamDevicePhasor SET NodeID = @nodeID, OutputStreamDeviceID = @outputStreamDeviceID , ID = @id, Label = @label, Type = @type, Phase = @phase " +
					" ScalingValue = @scalingValue, LoadOrder = @loadOrder,  PhasorType = @typeName, PhaseType = @PhaseType" +
					"UpdatedBy = @updatedBy, UpdatedOn = @updatedOn, CreatedBy = @createdBy, CreatedOn = @createdOn " +
					 DefaultTimeout, OutputStreamDevicePhasor.NodeID, OutputStreamDevicePhasor.OutputStreamDeviceID, OutputStreamDevicePhasor.ID, OutputStreamDevicePhasor.Label, OutputStreamDevicePhasor.Type,
						OutputStreamDevicePhasor.Phase, OutputStreamDevicePhasor.ScalingValue, OutputStreamDevicePhasor.LoadOrder, OutputStreamDevicePhasor.PhasorType, OutputStreamDevicePhasor.PhaseType, CommonFunctions.CurrentUser, database.UtcNow(), OutputStreamDevicePhasor.ID);

				return "OutputStreamDevicePhasor information saved successfully";
			}
			finally
			{
				if (createdConnection && database != null)
					database.Dispose();
			}
		}

		/// <summary>
		/// Deletes specified <see cref="OutputStreamDevicePhasor"/> record from database.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="OutputStreamDevicePhasorID">ID of the record to be deleted.</param>
		/// <returns>String, for display use, indicating success.</returns>
		public static string Delete(AdoDataConnection database, int OutputStreamDevicePhasorID)
		{
			bool createdConnection = false;

			try
			{
				createdConnection = CreateConnection(ref database);

				// Setup current user context for any delete triggers
				CommonFunctions.SetCurrentUserContext(database);

				database.Connection.ExecuteNonQuery("DELETE FROM OutputStreamDevicePhasor WHERE ID = @OutputStreamDevicePhasorID", DefaultTimeout, OutputStreamDevicePhasorID);

				return "OutputStreamDevicePhasor deleted successfully";
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
