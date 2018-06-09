using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    /// <summary>
    /// Set of pages in the server's buffer bool
    /// </summary>
    public class BufferPool
    {
        public List<PageAddress> CleanPages { get; } = new List<PageAddress>();

        public List<PageAddress> DirtyPages { get; } = new List<PageAddress>();
    }
}
