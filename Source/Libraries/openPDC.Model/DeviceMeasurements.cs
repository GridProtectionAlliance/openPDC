using System.Collections.Generic;

namespace openPDC.Model
{
    public class DeviceMeasurements
    {
        public List<MeasurementDetail> Analogs { get; set; }
        public List<MeasurementDetail> Digitals { get; set; }
    }
}