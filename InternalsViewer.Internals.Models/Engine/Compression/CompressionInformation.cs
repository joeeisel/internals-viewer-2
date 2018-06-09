using System.Collections;
using System.Text;
using InternalsViewer.Internals.Models.Engine.Pages;
using InternalsViewer.Internals.Models.Engine.Records.Compressed;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Compression
{
    public class CompressionInformation: Markable
    {
        public static byte CiSize = 7;
        public static short Offset = 96;

        [MarkerStyle(MarkerStyleType.PageModCount)]
        public short PageModCount { get; set; }

        [MarkerStyle(MarkerStyleType.CiSize)]
        public short Size { get; set; }

        public BitArray StatusBits { get; set; }

        public int SlotOffset { get; set; }

        public Page Page { get; set; }

        [MarkerStyle(MarkerStyleType.StatusBitsA)]
        public string StatusDescription
        {
            get
            {
                var sb = new StringBuilder();

                if (HasAnchorRecord)
                {
                    sb.Append("Has Anchor Record");
                }

                if (HasAnchorRecord && HasDictionary)
                {
                    sb.Append(", ");
                }

                if (HasDictionary)
                {
                    sb.Append("Has Dictionary");
                }

                return sb.ToString();
            }
        }
        public CompressedDataRecord AnchorRecord { get; set; }

        public Dictionary CompressionDictionary { get; set; }

        public bool HasAnchorRecord { get; set; }

        public bool HasDictionary { get; set; }

        [MarkerStyle(MarkerStyleType.CiLength)]
        public short Length { get; set; }
    }
}
