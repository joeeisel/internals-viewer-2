using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Records.Index
{
    public class IndexRecord : Record
    {
        /// <summary>
        /// Gets or sets down page pointer to the next page in the index
        /// </summary>
        [MarkerStyle(MarkerStyleType.DownPagePointer)]
        public PageAddress DownPagePointer { get; set; }

        /// <summary>
        /// Gets or sets the RID (Row Identifier) the index is pointing to
        /// </summary>
        [MarkerStyle(MarkerStyleType.Rid)]
        public RowIdentifier Rid { get; set; }

        public IndexType IndexType { get; set; }

        public bool IncludeKey { get; set; }
    }
}
