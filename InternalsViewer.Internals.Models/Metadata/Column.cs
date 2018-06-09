using System.Data;

namespace InternalsViewer.Internals.Models.Metadata
{
    /// <summary>
    /// DatabaseContainer Index or Table column
    /// </summary>
    public class Column
    {
        public bool Uniqueifer { get; set; }

        public string ColumnName { get; set; }

        public int ColumnId { get; set; }

        public SqlDbType DataType { get; set; }

        public short DataLength { get; set; } = 0;

        public short LeafOffset { get; set; }

        public byte Precision { get; set; }

        public byte Scale { get; set; }

        public bool Dropped { get; set; }

        public bool Sparse { get; set; }

        public short NullBit { get; set; }

        public override string ToString()
        {
            return string.Format("Column: {0,-40} Column ID: {1,-5} Data Type: {2,-20} Data Length: {3, -5} Leaf Offset {4,-5} Precision {5,-5} Scale {6,-5}",
                                 ColumnName,
                                 ColumnId,
                                 DataType,
                                 DataLength,
                                 LeafOffset,
                                 Precision,
                                 Scale);
        }
    }
}
