// ***********************************************************************
// Assembly         : mcfly
// Author           : @tsmithnet
// Created          : 02-19-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IndexOptions.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     Class IndexOptions.
    /// </summary>
    /// <seealso cref="IndexOptions" />
    /// <seealso cref="IndexOptions" />
    public class IndexOptions : IEquatable<IndexOptions>
    {
        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(IndexOptions other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return
                Equals(Start, other.Start) &&
                Equals(End, other.End) &&
                (MemoryRanges?.SequenceEqual(other.MemoryRanges)).GetValueOrDefault(true) &&
                (BreakpointMasks?.SequenceEqual(other.BreakpointMasks)).GetValueOrDefault(true) &&
                (AccessBreakpoints?.SequenceEqual(other.AccessBreakpoints)).GetValueOrDefault(true) &&
                Step == other.Step;
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
            return Equals((IndexOptions) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = MemoryRanges != null ? MemoryRanges.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Start != null ? Start.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (End != null ? End.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (BreakpointMasks != null
                               ? BreakpointMasks.Select(x => x.GetHashCode()).Aggregate((x, y) => x ^ y)
                               : 0);
                hashCode = (hashCode * 397) ^ (AccessBreakpoints != null
                               ? AccessBreakpoints.Select(x => x.GetHashCode()).Aggregate((x, y) => x ^ y)
                               : 0);
                hashCode = (hashCode * 397) ^ Step;
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(IndexOptions left, IndexOptions right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(IndexOptions left, IndexOptions right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Gets or sets the access breakpoints.
        /// </summary>
        /// <value>The access breakpoints.</value>
        public IEnumerable<AccessBreakpoint> AccessBreakpoints { get; set; }

        /// <summary>
        ///     Gets or sets the breakpoint masks.
        /// </summary>
        /// <value>The breakpoint masks.</value>
        public IEnumerable<BreakpointMask> BreakpointMasks { get; set; }

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        /// <value>The end.</value>
        public Position End { get; set; }

        /// <summary>
        ///     Gets or sets the memory ranges.
        /// </summary>
        /// <value>The memory ranges.</value>
        public IEnumerable<MemoryRange> MemoryRanges { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        /// <value>The start.</value>
        public Position Start { get; set; }

        /// <summary>
        ///     Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        public int Step { get; set; }
    }
}