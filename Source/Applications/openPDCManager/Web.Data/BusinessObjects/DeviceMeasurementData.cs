//******************************************************************************************************
//  DeviceMeasurementData.cs - Gbtc
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
//  03/12/2010 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Collections.ObjectModel;

namespace openPDCManager.Data.BusinessObjects
{
	public class DeviceMeasurementData
	{        
		public int ID { get; set; }
		public string Acronym { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
        public bool IsExpanded { get; set; }
        public string StatusColor { get; set; }
        public bool Enabled { get; set; }
        public ObservableCollection<DeviceInfo> DeviceList { get; set; }
	}

	public class DeviceInfo
	{
		public int? ID { get; set; }
		public string Acronym { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string ProtocolName { get; set; }
		public string VendorDeviceName { get; set; }
		public string ParentAcronym { get; set; }
        public bool IsExpanded { get; set; }
        public string StatusColor { get; set; }
        public bool Enabled { get; set; }
		public ObservableCollection<MeasurementInfo> MeasurementList { get; set; }
	}

	public class MeasurementInfo
	{
		public int? DeviceID { get; set; }
		public string SignalID { get; set; }
		public int PointID { get; set; }
		public string PointTag { get; set; }
        public string SignalReference { get; set; }
		public string SignalAcronym { get; set; }
        public string Description { get; set; }
        public string SignalName { get; set; }
        public string EngineeringUnits { get; set; }
        public string HistorianAcronym { get; set; }
		public string CurrentTimeTag { get; set; }
		public string CurrentValue { get; set; }
		public string CurrentQuality { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }
	}
}

