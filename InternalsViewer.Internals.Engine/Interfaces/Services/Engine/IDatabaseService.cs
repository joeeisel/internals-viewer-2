using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Database;

namespace InternalsViewer.Internals.Engine.Interfaces.Services.Engine
{
    public interface IDatabaseService
    {
        Task<DatabaseContainer> GetDatabase(string databaseName);

        Task LoadAllocations(DatabaseContainer database);

        Task LoadIndexAllocationMaps(DatabaseContainer container);

        Task LoadPfs(DatabaseContainer database);
    }
}