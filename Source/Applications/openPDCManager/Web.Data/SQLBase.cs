//*******************************************************************************************************
//  SQLBase.cs
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

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace openPDCManager.Web.Data
{
	/// <summary>
	/// Base class that defines CRUD operations on SQL Server Database.
	/// </summary>
    public class SQLBase
    {
        SqlConnection _Connection;

        public SQLBase()
        {
            _Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PhasorDataConnection"].ConnectionString);
        }
        protected void ExecuteCommand(SqlCommand command, ref DataTable table, bool isText)
        {
            command.Connection = _Connection;
            if (isText)
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
        }

        protected void ExecuteCommand(SqlCommand command, ref DataSet ds, bool isText)
        {
            command.Connection = _Connection;
            if (isText)
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            command.Connection.Close();
        }

        protected object ExecuteScalarCommand(SqlCommand command, bool isText)
        {
            command.Connection = _Connection;
            if (isText)
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            return command.ExecuteScalar();
        }

        protected SqlDataReader ExecuteReaderCommand(SqlCommand command, bool isText)
        {
            command.Connection = _Connection;
            if (isText)
                command.CommandType = CommandType.Text;
            else
                command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            return command.ExecuteReader();
        }
    }
}
