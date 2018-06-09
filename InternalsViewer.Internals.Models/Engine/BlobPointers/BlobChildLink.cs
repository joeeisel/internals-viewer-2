using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.BlobPointers
{
    public class BlobChildLink : Markable
    {
        public BlobChildLink()
        {
        }

        public BlobChildLink(RowIdentifier rowIdentifier, int offset, int length)
        {
            RowIdentifier = rowIdentifier;
            Offset = offset;
            Length = length;
        }

        [MarkerStyle(MarkerStyleType.Rid)]
        public RowIdentifier RowIdentifier { get; set; }

        [MarkerStyle(MarkerStyleType.BlobChildOffset)]
        public int Offset { get; set; }

        [MarkerStyle(MarkerStyleType.BlobChildLength)]
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Page: {RowIdentifier} Offset: {Offset} Length: {Length}";
        }
    }
}
