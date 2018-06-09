using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Services.Engine;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Tests.Internals.Engine.UnitTests.Readers.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Services.Engine
{
    [TestClass]
    public class AllocationServiceTests
    {
        [TestMethod]
        public async Task Can_Get_Allocation()
        {
            var pageReader = new TestFileReader(new []
            {
                @".\TestPages\Allocation\GamPage1.txt"
            });

            var service = new AllocationService(pageReader);

            var result = await service.GetAllocation(1, new PageAddress(1, 2), 1024);

            Assert.IsNotNull(result);
        }
    }
}
