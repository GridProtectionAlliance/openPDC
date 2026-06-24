using System.Collections.Generic;

namespace openPDC.Model
{
    public class DeviceMeasurements
    {
        public DeviceMeasurements()
        {
            Analogs = new List<MeasurementDetail>();
            Digitals = new List<MeasurementDetail>();
        }

        public List<MeasurementDetail> Analogs { get; set; }
        public List<MeasurementDetail> Digitals { get; set; }
    }
}