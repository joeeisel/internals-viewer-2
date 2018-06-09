using System.Data;

namespace InternalsViewer.Internals.Engine.Interfaces.Services
{
    public interface IDatabaseConnection
    {
        string ConnectionString { get; set; }

        IDbConnection GetConnection();

        void SetDatabase(string databaseName);
    }
}