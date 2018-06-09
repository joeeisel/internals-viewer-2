using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Records;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Compression
{
    public class Dictionary : Markable
    {
        public int Offset { get; set; }

        public List<DictionaryEntry> DictionaryEntries { get; set; } = new List<DictionaryEntry>();

        [MarkerStyle(MarkerStyleType.EntryCount)]
        public int EntryCount { get; set; }

        public ushort[] EntryOffset { get; set; }

        [MarkerStyle(MarkerStyleType.ColumnOffsetArray)]
        public string EntryOffsetArrayDescription => Record.GetArrayString(EntryOffset);
    }
}
