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
//  07/05/2009 - Mehulbhai Thakkar
//       Generated original version of source code.
//  09/15/2009 - Stephen C. Wills
//       Added new header and license agreement.
//  12/01/2010 - Mehulbhai P Thakkar
//       Added PerformTimestampReasonableCheck Property
//******************************************************************************************************


using System;
namespace openPDCManager.Data.Entities
{
    public class OutputStream
    {
		public string NodeID { get; set; }
        public int ID { get; set; }
		public string Acronym { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string ConnectionString { get; set; }
		public int IDCode { get; set; }
		public string CommandChannel { get; set; }
		public string DataChannel { get; set; }
		public bool AutoPublishConfigFrame { get; set; }
		public bool AutoStartDataChannel { get; set; }
		public int NominalFrequency { get; set; }
		public int FramesPerSecond { get; set; }
		public double LagTime { get; set; }
		public double LeadTime { get; set; }
		public bool UseLocalClockAsRealTime { get; set; }
		public bool AllowSortsByArrival { get; set; }
		public int LoadOrder { get; set; }
        public bool Enabled { get; set; }
        public bool IgnoreBadTimeStamps { get; set; }
        public int TimeResolution { get; set; }
        public bool AllowPreemptivePublishing { get; set; }
        public string DownsamplingMethod { get; set; }
        public string DataFormat { get; set; }
        public string CoordinateFormat { get; set; }
        public int CurrentScalingValue { get; set; }
        public int VoltageScalingValue { get; set; }
        public int AnalogScalingValue { get; set; }
        public int DigitalMaskValue { get; set; }
		public string NodeName { get; set; }
		public string TypeName { get; set; }
        public bool PerformTimestampReasonabilityCheck { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
