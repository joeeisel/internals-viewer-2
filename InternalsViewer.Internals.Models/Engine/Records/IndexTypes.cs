using System;

namespace InternalsViewer.Internals.Models.Engine.Records
{
    [Flags]
    public enum IndexType
    {
        Heap = 1,
        Clustered = 2,
        NonClustered = 4,
        Leaf = 8,
        Node = 16,
        TableClustered = 32,
        NonClusteredLeaf = NonClustered | Leaf
    }
}