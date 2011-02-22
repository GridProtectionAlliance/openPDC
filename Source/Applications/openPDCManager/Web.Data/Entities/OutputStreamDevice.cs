//******************************************************************************************************
//  OutputStreamDevice.cs - Gbtc
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
//  10/16/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//  12/01/2010 - Mehulbhai P Thakkar
//       Added IdCode Property
//******************************************************************************************************


using System;
namespace openPDCManager.Data.Entities
{
	public class OutputStreamDevice
	{
		public string NodeID { get; set; }
		public int AdapterID { get; set; }
		public int ID { get; set; }
        public int IdCode { get; set; }
		public string Acronym { get; set; }
		public string BpaAcronym { get; set; }
		public string Name { get; set; }
        public string PhasorDataFormat { get; set; }
        public string FrequencyDataFormat { get; set; }
        public string AnalogDataFormat { get; set; }
        public string CoordinateFormat { get; set; }
		public int LoadOrder { get; set; }
		public bool Enabled { get; set; }
		public bool Virtual { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
	}
}
