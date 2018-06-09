using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    public class IndexAllocationMapPage : AllocationMapPage
    {
        public const int SlotCount = 8;
        public const int SinglePageSlotOffset = 142;
        public const int StartPageOffset = 136;

        /// <summary>
        /// Gets the single page slots collection.
        /// </summary>
        /// <value>The single page slots collection.</value>
        public List<PageAddress> SinglePageSlots { get; } = new List<PageAddress>();
    }
}