using GSF.Communication;
using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.PhasorProtocols;
using GSF.Web.Shared.Model;
using openPDC.Adapters.Constants;
using openPDC.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace openPDC.Adapters
{
    public static class CommonController
    {
        #region [ Members ]

        private const int RetryBaseDelayMs = 1000;
        private const int RetryMaxAttempts = 3;
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(CommonController), MessageClass.Application);

        private static AdoDataConnection DataContext
        {
            get
            {
                return new AdoDataConnection(StringConstant.SystemSettings);
            }
        }

        #endregion [ Members ]

        #region [Methods ]

        /// <summary>
        /// Builds the MultiProtocolFrameParser connection string from deserialized .PmuConnection settings.
        /// Format: phasorProtocol=X;accessID=Y;transportProtocol=Z;server=A;port=B;...
        /// </summary>
        public static string BuildFrameParserConnectionString(ConnectionSettings settings)
        {
            var sb = new StringBuilder();

            sb.Append($"phasorProtocol={settings.PhasorProtocol};");

            if (settings.PmuID > 0)
                sb.Append($"accessID={settings.PmuID};");

            sb.Append($"transportProtocol={settings.TransportProtocol};");

            if (!string.IsNullOrEmpty(settings.ConnectionString))
                sb.Append(settings.ConnectionString.TrimEnd(';'));

            return sb.ToString().TrimEnd(';');
        }

        public static T ExecuteWithRetry<T>(Func<T> operation, string callerName)
        {
            for (int attempt = 1; ; attempt++)
            {
                try
                {
                    return operation();
                }
                catch (Exception ex) when (IsTransientException(ex) && attempt < RetryMaxAttempts)
                {
                    int delayMs = RetryBaseDelayMs * (int)Math.Pow(2, attempt - 1);
                    Log.Publish(MessageLevel.Warning, callerName,
                        $"Attempt {attempt}/{RetryMaxAttempts} failed ({ex.GetType().Name}): {ex.Message}. Retrying in {delayMs}ms...");
                    System.Threading.Thread.Sleep(delayMs);
                }
            }
        }

        /// <summary>
        /// Retrieves the protocol ID for the given PhasorProtocol enum value.
        /// </summary>
        public static int? GetProtocolID(PhasorProtocol phasorProtocol, AdoDataConnection context)
        {
            TableOperations<Protocol> protocolTable = new(context);
            var protocol = protocolTable.QueryRecordWhere("Acronym = {0}", phasorProtocol.ToString());
            return protocol?.ID;
        }

        /// <summary>
        /// Private helper method to load all measurements grouped by device. This method caches
        /// measurements in memory to avoid multiple database queries.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <returns>Dictionary of measurements keyed by device acronym.</returns>
        public static Dictionary<string, DeviceMeasurements> LoadMeasurementsByDevice()
        {
            using AdoDataConnection context = DataContext;
            TableOperations<MeasurementDetail> measurementTable = new(context);
            var allMeasurements = measurementTable.QueryRecords("DeviceAcronym, PointTag").ToList();

            var measurementsByDevice = new Dictionary<string, DeviceMeasurements>();

            foreach (var measurement in allMeasurements)
            {
                if (measurement.DeviceAcronym is not null)
                {
                    if (!measurementsByDevice.ContainsKey(measurement.DeviceAcronym))
                    {
                        measurementsByDevice[measurement.DeviceAcronym] = new DeviceMeasurements();
                    }

                    if (measurement.SignalAcronym == "ALOG")
                    {
                        measurementsByDevice[measurement.DeviceAcronym].Analogs.Add(measurement);
                    }
                    else if (measurement.SignalAcronym == "DIGI")
                    {
                        measurementsByDevice[measurement.DeviceAcronym].Digitals.Add(measurement);
                    }
                }
            }

            return measurementsByDevice;
        }

        /// <summary>
        /// Parses the SOAP XML of a .PmuConnection file and returns the connection settings. The
        /// file is produced by PMU Connection Tester via SoapFormatter; reading the XML directly
        /// avoids a dependency on the old TVA serialization assemblies.
        /// </summary>
        public static ConnectionSettings ParsePmuConnectionFile(Stream fileStream, string acronym)
        {
            Log.Publish(MessageLevel.Info, nameof(CommonController), $"Parsing .PmuConnection file for device: {acronym}");

            XDocument doc = XDocument.Load(fileStream);

            XElement settingsElement = doc.Descendants()
                .FirstOrDefault(e => e.Name.LocalName == "ConnectionSettings");

            if (settingsElement == null)
                throw new InvalidDataException(
                    "Invalid .PmuConnection file: ConnectionSettings element not found");

            string GetValue(string localName) => settingsElement.Elements().FirstOrDefault(e => e.Name.LocalName == localName)?.Value;

            int ParseInt(string localName, int fallback = 0)
            {
                string val = GetValue(localName);
                return int.TryParse(val, out int result) ? result : fallback;
            }

            Enum.TryParse(GetValue("PhasorProtocol"), out PhasorProtocol phasorProtocol);
            Enum.TryParse(GetValue("TransportProtocol"), out TransportProtocol transportProtocol);

            return new ConnectionSettings
            {
                PhasorProtocol = phasorProtocol,
                TransportProtocol = transportProtocol,
                ConnectionString = GetValue("ConnectionString"),
                PmuID = ParseInt("PmuID"),
                FrameRate = ParseInt("FrameRate", 30)
            };
        }

        public static string PmuSignalDescription(string suffix) => suffix switch
        {
            "FQ" => "Frequency",
            "DF" => "Frequency Delta (dF/dT)",
            "SF" => "Status Flags",
            _ => suffix
        };

        /// <summary>
        /// Connects to a PMU/PDC using MultiProtocolFrameParser (same engine as openPDC adapters)
        /// and waits up to <paramref name="timeoutSeconds"/> for its configuration frame. Returns
        /// null on timeout.
        /// </summary>
        public static async Task<IConfigurationFrame> RequestConfigurationFrameAsync(
            string connectionString, int timeoutSeconds = 240)
        {
            var tcs = new TaskCompletionSource<IConfigurationFrame>();

            using var parser = new MultiProtocolFrameParser();
            parser.ConnectionString = connectionString;
            parser.AutoStartDataParsingSequence = true;
            parser.SkipDisableRealTimeData = true;
            parser.MaximumConnectionAttempts = 3;

            parser.ReceivedConfigurationFrame += (sender, e) =>
                tcs.TrySetResult(e.Argument);

            parser.ConnectionException += (sender, e) =>
            {
                // Argument2 is the attempt number; fail only after the last attempt.
                if (e.Argument2 >= parser.MaximumConnectionAttempts)
                    tcs.TrySetException(new InvalidOperationException(
                        $"Connection failed after {parser.MaximumConnectionAttempts} attempt(s): {e.Argument1?.Message}"));
            };

            try
            {
                parser.Start();

                var completed = await Task.WhenAny(tcs.Task, Task.Delay(TimeSpan.FromSeconds(timeoutSeconds)));

                if (completed != tcs.Task)
                    return null; // timeout

                return await tcs.Task; // re-throws if faulted via ConnectionException
            }
            finally
            {
                parser.Stop();
            }
        }

        /// <summary>
        /// Resolves human-readable identifiers (acronym/name) into database IDs. Returns null for
        /// each field whose identifier was empty or not found; logs a warning on a miss so the
        /// caller is aware without aborting the whole import.
        /// </summary>
        public static DeviceMetadata ResolveDeviceMetadata(DeviceMetadata validRequest, AdoDataConnection context)
        {
            TableOperations<Company> companyTable = new(context);
            RecordRestriction restrictionCompany = new("Acronym = {0}", validRequest.CompanyAcronym);
            var company = companyTable.QueryRecords(restriction: restrictionCompany).FirstOrDefault();

            TableOperations<Historian> historianTable = new(context);
            RecordRestriction restrictionHistorian = new("Acronym = {0}", validRequest.HistorianAcronym);
            var historian = historianTable.QueryRecords(restriction: restrictionHistorian).FirstOrDefault();

            TableOperations<VendorDevice> vendorDeviceTable = new(context);
            RecordRestriction restrictionVendorDevice = new("Name = {0}", validRequest.VendorDeviceName);
            var vendorDevice = vendorDeviceTable.QueryRecords(restriction: restrictionVendorDevice).FirstOrDefault();

            TableOperations<Interconnection> interconnectionTable = new(context);
            RecordRestriction restrictionInterconnection = new("Name = {0}", validRequest.InterconnectionName);
            var interconnection = interconnectionTable.QueryRecords(restriction: restrictionInterconnection).FirstOrDefault();

            var deviceMetadata = new DeviceMetadata
            {
                CompanyID = company?.ID,
                HistorianID = historian?.ID,
                VendorDeviceID = vendorDevice?.ID,
                InterconnectionID = interconnection?.ID
            };

            return deviceMetadata;
        }

        /// <summary>
        /// Converts a PMU station name into a valid openPDC device acronym (uppercase, alphanumeric
        /// + underscore only).
        /// </summary>
        public static string SanitizeAcronym(string stationName)
        {
            if (string.IsNullOrWhiteSpace(stationName))
                return "PMU_UNKNOWN";

            return Regex.Replace(stationName.ToUpperInvariant().Trim(), @"[^A-Z0-9_]", "_")
                        .TrimStart('_');
        }

        /// <summary>
        /// Inserts a new measurement or updates the existing one matched by SignalReference.
        /// Preserves the SignalID (GUID) of existing records on update.
        /// </summary>
        public static void UpsertMeasurement(TableOperations<Measurement> measurementTable, Measurement measurement)
        {
            var existing = measurementTable.QueryRecordWhere("SignalReference = {0}", measurement.SignalReference);

            if (existing == null)
            {
                measurement.SignalID = Guid.NewGuid();
                measurementTable.AddNewRecord(measurement);
            }
            else
            {
                measurement.SignalID = existing.SignalID;
                measurementTable.UpdateRecord(measurement, new RecordRestriction("SignalReference = {0}", measurement.SignalReference));
            }
        }

        private static bool IsTransientException(Exception ex) =>
                                                  ex is TimeoutException ||
                          ex is System.Net.Sockets.SocketException ||
                          ex is System.IO.IOException ||
                          ex is System.Data.Common.DbException ||
                          ex is InvalidOperationException;

        #endregion [Methods ]
    }
}