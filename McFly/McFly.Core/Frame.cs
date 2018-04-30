// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-28-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="Frame.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace McFly.Core
{
    /// <summary>
    ///     Represents an instance in time for a thread in the trace file
    ///     Imagine you took a time slice of the process at an exact moment of time
    ///     and you will understand what this class represents
    /// </summary>
    /// <seealso cref="System.IComparable{McFly.Core.Frame}" />
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IEquatable{McFly.Core.Frame}" />
    public class
        Frame : IComparable<Frame>, IComparable,
            IEquatable<Frame> // todo: this doesn't seem like a value type.. shoudl be (position, thread) == (position, thread)
    {
        public Guid Id { get; set; } // todo: lock down?

        /// <summary>
        ///     The thread identifier
        /// </summary>
        private int _threadId;

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentException">Frame</exception>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Frame)) throw new ArgumentException($"Object must be of type {nameof(Frame)}");
            return CompareTo((Frame) obj);
        }

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(Frame other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var positionComparison = Comparer<Position>.Default.Compare(Position, other.Position);
            if (positionComparison != 0) return positionComparison;
            return _threadId.CompareTo(other._threadId);
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Equals(Frame other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _threadId == other._threadId && Equals(Position, other.Position) &&
                   Equals(RegisterSet, other.RegisterSet) && Equals(StackTrace, other.StackTrace) &&
                   Equals(DisassemblyLine, other.DisassemblyLine);
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
            return Equals((Frame) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _threadId;
                hashCode = (hashCode * 397) ^ (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RegisterSet != null ? RegisterSet.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StackTrace != null ? StackTrace.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DisassemblyLine != null ? DisassemblyLine.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Frame left, Frame right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the &gt; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) > 0;
        }

        /// <summary>
        ///     Implements the &gt;= operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) >= 0;
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Frame left, Frame right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Implements the &lt; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) < 0;
        }

        /// <summary>
        ///     Implements the &lt;= operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) <= 0;
        }

        /// <summary>
        ///     Gets or sets the disassembly line.
        /// </summary>
        /// <value>The disassembly line.</value>
        public DisassemblyLine DisassemblyLine { get; set; } = new DisassemblyLine();

        /// <summary>
        ///     Gets or sets the position for this frame in the context of the trace
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        ///     Gets or sets the register set.
        /// </summary>
        /// <value>The register set.</value>
        public RegisterSet RegisterSet { get; set; } = new RegisterSet();

        /// <summary>
        ///     Gets or sets the stack trace.
        /// </summary>
        /// <value>The stack trace.</value>
        public StackTrace StackTrace { get; set; } = new StackTrace();

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        public int ThreadId
        {
            get => _threadId;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be at least 0");
                _threadId = value;
            }
        }
    }
}