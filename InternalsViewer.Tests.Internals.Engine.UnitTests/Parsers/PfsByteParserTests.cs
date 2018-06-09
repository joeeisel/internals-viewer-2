using InternalsViewer.Internals.Engine.Parsers;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Parsers
{
    [TestClass]
    public class PfsByteParserTests
    {
        [TestMethod]
        public void Can_Parse_Pfs_Byte_UnAllocated_ZeroPercent_Mixed()
        {
            var pfsValue = 0x20;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // 0x20 MIXED_EXT   0_PCT_FULL
            Assert.AreEqual(false, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.Empty, pfsByte.PageSpaceFree);
            Assert.AreEqual(true, pfsByte.Mixed);
            Assert.AreEqual(false, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_Allocated_OneHundredPercent()
        {
            var pfsValue = 0x44;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // ALLOCATED 100_PCT_FULL
            Assert.AreEqual(true, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.OneHundredPercent, pfsByte.PageSpaceFree);
            Assert.AreEqual(false, pfsByte.Mixed);
            Assert.AreEqual(false, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_Allocated_ZeroPercent()
        {
            var pfsValue = 0x40;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            //0x40 ALLOCATED   0_PCT_FULL
            Assert.AreEqual(true, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.Empty, pfsByte.PageSpaceFree);
            Assert.AreEqual(false, pfsByte.Mixed);
            Assert.AreEqual(false, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_UnAllocated_ZeroPercent()
        {
            var pfsValue = 0x0;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // 0x0   0_PCT_FULL
            Assert.AreEqual(false, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.Empty, pfsByte.PageSpaceFree);
            Assert.AreEqual(false, pfsByte.Mixed);
            Assert.AreEqual(false, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_Allocated_ZeroPercent_Mixed()
        {
            var pfsValue = 0x60;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // 0x60 MIXED_EXT ALLOCATED   0_PCT_FULL
            Assert.AreEqual(true, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.Empty, pfsByte.PageSpaceFree);
            Assert.AreEqual(true, pfsByte.Mixed);
            Assert.AreEqual(false, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_Allocated_FiftyPercent_Mixed()
        {
            var pfsValue = 0x61;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // 0x61 MIXED_EXT ALLOCATED  50_PCT_FULL
            Assert.AreEqual(true, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.FiftyPercent, pfsByte.PageSpaceFree);
            Assert.AreEqual(true, pfsByte.Mixed);
            Assert.AreEqual(false, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_Iam_Allocated_ZeroPercent_Mixed()
        {
            var pfsValue = 0x70;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // 0x70 IAM_PG MIXED_EXT ALLOCATED   0_PCT_FULL
            Assert.AreEqual(true, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.Empty, pfsByte.PageSpaceFree);
            Assert.AreEqual(true, pfsByte.Mixed);
            Assert.AreEqual(true, pfsByte.Iam);
        }

        [TestMethod]
        public void Can_Parse_Pfs_Byte_Iam_Allocated_OneHundredPercent_Mixed()
        {
            var pfsValue = 0x74;

            var pfsByte = PfsByteParser.Parse((byte)pfsValue);

            // 0x74 IAM_PG MIXED_EXT ALLOCATED 100_PCT_FULL
            Assert.AreEqual(true, pfsByte.Allocated);
            Assert.AreEqual(SpaceFree.OneHundredPercent, pfsByte.PageSpaceFree);
            Assert.AreEqual(true, pfsByte.Mixed);
            Assert.AreEqual(true, pfsByte.Iam);
        }
    }
}