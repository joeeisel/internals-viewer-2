using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InternalsViewer.Ui.TestApp.Helpers.Extensions
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }
    }
}
