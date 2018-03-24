using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebsocketSubscriber.Data
{
    public class DatabaseHelper : IDisposable
    {
        private SqlConnection Connection = null;

        public SqlConnection ConnectionProvider(string Database="", string CustomConnection = "")
        {
            Connection = new SqlConnection();
            if(!string.IsNullOrEmpty(CustomConnection))
            {
                try
                {
                    DbConnectionStringBuilder CSToCheck = new DbConnectionStringBuilder();
                    CSToCheck.ConnectionString = CustomConnection;
                    Connection.ConnectionString = CustomConnection;
                }catch
                {
                    throw new ArgumentException("Incorrect database connection string. Please validate your database connection string.");
                }
            }

            if (string.IsNullOrEmpty(Connection.ConnectionString) && !string.IsNullOrEmpty(Database) && ConfigurationManager.ConnectionStrings[Database].ConnectionString != null)
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings[Database].ConnectionString;
            else // Fall to default
                Connection.ConnectionString = ConfigurationManager.ConnectionStrings["defaultconnnection"].ConnectionString;

            return Connection;

        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}