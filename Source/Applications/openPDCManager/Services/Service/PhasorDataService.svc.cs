//*******************************************************************************************************
//  PhasorDataService.cs
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
using openPDCManager.Web.Data;
using openPDCManager.Web.Data.BusinessObjects;
using openPDCManager.Web.Data.Entities;

namespace PCS.Services.Service
{
    // NOTE: If you change the class name "PhasorDataService" here, you must also update the reference to "PhasorDataService" in Web.config.
    public class PhasorDataService : IPhasorDataService
    {
        public List<Pdc> GetPdcList()
        {
            return CommonFunctions.GetPdcList();
        }
        public List<BasicPmuInfo> GetValidatedPmuList()
        {
            return CommonFunctions.GetValidatedPmuList();
        }
		public List<BasicPmuInfo> GetAllPmuList()
		{
			return CommonFunctions.GetAllPmuList();
		}
        public List<Historian> GetHistorianList()
        {
            return CommonFunctions.GetHistorianList();
        }
        public List<CalculatedMeasurement> GetCalculatedMeasurementList()
        {
            return CommonFunctions.GetCalculatedMeasurementList();
        }
        public List<OutputStream> GetOutputStreamList()
        {
            return CommonFunctions.GetOutputStreamList();
        }
		public Dictionary<int, string> GetCompanyList()
		{
			return CommonFunctions.GetCompanyList();
		}
		public Dictionary<int, string> GetVendorList()
		{
			return CommonFunctions.GetVendorList();
		}
		public Dictionary<int, string> GetProtocolList()
		{
			return CommonFunctions.GetProtocolList();
		}
		public List<string> GetTransportProtocolList()
		{
			return CommonFunctions.GetTransportProtocolList();
		}
		public List<string> GetParityList()
		{
			return CommonFunctions.GetParityList();
		}
		public List<string> GetStopBitList()
		{
			return CommonFunctions.GetStopBitList();
		}
		public Dictionary<string, string> GetTimeZonesList()
		{
			return CommonFunctions.GetTimeZonesList();
		}
		public List<StatusReport> GetStatusReportList()
		{
			return CommonFunctions.GetStatusReportList();
		}
	}
}
