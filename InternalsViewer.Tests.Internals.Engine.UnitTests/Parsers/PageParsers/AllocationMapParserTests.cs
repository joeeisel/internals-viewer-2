using System.Collections.Generic;
using System.Linq;
using InternalsViewer.Internals.Engine.Parsers.PageParsers;
using InternalsViewer.Internals.Engine.Readers.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Parsers.PageParsers
{
    [TestClass]
    public class AllocationMapParserTests
    {
        private static bool IsRangeFalse(IReadOnlyList<bool> data, int from, int to)
        {
            return Enumerable.Range(from, to - from + 1)
                             .Count(index => data[index]) == 0;
        }

        private static bool IsRangeTrue(IReadOnlyList<bool> data, int from, int to)
        {
            return Enumerable.Range(from, to - from + 1)
                             .Count(index => !data[index]) == 0;
        }

        private static int ExtentBit(int extent) => extent / 8;

        [TestMethod]
        public void Can_Parse_Gam()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\GamPage1.txt");

            var result = new AllocationMapParser().Parse(page);

            // DBCC PAGE information:
            //
            // (1:0)   - (1:288)      = ALLOCATED       0   36
            // (1:296) - (1:360)      = NOT ALLOCATED   37  45
            // (1:368) - (1:376)      = ALLOCATED       46  47
            // (1:384) - (1:400)      = NOT ALLOCATED   48  50
            // (1:408) -              = ALLOCATED       51  51
            // (1:416) - (1:440)      = NOT ALLOCATED   52  55
            // (1:448) - (1:512)      = ALLOCATED       56  64
            // (1:520) -              = NOT ALLOCATED   65  65
            // (1:528) -              = ALLOCATED       66  66
            // (1:536) - (1:552)      = NOT ALLOCATED   67  69
            // (1:560) - (1:576)      = ALLOCATED       70  72
            // (1:584) -              = NOT ALLOCATED   73  73
            // (1:592) -              = ALLOCATED       74  74
            // (1:600) - (1:616)      = NOT ALLOCATED   75  77
            // (1:624) - (1:680)      = ALLOCATED       78  85
            // (1:688) - (1:1016)     = NOT ALLOCATED   86  127

            Assert.IsNotNull(result);

            // Compare AllocationMap against the expected DBCC PAGE results

            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 0, 36));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 37, 45));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 46, 47));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 48, 50));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 51, 51));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 52, 55));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 56, 64));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 65, 65));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 66, 66));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 67, 69));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 70, 72));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 73, 73));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 74, 74));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 75, 77));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, 78, 85));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, 86, 127));
        }

        [TestMethod]
        public void Can_Parse_SGam()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\SGamPage1.txt");

            var result = new AllocationMapParser().Parse(page);

            // DBCC PAGE information:
            //
            //(1:0)   - (1:24)       = NOT ALLOCATED
            //(1:32)  - (1:40)       = ALLOCATED
            //(1:48)  - (1:64)       = NOT ALLOCATED
            //(1:72)  - (1:88)       = ALLOCATED
            //(1:96)  - (1:104)      = NOT ALLOCATED
            //(1:112) - (1:120)      = ALLOCATED
            //(1:128) -              = NOT ALLOCATED
            //(1:136) - (1:160)      = ALLOCATED
            //(1:168) - (1:176)      = NOT ALLOCATED
            //(1:184) -              = ALLOCATED
            //(1:192) -              = NOT ALLOCATED
            //(1:200) - (1:208)      = ALLOCATED
            //(1:216) - (1:232)      = NOT ALLOCATED
            //(1:240) -              = ALLOCATED
            //(1:248) - (1:1016)     = NOT ALLOCATED

            Assert.IsNotNull(result);

            // Compare AllocationMap against the expected DBCC PAGE results

            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(0), ExtentBit(24)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(32), ExtentBit(40)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(48), ExtentBit(64)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(72), ExtentBit(88)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(96), ExtentBit(104)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(112), ExtentBit(120)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(128), ExtentBit(128)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(136), ExtentBit(160)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(168), ExtentBit(176)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(184), ExtentBit(184)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(192), ExtentBit(192)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(200), ExtentBit(208)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(216), ExtentBit(232)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(240), ExtentBit(240)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(248), ExtentBit(1016)));
        }

        [TestMethod]
        public void Can_Parse_Bcm()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\BcmPage1.txt");

            //(1:0)        - (1:1016)     = NOT MIN_LOGGED

            var result = new AllocationMapParser().Parse(page);

            Assert.IsNotNull(result);

            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(0), ExtentBit(1016)));
        }

        [TestMethod]
        public void Can_Parse_Dcm()
        {
            var page = new FilePageReader().Read(@".\TestPages\Allocation\DcmPage1.txt");


            // (1:0)   - (1:336)      = CHANGED
            // (1:344) -              = NOT CHANGED
            // (1:352) -              = CHANGED
            // (1:360) -              = NOT CHANGED
            // (1:368) - (1:416)      = CHANGED
            // (1:424) - (1:440)      = NOT CHANGED
            // (1:448) - (1:512)      = CHANGED
            // (1:520) -              = NOT CHANGED
            // (1:528) -              = CHANGED
            // (1:536) - (1:552)      = NOT CHANGED
            // (1:560) - (1:576)      = CHANGED
            // (1:584) -              = NOT CHANGED
            // (1:592) -              = CHANGED
            // (1:600) - (1:616)      = NOT CHANGED
            // (1:624) - (1:680)      = CHANGED
            // (1:688) - (1:1016)     = NOT CHANGED
            var result = new AllocationMapParser().Parse(page);

            Assert.IsNotNull(result);

            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(0), ExtentBit(336)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(344), ExtentBit(344)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(352), ExtentBit(352)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(360), ExtentBit(360)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(368), ExtentBit(416)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(424), ExtentBit(440)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(448), ExtentBit(512)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(520), ExtentBit(520)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(528), ExtentBit(528)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(536), ExtentBit(552)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(560), ExtentBit(576)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(584), ExtentBit(584)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(592), ExtentBit(592)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(600), ExtentBit(616)));
            Assert.IsTrue(IsRangeTrue(result.AllocationMap, ExtentBit(624), ExtentBit(680)));
            Assert.IsTrue(IsRangeFalse(result.AllocationMap, ExtentBit(688), ExtentBit(1016)));
        }
    }
}