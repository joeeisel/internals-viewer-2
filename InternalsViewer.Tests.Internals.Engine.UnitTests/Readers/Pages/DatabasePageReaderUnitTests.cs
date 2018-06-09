using System.Data.SqlClient;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Readers.Pages;
using InternalsViewer.Internals.Engine.Services.Engine;
using InternalsViewer.Internals.Models.Engine.Address;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Readers.Pages
{
    [TestClass]
    public class DatabasePageReaderUnitTests
    {
        [TestMethod]
        public async Task Can_Read_Page()
        {
            var databaseConnection = new DatabaseConnection();
            databaseConnection.ConnectionString = Properties.Settings.Default.TestDatabaseConnectionString;

            var reader = new DatabasePageReader(databaseConnection);

            var page = await reader.Read(11, new PageAddress(1, 632));

            Assert.IsNotNull(page);
            Assert.IsNotNull(page.Data);

            Assert.AreEqual(0x01, page.Data[0]);
            Assert.AreEqual(0x11, page.Data[8191]);
        }
    }
}