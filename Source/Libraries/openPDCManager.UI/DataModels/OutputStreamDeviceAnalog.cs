using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeSeriesFramework.UI;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using TVA.Data;
using System.Data;

namespace openPDCManager.UI.DataModels
{
	 /// <summary>
	/// Represents a record of <see cref="OutputStreamDeviceAnalog"/> information as defined in the database.
	/// </summary>
	class OutputStreamDeviceAnalog : DataModelBase
	{
		# region[Members]

		public string m_nodeID; 
		public int m_outputStreamDeviceID ;
		public int m_id ;
		public string m_label ;
		public int m_type;
		public int m_scalingValue ;
		public int m_loadOrder ;
		public string m_typeName ;
		public DateTime m_createdOn ;
		public string m_createdBy ;
		public DateTime m_updatedOn ;
		public string m_updatedBy;

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
		/// <returns>Collection of <see cref="OutputStreamDeviceAnalog"/>.</returns>
		public static ObservableCollection<OutputStreamDeviceAnalog> Load(AdoDataConnection database, int outputStreamID)
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


		#endregion
	}
}
