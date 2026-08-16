// ReSharper disable CheckNamespace
#pragma warning disable 1591

using System.Collections.Generic;

namespace openPDC.Model
{
    /// <summary>
    /// DTO that represents a Device with its associated Analogs and Digitals measurements.
    /// </summary>
    public class DeviceWithMeasurements
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DeviceWithMeasurements()
        {
            Analogs = new List<MeasurementDetail>();
            Digitals = new List<MeasurementDetail>();
        }

        /// <summary>
        /// Device Information (PMU).
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// List of Analog measurements (SignalAcronym = 'ALOG') associated with the Device.
        /// </summary>
        public List<MeasurementDetail> Analogs { get; set; }

        /// <summary>
        /// List of Digital measurements (SignalAcronym = 'DIGI') associated with the Device.
        /// </summary>
        public List<MeasurementDetail> Digitals { get; set; }
    }
}
