using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Readers.Pages;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Tests.Internals.Engine.UnitTests.Readers.Pages
{
    public class TestFileReader : IDatabasePageReader
    {
        private readonly List<RawPage> pages = new List<RawPage>();

        public TestFileReader(IEnumerable<string> files)
        {
            LoadFiles(files);
        }

        private void LoadFiles(IEnumerable<string> files)
        {
            var reader = new FilePageReader();

            foreach (var file in files)
            {
                pages.Add(reader.Read(file));
            }
        }

        public IDbConnection Connection { get; set; }

        public Task<RawPage> Read(int databaseId, PageAddress pageAddress)
        {
            var page = pages.FirstOrDefault(f => f.Header.PageAddress == pageAddress);

            if (page == null)
            {
                throw new ArgumentException($"No file has been loaded into TestFileReader with the address: {pageAddress}");
            }

            return Task.FromResult(page);
        }
    }
}