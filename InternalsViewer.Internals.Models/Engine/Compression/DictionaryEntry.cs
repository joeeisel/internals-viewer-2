using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Compression
{
    public class DictionaryEntry: Markable
    {
        public DictionaryEntry(byte[] data)
        {
            Data = data;
        }

        [MarkerStyle(MarkerStyleType.Value)]
        public byte[] Data { get; set; }
    }
}
