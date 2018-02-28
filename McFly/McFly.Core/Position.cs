using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace McFly.Core
{
    [DebuggerDisplay("{_high}:{_low}")]
    public class Position : IComparable<Position>, IEquatable<Position>
    {
        private uint _high;
        private uint _low;

        public Position(uint high, uint low, uint? threadId = null)
        {
            _high = high;
            _low = low;
            ThreadId = threadId;
        }

        public uint? ThreadId { get; } // todo: make set?

        public uint High
        {
            get => _high;
            set
            {
                if (value < _low)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be at least Low");
                _high = value;
            }
        }

        public uint Low
        {
            get => _low;
            set
            {
                if (value > _high)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be at least High");
                _low = value;
            }
        }

        public static IEqualityComparer<Position> HighLowThreadIdComparer { get; } =
            new HighLowThreadIdEqualityComparer();

        public int CompareTo(Position other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var highComparison = _high.CompareTo(other._high);
            if (highComparison != 0) return highComparison;
            var lowComparison = _low.CompareTo(other._low);
            if (lowComparison != 0) return lowComparison;
            return Nullable.Compare(ThreadId, other.ThreadId);
        }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _high == other._high && _low == other._low && ThreadId == other.ThreadId;
        }

        public override string ToString()
        {
            return $"{High}:{Low}";
        }

        public static Position Parse(string text)
        {
            var match = Regex.Match(text, @"^\s*(?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+\s*$)");
            if (!match.Success)
                throw new FormatException($"{nameof(text)} is not a valid format for Position.. must be like 1f0:df");
            return new Position(Convert.ToUInt32(match.Groups["hi"].Value, 16),
                Convert.ToUInt32(match.Groups["lo"].Value, 16), null);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) _high;
                hashCode = (hashCode * 397) ^ (int) _low;
                hashCode = (hashCode * 397) ^ ThreadId.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public static bool operator <(Position left, Position right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Position left, Position right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Position left, Position right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Position left, Position right)
        {
            return left.CompareTo(right) >= 0;
        }

        private sealed class HighLowThreadIdEqualityComparer : IEqualityComparer<Position>
        {
            public bool Equals(Position x, Position y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._high == y._high && x._low == y._low && x.ThreadId == y.ThreadId;
            }

            public int GetHashCode(Position obj)
            {
                unchecked
                {
                    var hashCode = (int) obj._high;
                    hashCode = (hashCode * 397) ^ (int) obj._low;
                    hashCode = (hashCode * 397) ^ obj.ThreadId.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}