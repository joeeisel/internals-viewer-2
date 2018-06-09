using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// Page Header
    /// </summary>
    public class Header
    {
        public PageAddress PageAddress { get; set; }

        public PageAddress NextPage { get; set; }

        public PageAddress PreviousPage { get; set; }

        public PageType PageType { get; set; }

        public long AllocationUnitId { get; set; }

        /// <summary>
        /// Gets or sets the page index level.
        /// </summary>
        /// <value>The page index level.</value>
        public int Level { get; set; }

        public int IndexId { get; set; }

        public int SlotCount { get; set; }

        /// <summary>
        /// Gets or sets the free count value.
        /// </summary>
        /// <value>The free count value.</value>
        public int FreeCount { get; set; }

        /// <summary>
        /// Gets or sets the free data value.
        /// </summary>
        /// <value>The free data value.</value>
        public int FreeData { get; set; }

        public int MinLen { get; set; }

        public int ReservedCount { get; set; }

        public int XactReservedCount { get; set; }

        public long TornBits { get; set; }

        public string FlagBits { get; set; }

        public long ObjectId { get; set; }

        public long PartitionId { get; set; }

        public LogSequenceNumber Lsn { get; set; }

        public string AllocationUnit { get; set; }

        public string PageTypeName { get; set; }
    }
}
