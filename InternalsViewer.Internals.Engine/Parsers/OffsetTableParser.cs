using System;
using System.Collections.Generic;

namespace InternalsViewer.Internals.Engine.Parsers
{
    public class OffsetTableParser
    {
        /// <summary>
        /// Load the offset table with a given slot count from the page data
        /// </summary>
        public static List<ushort> Parse(byte[] data, int slotCount)
        {
            var offsetTable = new List<ushort>();

            for (var i = 2; i <= slotCount * 2; i += 2)
            {
                offsetTable.Add(BitConverter.ToUInt16(data, data.Length - i));
            }

            return offsetTable;
        }
    }
}