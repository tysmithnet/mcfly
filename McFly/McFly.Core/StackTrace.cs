// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-17-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="StackTrace.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly.Core
{
    /// <summary>
    ///     Represents the state of a threads stack at an instance in time during the trace.
    /// </summary>
    /// <seealso cref="System.IEquatable{McFly.Core.StackTrace}" />
    public sealed class StackTrace : IEquatable<StackTrace>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StackTrace" /> class.
        /// </summary>
        /// <param name="stackFrames">The stack frames.</param>
        /// <exception cref="ArgumentNullException">stackFrames</exception>
        public StackTrace(IEnumerable<StackFrame> stackFrames = null)
        {
            StackFrames = stackFrames?.ToList() ?? new List<StackFrame>();
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <inheritdoc />
        public bool Equals(StackTrace other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var bothNull = StackFrames == null && other.StackFrames == null;
            if (bothNull) return true;
            var mixOfNull = Convert.ToBoolean(StackFrames == null) ^ Convert.ToBoolean(other.StackFrames == null);
            if (mixOfNull) return false;

            var diffLength = StackFrames.Count != other.StackFrames.Count;
            if (diffLength) return false;
            for (var i = 0; i < StackFrames.Count; i++)
            {
                var lhs = StackFrames[i];
                var rhs = other.StackFrames[i];
                if (!lhs.Equals(rhs))
                    return false;
            }

            return true;
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
            return obj is StackTrace && Equals((StackTrace) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        /// <inheritdoc />
        public override int GetHashCode()
        {
            return StackFrames != null ? StackFrames.GetHashCode() : 0;
        }

        /// <summary>
        ///     Gets the stack frames.
        /// </summary>
        /// <value>The stack frames.</value>
        public IList<StackFrame> StackFrames { get; }
    }
}