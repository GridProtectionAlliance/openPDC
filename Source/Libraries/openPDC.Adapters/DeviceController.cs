using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.PhasorProtocols;
using GSF.Web.Shared.Model;
using openPDC.Adapters.Constants;
using openPDC.Adapters.Services;
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

        private readonly IDeviceService _deviceService;

        #endregion [ Members ]

        #region [ Constructors ]

        /// <summary>
        /// Creates a new <see cref="DeviceController"/>, used by Web API's default controller
        /// activator, which requires a parameterless constructor.
        /// </summary>
        public DeviceController() : this(new DeviceService())
        {
        }

        /// <summary>
        /// Creates a new <see cref="DeviceController"/> with the given <see cref="IDeviceService"/>.
        /// </summary>
        /// <param name="deviceService">Service providing device persistence operations.</param>
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
        }

        #endregion [ Constructors ]

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

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice();
                var measurements = measurementsByDevice.ContainsKey(device.Acronym)
                    ? measurementsByDevice[device.Acronym]
                    : new DeviceMeasurements();

                var result = new DeviceWithMeasurements
                {
                    Device = device,
                    Analogs = measurements.Analogs,
                    Digitals = measurements.Digitals
                };

                Log.Publish(MessageLevel.Info, nameof(GetDeviceByAcronym), $"Device found: {acronym} with {measurements.Analogs?.Count ?? 0} Analogs and {measurements.Digitals?.Count ?? 0} Digitals");
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

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice();
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

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice();
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

                var measurementsByDevice = CommonController.LoadMeasurementsByDevice();
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
                var validRequest = await _deviceService.ValidateRequestAsync(Request);

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

                    int count = await _deviceService.ProcessConfigurationFrameAsync(settings, configFrame, validRequest, User.Identity.Name);
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
        /// Updates or inserts a batch of devices (PMUs) in a single request. Each device is matched
        /// by its unique Acronym: existing devices are updated, new ones are inserted. A failure on
        /// one device does not stop the rest of the batch from being processed; the outcome of
        /// every device is returned individually along with a summary of the operation.
        /// </summary>
        /// <param name="devices">The devices to update or insert.</param>
        /// <response code="200">Returns the per-device results and a summary of the batch operation</response>
        /// <response code="400">No devices were provided</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpPost]
        [ResponseType(typeof(UpsertDeviceResponse))]
        public IHttpActionResult UpsertDevices(IReadOnlyList<Device> devices)
        {
            try
            {
                if (devices == null || devices.Count == 0)
                    return BadRequest("At least one device must be provided.");

                var response = CommonController.ExecuteWithRetry(() => _deviceService.UpsertDevices(devices, User.Identity.Name), nameof(UpsertDevices));

                Log.Publish(MessageLevel.Info, nameof(UpsertDevices),
                    $"Processed {response.NumberOfReceivedRecords} device(s): {response.NumberOfRecordsProcessedWithSuccess} succeeded, {response.NumberOfRecordsWithFail} failed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(UpsertDevices), $"Error upserting devices", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Creates or updates devices (PMUs), their phasors and all derived measurements from data
        /// supplied directly as JSON, replicating what the openPDC Input Device Wizard produces from
        /// a .PmuConnection file, but without connecting to the PMU. For each device the endpoint
        /// auto-creates the PMU-level signals (frequency, dF/dt, status flags), a magnitude/angle
        /// measurement pair per phasor, and one measurement per analog/digital label. Each item may
        /// be a standalone PMU or a concentrator with nested child PMUs. A failure on one device does
        /// not stop the rest of the batch; the outcome of every device (parent and children) is
        /// returned individually. PointTags are generated by the system's configured naming
        /// expression, so they may differ textually from the .PmuConnection flow; measurements are
        /// matched (and thus not duplicated) by SignalReference.
        /// </summary>
        /// <param name="devices">The devices (and, for concentrators, their children) to import.</param>
        /// <response code="200">Returns the per-device results and a summary of the batch operation</response>
        /// <response code="400">No devices were provided</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpPost]
        [ResponseType(typeof(UpsertDeviceResponse))]
        public IHttpActionResult UpsertDevicesFromData(IReadOnlyList<DeviceImportRequest> devices)
        {
            try
            {
                if (devices == null || devices.Count == 0)
                    return BadRequest("At least one device must be provided.");

                var response = CommonController.ExecuteWithRetry(() => _deviceService.UpsertDevicesFromData(devices, User.Identity.Name), nameof(UpsertDevicesFromData));

                Log.Publish(MessageLevel.Info, nameof(UpsertDevicesFromData),
                    $"Processed {response.NumberOfReceivedRecords} device(s): {response.NumberOfRecordsProcessedWithSuccess} succeeded, {response.NumberOfRecordsWithFail} failed");

                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(UpsertDevicesFromData), $"Error importing devices from data", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}