//*******************************************************************************************************
//  IPhasorDataService.cs
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
using System.ServiceModel;
using openPDCManager.Web.Data.BusinessObjects;
using openPDCManager.Web.Data.Entities;

namespace PCS.Services.Service
{
    // NOTE: If you change the interface name "IPhasorDataService" here, you must also update the reference to "IPhasorDataService" in Web.config.
	/// <summary>
	/// Interface defines service and operation contract between WCF service and its consumers.
	/// </summary>
    [ServiceContract]
    public interface IPhasorDataService
    {
        [OperationContract]
        List<Pdc> GetPdcList();

        [OperationContract]
        List<BasicPmuInfo> GetValidatedPmuList();

		[OperationContract]
		List<BasicPmuInfo> GetAllPmuList();

        [OperationContract]
        List<Historian> GetHistorianList();

        [OperationContract]
        List<CalculatedMeasurement> GetCalculatedMeasurementList();

        [OperationContract]
        List<OutputStream> GetOutputStreamList();

		[OperationContract]
		Dictionary<int, string> GetCompanyList();

		[OperationContract]
		Dictionary<int, string> GetVendorList();

		[OperationContract]
		Dictionary<int, string> GetProtocolList();

		[OperationContract]
		List<string> GetTransportProtocolList();

		[OperationContract]
		List<string> GetParityList();

		[OperationContract]
		List<string> GetStopBitList();

		[OperationContract]
		Dictionary<string, string> GetTimeZonesList();

		[OperationContract]
		List<StatusReport> GetStatusReportList();
    }
}
