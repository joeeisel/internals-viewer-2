using System;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;
using InternalsViewer.Internals.Engine.Parsers.PageParsers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class PageFreeSpaceService : IPageFreeSpaceService
    {
        public PageFreeSpaceService(IDatabasePageReader pageReader)
        {
            PageReader = pageReader;
        }

        protected IDatabasePageReader PageReader { get; set; }

        public async Task<PageFreeSpace> GetPfs(int databaseId, int fileSize, int fileId)
        {
            var pfs = new PageFreeSpace();

            var page = await GetPfsPage(databaseId, new PageAddress(fileId, 1));

            pfs.Pages.Add(page);

            var pfsCount = (int)Math.Ceiling(fileSize / (decimal)PageFreeSpace.Interval);

            if (pfsCount > 1)
            {
                for (var i = 1; i < pfsCount; i++)
                {
                    page = await GetPfsPage(databaseId, new PageAddress(fileId, i * PageFreeSpace.Interval));

                    pfs.Pages.Add(page);
                }
            }

            return pfs;
        }

        private async Task<PageFreeSpacePage> GetPfsPage(int databaseId, PageAddress addresss)
        {
            var page = await PageReader.Read(databaseId, addresss);

            var result = new PfsParser().Parse(page);

            return result;
        }
    }
}
