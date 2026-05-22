// ReSharper disable CheckNamespace
#pragma warning disable 1591

using System.Collections.Generic;

namespace openPDC.Model
{
    /// <summary>
    /// DTO que representa um Device com seus Phasors associados.
    /// </summary>
    public class DeviceWithPhasors
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public DeviceWithPhasors()
        {
            Phasors = new List<PhasorDetail>();
        }

        /// <summary>
        /// Informações do Device (PMU).
        /// </summary>
        public DeviceDetail Device { get; set; }

        /// <summary>
        /// Lista de Phasors associados ao Device.
        /// </summary>
        public List<PhasorDetail> Phasors { get; set; }
    }
}