//******************************************************************************************************
//  Device.cs - Gbtc
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
//  09/16/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System;

namespace openPDCManager.Data.Entities
{
	public class Device
	{
		//public Guid NodeID { get; set; }
		public string NodeID { get; set; }
		public int ID { get; set; }
		public int? ParentID { get; set; }
		public string Acronym { get; set; }
		public string Name { get; set; }
		public bool IsConcentrator { get; set; }
		public int? CompanyID { get; set; }
		public int? HistorianID { get; set; }
		public int AccessID { get; set; }
		public int? VendorDeviceID { get; set; }
		public int? ProtocolID { get; set; }
		public decimal? Longitude { get; set; }
		public decimal? Latitude { get; set; }
		public int? InterconnectionID { get; set; }
		public string ConnectionString { get; set; }
		public string TimeZone { get; set; }
		public int? FramesPerSecond { get; set; }
		public long TimeAdjustmentTicks { get; set; }
		public double DataLossInterval { get; set; }
		public string ContactList { get; set; }
		public int? MeasuredLines { get; set; }
		public int LoadOrder { get; set; }
		public bool Enabled { get; set; }        
        public int AllowedParsingExceptions { get; set; }
        public double ParsingExceptionWindow { get; set; }
        public double DelayedConnectionInterval { get; set; }
        public bool AllowUseOfCachedConfiguration { get; set; }
        public bool AutoStartDataParsingSequence { get; set; }
        public bool SkipDisableRealTimeData { get; set; }
        public int MeasurementReportingInterval { get; set; }
		public string CompanyName { get; set; }
		public string CompanyAcronym { get; set; }
		public string HistorianAcronym { get; set; }
		public string VendorDeviceName { get; set; }
		public string VendorAcronym { get; set; }
		public string ProtocolName { get; set; }
		public string InterconnectionName { get; set; }
		public string NodeName { get; set; }
		public string ParentAcronym { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
	}

	public enum DeviceType
	{
		Concentrator,
		NonConcentrator,
		All
	}
}
