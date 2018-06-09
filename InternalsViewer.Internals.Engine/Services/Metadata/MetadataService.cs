using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using InternalsViewer.Internals.Engine.Data.TypeMappers;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Interfaces.Services.Metadata;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Engine.Services.Metadata
{
    public class MetadataService : IMetadataService
    {
        public MetadataService(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;

            SqlMapper.ResetTypeHandlers();
            SqlMapper.AddTypeHandler(PageAddressTypeMapper.Default);
        }

        protected IDatabaseConnection DatabaseConnection { get; set; }

        public async Task<Database> GetDatabase(string name)
        {
            var connection = DatabaseConnection.GetConnection();

            connection.Open();
            connection.ChangeDatabase(name);

            var result = await connection.QueryAsync<Database, File, Database>(Properties.Resources.Sql_Metadata_Database,
                (database, file) =>
                {
                    database.Files.Add(file);

                    return database;
                }, splitOn: "FileId");

            return result.FirstOrDefault();
        }

        public Task<IEnumerable<AllocationUnit>> GetAllocationUnits()
        {
            var connection = DatabaseConnection.GetConnection();

            return connection.QueryAsync<AllocationUnit>(Properties.Resources.Sql_Metadata_AllocationUnits);
        }
    }
}
