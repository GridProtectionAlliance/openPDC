// ReSharper disable CheckNamespace
#pragma warning disable 1591

using GSF.Data.Model;

namespace openPDC.Model
{
    /// <summary>
    /// Data Availability 
    /// </summary>
    public class DataAvailability
    {
        [PrimaryKey(true)]
        public int ID { get; set; }
        public float GoodAvailableData { get; set; }
        public float BadAvailableData { get; set; }
        public float TotalAvailableData { get; set; }
    }
}
