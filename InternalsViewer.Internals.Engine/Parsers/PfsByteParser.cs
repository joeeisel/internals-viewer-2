using System.Collections;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Database;

namespace InternalsViewer.Internals.Engine.Parsers
{
    public class PfsByteParser
    {
        public static PfsByte Parse(byte data)
        {
            var pfsByte = new PfsByte();

            var bitArray = new BitArray(new[] { data });

            pfsByte.GhostRecords = bitArray[3];
            pfsByte.Iam = bitArray[4];
            pfsByte.Mixed = bitArray[5];
            pfsByte.Allocated = bitArray[6];

            pfsByte.PageSpaceFree = (SpaceFree)(data & 7);

            return pfsByte;
        }
    }
}