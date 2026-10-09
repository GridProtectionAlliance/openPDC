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
    /// Defines a REST API for retrieving <see cref="Company"/> records.
    /// </summary>
    public class CompanyController : ApiController
    {
        private static readonly LogPublisher Log = Logger.CreatePublisher(typeof(CompanyController), MessageClass.Application);

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
        [ResponseType(typeof(IEnumerable<Company>))]
        public IHttpActionResult GetAllCompanies()
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetAllCompanies), "Querying all companies");

                using AdoDataConnection context = DataContext;
                TableOperations<Company> companyTable = new(context);

                var companies = companyTable.QueryRecords(StringConstant.ID).ToList();

                Log.Publish(MessageLevel.Info, nameof(GetAllCompanies), $"Returned {companies.Count} companies");
                return Ok(companies);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetAllCompanies), "Error querying companies", exception: ex);
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the company with the specified acronym.
        /// </summary>
        /// <param name="acronym">Acronym that uniquely identifies the company.</param>
        /// <returns>The company matching the specified acronym, if found.</returns>
        /// <response code="200">Returns the matching company</response>
        /// <response code="500">Internal error processing the request</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Company>))]
        public IHttpActionResult GetCompanyByAcronym(string acronym)
        {
            try
            {
                Log.Publish(MessageLevel.Info, nameof(GetCompanyByAcronym), "Querying company by acronym");

                using AdoDataConnection context = DataContext;
                TableOperations<Company> companyTable = new(context);
                RecordRestriction restriction = new("Acronym = {0}", acronym);

                var company = companyTable.QueryRecords(restriction).FirstOrDefault();

                Log.Publish(MessageLevel.Info, nameof(GetCompanyByAcronym), $"Returned Company: {company?.Acronym}");
                return Ok(company);
            }
            catch (Exception ex)
            {
                Log.Publish(MessageLevel.Error, nameof(GetCompanyByAcronym), "Error querying company", exception: ex);
                return InternalServerError(ex);
            }
        }

        #endregion [ Methods ]
    }
}