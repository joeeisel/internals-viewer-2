using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// Allocation Page containing an allocation bitmap
    /// </summary>
    public class AllocationMapPage : Page
    {
        public const int AllocationArrayOffset = 194;
        public const int ExtentCount = 64000;

        public bool[] AllocationMap { get; } = new bool[ExtentCount];

        public PageAddress StartPage { get; set; }
    }
}
