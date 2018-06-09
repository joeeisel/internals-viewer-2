using System.Collections.Generic;
using System.Text;
using InternalsViewer.Internals.Models.Engine.Records;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.BlobPointers
{
    /// <summary>
    /// BLOB internal field
    /// </summary>
    public class BlobField : Field
    {
        /// <summary>
        /// Gets or sets the timestamp used by DBCC CHECKTABLE
        /// </summary>
        /// <value>The timestamp.</value>
        [MarkerStyle(MarkerStyleType.Timestamp)]
        public int Timestamp { get; set; }

        public List<BlobChildLink> Links { get; set; }

        [MarkerStyle(MarkerStyleType.Rid)]
        public BlobChildLink[] LinksArray => Links.ToArray();

        public byte[] Data { get; set; }

        /// <summary>
        /// Gets or sets the type of the blob pointer.
        /// </summary>
        [MarkerStyle(MarkerStyleType.PointerType)]
        public BlobFieldType PointerType { get; set; }

        /// <summary>
        /// Gets or sets the offset in the page for this blob field
        /// </summary>
        public int Offset { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Timestamp.ToString());

            foreach (var b in Links)
            {
                sb.AppendLine(b.ToString());
            }

            return sb.ToString();
        }
    }
}
