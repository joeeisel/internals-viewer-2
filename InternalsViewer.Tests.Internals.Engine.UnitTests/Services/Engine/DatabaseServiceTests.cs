using System.Data.SqlClient;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Readers.Pages;
using InternalsViewer.Internals.Engine.Services.Engine;
using InternalsViewer.Internals.Engine.Services.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Services.Engine
{
    [TestClass]
    public class DatabaseServiceTests
    {
        [TestMethod]
        public async Task Can_Load_Test_Database()
        {
            var databaseConnection = new DatabaseConnection();
            databaseConnection.ConnectionString = Properties.Settings.Default.TestDatabaseConnectionString;

            var metadataService = new MetadataService(databaseConnection);
            var pageReader = new DatabasePageReader(databaseConnection);
            var pageFreeSpaceService = new PageFreeSpaceService(pageReader);
            var allocationService = new AllocationService(pageReader);
            var iamService = new IndexAllocationMapService(pageReader);

            var service = new DatabaseService(metadataService, allocationService, pageFreeSpaceService, iamService);

            var result = await service.GetDatabase("InternalsViewerTests");
        }
    }
}