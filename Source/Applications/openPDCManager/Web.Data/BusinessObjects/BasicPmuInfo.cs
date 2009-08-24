//*******************************************************************************************************
//  BasicPmuInfo.cs
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
//  07/05/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace openPDCManager.Web.Data.BusinessObjects
{
    public class BasicPmuInfo
    {
        public int ID { get; set; }                
        public string Acronym { get; set; }        
        public string Name { get; set; }                
        public string CompanyName { get; set; }
        public string CompanyAcronym { get; set; } 
        public string DeviceName { get; set; }        
        public string ProtocolName { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public bool Reporting { get; set; }
        public bool Active { get; set; }
		public bool Validated { get; set; }
		public bool InProgress { get; set; }
    }
}
