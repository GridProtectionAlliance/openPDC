//******************************************************************************************************
//  OutputStreamMeasurement.cs - Gbtc
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
//   08/22/2011 - Aniket Salver
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
	/// Represents a record of <see cref="OutputStreamMeasurement"/> information as defined in the database.
	/// </summary>
   public class OutputStreamMeasurement : DataModelBase
   {
	   #region[Members]

		private string m_nodeID ;
		private int m_adapterID;
		private int m_id;
		private int? m_historianID ;
		private int m_pointID ;
		private string m_signalReference;
		private string m_sourcePointTag;
		private string m_historianAcronym;
		private DateTime m_createdOn;
		private string m_createdBy;
		private DateTime m_updatedOn;
		private string m_updatedBy;

	   #endregion

	   #region[Properties]

		/// <summary>
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s NodeID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamMeasurement NodeID is a required field, please provide value.")]
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
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s AdapterID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamMeasurement AdapterID is a required field, please provide value.")]
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
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s ID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamMeasurement ID is a required field, please provide value.")]
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
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s HistorianID.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamMeasurement HistorianID is a required field, please provide value.")]
		// Field is populated by database via auto-increment and has no screen interaction, so no validation attributes are applied
		public int? HistorianID
		{
			get
			{
				return m_historianID;
			}
			set
			{
				m_historianID = value;
			}
		}

	   /// <summary>
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s PointID.
	   /// </summary>
	   [Required(ErrorMessage = "OutputStreamMeasurement PointID is a required field, please provide value.")]
		public int PointID
		{
			get
			{
				return m_pointID;
			}
			set
			{
				m_pointID = value;
			}
		}

		/// <summary>
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s SignalReference.
		/// </summary>
		[StringLength(200, ErrorMessage = "OutputStreamMeasurement SignalReference cannot exceed 200 characters.")]
		[Required(ErrorMessage = "OutputStreamMeasurement SignalReference is a required field, please provide value.")]
		public string SignalReference
		{
			get
			{
				return m_signalReference;
			}
			set
			{
				m_signalReference = value;
			}
		}

		/// <summary>
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s SourcePointTag.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamMeasurement SourcePointTag is a required field, please provide value.")]
		public string SourcePointTag
		{
			get
			{
				return m_sourcePointTag;
			}
			set
			{
				m_sourcePointTag = value;
			}
		}

		/// <summary>
		/// Gets or sets the current <see cref="OutputStreamMeasurement"/>'s HistorianAcronym.
		/// </summary>
		[Required(ErrorMessage = "OutputStreamMeasurement HistorianAcronym is a required field, please provide value.")]
		public string HistorianAcronym
		{
			get
			{
				return m_historianAcronym;
			}
			set
			{
				m_historianAcronym = value;
			}
		}

		/// <summary>
		/// Gets or sets the Date or Time the current <see cref="OutputStreamMeasurement"/> was created on.
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
		/// Gets or sets who the current <see cref="OutputStreamMeasurement"/> was created by.
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
		/// Gets or sets the Date or Time when the current <see cref="OutputStreamMeasurement"/> was updated on.
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
		/// Gets or sets who the current <see cref="OutputStreamMeasurement"/> was updated by.
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
		/// Loads <see cref="OutputStreamMeasurement"/> information as an <see cref="ObservableCollection{T}"/> style list.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <returns>Collection of <see cref="OutputStreamMeasurement"/>.</returns>
		public static ObservableCollection<OutputStreamMeasurement> Load(AdoDataConnection database, int outputStreamID)
		{
			bool createdConnection = false;

			try
			{
				createdConnection = CreateConnection(ref database);

				ObservableCollection<OutputStreamMeasurement> OutputStreamMeasurementList = new ObservableCollection<OutputStreamMeasurement>();
				DataTable OutputStreamMeasurementTable = database.Connection.RetrieveData(database.AdapterType, "SELECT NodeID, AdapterID, ID,  " +
					"HistorianID, PointID, SignalReference, SourcePointTag, HistorianAcronym  " +
					"FROM OutputStreamMeasurement WHERE AdapterID = @outputStreamID ORDER BY LoadOrder", DefaultTimeout, outputStreamID);

				foreach (DataRow row in OutputStreamMeasurementTable.Rows)
				{
					OutputStreamMeasurementList.Add(new OutputStreamMeasurement()
					{
						NodeID = row.Field<string>("NodeID"),
						AdapterID = row.ConvertField<int>("AdapterID"),
						ID = row.ConvertField<int>("ID"),
						HistorianID = row.Field<int?>("HistorianID"),
						PointID = row.ConvertField<int>("PointID"),
						SignalReference = row.Field<string>("SignalReference "),
						SourcePointTag = row.Field<string>("SourcePointTag"),
						HistorianAcronym = row.Field<string>("HistorianAcronym"),
					});
				}

				return OutputStreamMeasurementList;
			}
			finally
			{
				if (createdConnection && database != null)
					database.Dispose();
			}
		}

		/// <summary>
		/// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="OutputStreamMeasurement"/> information.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
		/// <returns><see cref="Dictionary{T1,T2}"/> containing ID and NodeID of OutputStreamMeasurement defined in the database.</returns>
		public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = false)
		{
			bool createdConnection = false;
			try
			{
				createdConnection = CreateConnection(ref database);

				Dictionary<int, string> OutputStreamMeasurementList = new Dictionary<int, string>();
				if (isOptional)
					OutputStreamMeasurementList.Add(0, "Select OutputStreamMeasurement");

				DataTable OutputStreamMeasurementTable = database.Connection.RetrieveData(database.AdapterType, "SELECT ID, Name FROM OutputStreamMeasurement ORDER BY LoadOrder");

				foreach (DataRow row in OutputStreamMeasurementTable.Rows)
					OutputStreamMeasurementList[row.ConvertField<int>("ID")] = row.Field<string>("SignalReference");

				return OutputStreamMeasurementList;
			}
			finally
			{
				if (createdConnection && database != null)
					database.Dispose();
			}
		}

		/// <summary>
		/// Saves <see cref="OutputStreamMeasurement"/> information to database.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="OutputStreamMeasurement">Information about <see cref="OutputStreamMeasurement"/>.</param>        
		/// <returns>String, for display use, indicating success.</returns>
		public static string Save(AdoDataConnection database, OutputStreamMeasurement OutputStreamMeasurement)
		{
			bool createdConnection = false;
			try
			{
				createdConnection = CreateConnection(ref database);

				if (OutputStreamMeasurement.ID == 0)
					database.Connection.ExecuteNonQuery("INSERT INTO OutputStreamMeasurement (NodeID, AdapterID, ID, HistorianID, PointID, " +
						"SignalReference, SourcePointTag, HistorianAcronym, UpdatedBy, UpdatedOn, CreatedBy, CreatedOn)" +
						"VALUES (@nodeID, @adapterID, @iD, @historianID, @pointID, @signalReference, @sourcePointTag, @historianAcronym, @updatedBy, @updatedOn, @createdBy, @createdOn)", DefaultTimeout,
						OutputStreamMeasurement.NodeID, OutputStreamMeasurement.AdapterID, OutputStreamMeasurement.ID, OutputStreamMeasurement.HistorianID, OutputStreamMeasurement.PointID,
						OutputStreamMeasurement.SignalReference, OutputStreamMeasurement.SourcePointTag, OutputStreamMeasurement.HistorianAcronym, CommonFunctions.CurrentUser, database.UtcNow(),
						CommonFunctions.CurrentUser, database.UtcNow());
				else
					database.Connection.ExecuteNonQuery("UPDATE OutputStreamMeasurement SET NodeID = @nodeID, AdapterID = @adapterID , ID = @iD, HistorianID = @historianID, PointID = @pointID, " +
					"SignalReference = @signalReference, SourcePointTag = @sourcePointTag, HistorianAcronym = @historianAcronym," +
					"UpdatedBy = @updatedBy, UpdatedOn = @updatedOn, CreatedBy = @createdBy, CreatedOn = @createdOn " +
					 DefaultTimeout, OutputStreamMeasurement.NodeID, OutputStreamMeasurement.AdapterID, OutputStreamMeasurement.ID, OutputStreamMeasurement.HistorianID,
					 OutputStreamMeasurement.PointID, OutputStreamMeasurement.SignalReference, OutputStreamMeasurement.SourcePointTag, OutputStreamMeasurement.HistorianAcronym,
					 CommonFunctions.CurrentUser, database.UtcNow(), OutputStreamMeasurement.ID);

				return "OutputStreamMeasurement information saved successfully";
			}
			finally
			{
				if (createdConnection && database != null)
					database.Dispose();
			}
		}

		/// <summary>
		/// Deletes specified <see cref="OutputStreamMeasurement"/> record from database.
		/// </summary>
		/// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
		/// <param name="OutputStreamMeasurementID">ID of the record to be deleted.</param>
		/// <returns>String, for display use, indicating success.</returns>
		public static string Delete(AdoDataConnection database, int OutputStreamMeasurementID)
		{
			bool createdConnection = false;

			try
			{
				createdConnection = CreateConnection(ref database);

				// Setup current user context for any delete triggers
				CommonFunctions.SetCurrentUserContext(database);

				database.Connection.ExecuteNonQuery("DELETE FROM OutputStreamMeasurement WHERE ID = @OutputStreamMeasurementID", DefaultTimeout, OutputStreamMeasurementID);

				return "OutputStreamMeasurement deleted successfully";
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
