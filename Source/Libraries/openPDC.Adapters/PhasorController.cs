using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using openPDC.Adapters.Constants;
using openPDC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace openPDC.Adapters
{
    /// <summary>
    /// Controller for Phasor operations in openPDC. Provides endpoints to query phasor data
    /// from PMUs.
    /// </summary>
    public class PhasorController : ApiController
    {
        #region [ Members ]

        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(PhasorController), MessageClass.Application);

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
        /// Gets all phasors in the system.
        /// </summary>
        /// <returns>List of all registered phasors.</returns>
        /// <response code="200">Returns the list of phasors</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PhasorDetail>))]
        public IHttpActionResult GetAllPhasors()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllPhasors), "Querying all phasors");

                using AdoDataConnection context = DataContext;
                TableOperations<PhasorDetail> phasorTable = new(context);
                var phasors = phasorTable.QueryRecords(StringConstant.DeviceID);

                Log.Publish(MessageLevel.Info, nameof(GetAllPhasors), $"Returned {phasors.Count()} phasors");
                return Ok(phasors);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllPhasors), "Error querying phasors", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the phasors of a specific device by ID.
        /// </summary>
        /// <param name="deviceId">Device (PMU) ID.</param>
        /// <returns>List of phasors from the specified device.</returns>
        /// <response code="200">Returns the list of device phasors</response>
        /// <response code="404">Device not found or has no phasors</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PhasorDetail>))]
        public IHttpActionResult GetPhasorsByDevice(int deviceId)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetPhasorsByDevice), $"Querying phasors for device ID: {deviceId}");

                using AdoDataConnection context = DataContext;
                TableOperations<PhasorDetail> phasorTable = new(context);
                RecordRestriction restriction = new("DeviceID = {0}", deviceId);
                var phasors = phasorTable.QueryRecords(StringConstant.SourceIndex, restriction).ToList();

                if (!phasors.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetPhasorsByDevice), $"No phasors found for device ID: {deviceId}");
                    return NotFound();
                }

                Log.Publish(MessageLevel.Info, nameof(GetPhasorsByDevice), $"Returned {phasors.Count} phasors for device ID {deviceId}");
                return Ok(phasors);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetPhasorsByDevice), $"Error querying phasors for device ID {deviceId}", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the phasors of a specific device by Acronym.
        /// </summary>
        /// <param name="deviceAcronym">Device (PMU) acronym.</param>
        /// <returns>List of phasors from the specified device.</returns>
        /// <response code="200">Returns the list of device phasors</response>
        /// <response code="404">Device not found or has no phasors</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PhasorDetail>))]
        public IHttpActionResult GetPhasorsByDeviceAcronym(string deviceAcronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetPhasorsByDeviceAcronym), $"Querying phasors for device: {deviceAcronym}");

                using AdoDataConnection context = DataContext;
                TableOperations<PhasorDetail> phasorTable = new(context);
                RecordRestriction restriction = new("DeviceAcronym = {0}", deviceAcronym);
                var phasors = phasorTable.QueryRecords(StringConstant.SourceIndex, restriction).ToList();

                if (!phasors.Any())
                {
                    Log.Publish(MessageLevel.Warning, nameof(GetPhasorsByDeviceAcronym), $"No phasors found for device: {deviceAcronym}");
                    return NotFound();
                }

                Log.Publish(MessageLevel.Info, nameof(GetPhasorsByDeviceAcronym), $"Returned {phasors.Count} phasors for device {deviceAcronym}");
                return Ok(phasors);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetPhasorsByDeviceAcronym), $"Error querying phasors for device {deviceAcronym}", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}