using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using openPDC.Adapters.Constants;
using openPDC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace openPDC.Adapters
{
    /// <summary>
    /// Controller for combined Device and Phasor operations. Provides endpoints to query devices
    /// (PMUs) along with their phasors in a single request.
    /// </summary>
    public class DevicePhasorController : ApiController
    {
        #region [ Members ]

        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(DevicePhasorController), MessageClass.Application);

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
        /// Gets all devices with their respective phasors.
        /// </summary>
        /// <returns>List of devices with their phasors.</returns>
        /// <response code="200">Returns the list of devices with phasors</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithPhasors>))]
        public IHttpActionResult GetAllDevicesWithPhasors()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllDevicesWithPhasors), "Querying all devices with phasors");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                TableOperations<PhasorDetail> phasorTable = new(context);

                var devices = deviceTable.QueryRecords(StringConstant.Acronym).ToList();
                var allPhasors = phasorTable.QueryRecords("DeviceID, SourceIndex").ToList();

                var result = devices.Select(device => new DeviceWithPhasors
                {
                    Device = device,
                    Phasors = [.. allPhasors.Where(p => p.DeviceAcronym == device.Acronym).OrderBy(p => p.SourceIndex)]
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllDevicesWithPhasors), $"Returned {result.Count} devices with phasors");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllDevicesWithPhasors), "Error querying devices with phasors", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets all devices with their respective phasors in CSV format.
        /// </summary>
        /// <returns>List of devices with their phasors in CSV format.</returns>
        /// <response code="200">Returns the list of devices with phasors in CSV format</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        public HttpResponseMessage GetAllDevicesWithPhasorsAsCsv()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllDevicesWithPhasorsAsCsv), "Generating CSV with all devices and phasors");

                using AdoDataConnection context = DataContext;
                TableOperations<DeviceDetail> deviceTable = new(context);
                TableOperations<PhasorDetail> phasorTable = new(context);

                var devices = deviceTable.QueryRecords(StringConstant.Acronym).ToList();
                var allPhasors = phasorTable.QueryRecords("DeviceID, SourceIndex").ToList();

                var csv = new StringBuilder();

                // Cabeçalho
                csv.AppendLine("DeviceAcronym,DeviceName,CompanyAcronym,VendorAcronym,ProtocolName,IsConcentrator,FramesPerSecond,DeviceEnabled,Latitude,Longitude,PhasorID,PhasorLabel,PhasorType,PhasorPhase,SourceIndex,BaseKV");

                // Dados
                foreach (var device in devices)
                {
                    var devicePhasors = allPhasors.Where(p => p.DeviceAcronym == device.Acronym).OrderBy(p => p.SourceIndex).ToList();

                    if (devicePhasors.Any())
                    {
                        foreach (var phasor in devicePhasors)
                        {
                            csv.AppendLine($"{EscapeCsvField(device.Acronym)},{EscapeCsvField(device.Name)},{EscapeCsvField(device.CompanyAcronym)},{EscapeCsvField(device.VendorAcronym)},{EscapeCsvField(device.ProtocolName)},{EscapeCsvField(device.IsConcentrator.ToString())},{device.FramesPerSecond},{device.Enabled},{device.Latitude},{device.Longitude},{phasor.ID},{EscapeCsvField(phasor.Label)},{EscapeCsvField(phasor.Type)},{EscapeCsvField(phasor.Phase)},{phasor.SourceIndex},{phasor.BaseKV}");
                        }
                    }
                    else
                    {
                        // Device without phasors - add line with device information only
                        csv.AppendLine($"{EscapeCsvField(device.Acronym)},{EscapeCsvField(device.Name)},{EscapeCsvField(device.CompanyAcronym)},{EscapeCsvField(device.VendorAcronym)},{EscapeCsvField(device.ProtocolName)},{EscapeCsvField(device.IsConcentrator.ToString())},{device.FramesPerSecond},{device.Enabled},{device.Latitude},{device.Longitude},,,,,0,0");
                    }
                }

                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(csv.ToString(), Encoding.UTF8, "text/csv");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"all_devices_phasors_{DateTime.UtcNow:yyyyMMdd_HHmmss}.csv"
                };

                Log.Publish(MessageLevel.Info, nameof(GetAllDevicesWithPhasorsAsCsv), $"CSV generated with {devices.Count} devices");
                return response;
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllDevicesWithPhasorsAsCsv), "Error generating CSV", exception: ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets devices from a company with their phasors.
        /// </summary>
        /// <param name="companyAcronym">Company acronym.</param>
        /// <returns>List of devices from the company with their phasors.</returns>
        /// <response code="200">Returns the list of devices with phasors</response>
        /// <response code="404">No devices found for the company</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithPhasors>))]
        public IHttpActionResult GetDevicesWithPhasorsByCompany(string companyAcronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDevicesWithPhasorsByCompany), $"Querying devices with phasors for company: {companyAcronym}");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                TableOperations<PhasorDetail> phasorTable = new(context);

                RecordRestriction deviceRestriction = new("CompanyAcronym = {0}", companyAcronym);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym, restriction: deviceRestriction).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesWithPhasorsByCompany), $"No devices found for company: {companyAcronym}");
                    return NotFound();
                }

                var allPhasors = phasorTable.QueryRecords("DeviceID, SourceIndex").ToList();

                var result = devices.Select(device => new DeviceWithPhasors
                {
                    Device = device,
                    Phasors = [.. allPhasors.Where(p => p.DeviceAcronym == device.Acronym).OrderBy(p => p.SourceIndex)]
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetDevicesWithPhasorsByCompany), $"Returned {result.Count} devices from company {companyAcronym}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesWithPhasorsByCompany), $"Error querying devices for company {companyAcronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets enabled devices with their phasors.
        /// </summary>
        /// <param name="enabled">true for enabled, false for disabled.</param>
        /// <returns>List of devices filtered by status with their phasors.</returns>
        /// <response code="200">Returns the list of devices with phasors</response>
        /// <response code="404">No devices found with the specified status</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<DeviceWithPhasors>))]
        public IHttpActionResult GetDevicesWithPhasorsByStatus(bool enabled)
        {
            try
            {
                string status = enabled ? "enabled" : "disabled";
                Log.Publish(MessageLevel.Info, nameof(GetDevicesWithPhasorsByStatus), $"Querying {status} devices with phasors");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                TableOperations<PhasorDetail> phasorTable = new(context);

                RecordRestriction deviceRestriction = new("Enabled = {0}", enabled ? 1 : 0);
                var devices = deviceTable.QueryRecords(StringConstant.Acronym, restriction: deviceRestriction).ToList();

                if (!devices.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDevicesWithPhasorsByStatus), $"No {status} devices found");
                    return NotFound();
                }

                var allPhasors = phasorTable.QueryRecords("DeviceID, SourceIndex").ToList();

                var result = devices.Select(device => new DeviceWithPhasors
                {
                    Device = device,
                    Phasors = [.. allPhasors.Where(p => p.DeviceAcronym == device.Acronym).OrderBy(p => p.SourceIndex)]
                }).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetDevicesWithPhasorsByStatus), $"Returned {result.Count} {status} devices");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDevicesWithPhasorsByStatus), $"Error querying devices by status", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets a specific device with its phasors by Acronym.
        /// </summary>
        /// <param name="acronym">Device (PMU) acronym.</param>
        /// <returns>Device with its phasors.</returns>
        /// <response code="200">Returns the device with its phasors</response>
        /// <response code="404">Device not found</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(DeviceWithPhasors))]
        public IHttpActionResult GetDeviceWithPhasorsByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDeviceWithPhasorsByAcronym), $"Querying device {acronym} with phasors");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                TableOperations<PhasorDetail> phasorTable = new(context);

                RecordRestriction deviceRestriction = new("Acronym = {0}", acronym);
                var device = deviceTable.QueryRecords(restriction: deviceRestriction).FirstOrDefault();

                if (device == null)
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDeviceWithPhasorsByAcronym), $"Device not found: {acronym}");
                    return NotFound();
                }

                RecordRestriction phasorRestriction = new("DeviceAcronym = {0}", acronym);
                var phasors = phasorTable.QueryRecords(StringConstant.SourceIndex, phasorRestriction).ToList();

                var result = new DeviceWithPhasors
                {
                    Device = device,
                    Phasors = phasors
                };

                Log.Publish(MessageLevel.Info, nameof(GetDeviceWithPhasorsByAcronym), $"Returned device {acronym} with {phasors.Count} phasors");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDeviceWithPhasorsByAcronym), $"Error querying device {acronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets a specific device with its phasors by Acronym in CSV format.
        /// </summary>
        /// <param name="acronym">Device (PMU) acronym.</param>
        /// <returns>Device with its phasors in CSV format.</returns>
        /// <response code="200">Returns the device with its phasors in CSV format</response>
        /// <response code="404">Device not found</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        public HttpResponseMessage GetDeviceWithPhasorsByAcronymAsCsv(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetDeviceWithPhasorsByAcronymAsCsv), $"Generating CSV for device {acronym} with phasors");

                using AdoDataConnection context = DataContext;
                TableOperations<Device> deviceTable = new(context);
                TableOperations<PhasorDetail> phasorTable = new(context);

                RecordRestriction deviceRestriction = new("Acronym = {0}", acronym);
                var device = deviceTable.QueryRecords(restriction: deviceRestriction).FirstOrDefault();

                if (device == null)
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetDeviceWithPhasorsByAcronymAsCsv), $"Device not found: {acronym}");
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                RecordRestriction phasorRestriction = new("DeviceAcronym = {0}", acronym);
                var phasors = phasorTable.QueryRecords(StringConstant.SourceIndex, true, int.MaxValue, 0, phasorRestriction).ToList();

                var csv = new StringBuilder();

                // Cabeçalho do Device
                csv.AppendLine("# Device Information");
                csv.AppendLine("AccessID,Acronym,AllowedParsingExceptions,AllowUseOfCachedConfiguration,AutoStartDataParsingSequence,CompanyID,ConnectionString,ConnectOnDemand,ContactList,CreatedBy,CreatedOn,DataLossInterval,DelayedConnectionInterval,Enabled,FramesPerSecond,HistorianID,ID,InterconnectionID,IsConcentrator,Latitude,LoadOrder,Longitude,MeasuredLines,MeasurementReportingInterval,Name,NodeID,OriginalSource,ParentID,ParsingExceptionWindow,ProtocolID,SkipDisableRealTimeData,TimeAdjustmentTicks,TimeZone,UniqueID,UpdatedBy,UpdatedOn,VendorDeviceID");

                csv.AppendLine($"{device.AccessID},{EscapeCsvField(device.Acronym)},{device.AllowedParsingExceptions},{device.AllowUseOfCachedConfiguration},{device.AutoStartDataParsingSequence},{device.CompanyID},{EscapeCsvField(device.ConnectionString)},{device.ConnectOnDemand},{EscapeCsvField(device.ContactList)},{EscapeCsvField(device.CreatedBy)},{device.CreatedOn:o},{device.DataLossInterval},{device.DelayedConnectionInterval},{device.Enabled},{device.FramesPerSecond},{device.HistorianID},{device.ID},{device.InterconnectionID},{device.IsConcentrator},{device.Latitude},{device.LoadOrder},{device.Longitude},{device.MeasuredLines},{device.MeasurementReportingInterval},{EscapeCsvField(device.Name)},{device.NodeID},{EscapeCsvField(device.OriginalSource)},{device.ParentID},{device.ParsingExceptionWindow},{device.ProtocolID},{device.SkipDisableRealTimeData},{device.TimeAdjustmentTicks},{EscapeCsvField(device.TimeZone)},{device.UniqueID},{EscapeCsvField(device.UpdatedBy)},{device.UpdatedOn:o},{device.VendorDeviceID}");

                // Linha em branco
                csv.AppendLine();

                // Cabeçalho dos Phasors
                csv.AppendLine("# Phasors");
                csv.AppendLine("ID,DeviceAcronym,Label,Type,Phase,SourceIndex,BaseKV");

                // Dados dos Phasors
                foreach (var phasor in phasors)
                {
                    csv.AppendLine($"{phasor.ID},{EscapeCsvField(phasor.DeviceAcronym)},{EscapeCsvField(phasor.Label)},{EscapeCsvField(phasor.Type)},{EscapeCsvField(phasor.Phase)},{phasor.SourceIndex},{phasor.BaseKV}");
                }

                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(csv.ToString(), Encoding.UTF8, "text/csv");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"device_{acronym}_phasors.csv"
                };

                Log.Publish(MessageLevel.Info, nameof(GetDeviceWithPhasorsByAcronymAsCsv), $"CSV generated for device {acronym} with {phasors.Count} phasors");
                return response;
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetDeviceWithPhasorsByAcronymAsCsv), $"Error generating CSV for device {acronym}", exception: ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Escapes CSV fields to handle commas, quotes and line breaks.
        /// </summary>
        /// <param name="field">Field to be escaped.</param>
        /// <returns>Escaped field.</returns>
        private static string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
                return string.Empty;

            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r"))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }

            return field;
        }

        #endregion [ Methods ]
    }
}