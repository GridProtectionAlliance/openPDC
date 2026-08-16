using System.Collections.Generic;

namespace openPDC.Adapters.Services
{
    /// <summary>
    /// Outcome of an individual device within a batch upsert operation.
    /// </summary>
    public enum UpsertDeviceStatus
    {
        Included,
        Updated,
        Failed
    }

    /// <summary>
    /// Summary and per-device results of a batch device upsert operation.
    /// </summary>
    public class UpsertDeviceResponse
    {
        public IList<UpsertDeviceResponseDetail> Details { get; set; }
        public int NumberOfReceivedRecords { get; set; }
        public int NumberOfRecordsProcessedWithSuccess { get; set; }
        public int NumberOfRecordsWithFail { get; set; }
    }

    /// <summary>
    /// Outcome of upserting a single device within a batch operation.
    /// </summary>
    public class UpsertDeviceResponseDetail
    {
        public string DeviceAcronym { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}