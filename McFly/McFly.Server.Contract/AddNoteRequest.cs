// ***********************************************************************
// Assembly         : McFly.Server.Contract
// Author           : @tysmithnet
// Created          : 03-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="AddNoteRequest.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Contract
{
    /// <summary>
    ///     Class AddNoteRequest.
    /// </summary>
    /// <seealso cref="System.IEquatable{McFly.Server.Contract.AddNoteRequest}" />
    public class AddNoteRequest : IEquatable<AddNoteRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddNoteRequest" /> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="threadIds">The thread ids.</param>
        /// <param name="text">The text.</param>
        /// <exception cref="ArgumentNullException">threadIds</exception>
        public AddNoteRequest(Position position, IEnumerable<int> threadIds, string text)
        {
            Position = position;
            ThreadIds = threadIds ?? throw new ArgumentNullException(nameof(threadIds));
            Text = text;
        }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        ///     Gets or sets the thread ids.
        /// </summary>
        /// <value>The thread ids.</value>
        public IEnumerable<int> ThreadIds { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(AddNoteRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Position, other.Position) && ThreadIds.SequenceEqual(other.ThreadIds) &&
                   string.Equals(Text, other.Text);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AddNoteRequest) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Position != null ? Position.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ ThreadIds.GetHashCode();
                hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(AddNoteRequest left, AddNoteRequest right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(AddNoteRequest left, AddNoteRequest right)
        {
            return !Equals(left, right);
        }
    }
}