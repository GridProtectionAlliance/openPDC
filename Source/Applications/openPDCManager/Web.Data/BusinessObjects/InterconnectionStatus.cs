//*******************************************************************************************************
//  InterconnectionStatus.cs
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

using System.Collections.Generic;

namespace openPDCManager.Web.Data.BusinessObjects
{
    public class InterconnectionStatus
    {
        public string InterConnection { get; set; }
        public string TotalPmus { get; set; }
        public string DisplayName { get; set; }
        public List<MemberStatus> CompanyStatus { get; set; }
    }

    public class MemberStatus
    {
        public string Name { get; set; }
        public int MeasuredLines { get; set; }
        public int TotalDevices { get; set; }
        public int ValidatedDevices { get; set; }
        public int ReportingDevices { get; set; }
        public string Status { get; set; }
    }
}
