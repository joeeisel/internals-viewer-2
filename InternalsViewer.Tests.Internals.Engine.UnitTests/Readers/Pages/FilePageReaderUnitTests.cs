using System.Linq;
using InternalsViewer.Internals.Engine.Readers.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Readers.Pages
{
    [TestClass]
    public class FilePageReaderUnitTests
    {
        [TestMethod]
        public void Can_Read_Page()
        {
            var reader = new FilePageReader();

            var page = reader.Read(@".\TestPages\Records\SimpleHeapNullablePage1.txt");

            Assert.IsNotNull(page);
            Assert.IsNotNull(page.Data);

            Assert.AreEqual(0x01, page.Data[0]);
            Assert.AreEqual(0x11, page.Data[8191]);
        }
    }
}
