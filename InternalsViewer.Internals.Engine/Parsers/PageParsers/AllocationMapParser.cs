using System;
using System.Collections;
using InternalsViewer.Internals.Engine.Interfaces.Parsers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Parsers.PageParsers
{
    public class AllocationMapParser : IPageParser<AllocationMapPage>
    {
        public static bool IsAllocationPage(PageType pageType)
        {
            switch (pageType)
            {
                case PageType.Gam:
                case PageType.Sgam:
                case PageType.Dcm:
                case PageType.Bcm:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Parses a RawPage into an AllocationMapPage
        /// </summary>
        public AllocationMapPage Parse(RawPage page)
        {
            var allocationPage = new AllocationMapPage
            {
                Data = page.Data,
                Header = page.Header,
                StartPage = new PageAddress(page.Header.PageAddress.FileId, 0)
            };

            ParseAllocationMap(allocationPage);

            return allocationPage;
        }

        protected static void ParseAllocationMap(AllocationMapPage allocationMapPage)
        {
            var allocationData = new byte[AllocationMapPage.ExtentCount / 8];

            Array.Copy(allocationMapPage.Data,
                       AllocationMapPage.AllocationArrayOffset,
                       allocationData,
                       0,
                       allocationData.Length - allocationMapPage.Header.SlotCount * 2);

            var bitArray = new BitArray(allocationData);

            bitArray.CopyTo(allocationMapPage.AllocationMap, 0);
        }
    }
}