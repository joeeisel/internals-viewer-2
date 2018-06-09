using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.BlobPointers
{
    /// <summary>
    /// Row Overflow field
    /// </summary>
    public class OverflowField : BlobField
    {
        public const int ChildOffset = 12;
        public const int LevelOffset = 2;
        public const int TimestampOffset = 6;
        public const int UnusedOffset = 3;
        public const int UpdateSeqOffset = 4;

        /// <summary>
        /// Gets or sets the B-Tree level.
        /// </summary>
        /// <value>The level.</value>
        [MarkerStyle(MarkerStyleType.Level)]
        public byte Level { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [MarkerStyle(MarkerStyleType.OverflowLength)]
        public int Length { get; set; }

        [MarkerStyle(MarkerStyleType.Unused)]
        public byte Unused { get; set; }

        /// <summary>
        /// Gets or sets the update seq (used by optomistic concurrency control for cursors)
        /// </summary>
        /// <value>The update seq.</value>
        [MarkerStyle(MarkerStyleType.UpdateSeq)]
        public short UpdateSeq { get; set; }
    }
}
