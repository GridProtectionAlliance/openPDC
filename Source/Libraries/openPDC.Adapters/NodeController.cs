using GSF.Data;
using GSF.Data.Model;
using GSF.Diagnostics;
using GSF.Security.Model;
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
    /// Defines a REST API for retrieving <see cref="Company"/> records.
    /// </summary>
    public class NodeController : ApiController
    {
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(NodeController), MessageClass.Application);

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
        /// Gets all companies registered in the system.
        /// </summary>
        /// <returns>List of all registered companies.</returns>
        /// <response code="200">Returns the list of companies</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Node>))]
        public IHttpActionResult GetAllNodes()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllNodes), "Querying all nodes");

                using AdoDataConnection context = DataContext;
                TableOperations<Node> nodeTable = new(context);

                var nodes = nodeTable.QueryRecords(StringConstant.ID).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllNodes), $"Returned {nodes.Count} nodes");
                return Ok(nodes);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllNodes), "Error querying nodes", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}