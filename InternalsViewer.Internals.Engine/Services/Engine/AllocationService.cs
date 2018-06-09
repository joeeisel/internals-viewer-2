using System;
using System.Data;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;
using InternalsViewer.Internals.Engine.Parsers.PageParsers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class AllocationService : IAllocationService
    {
        public AllocationService(IDatabasePageReader pageReader)
        {
            PageReader = pageReader;
        }

        protected IDatabasePageReader PageReader { get; set; }

        public IDbConnection Connection { get; set; }

        public async Task<AllocationMap> GetAllocation(int databaseId, PageAddress pageAddress, int fileSize)
        {
            var allocation = new AllocationMap();

            await BuildAllocationChain(allocation, databaseId, pageAddress, fileSize);

            return allocation;
        }

        /// <summary>
        /// Builds the allocation chain following the GAM interval
        /// </summary>
        private async Task BuildAllocationChain(AllocationMap allocationMap,
                                                int databaseId,
                                                PageAddress pageAddress,
                                                int fileSize)
        {
            var allocationPage = await GetAllocationPage(databaseId, pageAddress);

            if (allocationPage.Header.PageType == PageType.Iam)
            {
                throw new ArgumentException();
            }

            allocationMap.Pages.Add(allocationPage);

            var interval = AllocationMap.Interval;

            var pageCount = (int)Math.Ceiling(fileSize / (decimal)interval);

            if (pageCount > 1)
            {
                for (var i = 1; i < pageCount; i++)
                {
                    var allocationAddress = new PageAddress(pageAddress.FileId, pageAddress.PageId + (i * interval));

                    allocationMap.Pages.Add(await GetAllocationPage(databaseId, allocationAddress));
                }
            }
        }

        private async Task<AllocationMapPage> GetAllocationPage(int databaseId, PageAddress addresss)
        {
            var page = await PageReader.Read(databaseId, addresss);

            var result = new AllocationMapParser().Parse(page);

            return result;
        }
    }
}