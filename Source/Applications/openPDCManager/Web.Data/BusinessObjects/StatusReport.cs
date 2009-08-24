//*******************************************************************************************************
//  StatusReport.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Mehul P. Thakkar
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR BK-C
//       Phone: 423/751-7571
//       Email: mpthakka@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  08/17/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace openPDCManager.Web.Data.BusinessObjects
{
	public class StatusReport
	{
		public int ID { get; set; }
		public string Acronym { get; set; }
		public string CompanyName { get; set; }
		public string Status { get; set; }
		public List<PmuStatus> PmusStatus { get; set; }
	}
	public class PmuStatus
	{
		public string Acronym { get; set; }
		public string Name { get; set; }
		public int CompanyID { get; set; }
		public string DeviceDescription { get; set; }
		public string ProtocolName { get; set; }
		public bool Reporting { get; set; }
		public bool Validated { get; set; }
		public string StatusColor { get; set; }
	}
}
