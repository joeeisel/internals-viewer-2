using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.BlobPointers
{
    public class RootField : BlobField
    {
        public const int ChildOffset = 12;
        public const short LevelOffset = 2;
        public const int TimestampOffset = 6;
        public const int UnusedOffset = 3;
        public const int UpdateSeqOffset = 4;

        [MarkerStyle(MarkerStyleType.SlotCount)]
        public int SlotCount { get; set; }

        [MarkerStyle(MarkerStyleType.Level)]
        public byte Level { get; set; }

        [MarkerStyle(MarkerStyleType.Unused)]
        public byte Unused { get; set; }

        [MarkerStyle(MarkerStyleType.UpdateSeq)]
        public short UpdateSeq { get; set; }
    }
}
