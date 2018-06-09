using System.Collections.Generic;

namespace InternalsViewer.Internals.Models.Metadata
{
    /// <summary>
    ///  Hobt (Heap or B-Tree) structure
    /// </summary>
    public abstract class HobtStructure
    {
        public long AllocationUnitId { get; set; }

        public List<Column> Columns { get;} = new List<Column>();

        public bool HasSparseColumns { get; set; }
    }
}
