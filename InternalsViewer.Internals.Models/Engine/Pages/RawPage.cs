using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    public class RawPage
    {
        public byte[] Data { get; set; }

        public Header Header { get; set; }
    }
}