//*******************************************************************************************************
//  PmuDistribution.cs
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

namespace openPDCManager.Web.Data.BusinessObjects
{
    public class PmuDistribution
    {
        public string Status { get; set; }
        public string EasternCount { get; set; }
        public string WesternCount { get; set; }
        public string TexasCount { get; set; }
        public string QuebecCount { get; set; }
        public string AlaskanCount { get; set; }
        public string HawaiiCount { get; set; }
        public int Total { get; set; }
    }
}
