using System;

namespace InternalsViewer.Internals.Models.Marking
{
    /// <summary>
    /// Custom attribute to store mark style
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MarkerStyleAttribute : Attribute
    {
        public string Description { get; set; }

        public MarkerStyleType MarkerStyleType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerStyleAttribute"/> class.
        /// </summary>
        public MarkerStyleAttribute(MarkerStyleType markerStyleType)
        {
            MarkerStyleType = markerStyleType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerStyleAttribute"/> class.
        /// </summary>
        public MarkerStyleAttribute(MarkerStyleType markerStyleType, string description)
        {
            MarkerStyleType = markerStyleType;
            Description = description;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MarkerStyleAttribute"/> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }
    }
}
