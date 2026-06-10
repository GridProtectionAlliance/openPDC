using GSF.Communication;
using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.PhasorProtocols;
using GSF.Security.Model;
using GSF.Web.Shared.Model;
using openPDC.Adapters.Constants;
using openPDC.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;

namespace openPDC.Adapters
{
    /// <summary>
    /// Controller for Device (PMU) operations in openPDC. Provides endpoints to query data from
    /// devices registered in the system.
    /// </summary>
    public class DeviceController : ApiController
    {
        #region [ Members ]

        private const int RetryBaseDelayMs = 1000;
        private const int RetryMaxAttempts = 3;
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(DeviceController), MessageClass.Application);

        #endregion [ Members ]

        #region [ Properties ]

        /// <summary>
        /// Gets the DataContext for database operations.
        /// </summary>
        private static AdoDataConnection DataContext
        {
            get
            {
                return new AdoDataConnection(StringConstant.SystemSettings);
            }
        }

        #endregion [ Properties ]

        #region [ Methods ]

        /// <summary>
        /// Gets all devices (PMUs) in the system.
        /// </summary>
        /// <returns>List of all registered devices.</returns>
        /// <response code="200">Returns the list of devices</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceDetail>))]
        public IHttpActionResult GetAllDevices()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllDevices), "Querying all devices");

                using AdoDataConnection context = DataContext;
                TableOperations<DeviceDetail> deviceTable = new(context);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym);

                Log.Publish(MessageLevel.Info, nameof(GetAllDevices), $"Returned {devices.Count()} devices");
                return Ok(devices);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllDevices), "Error querying devices", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets a specific device by Acronym.
        /// </summary>
        /// <param name="acronym">Device (PMU) acronym.</param>
        /// <returns>Specified device.</returns>
        /// <response code="200">Returns the device</response>
        /// <response code="404">Device not found</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(DeviceDetail))]
        public IHttpActionResult GetDeviceByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDeviceByAcronym), $"Querying device with acronym: {acronym}");

                using AdoDataConnection context = DataContext;
                TableOperations<DeviceDetail> deviceTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);
                var device = deviceTable.QueryRecords(restriction: restriction).FirstOrDefault();

                if (device == null)
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDeviceByAcronym), $"Device not found: {acronym}");
                    return NotFound();
                }

                Log.Publish(MessageLevel.Info, nameof(GetDeviceByAcronym), $"Device found: {acronym}");
                return Ok(device);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDeviceByAcronym), $"Error querying device {acronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets devices by company.
        /// </summary>
        /// <param name="companyAcronym">Company acronym.</param>
        /// <returns>List of devices from the specified company.</returns>
        /// <response code="200">Returns the list of devices</response>
        /// <response code="404">No devices found for the company</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceDetail>))]
        public IHttpActionResult GetDevicesByCompany(string companyAcronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDevicesByCompany), $"Querying devices for company: {companyAcronym}");

                using AdoDataConnection context = DataContext;
                TableOperations<DeviceDetail> deviceTable = new(context);
                RecordRestriction restriction = new("CompanyAcronym = {0}", companyAcronym);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym, restriction: restriction).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesByCompany), $"No devices found for company: {companyAcronym}");
                    return NotFound();
                }

                Log.Publish(MessageLevel.Info, nameof(GetDevicesByCompany), $"Returned {devices.Count} devices from company {companyAcronym}");
                return Ok(devices);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesByCompany), $"Error querying devices for company {companyAcronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets devices by protocol.
        /// </summary>
        /// <param name="protocolName">Protocol name (e.g.: IeeeC37_118V1, SEL Fast Message).</param>
        /// <returns>List of devices using the specified protocol.</returns>
        /// <response code="200">Returns the list of devices</response>
        /// <response code="404">No devices found for the protocol</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceDetail>))]
        public IHttpActionResult GetDevicesByProtocol(string protocolName)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDevicesByProtocol), $"Querying devices for protocol: {protocolName}");

                using AdoDataConnection context = DataContext;
                TableOperations<DeviceDetail> deviceTable = new(context);
                RecordRestriction restriction = new("ProtocolName = {0}", protocolName);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym, restriction: restriction).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesByProtocol), $"No devices found for protocol: {protocolName}");
                    return NotFound();
                }

                Log.Publish(MessageLevel.Info, nameof(GetDevicesByProtocol), $"Returned {devices.Count} devices for protocol {protocolName}");
                return Ok(devices);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesByProtocol), $"Error querying devices for protocol {protocolName}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets enabled or disabled devices.
        /// </summary>
        /// <param name="enabled">true for enabled, false for disabled.</param>
        /// <returns>List of devices filtered by status.</returns>
        /// <response code="200">Returns the list of devices</response>
        /// <response code="404">No devices found with the specified status</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceDetail>))]
        public IHttpActionResult GetDevicesByStatus(bool enabled)
        {
            try
            {
                string status = enabled ? "enabled" : "disabled";
                Log.Publish(MessageLevel.Info, nameof(GetDevicesByStatus), $"Querying {status} devices");

                using AdoDataConnection context = DataContext;
                TableOperations<DeviceDetail> deviceTable = new(context);
                RecordRestriction restriction = new("Enabled = {0}", enabled ? 1 : 0);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym, restriction: restriction).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesByStatus), $"No {status} devices found");
                    return NotFound();
                }

                Log.Publish(MessageLevel.Info, nameof(GetDevicesByStatus), $"Returned {devices.Count} {status} devices");
                return Ok(devices);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesByStatus), $"Error querying devices by status", exception: ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage Index()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Update or Insert device.
        /// </summary>
        /// <param name="device">The device to update or insert.</param>
        /// <response code="200">Device created or updated successfully</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpPost]
        public IHttpActionResult UpsertDevice(Device device)
        {
            try
            {
                var deviceIdInDatabase = ExecuteWithRetry(() => UpsertDeviceRecord(device), nameof(UpsertDevice));
                Log.Publish(MessageLevel.Info, nameof(UpsertDevice), $"Device {device.Acronym} upserted successfully");

                return Ok(deviceIdInDatabase);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(UpsertDevice), $"Error upserting device", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Update or Insert a device using a .PmuConnection file generated by PMU Connection
        /// Tester. Connects to the PMU to retrieve its configuration frame (device name, phasors)
        /// exactly like the openPDCManager Input Device Wizard "Request Configuration" button.
        /// Expects multipart/form-data: file (.PmuConnection), acronym (required), c (optional).
        /// For concentrators with multiple PMUs, all child devices are saved under the provided acronym.
        /// </summary>
        /// <response code="200">Device(s) and phasors created or updated successfully</response>
        /// <response code="400">Invalid request or unable to connect to PMU</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpPost]
        public async Task<IHttpActionResult> UpsertDeviceByPmuConnectionFile()
        {
            try
            {
                var validRequest = await ValidateRequest();

                ConnectionSettings settings;

                using (var stream = new MemoryStream(validRequest.FileBytes))
                    settings = ParsePmuConnectionFile(stream, validRequest.Acronym);

                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile),
                    $"Parsed: Protocol={settings.PhasorProtocol}, Transport={settings.TransportProtocol}, " +
                    $"PmuID={settings.PmuID}, FrameRate={settings.FrameRate}");

                // Connect to the PMU and request its configuration frame, mirroring the
                // openPDCManager "Request Configuration" flow.
                string frameParserConnectionString = BuildFrameParserConnectionString(settings);

                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile),
                    $"Requesting configuration frame from: {settings.ConnectionString}");

                (int savedDeviceCount, string resultAcronym) = await ExecuteWithRetryAsync(async () =>
                {
                    IConfigurationFrame configFrame = await RequestConfigurationFrameAsync(frameParserConnectionString);

                    if (configFrame == null)
                        throw new TimeoutException(
                            "Did not receive a configuration frame from the PMU within the timeout period.");

                    Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile),
                        $"Received configuration frame with {configFrame.Cells.Count} device(s)");

                    int count = await ProcessConfigurationFrame(settings, configFrame, validRequest);
                    return (count, validRequest.Acronym);
                }, nameof(UpsertDeviceByPmuConnectionFile));

                return Ok(new { devices = savedDeviceCount, acronym = resultAcronym });
            }
            catch (TimeoutException)
            {
                return BadRequest("Did not receive a configuration frame from the PMU. " +
                    "Verify the connection parameters and that the device is reachable.");
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(UpsertDeviceByPmuConnectionFile),
                    "Error upserting device from .PmuConnection file", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Builds the MultiProtocolFrameParser connection string from deserialized .PmuConnection settings.
        /// Format: phasorProtocol=X;accessID=Y;transportProtocol=Z;server=A;port=B;...
        /// </summary>
        private static string BuildFrameParserConnectionString(ConnectionSettings settings)
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

        private static T ExecuteWithRetry<T>(Func<T> operation, string callerName)
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

        private static async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> operation, string callerName)
        {
            for (int attempt = 1; ; attempt++)
            {
                try
                {
                    return await operation();
                }
                catch (Exception ex) when (IsTransientException(ex) && attempt < RetryMaxAttempts)
                {
                    int delayMs = RetryBaseDelayMs * (int)Math.Pow(2, attempt - 1);
                    Log.Publish(MessageLevel.Warning, callerName,
                        $"Attempt {attempt}/{RetryMaxAttempts} failed ({ex.GetType().Name}): {ex.Message}. Retrying in {delayMs}ms...");
                    await Task.Delay(delayMs);
                }
            }
        }

        /// <summary>
        /// Retrieves the protocol ID for the given PhasorProtocol enum value.
        /// </summary>
        private static int? GetProtocolID(PhasorProtocol phasorProtocol)
        {
            using AdoDataConnection context = DataContext;
            TableOperations<Protocol> protocolTable = new(context);
            var protocol = protocolTable.QueryRecordWhere("Acronym = {0}", phasorProtocol.ToString());
            return protocol?.ID;
        }

        private static bool IsTransientException(Exception ex) =>
                    ex is TimeoutException ||
                    ex is System.Net.Sockets.SocketException ||
                    ex is System.IO.IOException ||
                    ex is System.Data.Common.DbException ||
                    ex is InvalidOperationException;

        /// <summary>
        /// Parses the SOAP XML of a .PmuConnection file and returns the connection settings. The
        /// file is produced by PMU Connection Tester via SoapFormatter; reading the XML directly
        /// avoids a dependency on the old TVA serialization assemblies.
        /// </summary>
        private static ConnectionSettings ParsePmuConnectionFile(Stream fileStream, string acronym)
        {
            Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile), $"Parsing .PmuConnection file for device: {acronym}");

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

        private static string PmuSignalDescription(string suffix) => suffix switch
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
        private static async Task<IConfigurationFrame> RequestConfigurationFrameAsync(
            string connectionString, int timeoutSeconds = 60)
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
        private static DeviceMetadata ResolveDeviceMetadata(DeviceMetadata validRequest)
        {
            using AdoDataConnection context = DataContext;

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
        private static string SanitizeAcronym(string stationName)
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
        private static void UpsertMeasurement(TableOperations<Measurement> measurementTable, Measurement measurement)
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

        /// <summary>
        /// Builds a Device object for the parent/main device (either concentrator or standalone PMU).
        /// </summary>
        private Device BuildParentDevice(DeviceMetadata validRequest,
                                         bool isConcentrator,
                                         int? protocolID,
                                         ConnectionSettings settings,
                                         IConfigurationFrame configFrame,
                                         string deviceConnectionString,
                                         DeviceMetadata deviceMetadata)
        {
            return new Device
            {
                Acronym = validRequest.Acronym,
                Name = validRequest.Name,
                IsConcentrator = isConcentrator,
                ProtocolID = protocolID,
                CompanyID = deviceMetadata.CompanyID,
                HistorianID = deviceMetadata.HistorianID,
                VendorDeviceID = deviceMetadata.VendorDeviceID,
                InterconnectionID = deviceMetadata.InterconnectionID,
                AccessID = isConcentrator
                    ? (int)configFrame.IDCode
                    : (int)configFrame.Cells.Cast<IConfigurationCell>().First().IDCode,
                FramesPerSecond = settings.FrameRate > 0 ? settings.FrameRate : 30,
                ConnectionString = deviceConnectionString,
                Enabled = true,
                AllowUseOfCachedConfiguration = true,
                AutoStartDataParsingSequence = true,
                ConnectOnDemand = true,
                DataLossInterval = 5.0,
                AllowedParsingExceptions = 10,
                ParsingExceptionWindow = 5.0,
                DelayedConnectionInterval = 5.0,
                MeasurementReportingInterval = 100000,
            };
        }

        /// <summary>
        /// Processes all cells from the configuration frame, creating child devices (if
        /// concentrator) and saving their phasor definitions and measurements.
        /// </summary>
        private void ProcessAllCells(IConfigurationFrame configFrame,
                                     ConnectionSettings settings,
                                     int parentDeviceID,
                                     int? protocolID,
                                     bool isConcentrator,
                                     DeviceMetadata validRequest,
                                     DeviceMetadata deviceMetadata,
                                     ref int savedDeviceCount)
        {
            using AdoDataConnection context = DataContext;
            TableOperations<Phasor> phasorTable = new(context);
            TableOperations<Measurement> measurementTable = new(context);

            foreach (IConfigurationCell cell in configFrame.Cells)
            {
                int targetDeviceID;
                string targetAcronym;
                string targetName;

                if (isConcentrator)
                {
                    targetDeviceID = ProcessAndSaveChildDevice(cell, settings, parentDeviceID, protocolID, deviceMetadata);
                    targetAcronym = SanitizeAcronym(cell.StationName);
                    targetName = cell.StationName;
                    savedDeviceCount++;
                }
                else
                {
                    targetDeviceID = parentDeviceID;
                    targetAcronym = validRequest.Acronym;
                    targetName = validRequest.Name;
                }

                SavePhaseorsForCell(cell, targetDeviceID, phasorTable);
                SaveMeasurementsForCell(cell, targetDeviceID, targetAcronym, targetName, deviceMetadata.HistorianID, measurementTable, context);
            }
        }

        /// <summary>
        /// Processes a cell from a concentrator, creating a child device record for it. Returns the
        /// ID of the created or updated child device.
        /// </summary>
        private int ProcessAndSaveChildDevice(IConfigurationCell cell,
                                              ConnectionSettings settings,
                                              int parentDeviceID,
                                              int? protocolID,
                                              DeviceMetadata deviceMetadata)
        {
            string cellAcronym = SanitizeAcronym(cell.StationName);

            var concentrator = new Device
            {
                Acronym = cellAcronym,
                Name = cell.StationName,
                IsConcentrator = false,
                ProtocolID = protocolID,
                CompanyID = deviceMetadata.CompanyID,
                HistorianID = deviceMetadata.HistorianID,
                VendorDeviceID = deviceMetadata.VendorDeviceID,
                InterconnectionID = deviceMetadata.InterconnectionID,
                AccessID = (int)cell.IDCode,
                ParentID = parentDeviceID,
                FramesPerSecond = settings.FrameRate > 0 ? settings.FrameRate : 30,
                ConnectionString = string.Empty,
                Enabled = true,
                AllowUseOfCachedConfiguration = true,
                AutoStartDataParsingSequence = true,
                ConnectOnDemand = false,
                DataLossInterval = 5.0,
                AllowedParsingExceptions = 10,
                ParsingExceptionWindow = 5.0,
                DelayedConnectionInterval = 5.0,
                MeasurementReportingInterval = 100000
            };

            return UpsertDeviceRecord(concentrator);
        }

        private async Task<int> ProcessConfigurationFrame(ConnectionSettings settings, IConfigurationFrame configFrame, DeviceMetadata validRequest)
        {
            using AdoDataConnection context = DataContext;

            int? protocolID = GetProtocolID(settings.PhasorProtocol);
            bool isConcentrator = configFrame.Cells.Count > 1;
            string deviceConnectionString = $"TransportProtocol={settings.TransportProtocol};{settings.ConnectionString}";

            var deviceMetadata = ResolveDeviceMetadata(validRequest);

            var parentDevice = BuildParentDevice(validRequest, isConcentrator, protocolID, settings, configFrame, deviceConnectionString, deviceMetadata);

            var parentDeviceID = UpsertDeviceRecord(parentDevice);

            int savedDeviceCount = 1;

            ProcessAllCells(configFrame, settings, parentDeviceID, protocolID, isConcentrator, validRequest, deviceMetadata, ref savedDeviceCount);

            Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile),
                $"Saved {savedDeviceCount} device(s) for acronym '{validRequest.Acronym}'");

            return savedDeviceCount;
        }

        /// <summary>
        /// Creates or updates all measurements for a configuration cell: PMU-level signals
        /// (frequency, dF/dt, status flags), phasor magnitude/angle pairs, analog values, and
        /// digital values. Matches openPDCManager's SaveDevice/SavePhasor measurement pattern.
        /// PointTag format mirrors the Device Wizard: PMU signals :
        /// {company}_{device}:{vendor}{abbreviation} e.g. GPA_SHELBY:SHELPMUF Phasors :
        /// {company}_{device}-{suffix}{idx}:{vendor}{abbreviation} e.g. GPA_SHELBY-PM1:SHELPMУВ
        /// Analog : {company}_{device}:{vendor}A{idx} Digital : {company}_{device}:{vendor}D{idx}
        /// </summary>
        private void SaveMeasurementsForCell(IConfigurationCell cell,
                                             int deviceID,
                                             string deviceAcronym,
                                             string deviceName,
                                             int? historianID,
                                             TableOperations<Measurement> measurementTable,
                                             AdoDataConnection context)
        {
            TableOperations<DeviceDetail> deviceDetailTable = new(context);
            var deviceDetail = deviceDetailTable.QueryRecordWhere("Acronym = {0}", deviceAcronym);
            string companyAcronym = deviceDetail?.CompanyAcronym ?? string.Empty;

            var nowTime = DateTime.Now;
            var now = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);
            var user = User.Identity.Name;

            // Pre-load SignalType records. PMU types (FQ/DF/SF) carry their Acronym used verbatim
            // in the tag. Phasor types are keyed by Suffix (PM/PA) in separate voltage/current
            // maps; only the first char of Abbreviation is used in the phasor tag.
            TableOperations<GSF.TimeSeries.Model.SignalType> sigTypeTable = new(context);

            var pmuTypes = new Dictionary<string, (int ID, string Acronym)>();
            foreach (string pmuSuffix in new[] { "FQ", "DF", "SF" })
            {
                var st = sigTypeTable.QueryRecordWhere("Suffix = {0} AND Source = 'PMU'", pmuSuffix);
                if (st?.ID > 0)
                    pmuTypes[pmuSuffix] = (st.ID, st.Acronym ?? pmuSuffix);
            }

            // Voltage phasors: VPHM (PM, Abbreviation='V') and VPHA (PA, Abbreviation='VH')
            var voltagePhasorTypes = new Dictionary<string, (int ID, string Abbreviation)>();
            foreach (string acronym in new[] { "VPHM", "VPHA" })
            {
                var st = sigTypeTable.QueryRecordWhere("Acronym = {0}", acronym);
                if (st?.ID > 0)
                    voltagePhasorTypes[st.Suffix] = (st.ID, st.Abbreviation ?? string.Empty);
            }

            // Current phasors: IPHM (PM, Abbreviation='I') and IPHA (PA, Abbreviation='IH')
            var currentPhasorTypes = new Dictionary<string, (int ID, string Abbreviation)>();
            foreach (string acronym in new[] { "IPHM", "IPHA" })
            {
                var st = sigTypeTable.QueryRecordWhere("Acronym = {0}", acronym);
                if (st?.ID > 0)
                    currentPhasorTypes[st.Suffix] = (st.ID, st.Abbreviation ?? string.Empty);
            }

            var alogST = sigTypeTable.QueryRecordWhere("Acronym = {0}", "ALOG");
            var digiST = sigTypeTable.QueryRecordWhere("Acronym = {0}", "DIGI");

            // Phasors are saved by SavePhaseorsForCell before this call; read their Phase values so
            // the PointTag reflects the correct phase. Default is '+' (positive sequence).
            TableOperations<Phasor> phasorTable = new(context);
            var savedPhasors = phasorTable
                .QueryRecords(restriction: new RecordRestriction("DeviceID = {0}", deviceID))
                .ToDictionary(p => p.SourceIndex, p => p.Phase ?? "+");

            // PMU-level signals — PointTag: {company}_{device}:{SignalType.Acronym} Matches
            // expression: [?Source!=Phasor[?Acronym!=ALOG[:{SignalType.Acronym}]]]
            foreach (string suffix in new[] { "FQ", "DF", "SF" })
            {
                if (!pmuTypes.TryGetValue(suffix, out var pmuType))
                    continue;

                UpsertMeasurement(measurementTable, new Measurement
                {
                    DeviceID = deviceID,
                    HistorianID = historianID,
                    PointTag = $"{companyAcronym}_{deviceAcronym}:{pmuType.Acronym}",
                    SignalTypeID = pmuType.ID,
                    SignalReference = $"{deviceAcronym}-{suffix}",
                    Description = $"{deviceName} {PmuSignalDescription(suffix)}",
                    Internal = true,
                    Enabled = true,
                    Adder = 0.0d,
                    Multiplier = 1.0d,
                    CreatedBy = user,
                    UpdatedBy = user,
                    CreatedOn = now,
                    UpdatedOn = now
                });
            }

            // Phasor measurements: magnitude (PM) and angle (PA) for each defined phasor.
            // PointTag: {company}_{device}:{cleanLabel}_{Abbr[0]}{phaseStr}[.MAG|.ANG]
            // Replicates: eval{Label.Trim().ToUpper().Replace(' ','_')}_eval{Abbr.Substring(0,1)} eval{Phase=='+'?'1':(Phase=='-'?'2':Phase)}[.MAG|.ANG]
            int phasorIndex = 1;
            foreach (IPhasorDefinition phasorDef in cell.PhasorDefinitions)
            {
                string label = phasorDef.Label?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(label) || label.Equals("unused", StringComparison.OrdinalIgnoreCase))
                {
                    phasorIndex++;
                    continue;
                }

                bool isVoltage = phasorDef.PhasorType == GSF.Units.EE.PhasorType.Voltage;
                var phasorTypes = isVoltage ? voltagePhasorTypes : currentPhasorTypes;

                string phase = savedPhasors.TryGetValue(phasorIndex, out string savedPhase) ? savedPhase : "+";
                string phaseStr = phase == "+" ? "1" : (phase == "-" ? "2" : phase);
                string cleanLabel = label.ToUpper().Replace(' ', '_');

                foreach (string sfx in new[] { "PM", "PA" })
                {
                    if (!phasorTypes.TryGetValue(sfx, out var phasorType))
                        continue;

                    string abbrFirst = phasorType.Abbreviation.Length > 0
                        ? phasorType.Abbreviation.Substring(0, 1)
                        : string.Empty;
                    string tagSuffix = sfx == "PM" ? ".MAG" : ".ANG";
                    string measurementLabel = sfx == "PM"
                        ? (isVoltage ? "Voltage Magnitude" : "Current Magnitude")
                        : (isVoltage ? "Voltage Angle" : "Current Angle");

                    UpsertMeasurement(measurementTable, new Measurement
                    {
                        DeviceID = deviceID,
                        HistorianID = historianID,
                        PointTag = $"{companyAcronym}_{deviceAcronym}:{cleanLabel}_{abbrFirst}{phaseStr}{tagSuffix}",
                        SignalTypeID = phasorType.ID,
                        PhasorSourceIndex = phasorIndex,
                        SignalReference = $"{deviceAcronym}-{sfx}{phasorIndex}",
                        Description = $"{deviceName} {label} {measurementLabel}",
                        Internal = true,
                        Enabled = true,
                        Adder = 0.0d,
                        Multiplier = 1.0d,
                        CreatedBy = user,
                        UpdatedBy = user,
                        CreatedOn = now,
                        UpdatedOn = now
                    });
                }

                phasorIndex++;
            }

            // Analog values — PointTag: {company}_{device}:{cleanLabel} or :ALOG{idx:D2}
            // Replicates: [?Acronym=ALOG[:eval{Label.Length>0?Label.Trim().ToUpper():ALOG+idx:D2}]]
            if (alogST?.ID > 0)
            {
                int analogIndex = 1;
                foreach (IAnalogDefinition analogDef in cell.AnalogDefinitions)
                {
                    string analogLabel = analogDef.Label?.Trim() ?? string.Empty;
                    string analogTag = !string.IsNullOrEmpty(analogLabel)
                        ? analogLabel.ToUpper().Replace(' ', '_')
                        : $"ALOG{analogIndex:D2}";

                    UpsertMeasurement(measurementTable, new Measurement
                    {
                        DeviceID = deviceID,
                        HistorianID = historianID,
                        PointTag = $"{companyAcronym}_{deviceAcronym}:{analogTag}",
                        SignalTypeID = alogST.ID,
                        SignalReference = $"{deviceAcronym}-AV{analogIndex}",
                        Description = $"{deviceName} Analog Value {analogIndex}",
                        Internal = true,
                        Enabled = true,
                        Adder = 0.0d,
                        Multiplier = 1.0d,
                        CreatedBy = user,
                        UpdatedBy = user,
                        CreatedOn = now,
                        UpdatedOn = now
                    });
                    analogIndex++;
                }
            }

            // Digital values — PointTag: {company}_{device}:DIGI{idx:D2}
            if (digiST?.ID > 0)
            {
                int digitalIndex = 1;
                foreach (IDigitalDefinition _ in cell.DigitalDefinitions)
                {
                    UpsertMeasurement(measurementTable, new Measurement
                    {
                        DeviceID = deviceID,
                        HistorianID = historianID,
                        PointTag = $"{companyAcronym}_{deviceAcronym}:DIGI{digitalIndex:D2}",
                        SignalTypeID = digiST.ID,
                        SignalReference = $"{deviceAcronym}-DV{digitalIndex}",
                        Description = $"{deviceName} Digital Value {digitalIndex}",
                        Internal = true,
                        Enabled = true,
                        Adder = 0.0d,
                        Multiplier = 1.0d,
                        CreatedBy = user,
                        UpdatedBy = user,
                        CreatedOn = now,
                        UpdatedOn = now
                    });
                    digitalIndex++;
                }
            }

            Log.Publish(MessageLevel.Info, nameof(SaveMeasurementsForCell),
                $"Measurements saved for device '{deviceAcronym}'");
        }

        /// <summary>
        /// Saves all phasor definitions from a configuration cell to the database, inserting new
        /// phasors or updating existing ones matched by DeviceID and SourceIndex. Skips phasors
        /// with empty or "unused" labels.
        /// </summary>
        private void SavePhaseorsForCell(IConfigurationCell cell, int targetDeviceID, TableOperations<Phasor> phasorTable)
        {
            int sourceIndex = 1;

            foreach (IPhasorDefinition phasorDef in cell.PhasorDefinitions)
            {
                string label = phasorDef.Label?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(label) ||
                    label.Equals("unused", StringComparison.OrdinalIgnoreCase))
                {
                    sourceIndex++;
                    continue;
                }

                var existingPhasor = phasorTable.QueryRecordWhere(
                    "DeviceID = {0} AND SourceIndex = {1}", targetDeviceID, sourceIndex);

                var phasor = new Phasor
                {
                    DeviceID = targetDeviceID,
                    Label = label,
                    Type = phasorDef.PhasorType == GSF.Units.EE.PhasorType.Current ? "I" : "V",
                    Phase = "+",
                    SourceIndex = sourceIndex
                };

                var nowTime = DateTime.Now;
                var nowTimeFormatted = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);
                var user = User.Identity.Name;

                phasor.CreatedBy = user;
                phasor.UpdatedBy = user;
                phasor.CreatedOn = nowTimeFormatted;
                phasor.UpdatedOn = nowTimeFormatted;

                if (existingPhasor == null)
                    phasorTable.AddNewRecord(phasor);
                else
                    phasorTable.UpdateRecord(phasor, new RecordRestriction(
                        "DeviceID = {0} AND SourceIndex = {1}", targetDeviceID, sourceIndex));

                sourceIndex++;
            }
        }

        /// <summary>
        /// Inserts a new device record or updates the existing one (matched by Acronym). Returns
        /// the ID of the saved device.
        /// </summary>
        private int UpsertDeviceRecord(Device device)
        {
            Log.Publish(MessageLevel.Info, nameof(UpsertDeviceRecord), $"Upserting device record");

            using AdoDataConnection context = DataContext;

            TableOperations<Node> nodeTable = new(context);
            var defaultNode = nodeTable.QueryRecordWhere("Name = 'Default'");

            TableOperations<Device> deviceTable = new(context);
            var deviceInDatabase = deviceTable.QueryRecordWhere("Acronym = {0}", device.Acronym);

            var nowTime = DateTime.Now;
            var nowTimeFormatted = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond, DateTimeKind.Local);
            var user = User.Identity.Name;

            device.NodeID = defaultNode.ID;
            device.UniqueID = Guid.NewGuid();
            device.CreatedBy = user;
            device.UpdatedBy = user;
            device.CreatedOn = nowTimeFormatted;
            device.UpdatedOn = nowTimeFormatted;

            if (deviceInDatabase == null)
            {
                deviceTable.AddNewRecord(device);
                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceRecord), $"Device added successfully");
                deviceInDatabase = deviceTable.QueryRecordWhere("Acronym = {0}", device.Acronym);
            }
            else
            {
                var restriction = new RecordRestriction("Acronym = {0}", deviceInDatabase.Acronym);
                deviceTable.UpdateRecord(device, restriction);
                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceRecord), $"Device updated successfully");
            }

            return deviceInDatabase.ID;
        }

        private async Task<DeviceMetadata> ValidateRequest()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new InvalidOperationException("Expected multipart/form-data content with a .PmuConnection file");

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            string acronym = null;
            string name = null;
            byte[] fileBytes = null;
            string companyAcronym = null;
            string historianAcronym = null;
            string vendorDeviceName = null;
            string interconnectionName = null;

            foreach (var content in provider.Contents)
            {
                string fieldName = content.Headers.ContentDisposition?.Name?.Trim('"');
                bool isFile = content.Headers.ContentDisposition?.FileName != null;

                if (isFile)
                    fileBytes = await content.ReadAsByteArrayAsync();
                else if (string.Equals(fieldName, "acronym", StringComparison.OrdinalIgnoreCase))
                    acronym = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "name", StringComparison.OrdinalIgnoreCase))
                    name = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "companyAcronym", StringComparison.OrdinalIgnoreCase))
                    companyAcronym = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "historianAcronym", StringComparison.OrdinalIgnoreCase))
                    historianAcronym = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "vendorDeviceName", StringComparison.OrdinalIgnoreCase))
                    vendorDeviceName = await content.ReadAsStringAsync();
                else if (string.Equals(fieldName, "interconnectionName", StringComparison.OrdinalIgnoreCase))
                    interconnectionName = await content.ReadAsStringAsync();
            }

            if (fileBytes == null || fileBytes.Length == 0)
                throw new InvalidOperationException("A .PmuConnection file is required");

            if (string.IsNullOrWhiteSpace(acronym))
                throw new InvalidOperationException("The 'acronym' form field is required");

            name = string.IsNullOrWhiteSpace(name) ? acronym : name;

            var deviceByPmuConnectionFile = new DeviceMetadata
            {
                Acronym = acronym,
                Name = name,
                FileBytes = fileBytes,
                CompanyAcronym = companyAcronym,
                HistorianAcronym = historianAcronym,
                VendorDeviceName = vendorDeviceName,
                InterconnectionName = interconnectionName
            };

            return deviceByPmuConnectionFile;
        }

        #endregion [ Methods ]
    }
}