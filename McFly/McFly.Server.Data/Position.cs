using System;
using System.Text.RegularExpressions;

namespace McFly.Server.Data
{
    public struct Position
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
    }
}