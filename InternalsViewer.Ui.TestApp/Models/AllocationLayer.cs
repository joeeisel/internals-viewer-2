using System.Collections.Generic;
using System.Collections.ObjectModel;
using InternalsViewer.Internals.Models.Engine.Allocations;

namespace InternalsViewer.Ui.TestApp.Models
{
    public class AllocationLayers
    {
        public ObservableCollection<AllocationMap> Allocations { get; set; } = new ObservableCollection<AllocationMap>();

        public AllocationLayers(IEnumerable<AllocationMap> allocationMaps)
        {
            Allocations.AddRange(allocationMaps);
        }
    }
}
