// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-25-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-24-2018
// ***********************************************************************
// <copyright file="Position.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace McFly.Core
{
    /// <summary>
    ///     Class Position.
    /// </summary>
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IComparable{McFly.Core.Position}" />
    /// <seealso cref="System.IEquatable{McFly.Core.Position}" />
    [DebuggerDisplay("{_high:X}:{_low:X}")]
    public class Position : IComparable<Position>, IEquatable<Position>, IComparable
    {
        /// <summary>
        ///     The high portion of the position, e.g. abc:123 =&gt; abc
        /// </summary>
        private int _high;

        /// <summary>
        ///     The low portion of the position, e.g. abc:123 =&gt; 123
        /// </summary>
        private int _low;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Position" /> class.
        /// </summary>
        /// <param name="high">The high.</param>
        /// <param name="low">The low.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     high
        ///     or
        ///     low
        /// </exception>
        public Position(int high, int low)
        {
            High = high;
            Low = low;
        }

        /// <summary>
        ///     Gets or sets the high portion.
        /// </summary>
        /// <value>The high portion.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">value</exception>
        public int High
        {
            get => _high;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be at least 0");
                _high = value;
            }
        }

        /// <summary>
        ///     Gets or sets the low portion.
        /// </summary>
        /// <value>The low portion.</value>
        /// <exception cref="ArgumentOutOfRangeException">value</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">value</exception>
        public int Low
        {
            get => _low;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be at least 0");
                _low = value;
            }
        }

        /// <summary>
        ///     Gets a comparator that first compares the high portions and then the low portions only if the high are equal
        /// </summary>
        /// <value>The high low thread identifier comparer.</value>
        public static IEqualityComparer<Position> HighLowComparer { get; } =
            new HighLowEqualityComparer();

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentException">Position</exception>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is Position)) throw new ArgumentException($"Object must be of type {nameof(Position)}");
            return CompareTo((Position) obj);
        }

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(Position other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var highComparison = _high.CompareTo(other._high);
            if (highComparison != 0) return highComparison;
            return _low.CompareTo(other._low);
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise,
        ///     false.
        /// </returns>
        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _high == other._high && _low == other._low;
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{High:X}:{Low:X}";
        }

        /// <summary>
        ///     Parses the specified text into a new Position instance.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Position.</returns>
        /// <exception cref="FormatException">text</exception>
        /// <exception cref="System.FormatException">text</exception>
        public static Position Parse(string text)
        {
            var match = Regex.Match(text, @"^\s*(?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+\s*$)");
            if (!match.Success)
                throw new FormatException($"{nameof(text)} is not a valid format for Position.. must be like 1f0:df");
            return new Position(Convert.ToInt32(match.Groups["hi"].Value, 16),
                Convert.ToInt32(match.Groups["lo"].Value, 16));
        }

        /// <summary>
        ///     Tries the parse.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="outVar">The out variable.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool TryParse(string text, out Position outVar)
        {
            var match = Regex.Match(text, @"^\s*(?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+\s*$)");
            if (!match.Success)
            {
                outVar = null;
                return false;
            }
            outVar = new Position(Convert.ToInt32(match.Groups["hi"].Value, 16),
                Convert.ToInt32(match.Groups["lo"].Value, 16));
            return true;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Position) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _high;
                hashCode = (hashCode * 397) ^ _low;
                return hashCode;
            }
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Position left, Position right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null)) return false;
            if (ReferenceEquals(right, null)) return false;
            return left.Equals(right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        /// <summary>
        ///     Implements the &lt; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(Position left, Position right)
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        ///     Implements the &gt; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(Position left, Position right)
        {
            return left.CompareTo(right) > 0;
        }

        /// <summary>
        ///     Implements the &lt;= operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(Position left, Position right)
        {
            return left.CompareTo(right) <= 0;
        }

        /// <summary>
        ///     Implements the &gt;= operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(Position left, Position right)
        {
            return left.CompareTo(right) >= 0;
        }

        /// <summary>
        ///     Class HighLowThreadIdEqualityComparer. This class cannot be inherited.
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEqualityComparer{McFly.Core.Position}" />
        internal sealed class HighLowEqualityComparer : IEqualityComparer<Position>
        {
            /// <summary>
            ///     Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type T to compare.</param>
            /// <param name="y">The second object of type T to compare.</param>
            /// <returns>true if the specified objects are equal; otherwise, false.</returns>
            public bool Equals(Position x, Position y)
            {
                return x?.Equals(y) ?? y == null;
            }

            /// <summary>
            ///     Returns a hash code for this instance.
            /// </summary>
            /// <param name="obj">The <see cref="T:System.Object"></see> for which a hash code is to be returned.</param>
            /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public int GetHashCode(Position obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}