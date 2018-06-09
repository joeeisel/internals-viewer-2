using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class ServerService : IServerService
    {
        public ServerService(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        protected IDatabaseConnection DatabaseConnection { get; set; }

        public Task<IEnumerable<string>> GetDatabases()
        {
            var connection = DatabaseConnection.GetConnection();

            return connection.QueryAsync<string>(Properties.Resources.Sql_Metadata_Databases);
        }
    }
}