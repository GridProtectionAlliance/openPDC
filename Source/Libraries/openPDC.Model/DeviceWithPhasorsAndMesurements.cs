// ReSharper disable CheckNamespace
#pragma warning disable 1591

using System.Collections.Generic;

namespace openPDC.Model
{
    /// <summary>
    /// DTO that represents a Device with its associated Phasors.
    /// </summary>
    public class DeviceWithPhasorsAndMesurements
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DeviceWithPhasorsAndMesurements()
        {
            Phasors = new List<PhasorDetail>();
            Analogs = new List<MeasurementDetail>();
            Digitals = new List<MeasurementDetail>();
        }

        /// <summary>
        /// List of Analog measurements (SignalAcronym = 'ALOG') associated with the Device.
        /// </summary>
        public List<MeasurementDetail> Analogs { get; set; }

        /// <summary>
        /// Device Information(PMU).
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// List of Digital measurements (SignalAcronym = 'DIGI') associated with the Device.
        /// </summary>
        public List<MeasurementDetail> Digitals { get; set; }

        /// <summary>
        /// List of Phasors associated with the Device.
        /// </summary>
        public List<PhasorDetail> Phasors { get; set; }
    }
}