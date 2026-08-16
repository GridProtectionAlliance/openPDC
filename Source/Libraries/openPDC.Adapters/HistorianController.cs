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
    /// Defines a REST API for retrieving <see cref="Historian"/> records.
    /// </summary>
    public class HistorianController : ApiController
    {
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(HistorianController), MessageClass.Application);

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
        /// Gets all historians registered in the system.
        /// </summary>
        /// <returns>List of all registered historians.</returns>
        /// <response code="200">Returns the list of historians</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Historian>))]
        public IHttpActionResult GetAllHistorians()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllHistorians), "Querying all historians");

                using AdoDataConnection context = DataContext;
                TableOperations<Historian> historianTable = new(context);

                var historians = historianTable.QueryRecords(StringConstant.ID).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllHistorians), $"Returned {historians.Count} historians");
                return Ok(historians);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllHistorians), "Error querying historians", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the historian with the specified acronym.
        /// </summary>
        /// <param name="acronym">Acronym that uniquely identifies the historian.</param>
        /// <returns>The historian matching the specified acronym, if found.</returns>
        /// <response code="200">Returns the matching historian</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Historian>))]
        public IHttpActionResult GetHistorianByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetHistorianByAcronym), "Querying historian by acronym");

                using AdoDataConnection context = DataContext;
                TableOperations<Historian> historianTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);

                var historian = historianTable.QueryRecords(restriction).FirstOrDefault();

                Log.Publish(MessageLevel.Info, nameof(GetHistorianByAcronym), $"Returned Historian: {historian?.Name}");
                return Ok(historian);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetHistorianByAcronym), "Error querying historian", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}