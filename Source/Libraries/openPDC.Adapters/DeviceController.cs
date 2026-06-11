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
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace openPDC.Adapters
{
    /// <summary>
    /// Controller for Device (PMU) operations in openPDC. Provides endpoints to query data from
    /// devices registered in the system.
    /// </summary>
    public class DeviceController : ApiController
    {
        #region [ Members ]

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
        /// Gets all devices (PMUs) in the system with their associated Analog and Digital measurements.
        /// </summary>
        /// <returns>List of all registered devices with Analogs and Digitals.</returns>
        /// <response code="200">Returns the list of devices with Analogs and Digitals</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithMeasurements>))]
        public IHttpActionResult GetAllDevices()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllDevices), "Querying all devices with Analogs and Digitals");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                TableOperations<MeasurementDetail> measurementTable = new(context);

                var devices = deviceTable.QueryRecords(StringConstant.Acronym).ToList();
                var allMeasurements = measurementTable.QueryRecords("DeviceAcronym, PointTag").ToList();

                var result = devices.Select(device => new DeviceWithMeasurements
                {
                    Device = device,
                    Analogs = [.. allMeasurements.Where(m => m.DeviceAcronym == device.Acronym && m.SignalAcronym == "ALOG")],
                    Digitals = [.. allMeasurements.Where(m => m.DeviceAcronym == device.Acronym && m.SignalAcronym == "DIGI")]
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllDevices), $"Returned {result.Count} devices with Analogs and Digitals");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllDevices), "Error querying devices with Analogs and Digitals", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets a specific device by Acronym with its associated Analog and Digital measurements.
        /// </summary>
        /// <param name="acronym">Device (PMU) acronym.</param>
        /// <returns>Specified device with Analogs and Digitals.</returns>
        /// <response code="200">Returns the device with Analogs and Digitals</response>
        /// <response code="404">Device not found</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(DeviceWithMeasurements))]
        public IHttpActionResult GetDeviceByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDeviceByAcronym), $"Querying device with acronym: {acronym}");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);
                var device = deviceTable.QueryRecords(restriction: restriction).FirstOrDefault();

                if (device == null)
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDeviceByAcronym), $"Device not found: {acronym}");
                    return NotFound();
                }

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice(context);
                var measurements = measurementsByDevice.ContainsKey(device.Acronym)
                    ? measurementsByDevice[device.Acronym]
                    : new DeviceMeasurements();

                var result = new DeviceWithMeasurements
                {
                    Device = device,
                    Analogs = measurements.Analogs,
                    Digitals = measurements.Digitals
                };

                Log.Publish(MessageLevel.Info, nameof(GetDeviceByAcronym), $"Device found: {acronym} with {measurements.Analogs.Count} Analogs and {measurements.Digitals.Count} Digitals");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDeviceByAcronym), $"Error querying device {acronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets devices by company with their associated Analog and Digital measurements.
        /// </summary>
        /// <param name="companyAcronym">Company acronym.</param>
        /// <returns>List of devices from the specified company with Analogs and Digitals.</returns>
        /// <response code="200">Returns the list of devices with Analogs and Digitals</response>
        /// <response code="404">No devices found for the company</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithMeasurements>))]
        public IHttpActionResult GetDevicesByCompany(string companyAcronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDevicesByCompany), $"Querying devices for company: {companyAcronym}");

                using AdoDataConnection context = DataContext;

                TableOperations<Company> companyTable = new(context);
                var company = companyTable.QueryRecordsWhere("Acronym = {0}", companyAcronym).FirstOrDefault();

                TableOperations<Device> deviceTable = new(context);
                var devices = deviceTable.QueryRecordsWhere("CompanyID = {0}", company?.ID).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesByCompany), $"No devices found for company: {companyAcronym}");
                    return NotFound();
                }

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice(context);
                var result = devices.Select(device => new DeviceWithMeasurements
                {
                    Device = device,
                    Analogs = measurementsByDevice.ContainsKey(device.Acronym) ? measurementsByDevice[device.Acronym].Analogs : [],
                    Digitals = measurementsByDevice.ContainsKey(device.Acronym) ? measurementsByDevice[device.Acronym].Digitals : []
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetDevicesByCompany), $"Returned {result.Count} devices from company {companyAcronym}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesByCompany), $"Error querying devices for company {companyAcronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets devices by protocol with their associated Analog and Digital measurements.
        /// </summary>
        /// <param name="protocolName">Protocol name (e.g.: IeeeC37_118V1, SEL Fast Message).</param>
        /// <returns>List of devices using the specified protocol with Analogs and Digitals.</returns>
        /// <response code="200">Returns the list of devices with Analogs and Digitals</response>
        /// <response code="404">No devices found for the protocol</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithMeasurements>))]
        public IHttpActionResult GetDevicesByProtocol(string protocolName)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDevicesByProtocol), $"Querying devices for protocol: {protocolName}");

                using AdoDataConnection context = DataContext;

                TableOperations<Protocol> protocolTable = new(context);
                var protocol = protocolTable.QueryRecordsWhere("Name = {0}", protocolName).FirstOrDefault();

                TableOperations<Device> deviceTable = new(context);
                var devices = deviceTable.QueryRecordsWhere("ProtocolID = {0}", protocol?.ID).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesByProtocol), $"No devices found for protocol: {protocolName}");
                    return NotFound();
                }

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice(context);
                var result = devices.Select(device => new DeviceWithMeasurements
                {
                    Device = device,
                    Analogs = measurementsByDevice.ContainsKey(device.Acronym) ? measurementsByDevice[device.Acronym].Analogs : [],
                    Digitals = measurementsByDevice.ContainsKey(device.Acronym) ? measurementsByDevice[device.Acronym].Digitals : []
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetDevicesByProtocol), $"Returned {result.Count} devices for protocol {protocolName}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesByProtocol), $"Error querying devices for protocol {protocolName}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets enabled or disabled devices with their associated Analog and Digital measurements.
        /// </summary>
        /// <param name="enabled">true for enabled, false for disabled.</param>
        /// <returns>List of devices filtered by status with Analogs and Digitals.</returns>
        /// <response code="200">Returns the list of devices with Analogs and Digitals</response>
        /// <response code="404">No devices found with the specified status</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithMeasurements>))]
        public IHttpActionResult GetDevicesByStatus(bool enabled)
        {
            try
            {
                string status = enabled ? "enabled" : "disabled";
                Log.Publish(MessageLevel.Info, nameof(GetDevicesByStatus), $"Querying {status} devices");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                RecordRestriction restriction = new("Enabled = {0}", enabled ? 1 : 0);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym, restriction: restriction).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesByStatus), $"No {status} devices found");
                    return NotFound();
                }

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice(context);
                var result = devices.Select(device => new DeviceWithMeasurements
                {
                    Device = device,
                    Analogs = measurementsByDevice.ContainsKey(device.Acronym) ? measurementsByDevice[device.Acronym].Analogs : [],
                    Digitals = measurementsByDevice.ContainsKey(device.Acronym) ? measurementsByDevice[device.Acronym].Digitals : []
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetDevicesByStatus), $"Returned {result.Count} {status} devices");
                return Ok(result);
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
                var deviceIdInDatabase = CommonController.ExecuteWithRetry(() => UpsertDeviceRecord(device), nameof(UpsertDevice));
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
                    settings = CommonController.ParsePmuConnectionFile(stream, validRequest.Acronym);

                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile),
                    $"Parsed: Protocol={settings.PhasorProtocol}, Transport={settings.TransportProtocol}, " +
                    $"PmuID={settings.PmuID}, FrameRate={settings.FrameRate}");

                // Connect to the PMU and request its configuration frame, mirroring the
                // openPDCManager "Request Configuration" flow.
                string frameParserConnectionString = CommonController.BuildFrameParserConnectionString(settings);

                Log.Publish(MessageLevel.Info, nameof(UpsertDeviceByPmuConnectionFile),
                    $"Requesting configuration frame from: {settings.ConnectionString}");

                (int savedDeviceCount, string resultAcronym) = await CommonController.ExecuteWithRetry(async () =>
                {
                    IConfigurationFrame configFrame = await CommonController.RequestConfigurationFrameAsync(frameParserConnectionString);

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
                    targetAcronym = CommonController.SanitizeAcronym(cell.StationName);
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
            string cellAcronym = CommonController.SanitizeAcronym(cell.StationName);

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

            int? protocolID = CommonController.GetProtocolID(settings.PhasorProtocol, context);
            bool isConcentrator = configFrame.Cells.Count > 1;
            string deviceConnectionString = $"TransportProtocol={settings.TransportProtocol};{settings.ConnectionString}";

            var deviceMetadata = CommonController.ResolveDeviceMetadata(validRequest, context);

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
            TableOperations<DeviceDetail> DeviceTable = new(context);
            var Device = DeviceTable.QueryRecordWhere("Acronym = {0}", deviceAcronym);
            string companyAcronym = Device?.CompanyAcronym ?? string.Empty;

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

                CommonController.UpsertMeasurement(measurementTable, new Measurement
                {
                    DeviceID = deviceID,
                    HistorianID = historianID,
                    PointTag = $"{companyAcronym}_{deviceAcronym}:{pmuType.Acronym}",
                    SignalTypeID = pmuType.ID,
                    SignalReference = $"{deviceAcronym}-{suffix}",
                    Description = $"{deviceName} {CommonController.PmuSignalDescription(suffix)}",
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

                    CommonController.UpsertMeasurement(measurementTable, new Measurement
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

                    CommonController.UpsertMeasurement(measurementTable, new Measurement
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
                    CommonController.UpsertMeasurement(measurementTable, new Measurement
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