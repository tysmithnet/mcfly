// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 02-28-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
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
    /// <seealso cref="McFly.Core.DomainEntity{McFly.Core.Frame}" />
    /// <seealso cref="System.IComparable{McFly.Core.Frame}" />
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IEquatable{McFly.Core.Frame}" />
    public class
        Frame : DomainEntity<Frame>, IComparable<Frame>
    {
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
        ///     Determines if this instance is value-type equal with another instance.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns><c>true</c> if this instance is value-type equal with the other instance, <c>false</c> otherwise.</returns>
        /// <inheritdoc />
        /// <remarks>Typically this is a field by field equality operation, but does NOT consider the ID</remarks>
        public override bool ValueEquals(Frame other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            var positionEqual = Position.Equals(other.Position);
            if (!positionEqual)
                return false;
            var registerEqual = RegisterSet.Equals(other.RegisterSet);
            if (!registerEqual)
                return false;
            var stackFramesEqual = StackTrace.Equals(other.StackTrace);
            if (!stackFramesEqual)
                return false;
            var threadEqual = ThreadId.Equals(other.ThreadId);
            if (!threadEqual)
                return false;
            var disassemblyLineEqual = DisassemblyLine.Equals(other.DisassemblyLine);
            if (!disassemblyLineEqual)
                return false;
            return true;
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