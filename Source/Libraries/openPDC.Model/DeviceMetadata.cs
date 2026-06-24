namespace openPDC.Model
{
    public class DeviceMetadata
    {
        public string Acronym { get; set; }
        public string CompanyAcronym { get; set; }
        public int? CompanyID { get; set; }
        public byte[] FileBytes { get; set; }
        public string HistorianAcronym { get; set; }
        public int? HistorianID { get; set; }
        public int? InterconnectionID { get; set; }
        public string InterconnectionName { get; set; }
        public string Name { get; set; }
        public int? VendorDeviceID { get; set; }
        public string VendorDeviceName { get; set; }
    }
}