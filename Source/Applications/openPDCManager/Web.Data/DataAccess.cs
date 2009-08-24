//*******************************************************************************************************
//  DataAccess.cs
//  Copyright © 2009 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: Mehul P. Thakkar
//      Office: INFO SVCS APP DEV, CHATTANOOGA - MR BK-C
//       Phone: 423/751-7571
//       Email: mpthakka@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/05/2009 - Mehul P. Thakkar
//       Generated original version of source code.
//
//*******************************************************************************************************

using System.Data;
using System.Data.SqlClient;

namespace openPDCManager.Web.Data
{
	/// <summary>
	/// Data Access Layer class that defines basic ADO.Net operations
	/// </summary>
    class DataAccess : SQLBase
    {
        public DataTable GetDataTable(SqlCommand command, bool isText)
        {
            DataTable data = new DataTable();
            ExecuteCommand(command, ref data, isText);
            return data;
        }
        public void GetDataSet(SqlCommand command, ref DataSet ds, bool isText)
        {
            ExecuteCommand(command, ref ds, isText);
        }
        public DataRow GetDataRow(SqlCommand command, bool isText)
        {
            DataTable data = new DataTable();
            ExecuteCommand(command, ref data, isText);
            if (data.Rows.Count > 0)
                return data.Rows[0];
            else
                return null;
        }
        public object RunScalarCommand(SqlCommand command, bool isText)
        {
            return ExecuteScalarCommand(command, isText);
        }
    }
}
