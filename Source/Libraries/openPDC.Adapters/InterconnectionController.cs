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
    /// Defines a REST API for retrieving <see cref="Interconnection"/> records.
    /// </summary>
    public class InterconnectionController : ApiController
    {
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(InterconnectionController), MessageClass.Application);

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
        /// Gets all interconnections registered in the system.
        /// </summary>
        /// <returns>List of all registered interconnections.</returns>
        /// <response code="200">Returns the list of interconnections</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Interconnection>))]
        public IHttpActionResult GetAllInterconnections()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllInterconnections), "Querying all interconnections");

                using AdoDataConnection context = DataContext;
                TableOperations<Interconnection> interconnectionTable = new(context);

                var interconnections = interconnectionTable.QueryRecords(StringConstant.ID).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllInterconnections), $"Returned {interconnections.Count} interconnections");
                return Ok(interconnections);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllInterconnections), "Error querying interconnections", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the interconnection with the specified acronym.
        /// </summary>
        /// <param name="acronym">Acronym that uniquely identifies the interconnection.</param>
        /// <returns>The interconnection matching the specified acronym, if found.</returns>
        /// <response code="200">Returns the matching interconnection</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Interconnection>))]
        public IHttpActionResult GetInterconnectionByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetInterconnectionByAcronym), "Querying interconnection by acronym");

                using AdoDataConnection context = DataContext;
                TableOperations<Interconnection> interconnectionTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);

                var interconnection = interconnectionTable.QueryRecords(restriction).FirstOrDefault();

                Log.Publish(MessageLevel.Info, nameof(GetInterconnectionByAcronym), $"Returned Interconnection: {interconnection?.Acronym}");
                return Ok(interconnection);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetInterconnectionByAcronym), "Error querying interconnection", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}