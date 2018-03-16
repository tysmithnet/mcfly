// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-03-2018
//
// Last Modified By : master
// Last Modified On : 03-09-2018
// ***********************************************************************
// <copyright file="PositionsRecord.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     One line of !positions
    /// </summary>
    public sealed class PositionsRecord
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PositionsRecord" /> class.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="position">The position.</param>
        /// <param name="isThreadWithBreak">if set to <c>true</c> [is thread with break].</param>
        /// <exception cref="System.ArgumentNullException">position</exception>
        public PositionsRecord(int threadId, Position position, bool isThreadWithBreak)
        {
            ThreadId = threadId;
            Position = position ?? throw new ArgumentNullException(nameof(position));
            IsThreadWithBreak = isThreadWithBreak;
        }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId { get; internal set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is thread with break.
        /// </summary>
        /// <value><c>true</c> if this instance is thread with break; otherwise, <c>false</c>.</value>
        public bool IsThreadWithBreak { get; internal set; }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Equals(PositionsRecord other)
        {
            return ThreadId == other.ThreadId && Position.Equals(other.Position) &&
                   IsThreadWithBreak == other.IsThreadWithBreak;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is PositionsRecord && Equals((PositionsRecord) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ThreadId;
                hashCode = (hashCode * 397) ^ Position.GetHashCode();
                hashCode = (hashCode * 397) ^ IsThreadWithBreak.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(PositionsRecord left, PositionsRecord right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(PositionsRecord left, PositionsRecord right)
        {
            return !Equals(left, right);
        }
    }
}