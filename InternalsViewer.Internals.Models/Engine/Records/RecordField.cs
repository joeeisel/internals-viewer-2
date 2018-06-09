using InternalsViewer.Internals.Models.Engine.BlobPointers;
using InternalsViewer.Internals.Models.Marking;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Models.Engine.Records
{
    /// <summary>
    /// Record field
    /// </summary>
    public class RecordField : Field
    {
        public RecordField(Column column)
        {
            Column = column;
        }

        public BlobField BlobInlineRoot { get; set; }

        public Column Column { get; set; }

        public int LeafOffset => Column.LeafOffset;

        public int Length { get; set; }

        public int Offset { get; set; }

        public byte[] Data { get; set; }

        public int VariableOffset { get; set; }

        public bool Compressed { get; set; }

        public bool Sparse { get; set; }

        public string Name => Column.ColumnName;

        [MarkerStyle(MarkerStyleType.Value)]
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("  Offset: {0, -4} Leaf Offset: {1, -4} Length: {2, -4} Field: {3, -30} Data type: {4, -10} Value: {5}",
                                 Offset,
                                 LeafOffset,
                                 Length,
                                 Column.ColumnName,
                                 Column.DataType,
                                 Value);
        }
    }
}
