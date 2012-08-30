//******************************************************************************************************
//  MapData.cs - Gbtc
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
//  10/04/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************


namespace openPDCManager.Data.BusinessObjects
{
	public class MapData
	{
		public string DeviceType { get; set; }
		public string NodeID { get; set; }
		public int ID { get; set; }
		public string Acronym { get; set; }
		public string Name { get; set; }
		public string CompanyMapAcronym { get; set; }
		public string CompanyName { get; set; }
		public string VendorDeviceName { get; set; }
		public decimal? Longitude { get; set; }
		public decimal? Latitude { get; set; }
		public bool Reporting { get; set; }
		public bool InProgress { get; set; }
		public bool Planned { get; set; }
		public bool Desired { get; set; }
	}

	public enum MapType
	{
		Active,
		Planning
	}
}
