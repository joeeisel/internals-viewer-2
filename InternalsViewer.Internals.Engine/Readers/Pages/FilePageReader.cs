using System.Data;
using System.IO;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Readers.Pages
{
    public class FilePageReader: TextPageReader
    {
        public new RawPage Read(string path)
        {
            var value = File.ReadAllText(path);

            return base.Read(value);
        }
    }
}
