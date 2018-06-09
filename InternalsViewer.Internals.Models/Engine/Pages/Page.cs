using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Compression;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Internals.Models.Marking;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// Page
    /// </summary>
    public class Page : Markable
    {
        public const int Size = 8192;

        public CompressionType CompressionType { get; set; }

        public DatabaseContainer DatabaseContainer { get; set; }

        public PageAddress PageAddress { get; set; }

        public byte[] Data { get; set; }

        public Header Header { get; set; }

        public List<ushort> OffsetTable { get; } = new List<ushort>();

        public CompressionInformation CompressionInformation { get; set; }
    }
}
