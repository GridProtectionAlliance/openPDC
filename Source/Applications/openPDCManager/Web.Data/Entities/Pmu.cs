//*******************************************************************************************************
//  Pmu.cs
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

namespace openPDCManager.Web.Data.Entities
{
	/// <summary>
	/// Class that defines PMU and its properties
	/// </summary>
    public class Pmu
    {
        public int ID { get; set; }
        public int? PdcID { get; set; }
        public string PdcAcronym { get; set; }
        public string PdcName { get; set; }
        public int? IoIndex { get; set; }
        public string Acronym { get; set; }
        public string BpaAcronym { get; set; }
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public string CompanyAcronym { get; set; }
        public string CompanyName { get; set; }
        public int? HistorianID { get; set; }
        public string HistorianAcronym { get; set; }
        public string HistorianName { get; set; }
        public int AccessID { get; set; }
        public int VendorDeviceID {get; set;}
        public string DeviceName { get; set; }
        public int ProtocolID { get; set; }
        public string ProtocolName { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string DataSource { get; set; }
        public string ConnectionString { get; set; }
        public string PhasorDataFormat { get; set; }
        public string TimeZone { get; set; }
        public string Interconnection { get; set; }
        public int FramesPerSecond { get; set; }
        public bool Reporting { get; set; }
    }
}
