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

        public Position(uint high, uint low)
        {
            _high = high;
            _low = low;
        }
                
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
            return _low.CompareTo(other._low);
        }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _high == other._high && _low == other._low;
        }

        public override string ToString()
        {
            return $"{High:X}:{Low:X}";
        }

        public static Position Parse(string text)
        {
            var match = Regex.Match(text, @"^\s*(?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+\s*$)");
            if (!match.Success)
                throw new FormatException($"{nameof(text)} is not a valid format for Position.. must be like 1f0:df");
            return new Position(Convert.ToUInt32(match.Groups["hi"].Value, 16),
                Convert.ToUInt32(match.Groups["lo"].Value, 16));
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
                return x._high == y._high && x._low == y._low;
            }

            public int GetHashCode(Position obj)
            {
                unchecked
                {
                    var hashCode = (int) obj._high;
                    hashCode = (hashCode * 397) ^ (int) obj._low;
                    return hashCode;
                }
            }
        }
    }
}