﻿// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 02-19-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-05-2018
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

namespace McFly.WinDbg
{
    /// <summary>
    ///     Options for the index method
    /// </summary>
    /// <seealso cref="System.IEquatable{McFly.WinDbg.IndexOptions}" />
    /// <seealso cref="IndexOptions" />
    /// <seealso cref="IndexOptions" />
    internal class IndexOptions : IEquatable<IndexOptions>
    {
        /// <summary>
        ///     Determines whether the specified <see cref="IndexOptions" /> is equal to this instance.
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
                var hashCode = 135135;
                if (Start != null)
                    hashCode ^= Start.GetHashCode() * 3515;
                if (End != null)
                    hashCode = End.GetHashCode() * 34344;
                if (MemoryRanges != null)
                {
                    foreach (var range in MemoryRanges)
                    {
                        hashCode ^= range.GetHashCode();
                    }
                }

                if (AccessBreakpoints != null)
                {
                    foreach (var accessBreakpoint in AccessBreakpoints)
                    {
                        hashCode ^= accessBreakpoint.GetHashCode();
                    }
                }

                if (BreakpointMasks != null)
                {
                    foreach (var breakpointMask in BreakpointMasks)
                    {
                        hashCode ^= breakpointMask.GetHashCode();
                    }
                }

                hashCode ^= Step * (IsAllPositionsInRange ? 13513 : 55313);
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
        ///     Gets or sets a value indicating whether this instance is all positions in range.
        /// </summary>
        /// <value><c>true</c> if this instance is all positions in range; otherwise, <c>false</c>.</value>
        public bool IsAllPositionsInRange { get; set; }

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