using System.IO;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Readers.Headers
{
    public class FileHeaderReader
    {
        public static Header ReadHeader(string path)
        {
            var pageString = File.ReadAllText(path);

            var reader = new TextHeaderReader(pageString);

            var header = new Header();

            reader.LoadHeader(header);

            return header;
        }
    }
}