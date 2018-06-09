using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalsViewer.Internals.Engine.Interfaces.Services.Engine
{
    public interface IServerService
    {
        Task<IEnumerable<string>> GetDatabases();
    }
}