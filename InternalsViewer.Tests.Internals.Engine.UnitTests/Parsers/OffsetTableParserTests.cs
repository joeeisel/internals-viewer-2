using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Parsers;
using InternalsViewer.Internals.Engine.Readers.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Parsers
{
    [TestClass]
    public class OffsetTableParserTests
    {
        [TestMethod]
        public void Can_Parse_Offset_Table()
        {
            var reader = new FilePageReader();

            var page = reader.Read(@".\TestPages\Records\SimpleHeapNullablePage1.txt");

            var result = OffsetTableParser.Parse(page.Data, page.Header.SlotCount);

            Assert.AreEqual(page.Header.SlotCount, result.Count);

            Assert.AreEqual(0x17fa, result[10]);
            Assert.AreEqual(0x175a, result[9]);
            Assert.AreEqual(0x16ba, result[8]);
            Assert.AreEqual(0x1616, result[7]);
            Assert.AreEqual(0x1576, result[6]);
            Assert.AreEqual(0x14bb, result[5]);
            Assert.AreEqual(0x1419, result[4]);
            Assert.AreEqual(0x137a, result[3]);
            Assert.AreEqual(0x12d6, result[2]);
            Assert.AreEqual(0x1233, result[1]);
            Assert.AreEqual(0x1194, result[0]);
        }
    }
}
