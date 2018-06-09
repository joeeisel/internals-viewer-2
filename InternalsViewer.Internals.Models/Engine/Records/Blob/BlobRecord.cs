using System;
using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.BlobPointers;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Records.Blob
{
    public class BlobRecord : Record
    {
        public const short CurLinksOffset = 16;
        public const short DataOffset = 14;
        public const short IdOffset = 4;
        public const short InternalChildOffset = 20;
        public const short LengthOffset = 2;
        public const short MaxLinksOffset = 14;
        public const short RootChildOffset = 24;
        public const short RootLevelOffset = 18;
        public const short SmallDataOffset = 20;
        public const short SmallSizeOffset = 14;
        public const short TypeOffset = 12;

        [MarkerStyle(MarkerStyleType.StatusBitsA)]
        public new string StatusBitsADescription => "TODO";

        [MarkerStyle(MarkerStyleType.StatusBitsB)]
        public string StatusBitsBDescription => string.Empty;

        [MarkerStyle(MarkerStyleType.BlobId)]
        public long BlobId { get; set; }

        [MarkerStyle(MarkerStyleType.BlobLength)]
        public int Length { get; set; }

        public BlobType BlobType { get; set; }

        [MarkerStyle(MarkerStyleType.BlobType)]
        public string BlobTypeDescription => BlobType.ToString();

        [MarkerStyle(MarkerStyleType.MaxLinks)]
        public int MaxLinks { get; set; }

        [MarkerStyle(MarkerStyleType.CurrentLinks)]
        public int CurLinks { get; set; }

        [MarkerStyle(MarkerStyleType.Level)]
        public short Level { get; set; }

        [MarkerStyle(MarkerStyleType.BlobSize)]
        public short Size { get; set; }

        [MarkerStyle(MarkerStyleType.BlobData)]
        public byte[] Data { get; set; }

        public List<BlobChildLink> BlobChildren { get; set; }

        public BlobChildLink[] BlobChildrenArray => BlobChildren.ToArray();

        internal static string GetRecordType(RecordType recordType)
        {
            throw new NotImplementedException();
        }
    }
}
