//******************************************************************************************************
//  WizardDeviceInfo.cs - Gbtc
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
//  11/06/2009 - Mehulbhai P Thakkar
//       Generated original version of source code.
//
//******************************************************************************************************

using System.Collections.ObjectModel;

namespace openPDCManager.Data.BusinessObjects
{
	public class WizardDeviceInfo
	{		
		public string Acronym { get; set; }
		public string Name { get; set; }
		public decimal Longitude { get; set; }
		public decimal Latitude { get; set; }
		public int? VendorDeviceID { get; set; }
		public int AccessID { get; set; }
		public int ParentAccessID { get; set; }
		public bool Include { get; set; }
		public int DigitalCount { get; set; }
		public int AnalogCount { get; set; }
		public bool AddDigitals { get; set; }
		public bool AddAnalogs { get; set; }
        public bool IsNew { get; set; }
		public ObservableCollection<PhasorInfo> PhasorList {get; set;}
	}

	public class PhasorInfo
	{		
		public string Label { get; set; }
		public string Type { get; set; }
		public string Phase { get; set; }
		public string DestinationLabel { get; set; }
		public bool Include { get; set; }
	}
}
