// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-28-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-03-2018
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
    ///     Class Frame.
    /// </summary>
    public class Frame : IComparable<Frame>, IComparable
    {
        public int CompareTo(Frame other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var positionComparison = Comparer<Position>.Default.Compare(Position, other.Position);
            if (positionComparison != 0) return positionComparison;
            return _threadId.CompareTo(other._threadId);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Frame)) throw new ArgumentException($"Object must be of type {nameof(Frame)}");
            return CompareTo((Frame) obj);
        }

        public static bool operator <(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Frame left, Frame right)
        {
            return Comparer<Frame>.Default.Compare(left, right) >= 0;
        }

        private int _threadId;

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
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

        /// <summary>
        ///     Gets or sets the register set.
        /// </summary>
        /// <value>The register set.</value>
        public RegisterSet RegisterSet { get; set; }

        public StackTrace StackTrace { get; set; }

        public DisassemblyLine DisassemblyLine { get; set; }
    }
}