using System;
using InternalsViewer.Internals.Models.Engine.Address;

namespace InternalsViewer.Internals.Models.Engine.Pages
{
    /// <summary>
    /// Event data for page related events
    /// </summary>
    public class PageEventArgs : EventArgs
    {
        private RowIdentifier rowId;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageEventArgs"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="openInNewWindow">if set to <c>true</c> [open in new window].</param>
        public PageEventArgs(RowIdentifier address, bool openInNewWindow)
        {
            RowId = address;
            OpenInNewWindow = openInNewWindow;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event triggers a new window to be opened
        /// </summary>
        public bool OpenInNewWindow { get; set; }

        public RowIdentifier RowId
        {
            get => rowId;
            set => rowId = value;
        }

        public PageAddress Address
        {
            get => rowId.PageAddress;
            set => rowId.PageAddress = value;
        }
    }
}
