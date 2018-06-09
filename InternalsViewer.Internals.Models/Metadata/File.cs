using System;

namespace InternalsViewer.Internals.Models.Metadata
{
    public class File
    {
        public int TotalExtents { get; set; }

        public int TotalPages => TotalExtents * 8;

        public int UsedPages => UsedExtents * 8;

        public int UsedExtents { get; set; }

        public float TotalMb => TotalExtents * 64 / 1024F;

        public float UsedMb => UsedExtents * 64 / 1024F;

        public int FileId { get; set; }

        public string FileGroup { get; set; }

        public string FilePath { get; set; }

        public string PhysicalName { get; set; }

        public string FileName => PhysicalName.Substring(PhysicalName.LastIndexOf(@"\", StringComparison.Ordinal) + 1);

        public int Size { get; set; }
    }
}
