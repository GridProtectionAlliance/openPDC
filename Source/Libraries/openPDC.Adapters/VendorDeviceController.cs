using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.Web.Shared.Model;
using openPDC.Adapters.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace openPDC.Adapters
{
    /// <summary>
    /// Defines a REST API for retrieving <see cref="VendorDevice"/> records.
    /// </summary>
    public class VendorDeviceController : ApiController
    {
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(VendorDeviceController), MessageClass.Application);

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
        /// Gets all vendor devices registered in the system.
        /// </summary>
        /// <returns>List of all registered vendor devices.</returns>
        /// <response code="200">Returns the list of vendor devices</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<VendorDevice>))]
        public IHttpActionResult GetAllVendorDevices()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllVendorDevices), "Querying all vendor devices");

                using AdoDataConnection context = DataContext;
                TableOperations<VendorDevice> vendorDeviceTable = new(context);

                var vendorDevices = vendorDeviceTable.QueryRecords(StringConstant.ID).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllVendorDevices), $"Returned {vendorDevices.Count} vendor devices");
                return Ok(vendorDevices);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllVendorDevices), "Error querying vendor devices", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the vendor device with the specified acronym.
        /// </summary>
        /// <param name="acronym">Acronym that uniquely identifies the vendor device.</param>
        /// <returns>The vendor device matching the specified acronym, if found.</returns>
        /// <response code="200">Returns the matching vendor device</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<VendorDevice>))]
        public IHttpActionResult GetVendorDeviceByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetVendorDeviceByAcronym), "Querying vendor device by acronym");

                using AdoDataConnection context = DataContext;
                TableOperations<VendorDevice> vendorDeviceTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);

                var vendorDevice = vendorDeviceTable.QueryRecords(restriction).FirstOrDefault();

                Log.Publish(MessageLevel.Info, nameof(GetVendorDeviceByAcronym), $"Returned Vendor Device: {vendorDevice?.Name}");
                return Ok(vendorDevice);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetVendorDeviceByAcronym), "Error querying vendor device", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}