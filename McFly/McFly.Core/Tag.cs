// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-01-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
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
    /// <seealso cref="System.IEquatable{McFly.Core.Tag}" />
    public sealed class Tag : IEquatable<Tag>
    {
        /// <summary>
        ///     Determines whether the specified &lt;see cref="System.Object" /&gt; is equal to this instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <inheritdoc />
        public bool Equals(Tag other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TagId == other.TagId;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Tag tag && Equals(tag);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        /// <inheritdoc />
        public override int GetHashCode()
        {
            return TagId.GetHashCode();
        }

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
        ///     Gets or sets the tag identifier.
        /// </summary>
        /// <value>The tag identifier.</value>
        public long TagId { get; set; }

        /// <summary>
        ///     Gets or sets the title of this tag
        /// </summary>
        /// <value>The text.</value>
        public string Title { get; set; }
    }
}