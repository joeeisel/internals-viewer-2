using System;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Parsers.PageParsers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class IndexAllocationMapService : IIndexAllocationMapService
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IndexAllocationMapService(IDatabasePageReader pageReader)
        {
            PageReader = pageReader;
        }

        protected IDatabasePageReader PageReader { get; set; }

        public async Task<IndexAllocationMap> GetAllocation(int databaseId, PageAddress pageAddress)
        {
            var allocation = new IndexAllocationMap();

            await BuildAllocationChain(allocation, databaseId, pageAddress);

            return allocation;
        }

        private async Task BuildAllocationChain(IndexAllocationMap allocationMap, int databaseId, PageAddress pageAddress)
        {
            while (true)
            {
                var page = await GetAllocationPage(databaseId, pageAddress);

                if (page.Header.PageType != PageType.Iam)
                {
                    Log.Error($"Page {pageAddress} is not an IAM page");
                    return;
                }

                allocationMap.Pages.Add(page);
                allocationMap.SinglePageSlots.AddRange(page.SinglePageSlots);

                if (page.Header.NextPage != PageAddress.Empty)
                {
                    pageAddress = page.Header.NextPage;
                    continue;
                }

                break;
            }
        }

        private async Task<IndexAllocationMapPage> GetAllocationPage(int databaseId, PageAddress addresss)
        {
            var page = await PageReader.Read(databaseId, addresss);

            var result = new IndexAllocationMapParser().Parse(page);

            return result;
        }
    }
}