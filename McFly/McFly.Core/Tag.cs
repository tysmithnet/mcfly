// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="Tag.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace McFly.Core
{
    /// <summary>
    ///     Represents a piece of information associated with a thread/position
    ///     in the trace
    /// </summary>
    public sealed class Tag
    {
        /// <summary>
        ///     Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        public string Body { get; set; }

        /// <summary>
        ///     Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime CreateDateUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     Gets or sets the title of this tag
        /// </summary>
        /// <value>The text.</value>
        public string Title { get; set; }
    }
}