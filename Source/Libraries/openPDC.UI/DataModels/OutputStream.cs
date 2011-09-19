//******************************************************************************************************
//  OutputStream.cs - Gbtc
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
//  07/26/2011 - Magdiel Lorenzo
//       Generated original version of source code.
//  09/08/2011 - Mehulbhai Thakkar
//       Modified code to use sql queries directly instead from script file resource.
//       Added comments to all properties and static methods.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using TimeSeriesFramework.UI;
using TimeSeriesFramework.UI.DataModels;
using TVA.Data;

namespace openPDCManager.UI.DataModels
{
    /// <summary>
    /// Represents a record of <see cref="OutputStream"/> as defined in the database.
    /// </summary>
    public class OutputStream : DataModelBase
    {
        #region [ Members ]

        private Guid m_nodeID;
        private int m_ID;
        private string m_acronym;
        private string m_name;
        private int m_type;
        private string m_connectionString;
        private int m_idCode;
        private string m_commandChannel;
        private string m_dataChannel;
        private bool m_autoPublishConfigFrame;
        private bool m_autoStartDataChannel;
        private int m_nominalFrequency;
        private int m_framesPerSecond;
        private double m_lagTime;
        private double m_leadTime;
        private bool m_useLocalClockAsRealTime;
        private bool m_allowSortsByArrival;
        private int m_loadOrder;
        private bool m_enabled;
        private bool m_ignoreBadTimeStamps;
        private int m_timeResolution;
        private bool m_allowPreemptivePublishing;
        private string m_downsamplingMethod;
        private string m_dataFormat;
        private string m_coordinateFormat;
        private int m_currentScalingValue;
        private int m_voltageScalingValue;
        private int m_analogScalingValue;
        private int m_digitalMaskValue;
        private string m_nodeName;
        private string m_typeName;
        private bool m_performTimestampReasonabilityCheck;
        private DateTime m_createdOn;
        private string m_createdBy;
        private DateTime m_updatedOn;
        private string m_updatedBy;

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s NodeID.
        /// </summary>
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
        /// Gets or sets <see cref="OutputStream"/>'s ID.
        /// </summary>
        // Field is populated by database via auto-increment and has no screen interaction, so no validation attributes are applied.
        public int ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s Acronym.
        /// </summary>
        [Required(ErrorMessage = "Output stream acronym is a required field, please provide value.")]
        [StringLength(200, ErrorMessage = "Output stream acronym cannot exceed 200 characters.")]
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
        /// Gets or sets <see cref="OutputStream"/>'s Name.
        /// </summary>
        [StringLength(200, ErrorMessage = "Output stream name cannot exceed 200 characters.")]
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
        /// Gets or sets <see cref="OutputStream"/>'s Type.
        /// </summary>
        [Required(ErrorMessage = "Output stream type is a required, please provide a value.")]
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
        /// Gets or sets <see cref="OutputStream"/>'s ConnectionString.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;
                OnPropertyChanged("ConnectionString");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s IDCode.
        /// </summary>
        [Required(ErrorMessage = "Output stream IDCode is a required field, please provide a value.")]
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
        /// Gets or sets <see cref="OutputStream"/>'s CommandChannel.
        /// </summary>
        public string CommandChannel
        {
            get
            {
                return m_commandChannel;
            }
            set
            {
                m_commandChannel = value;
                OnPropertyChanged("CommandChannel");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s DataChannel.
        /// </summary>
        public string DataChannel
        {
            get
            {
                return m_dataChannel;
            }
            set
            {
                m_dataChannel = value;
                OnPropertyChanged("DataChannel");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s AutoPublishConfigFrame flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream auto publish config frame is a required field, please provide a value.")]
        [DefaultValue(false)]
        public bool AutoPublishConfigFrame
        {
            get
            {
                return m_autoPublishConfigFrame;
            }
            set
            {
                m_autoPublishConfigFrame = value;
                OnPropertyChanged("AutoPublishConfigFrame");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s AutoStartDataChannel flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream auto start data channel is a required field, please provide a value.")]
        [DefaultValue(true)]
        public bool AutoStartDataChannel
        {
            get
            {
                return m_autoStartDataChannel;
            }
            set
            {
                m_autoStartDataChannel = value;
                OnPropertyChanged("AutoStartDataChannel");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s Nominal Frequency.
        /// </summary>
        [Required(ErrorMessage = "Output stream nominal frequency is a required field, please provide a value.")]
        [DefaultValue(60)]
        public int NominalFrequency
        {
            get
            {
                return m_nominalFrequency;
            }
            set
            {
                m_nominalFrequency = value;
                OnPropertyChanged("NominalFrequency");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s Frames Per Second.
        /// </summary>
        [Required(ErrorMessage = "Output stream frames per second is a required field, please provide a value.")]
        [DefaultValue(30)]
        public int FramesPerSecond
        {
            get
            {
                return m_framesPerSecond;
            }
            set
            {
                m_framesPerSecond = value;
                OnPropertyChanged("FramesPerSecond");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s LagTime.
        /// </summary>
        [Required(ErrorMessage = "Output stream lag time is a required field, please provide a value.")]
        [DefaultValue(3.0)]
        public double LagTime
        {
            get
            {
                return m_lagTime;
            }
            set
            {
                m_lagTime = value;
                OnPropertyChanged("LagTime");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s LeadTime.
        /// </summary>
        [Required(ErrorMessage = "Output stream lead time is a required field, please provide a value.")]
        [DefaultValue(1.0)]
        public double LeadTime
        {
            get
            {
                return m_leadTime;
            }
            set
            {
                m_leadTime = value;
                OnPropertyChanged("LeadTime");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s UseLocalClockAsRealTime flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream use local clock as realtime is a required field, please provide a value.")]
        [DefaultValue(false)]
        public bool UseLocalClockAsRealTime
        {
            get
            {
                return m_useLocalClockAsRealTime;
            }
            set
            {
                m_useLocalClockAsRealTime = value;
                OnPropertyChanged("UseLocalClockAsRealTime");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s AllowSortsByArrival flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream allow sorts by arrival is a required field, please provide a value.")]
        [DefaultValue(true)]
        public bool AllowSortsByArrival
        {
            get
            {
                return m_allowSortsByArrival;
            }
            set
            {
                m_allowSortsByArrival = value;
                OnPropertyChanged("AllowSortsByArrival");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s LoadOrder.
        /// </summary>
        [Required(ErrorMessage = "Output stream load order is a required field, please provide a value.")]
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
        /// Gets or sets <see cref="OutputStream"/>'s Enabled flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream enabled is a required field, please provide a value.")]
        [DefaultValue(false)]
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
        /// Gets or sets <see cref="OutputStream"/>'s IgnoreBadTimeStamps flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream ignore bad timestamps is a required field, please provide a value.")]
        [DefaultValue(false)]
        public bool IgnoreBadTimeStamps
        {
            get
            {
                return m_ignoreBadTimeStamps;
            }
            set
            {
                m_ignoreBadTimeStamps = value;
                OnPropertyChanged("IgnoreBadTimeStamps");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s TimeResolution.
        /// </summary>
        [Required(ErrorMessage = "Output stream time resolution is a required field, please provide a value.")]
        [DefaultValue(330000)]
        public int TimeResolution
        {
            get
            {
                return m_timeResolution;
            }
            set
            {
                m_timeResolution = value;
                OnPropertyChanged("TimeResolution");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s AllowPreemptivePublishing flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream allow preemptive publishing flag is a required field, please provide a value.")]
        [DefaultValue(true)]
        public bool AllowPreemptivePublishing
        {
            get
            {
                return m_allowPreemptivePublishing;
            }
            set
            {
                m_allowPreemptivePublishing = value;
                OnPropertyChanged("AllowPreemptivePublishing");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s DownSamplingMethod.
        /// </summary>
        [Required(ErrorMessage = "Output stream down sampling method is a required field, please provide a value.")]
        [DefaultValue("LastReceived")]
        public string DownSamplingMethod
        {
            get
            {
                return m_downsamplingMethod;
            }
            set
            {
                m_downsamplingMethod = value;
                OnPropertyChanged("DownSamplingMethod");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s DataFormat.
        /// </summary>
        [Required(ErrorMessage = "Output stream data format is a required field, please provide a value.")]
        [DefaultValue("FloatingPoint")]
        public string DataFormat
        {
            get
            {
                return m_dataFormat;
            }
            set
            {
                m_dataFormat = value;
                OnPropertyChanged("DataFormat");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s CoordinateFormat.
        /// </summary>
        [Required(ErrorMessage = "Output stream coordinate format is a required field, please provide a value.")]
        [DefaultValue("Polar")]
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
        /// Gets or sets <see cref="OutputStream"/>'s CurrentScalingValue.
        /// </summary>
        [Required(ErrorMessage = "Output stream current scaling value is a required field, please provide a value.")]
        [DefaultValue(2423)]
        public int CurrentScalingValue
        {
            get
            {
                return m_currentScalingValue;
            }
            set
            {
                m_currentScalingValue = value;
                OnPropertyChanged("CurrentScalingValue");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s VoltageScalingValue.
        /// </summary>
        [Required(ErrorMessage = "Output stream voltage scaling value is a required field, please provide a value.")]
        [DefaultValue(2725785)]
        public int VoltageScalingValue
        {
            get
            {
                return m_voltageScalingValue;
            }
            set
            {
                m_voltageScalingValue = value;
                OnPropertyChanged("VoltageScalingValue");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s AnalogScalingValue.
        /// </summary>
        [Required(ErrorMessage = "Output stream analog scaling value is a required field, please provide a value.")]
        [DefaultValue(1373291)]
        public int AnalogScalingValue
        {
            get
            {
                return m_analogScalingValue;
            }
            set
            {
                m_analogScalingValue = value;
                OnPropertyChanged("AnalogScalingValue");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s DigitalMaskValue.
        /// </summary>
        [Required(ErrorMessage = "Output stream digital mask value is a required field, please provide a value.")]
        [DefaultValue(-65536)]
        public int DigitalMaskValue
        {
            get
            {
                return m_digitalMaskValue;
            }
            set
            {
                m_digitalMaskValue = value;
                OnPropertyChanged("DigitalMaskValue");
            }
        }

        /// <summary>
        /// Gets <see cref="OutputStream"/>'s Node name.
        /// </summary>        
        public string NodeName
        {
            get
            {
                return m_nodeName;
            }
        }

        /// <summary>
        /// Gets <see cref="OutputStream"/>'s TypeName.
        /// </summary>
        public string TypeName
        {
            get
            {
                return m_typeName;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/>'s PerformTimestampReasonabilityCheck flag.
        /// </summary>
        [Required(ErrorMessage = "Output stream perform timestamp reasonability check is a required field, please provide a value.")]
        [DefaultValue(true)]
        public bool PerformTimestampReasonabilityCheck
        {
            get
            {
                return m_performTimestampReasonabilityCheck;
            }
            set
            {
                m_performTimestampReasonabilityCheck = value;
                OnPropertyChanged("PerformTimestampReasonabilityCheck");
            }
        }

        /// <summary>
        /// Gets or sets <see cref="OutputStream"/> CreatedOn.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
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
        /// Gets or sets <see cref="OutputStream"/> CreatedBy.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
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
        /// Gets or sets <see cref="OutputStream"/> UpdatedOn.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
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
        /// Gets or sets <see cref="OutputStream"/> UpdatedBy.
        /// </summary>
        // Field is populated by database via trigger and has no screen interaction, so no validation attributes are applied
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
        /// Loads <see cref="OutputStream"/> information as an <see cref="ObservableCollection{T}"/> style list.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="enabledOnly">Boolean flag indicating if only enabled <see cref="OutputStream"/>s needed.</param>        
        /// <returns>Collection of <see cref="OutputStream"/>.</returns>
        public static ObservableCollection<OutputStream> Load(AdoDataConnection database, bool enabledOnly)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                ObservableCollection<OutputStream> outputStreamList;

                DataTable resultTable;

                if (enabledOnly)
                {
                    resultTable = database.Connection.RetrieveData(database.AdapterType, "SELECT * FROM OuputStreamDetail WHERE NodeID = @nodeID AND Enabled = @enabled ORDER BY Load Order", database.CurrentNodeID(), true);
                }
                else
                {
                    resultTable = database.Connection.RetrieveData(database.AdapterType, "SELECT * FROM OutputStreamdetail WHERE NodeID = @nodeID ORDER BY LoadOrder", database.CurrentNodeID());
                }

                outputStreamList = new ObservableCollection<OutputStream>(from item in resultTable.AsEnumerable()
                                                                          select new OutputStream()
                                                                          {
                                                                              NodeID = database.Guid(item, "NodeID"),
                                                                              ID = Convert.ToInt32(item.Field<object>("ID")),
                                                                              Acronym = item.Field<string>("Acronym"),
                                                                              Name = item.Field<string>("Name"),
                                                                              Type = Convert.ToInt32(item.Field<object>("Type")),
                                                                              ConnectionString = item.Field<string>("ConnectionString"),
                                                                              IDCode = Convert.ToInt32(item.Field<object>("IDCode")),
                                                                              CommandChannel = item.Field<string>("CommandChannel"),
                                                                              DataChannel = item.Field<string>("DataChannel"),
                                                                              AutoPublishConfigFrame = Convert.ToBoolean(item.Field<object>("AutoPublishConfigFrame")),
                                                                              AutoStartDataChannel = Convert.ToBoolean(item.Field<object>("AutoStartDataChannel")),
                                                                              NominalFrequency = Convert.ToInt32(item.Field<object>("NominalFrequency")),
                                                                              FramesPerSecond = Convert.ToInt32(item.Field<object>("FramesPerSecond") ?? 30),
                                                                              LagTime = item.Field<double>("LagTime"),
                                                                              LeadTime = item.Field<double>("LeadTime"),
                                                                              UseLocalClockAsRealTime = Convert.ToBoolean(item.Field<object>("UseLocalClockAsRealTime")),
                                                                              AllowSortsByArrival = Convert.ToBoolean(item.Field<object>("AllowSortsByArrival")),
                                                                              LoadOrder = Convert.ToInt32(item.Field<object>("LoadOrder")),
                                                                              Enabled = Convert.ToBoolean(item.Field<object>("Enabled")),
                                                                              m_nodeName = item.Field<string>("NodeName"),
                                                                              m_typeName = Convert.ToInt32(item.Field<object>("Type")) == 0 ? "IEEE C37.118" : "BPA",
                                                                              IgnoreBadTimeStamps = Convert.ToBoolean(item.Field<object>("IgnoreBadTimeStamps")),
                                                                              TimeResolution = Convert.ToInt32(item.Field<object>("TimeResolution")),
                                                                              AllowPreemptivePublishing = Convert.ToBoolean(item.Field<object>("AllowPreemptivePublishing")),
                                                                              DownSamplingMethod = item.Field<string>("DownsamplingMethod"),
                                                                              DataFormat = item.Field<string>("DataFormat"),
                                                                              CoordinateFormat = item.Field<string>("CoordinateFormat"),
                                                                              CurrentScalingValue = Convert.ToInt32(item.Field<object>("CurrentScalingValue")),
                                                                              VoltageScalingValue = Convert.ToInt32(item.Field<object>("VoltageScalingValue")),
                                                                              AnalogScalingValue = Convert.ToInt32(item.Field<object>("AnalogScalingValue")),
                                                                              DigitalMaskValue = Convert.ToInt32(item.Field<object>("DigitalMaskValue")),
                                                                              PerformTimestampReasonabilityCheck = Convert.ToBoolean(item.Field<object>("PerformTimestampReasonabilityCheck"))
                                                                          });
                return outputStreamList;

            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Saves <see cref="OutputStream"/> information to database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStream">Information about <see cref="OutputStream"/>.</param>        
        /// <returns>String, for display use, indicating success.</returns>
        public static string Save(AdoDataConnection database, OutputStream outputStream)
        {
            bool createdConnection = false;
            try
            {
                createdConnection = CreateConnection(ref database);

                if (outputStream.ID == 0)
                {
                    database.Connection.ExecuteNonQuery("INSERT INTO OutputStream (NodeID, Acronym, Name,  Type, ConnectionString, IDCode, CommandChannel, DataChannel, " +
                        "AutoPublishConfigFrame, AutoStartDataChannel, NominalFrequency, FramesPerSecond, LagTime, LeadTime, UseLocalClockAsRealTime, AllowSortsByArrival, " +
                        "LoadOrder, Enabled, IgnoreBadTimeStamps, TimeResolution, AllowPreemptivePublishing, DownSamplingMethod, DataFormat, CoordinateFormat, " +
                        "CurrentScalingValue, VoltageScalingValue, AnalogScalingValue, DigitalMaskValue, PerformTimestampReasonabilityCheck, UpdatedBy, UpdatedOn, " +
                        "CreatedBy, CreatedOn) VALUES (@nodeID, @acronym, @name, @type, @connectionString, @idCode, @commandChannel, @dataChannel, @autoPublishConfigFrame, " +
                        "@autoStartDataChannel, @nominalFrequency, @framesPerSecond, @lagTime, @leadTime, @useLocalClockAsRealTime, @allowSortsByArrival, @loadOrder, " +
                        "@enabled, @ignoreBadTimeStamps, @timeResolution, @allowPreemptivePublishing, @downSamplingMethod, @dataFormat, @coordinateFormat, @currentScalingValue," +
                        "@voltageScalingValue, @analogScalingValue, @digitalMaskValue, @performTimestampReasonabilityCheck, @updatedBy, @updatedOn, @createdBy, @createdOn)",
                        database.Guid(outputStream.NodeID), outputStream.Acronym.Replace(" ", "").ToUpper(), outputStream.Name, outputStream.Type, outputStream.ConnectionString.ToNotNull(),
                        outputStream.IDCode, outputStream.CommandChannel.ToNotNull(), outputStream.DataChannel.ToNotNull(), outputStream.AutoPublishConfigFrame, outputStream.AutoStartDataChannel,
                        outputStream.NominalFrequency, outputStream.FramesPerSecond, outputStream.LagTime, outputStream.LeadTime, outputStream.UseLocalClockAsRealTime, outputStream.AllowSortsByArrival,
                        outputStream.LoadOrder, outputStream.Enabled, outputStream.IgnoreBadTimeStamps, outputStream.TimeResolution, outputStream.AllowPreemptivePublishing,
                        outputStream.DownSamplingMethod.ToNotNull(), outputStream.DataFormat.ToNotNull(), outputStream.CoordinateFormat.ToNotNull(), outputStream.CurrentScalingValue,
                        outputStream.VoltageScalingValue, outputStream.AnalogScalingValue, outputStream.DigitalMaskValue, outputStream.PerformTimestampReasonabilityCheck,
                        CommonFunctions.CurrentUser, database.UtcNow(), CommonFunctions.CurrentUser, database.UtcNow());
                }
                else
                {
                    database.Connection.ExecuteNonQuery("UPDATE OutputStream SET NodeID = @nodeID, Acronym = @acronym, Name = @name, Type = @type, ConnectionString = @connectionString, " +
                        "IDCode = @idCode, CommandChannel = @commandChannel, DataChannel = @dataChannel, AutoPublishConfigFrame = @autoPublishConfigFrame, AutoStartDataChannel = @autoStartDataChannel, " +
                        "NominalFrequency = @nominalFrequency, FramesPerSecond = @framesPerSecond, LagTime = @lagTime, LeadTime = @leadTime, UseLocalClockAsRealTime = @useLocalClockAsRealTime, " +
                        "AllowSortsByArrival = @allowSortsByArrival, LoadOrder = @loadOrder, Enabled = @enabled, IgnoreBadTimeStamps = @ignoreBadTimeStamps, TimeResolution = @timeResolution, " +
                        "AllowPreemptivePublishing = @allowPreemptivePublishing, DownSamplingMethod = @downsamplingMethod, DataFormat = @dataFormat, CoordinateFormat = @coordinateFormat, " +
                        "CurrentScalingValue = @currentScalingValue, VoltageScalingValue = @voltageScalingValue, AnalogScalingValue = @analogScalingValue, DigitalMaskValue = @digitalMaskValue, " +
                        "PerformTimestampReasonabilityCheck = @perforTimestampReasonabilityCheck, UpdatedBy = @updatedBy, UpdatedOn = @updatedOn WHERE ID = @id", DefaultTimeout,
                        database.Guid(outputStream.NodeID), outputStream.Acronym.Replace(" ", "").ToUpper(), outputStream.Name, outputStream.Type, outputStream.ConnectionString.ToNotNull(),
                        outputStream.IDCode, outputStream.CommandChannel.ToNotNull(), outputStream.DataChannel.ToNotNull(), outputStream.AutoPublishConfigFrame, outputStream.AutoStartDataChannel,
                        outputStream.NominalFrequency, outputStream.FramesPerSecond, outputStream.LagTime, outputStream.LeadTime, outputStream.UseLocalClockAsRealTime,
                        outputStream.AllowSortsByArrival, outputStream.LoadOrder, outputStream.Enabled, outputStream.IgnoreBadTimeStamps, outputStream.TimeResolution,
                        outputStream.AllowPreemptivePublishing, outputStream.DownSamplingMethod.ToNotNull(), outputStream.DataFormat.ToNotNull(), outputStream.CoordinateFormat.ToNotNull(),
                        outputStream.CurrentScalingValue, outputStream.VoltageScalingValue, outputStream.AnalogScalingValue, outputStream.DigitalMaskValue, outputStream.PerformTimestampReasonabilityCheck,
                        CommonFunctions.CurrentUser, database.UtcNow(), outputStream.ID);
                }
                return "Output Stream Information Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Gets a <see cref="Dictionary{T1,T2}"/> style list of <see cref="OutputStream"/> information.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="isOptional">Indicates if selection on UI is optional for this collection.</param>
        /// <returns><see cref="Dictionary{T1,T2}"/> containing ID and Name of <see cref="OutputStream"/>s defined in the database.</returns>
        public static Dictionary<int, string> GetLookupList(AdoDataConnection database, bool isOptional = true)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                Dictionary<int, string> osList = new Dictionary<int, string>();

                DataTable results = database.Connection.RetrieveData(database.AdapterType, "SELECT ID, Name FROM OutputStream WHERE NodeID = @nodeID ORDER BY Name", DefaultTimeout, database.CurrentNodeID());

                foreach (DataRow row in results.Rows)
                    osList[row.ConvertField<int>("ID")] = row.Field<string>("Name");

                return osList;
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Deletes specified <see cref="OutputStream"/> record from database.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="outputStreamID">ID of the record to be deleted.</param>
        /// <returns>String, for display use, indicating success.</returns>
        public static string DeleteOutputStream(AdoDataConnection database, int outputStreamID)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                database.Connection.ExecuteNonQuery("DELETE FROM OutputStream WHERE ID = @outputStreamID", DefaultTimeout, outputStreamID);

                return "Output Stream Deleted Successfully";
            }
            finally
            {
                if (createdConnection && database != null)
                    database.Dispose();
            }
        }

        /// <summary>
        /// Retrieves <see cref="OutputStream"/> information based on acronym provided.
        /// </summary>
        /// <param name="database"><see cref="AdoDataConnection"/> to connection to database.</param>
        /// <param name="acronym"><see cref="OutputStream"/> acronym to filter data.</param>
        /// <returns><see cref="OutputStream"/> information.</returns>
        public static OutputStream GetOutputStreamByAcronym(AdoDataConnection database, string acronym)
        {
            try
            {
                List<OutputStream> outputStreamList = new List<OutputStream>();
                outputStreamList = (from item in Load(database, false)
                                    where item.Acronym.ToUpper() == acronym.ToUpper()
                                    select item).ToList();

                if (outputStreamList.Count > 0)
                    return outputStreamList[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(database, "GetOutputStreamByAcronym", ex);
                return null;
            }
        }

        public static List<Measurement> GetOutputStreamStatistics(AdoDataConnection database, string outputStreamAcronym)
        {
            try
            {
                List<Measurement> measurementList = new List<Measurement>();
                measurementList = (from item in Measurement.Load(database)
                                   where item.SignalReference.StartsWith(outputStreamAcronym + "!OS")
                                   select item).ToList();
                return measurementList;
            }
            catch (Exception ex)
            {
                CommonFunctions.LogException(database, "GetOutputStreamStatistics", ex);
                return null;
            }
        }

        public static string UpdateOutputStreamStatistics(AdoDataConnection database, string oldAcronym, string newAcronym, string oldName, string newName)
        {
            bool createdConnection = false;

            try
            {
                createdConnection = CreateConnection(ref database);

                if (!string.IsNullOrEmpty(oldAcronym) && oldAcronym != newAcronym)
                {
                    List<Measurement> measurementList = GetOutputStreamStatistics(database, oldAcronym);
                    foreach (Measurement measurement in measurementList)
                    {
                        measurement.SignalReference = measurement.SignalReference.Replace(oldAcronym, newAcronym);
                        measurement.PointTag = measurement.PointTag.Replace(oldAcronym, newAcronym);
                        measurement.Description = System.Text.RegularExpressions.Regex.Replace(measurement.Description, oldName, newName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);      //measurement.Description.Replace(oldAcronym, newAcronym);
                        Measurement.Save(database, measurement);
                    }
                }

                return "";
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
