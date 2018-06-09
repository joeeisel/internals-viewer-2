using System.Linq;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Services.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Services.Engine
{
    [TestClass]
    public class ServerServiceUnitTests
    {
        public static ServerService CreateService()
        {
            var databaseConnection = new DatabaseConnection();
            databaseConnection.ConnectionString = Properties.Settings.Default.TestDatabaseConnectionString;

            var service = new ServerService(databaseConnection);

            return service;
        }

        [TestMethod]
        public async Task Can_Get_Databases()
        {
            var service = CreateService();

            var result = await service.GetDatabases();

            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Contains("master"));
            Assert.IsTrue(result.Contains("InternalsViewerTests"));
        }
    }
}