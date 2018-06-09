using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Models.Engine.Database
{
    public class DatabaseContainer
    {
        public int DatabaseId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// GAM (Global Allocation Map)
        /// </summary>
        public Dictionary<int, AllocationMap> Gam { get; set; } = new Dictionary<int, AllocationMap>();

        /// <summary>
        /// SGAM (Shared Global Allocation Map)
        /// </summary>
        public Dictionary<int, AllocationMap> SGam { get; set; } = new Dictionary<int, AllocationMap>();

        /// <summary>
        /// DCM (Differential Change Map) or DIFF (Differential) Map
        /// </summary>
        public Dictionary<int, AllocationMap> Dcm { get; set; } = new Dictionary<int, AllocationMap>();

        /// <summary>
        /// BCP (Bulk Change Map) or ML (Minimally Logged) Map
        /// </summary>
        public Dictionary<int, AllocationMap> Bcm { get; set; } = new Dictionary<int, AllocationMap>();

        /// <summary>
        /// Page Free Spage
        /// </summary>
        public Dictionary<int, PageFreeSpace> Pfs { get; set; } = new Dictionary<int, PageFreeSpace>();

        /// <summary>
        /// Allocation Units metadata
        /// </summary>
        public IEnumerable<AllocationUnit> AllocationUnits = new List<AllocationUnit>();

        /// <summary>
        /// IAM Chains for the Allocation Units in the database
        /// </summary>
        public Dictionary<long, IndexAllocationMap> IndexAllocationMaps = new Dictionary<long, IndexAllocationMap>();

        public IEnumerable<File> Files { get; set; }

        public byte CompatibilityLevel { get; set; }
    }
}