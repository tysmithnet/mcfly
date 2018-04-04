// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="AddNoteOptions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace McFly
{
    /// <summary>
    /// Class AddNoteOptions.
    /// </summary>
    internal class AddNoteOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is all threads at position.
        /// </summary>
        /// <value><c>true</c> if this instance is all threads at position; otherwise, <c>false</c>.</value>
        public bool IsAllThreadsAtPosition { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Text { get; set; }
    }
}