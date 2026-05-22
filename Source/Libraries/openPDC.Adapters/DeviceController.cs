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

        #endregion [ Methods ]
    }
}