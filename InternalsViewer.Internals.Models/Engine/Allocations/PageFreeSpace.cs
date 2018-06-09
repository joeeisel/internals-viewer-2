using System.Collections.Generic;
using InternalsViewer.Internals.Models.Engine.Database;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Models.Engine.Allocations
{
    /// <summary>
    /// The Page Free Space allocation pages
    /// </summary>
    /// <remarks>
    /// This contains the PFS allocation structure. Each page in the database is represented by a <see cref="PfsByte">PFS Byte</see>.
    /// Each PFS page covers 8088 bytes/pages (PfsInterval), then another PFS appears at each interval.
    /// </remarks>
    public class PageFreeSpace
    {
        public const int Interval = 8088;

        public List<PageFreeSpacePage> Pages;

        public PageFreeSpace()
        {
            Pages = new List<PageFreeSpacePage>();
        }

        /// <summary>
        /// Returns a PFS Byte for a given page number
        /// </summary>
        public PfsByte GetPagePfsByte(int page)
        {
            return Pages[page / Interval].PfsBytes[page % Interval];
        }
    }
}
