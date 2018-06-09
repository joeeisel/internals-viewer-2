using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Compression;

namespace InternalsViewer.Internals.Models.Engine.Records.Compressed
{
    public class CompressedDataRecord : Record
    {
        public List<CdArrayItem> CdItems { get; } = new List<CdArrayItem>();

        public CdArrayItem[] CdItemsArray => CdItems.ToArray();

        public byte GetCdByte(int columnId)
        {
            return CdItems[columnId / 2].Values[columnId % 2];
        }

        public short CompressedSize { get; set; }
    }
}
