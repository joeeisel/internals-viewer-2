using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <inheritdoc />
    /// <summary>
    /// Boot Page
    /// </summary>
    public class BootPage : Page
    {
        public const int CheckpointLsnOffset = 444;

        /// <summary>
        /// Gets or sets the last checkpoint LSN.
        /// </summary>
        public LogSequenceNumber CheckpointLsn { get; set; }
    }
}
