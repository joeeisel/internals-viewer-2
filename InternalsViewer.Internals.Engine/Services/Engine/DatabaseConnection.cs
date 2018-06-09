using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Services;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public string ConnectionString { get; set; }

        public void SetDatabase(string databaseName)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(ConnectionString);

            connectionStringBuilder.InitialCatalog = databaseName;

            ConnectionString = connectionStringBuilder.ToString();
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
