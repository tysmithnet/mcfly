using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace McFly.Core
{
    public struct Position : IComparable<Position>, IEquatable<Position>
    {
        private int _high;
        private int _low;

        public int High
        {
            get => _high;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive");
                }
                _high = value;
            }
        }

        public int Low
        {
            get => _low;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be positive");
                }
                _low = value;
            }
        }

        public override string ToString()
        {
            return $"{High}:{Low}";
        }

        public static Position Parse(string text)
        {
            var match = Regex.Match(text, @"^\s*(?<hi>[a-fA-F0-9]+):(?<lo>[a-fA-F0-9]+\s*$)");
            if (!match.Success)
            {
                throw new FormatException($"{nameof(text)} is not a valid format for Position.. must be like 1f0:df");
            }
            return new Position
            {
                High = Convert.ToInt32(match.Groups["hi"]),
                Low = Convert.ToInt32(match.Groups["lo"])
            };
        }

        public int CompareTo(Position other)
        {
            var highComparison = _high.CompareTo(other._high);
            if (highComparison != 0) return highComparison;
            return _low.CompareTo(other._low);
        }

        public override bool Equals(object obj)
        {
            return obj is Position && Equals((Position)obj);
        }

        public bool Equals(Position other)
        {
            return _high == other._high &&
                   _low == other._low &&
                   High == other.High &&
                   Low == other.Low;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 628841656;
                hashCode = hashCode * -1521134295 ^ _high.GetHashCode();
                hashCode = hashCode * -1521134295 ^ _low.GetHashCode();
                return hashCode;
            }
        }

        private sealed class HighLowRelationalComparer : Comparer<Position>
        {
            public override int Compare(Position x, Position y)
            {
                var highComparison = x._high.CompareTo(y._high);
                if (highComparison != 0) return highComparison;
                return x._low.CompareTo(y._low);
            }
        }

        public static Comparer<Position> HighLowComparer { get; } = new HighLowRelationalComparer();

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
    }
}
