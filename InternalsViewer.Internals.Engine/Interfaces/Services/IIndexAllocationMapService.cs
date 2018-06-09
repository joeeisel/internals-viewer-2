using System.Data;
using System.Threading.Tasks;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Allocations;

namespace InternalsViewer.Internals.Engine.Interfaces.Services
{
    public interface IIndexAllocationMapService
    {
        Task<IndexAllocationMap> GetAllocation(int databaseId, PageAddress pageAddress);
    }
}