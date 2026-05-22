// ReSharper disable CheckNamespace
#pragma warning disable 1591

using System.Collections.Generic;

namespace openPDC.Model
{
    /// <summary>
    /// DTO that represents a Device with its associated Phasors.
    /// </summary>
    public class DeviceWithPhasors
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DeviceWithPhasors()
        {
            Phasors = new List<PhasorDetail>();
        }

        /// <summary>
        /// Device Information(PMU).
        /// </summary>
        public DeviceDetail Device { get; set; }

        /// <summary>
        /// List of Phasors associated with the Device.
        /// </summary>
        public List<PhasorDetail> Phasors { get; set; }
    }
}