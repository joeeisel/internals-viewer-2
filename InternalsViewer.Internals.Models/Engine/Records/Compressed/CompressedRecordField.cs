using InternalsViewer.Internals.Models.Marking;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Models.Engine.Records.Compressed
{
    public class CompressedRecordField : RecordField
    {
        public CompressedRecordField(Column column, CompressedDataRecord parentRecord)
            : base(column)
        {
            Record = parentRecord;
        }

        public bool IsNull { get; set; }

        public int AnchorLength { get; set; }

        public RecordField AnchorField { get; set; }

        public CompressedDataRecord Record { get; set; }

        public short SymbolOffset { get; set; }

        public bool PageSymbol { get; set; }

        [MarkerStyle(MarkerStyleType.CompressedValue)]
        public new string Value { get; set; }
    }
}
