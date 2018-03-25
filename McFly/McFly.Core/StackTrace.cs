// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-17-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-20-2018
// ***********************************************************************
// <copyright file="StackTrace.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace McFly.Core
{
    /// <summary>
    ///     Represents the state of a threads stack at an instance in time during the trace.
    /// </summary>
    public class StackTrace
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StackTrace" /> class.
        /// </summary>
        /// <param name="stackFrames">The stack frames.</param>
        /// <exception cref="ArgumentNullException">stackFrames</exception>
        public StackTrace(IEnumerable<StackFrame> stackFrames)
        {
            StackFrames = stackFrames?.ToList() ?? throw new ArgumentNullException(nameof(stackFrames));
            NumFrames = StackFrames.Count();
        }

        /// <summary>
        ///     Gets the stack frames.
        /// </summary>
        /// <value>The stack frames.</value>
        public IEnumerable<StackFrame> StackFrames { get; internal set; }

        /// <summary>
        ///     Gets the number frames.
        /// </summary>
        /// <value>The number frames.</value>
        public int NumFrames { get; internal set; }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool Equals(StackTrace other)
        {
            return StackFrames.SequenceEqual(other.StackFrames);
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
            return Equals((StackTrace) obj);
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
                var hashCode = 455627;
                hashCode = (hashCode * 397) ^ (StackFrames != null
                               ? StackFrames.Select(x => x.GetHashCode())
                                   .Aggregate((l, r) => l.GetHashCode() ^ r.GetHashCode())
                               : 0);
                hashCode = (hashCode * 397) ^ NumFrames;
                return hashCode;
            }
        }
    }
}