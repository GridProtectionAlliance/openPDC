//*******************************************************************************************************
//  Pdc.cs
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
	/// Class that defines PDC and its properties.
	/// </summary>
    public class Pdc
    {           
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int AccessID { get; set; }
        public int VendorDeviceID { get; set; }
        public int ProtocolID { get; set; }
        public int FramesPerSecond { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string AdditionalConnectionInfo { get; set; }
        public string TimeZone { get; set; }
        public string TimeOffsetTicks { get; set; }
        public string EmailList { get; set; }
        public bool Enabled { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        // These are detailed list of properties. 
        public string CompanyAcronym { get; set; }
        public string CompanyName { get; set; }
        public string VendorDeviceName { get; set; }
        public string VendorDeviceDescription { get; set; }
        public string ProtocolName { get; set; }
        public string ProtocolAcronym { get; set; }
    }
}
