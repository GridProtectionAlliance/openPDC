// ReSharper disable CheckNamespace
#pragma warning disable 1591

using System;

namespace openPDC.Model
{
    public class MeasurementValue
    {
        public double Timestamp { get; set; }
        public double Value { get; set; }
        public Guid ID { get; set; }
    }
}
