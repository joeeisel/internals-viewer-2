using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Allocations
{
    /// <summary>
    /// An IAM allocation structure
    /// </summary>
    public class IndexAllocationMap : AllocationMap
    {
        public List<PageAddress> SinglePageSlots { get; set; } = new List<PageAddress>();
    }
}
