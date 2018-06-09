using System;
using InternalsViewer.Internals.Engine.Readers.Headers;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Readers.Pages
{
    /// <summary>
    /// Loads a page from text, e.g. DBCC PAGE output
    /// </summary>
    public class TextPageReader : PageReader
    {
        public RawPage Read(string value)
        {
            var rawPage = new RawPage();

            var header = new Header();

            new TextHeaderReader(value).LoadHeader(header);

            rawPage.Data = ReadData(value);
            rawPage.Header = header;

            return rawPage;
        }

        private static byte[] ReadData(string value)
        {
            var offset = 0;

            var dumpFound = false;

            var data = new byte[Page.Size];

            foreach (var line in value.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (line.StartsWith("OFFSET TABLE"))
                {
                    break;
                }
                if (line.StartsWith(@"Memory Dump @"))
                {
                    dumpFound = true;
                    continue;
                }
                if (dumpFound && !string.IsNullOrWhiteSpace(line))
                {
                    offset = ReadData(line, offset, data);
                }
            }

            return data;
        }
    }
}