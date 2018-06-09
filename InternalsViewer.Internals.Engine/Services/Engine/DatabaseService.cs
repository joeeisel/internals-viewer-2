using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Interfaces.Services.Engine;
using InternalsViewer.Internals.Engine.Interfaces.Services.Metadata;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Database;

namespace InternalsViewer.Internals.Engine.Services.Engine
{
    public class DatabaseService : IDatabaseService
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Service responsible for loading a DatabaseContainer, with metadata, allocation bitmaps (GAM, SGAM, DCM, BCM) and the PFS
        /// </summary>
        public DatabaseService(IMetadataService metadataService,
                               IAllocationService allocationService,
                               IPageFreeSpaceService pageFreeSpaceService,
                               IIndexAllocationMapService indexAllocationMapService)
        {
            MetadataService = metadataService;
            AllocationService = allocationService;
            PageFreeSpaceService = pageFreeSpaceService;
            IndexAllocationMapService = indexAllocationMapService;
        }

        protected IMetadataService MetadataService { get; set; }

        protected IAllocationService AllocationService { get; set; }

        protected IPageFreeSpaceService PageFreeSpaceService { get; set; }

        protected IIndexAllocationMapService IndexAllocationMapService { get; set; }

        public async Task<DatabaseContainer> GetDatabase(string databaseName)
        {
            var databaseInfo = await MetadataService.GetDatabase(databaseName);

            var database = new DatabaseContainer
            {
                DatabaseId = databaseInfo.DatabaseId,
                Files = databaseInfo.Files,
                CompatibilityLevel = databaseInfo.CompatabilityLevel,
                AllocationUnits = await MetadataService.GetAllocationUnits()
            };

            await LoadAllocations(database);

            await LoadPfs(database);

            await LoadIndexAllocationMaps(database);

            return database;
        }

        public async Task LoadAllocations(DatabaseContainer database)
        {
            Log.Debug($"Getting allocations");

            foreach (var file in database.Files)
            {
                Log.Debug($"Getting allocations for File: {file.FileId} - {file.FileName}");

                var fileSize = file.Size;

                Log.Debug($"Loading GAM");
                var gam = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 2), fileSize);
                database.Gam.Add(file.FileId, gam);

                Log.Debug($"Loading SGAM");

                var sGam = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 3), fileSize);
                database.SGam.Add(file.FileId, sGam);

                Log.Debug($"Loading DCM");
                var dcm = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 6), fileSize);
                database.Dcm.Add(file.FileId, dcm);

                Log.Debug($"Loading BCM");
                var bcm = await AllocationService.GetAllocation(database.DatabaseId, new PageAddress(file.FileId, 7), fileSize);
                database.Bcm.Add(file.FileId, bcm);
            }
        }

        public async Task LoadPfs(DatabaseContainer database)
        {
            Log.Debug($"Getting PFS");

            foreach (var file in database.Files)
            {
                Log.Debug($"Getting allocations for File: {file.FileId} - {file.FileName}");

                var pfs = await PageFreeSpaceService.GetPfs(database.DatabaseId, file.Size, file.FileId);

                database.Pfs.Add(file.FileId, pfs);
            }
        }

        public async Task LoadIndexAllocationMaps(DatabaseContainer container)
        {
            Log.Debug($"Getting IAMs");

            foreach (var allocationUnit in container.AllocationUnits.Where(p => p.FirstIamPage != PageAddress.Empty))
            {
                Log.DebugFormat("Getting IAM for Allocation Unit {0} - {1}.{2}.{3}",
                                allocationUnit.AllocationUnitId,
                                allocationUnit.SchemaName,
                                allocationUnit.TableName,
                                allocationUnit.IndexName);

                var iam = await IndexAllocationMapService.GetAllocation(container.DatabaseId,
                                                                        allocationUnit.FirstIamPage);

                container.IndexAllocationMaps.Add(allocationUnit.AllocationUnitId, iam);
            }
        }
    }
}