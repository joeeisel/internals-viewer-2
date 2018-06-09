using System;
using System.Collections.Generic;
using System.Text;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Allocations;
using InternalsViewer.Internals.Models.Engine.Database;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// PFS (Page Free Space) page
    /// </summary>
    public class PageFreeSpacePage : Page
    {
        public const int PfsOffset = 100;
        public const int PfsSize = 8088;

        /// <summary>
        /// Gets or sets the PFS bytes collection.
        /// </summary>
        /// <value>The PFS bytes collection.</value>
        public List<PfsByte> PfsBytes { get; set; } = new List<PfsByte>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (var i = 0; i <= PfsBytes.Count - 1; i++)
            {
                sb.AppendFormat("{0,-14}{1}", new PageAddress(1, i), PfsBytes[i]);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
