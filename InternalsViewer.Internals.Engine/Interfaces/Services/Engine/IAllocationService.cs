using System.Data;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Database;

namespace InternalsViewer.Internals.Engine.Interfaces.Services.Engine
{
    public interface IAllocationService
    {
        IDbConnection Connection { get; set; }

        Task<AllocationMap> GetAllocation(int databaseId, PageAddress pageAddress, int fileSize);
    }
}