using System;

namespace InternalsViewer.Internals.Models.Engine.Compression
{
    /// <summary>
    /// Page compression type
    /// </summary>
    [Flags]
    public enum CompressionType : byte
    {
        /// <summary>
        /// No compression (default)
        /// </summary>
        None = 0,
        /// <summary>
        /// Row level compressions
        /// </summary>
        Row = 1,
        /// <summary>
        /// Page level compression
        /// </summary>
        Page = 2
    }
}
