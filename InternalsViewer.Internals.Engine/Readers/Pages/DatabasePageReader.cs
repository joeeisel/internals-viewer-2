using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using InternalsViewer.Internals.Engine.Interfaces.Readers;
using InternalsViewer.Internals.Engine.Interfaces.Services;
using InternalsViewer.Internals.Engine.Readers.Headers;
using InternalsViewer.Internals.Models.Engine.Address;
using InternalsViewer.Internals.Models.Engine.Pages;

namespace InternalsViewer.Internals.Engine.Readers.Pages
{
    /// <summary>
    /// Reads a page using a database connection with DBCC PAGE
    /// </summary>
    public class DatabasePageReader : PageReader, IDatabasePageReader
    {
        public DatabasePageReader(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        public IDatabaseConnection DatabaseConnection { get; set; }

        public async Task<RawPage> Read(int databaseId, PageAddress pageAddress)
        {
            var connection = DatabaseConnection.GetConnection();

            var pageCommand = string.Format(Properties.Resources.Sql_DatabasePageReader_Page,
                                            databaseId,
                                            pageAddress.FileId,
                                            pageAddress.PageId,
                                            2);
            var offset = 0;
            var data = new byte[Page.Size];

            var headerData = new Dictionary<string, string>();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = new SqlCommand(pageCommand, (SqlConnection)connection)
            {
                CommandType = CommandType.Text
            };

            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    if (reader[0].ToString() == "DATA:" && reader[1].ToString().StartsWith("Memory Dump"))
                    {
                        var currentRow = reader[3].ToString();

                        offset = ReadData(currentRow, offset, data);
                    }
                    else if (reader[0].ToString() == "PAGE HEADER:")
                    {
                        headerData.Add(reader[2].ToString(), reader[3].ToString());
                    }
                }

                reader.Close();
            }

            command.Dispose();
            connection.Close();

            return GetRawPage(data, headerData);
        }

        private static RawPage GetRawPage(byte[] data, IDictionary<string, string> headerData)
        {
            var header = new Header();

            new DictionaryHeaderReader(headerData).LoadHeader(header);

            return new RawPage
            {
                Data = data,
                Header = header
            };
        }
    }
}
