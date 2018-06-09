using System;
using InternalsViewer.Internals.Engine.Interfaces.Parsers;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Parsers.PageParsers
{
    public class PfsParser : IPageParser<PageFreeSpacePage>
    {
        public PageFreeSpacePage Parse(RawPage page)
        {
            if (page.Header.PageType != PageType.Pfs)
            {
                throw new InvalidOperationException($"Page is not a PFS pageFreeSpacePage - {page.Header.PageType}");
            }

            var pfsPage = new PageFreeSpacePage
            {
                Header = page.Header,
                Data = page.Data
            };

            LoadPfsBytes(pfsPage);

            return pfsPage;
        }

        /// <summary>
        /// Loads the PFS bytes collection
        /// </summary>
        private static void LoadPfsBytes(PageFreeSpacePage pageFreeSpacePage)
        {
            var pfsData = new byte[PageFreeSpacePage.PfsSize];

            Array.Copy(pageFreeSpacePage.Data, PageFreeSpacePage.PfsOffset, pfsData, 0, PageFreeSpacePage.PfsSize);

            foreach (var pfsByte in pfsData)
            {
                pageFreeSpacePage.PfsBytes.Add(PfsByteParser.Parse(pfsByte));
            }
        }
    }
}