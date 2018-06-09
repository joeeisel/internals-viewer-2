using InternalsViewer.Internals.Models.Engine.Records.Data;
using InternalsViewer.Internals.Models.Marking;
using InternalsViewer.Internals.Models.Metadata;

namespace InternalsViewer.Internals.Models.Engine.Records
{
    public class SparseVector: Markable
    {
        public const int ColCountOffset = 2;
        public const int ColumnsOffset = 4;

        public static string GetComplexHeaderDescription(short complexVector)
        {
            switch (complexVector)
            {
                case 5:
                    return "In row sparse vector";
                default:
                    return "Unknown";
            }
        }

        internal TableStructure HobtStructure { get; set; }

        public byte[] Data { get; set; }

        internal DataRecord ParentRecord { get; set; }

        public ushort[] Columns { get; set; }

        [MarkerStyle(MarkerStyleType.SparseColumns)]
        public string ColumnsDescription => Record.GetArrayString(Columns);

        [MarkerStyle(MarkerStyleType.SparseColumnOffsets)]
        public string OffsetsDescription => Record.GetArrayString(Offset);

        public ushort[] Offset { get; set; }

        [MarkerStyle(MarkerStyleType.SparseColumnCount)]
        public short ColCount { get; set; }

        public short RecordOffset { get; set; }

        public short ComplexHeader { get; set; }

        [MarkerStyle(MarkerStyleType.ComplexHeader)]
        public string ComplexHeaderDescription => GetComplexHeaderDescription(ComplexHeader);
    }
}
