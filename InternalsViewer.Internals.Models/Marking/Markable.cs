using System.Collections.Generic;

namespace InternalsViewer.Internals.Models.Marking
{
    public class Markable
    {
        public List<MarkItem> MarkItems { get; } = new List<MarkItem>();

        public void Mark(string propertyName, int startPosition, int length)
        {
            MarkItems.Add(new MarkItem(propertyName, startPosition, length));
        }

        public void Mark(string propertyName, int startPosition, int length, int index)
        {
            MarkItems.Add(new MarkItem(propertyName, startPosition, length, index));
        }

        public void Mark(string propertyName, string prefix, int startPosition, int length, int index)
        {
            MarkItems.Add(new MarkItem(propertyName, startPosition, length, index));
        }

        public void Mark(string propertyName, string prefix, int index)
        {
            MarkItems.Add(new MarkItem(propertyName, prefix, index));
        }

        public void Mark(string propertyName)
        {
            MarkItems.Add(new MarkItem(propertyName, string.Empty, -1));
        }
    }
}
