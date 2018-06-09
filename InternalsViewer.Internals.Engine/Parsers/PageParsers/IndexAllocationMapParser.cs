using System;
using InternalsViewer.Internals.Engine.Interfaces.Parsers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Parsers.PageParsers
{
    public class IndexAllocationMapParser : AllocationMapParser, IPageParser<IndexAllocationMapPage>
    {
        public new IndexAllocationMapPage Parse(RawPage page)
        {
            var allocationPage = new IndexAllocationMapPage
            {
                Data = page.Data,
                Header = page.Header
            };

            ParseAllocationMap(allocationPage);

            ParseIamHeader(allocationPage);
            ParseSinglePageSlots(allocationPage);

            return allocationPage;
        }

        /// <summary>
        /// Parse the IAM header.
        /// </summary>
        private static void ParseIamHeader(IndexAllocationMapPage mapPage)
        {
            var pageAddress = new byte[PageAddress.Size];

            Array.Copy(mapPage.Data, IndexAllocationMapPage.StartPageOffset, pageAddress, 0, PageAddress.Size);

            mapPage.StartPage = new PageAddress(pageAddress);
        }

        /// <summary>
        /// Parse the single mapPage slots.
        /// </summary>
        private static void ParseSinglePageSlots(IndexAllocationMapPage mapPage)
        {
            var offset = IndexAllocationMapPage.SinglePageSlotOffset;

            for (var i = 0; i < IndexAllocationMapPage.SlotCount; i++)
            {
                var pageAddress = new byte[PageAddress.Size];

                Array.Copy(mapPage.Data, offset, pageAddress, 0, PageAddress.Size);

                mapPage.SinglePageSlots.Add(new PageAddress(pageAddress));

                offset += PageAddress.Size;
            }
        }
    }
}