using System.Collections.Generic;

namespace InternalsViewer.Internals.Models.Metadata
{
    public class Database
    {
        public int DatabaseId { get; set; }

        public string Name { get; set; }

        public byte CompatabilityLevel { get; set; }

        public List<File> Files { get; set; } = new List<File>();
    }
}