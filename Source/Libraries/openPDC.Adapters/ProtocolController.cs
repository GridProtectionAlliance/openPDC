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
    /// Defines a REST API for retrieving <see cref="Protocol"/> records.
    /// </summary>
    public class ProtocolController : ApiController
    {
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(ProtocolController), MessageClass.Application);

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
        /// Gets all protocols registered in the system.
        /// </summary>
        /// <returns>List of all registered protocols.</returns>
        /// <response code="200">Returns the list of protocols</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Protocol>))]
        public IHttpActionResult GetAllProtocols()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllProtocols), "Querying all protocols");

                using AdoDataConnection context = DataContext;
                TableOperations<Protocol> protocolTable = new(context);

                var protocols = protocolTable.QueryRecords(StringConstant.ID).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllProtocols), $"Returned {protocols.Count} protocols");
                return Ok(protocols);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllProtocols), "Error querying protocols", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the protocol with the specified acronym.
        /// </summary>
        /// <param name="acronym">Acronym that uniquely identifies the protocol.</param>
        /// <returns>The protocol matching the specified acronym, if found.</returns>
        /// <response code="200">Returns the matching protocol</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Protocol>))]
        public IHttpActionResult GetProtocolByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetProtocolByAcronym), "Querying protocol by acronym");

                using AdoDataConnection context = DataContext;
                TableOperations<Protocol> protocolTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);

                var protocol = protocolTable.QueryRecords(restriction).FirstOrDefault();

                Log.Publish(MessageLevel.Info, nameof(GetProtocolByAcronym), $"Returned Protocol: {protocol?.Name}");
                return Ok(protocol);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetProtocolByAcronym), "Error querying protocol", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}