using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly.Search
{
    public sealed class SearchFilter : IEquatable<SearchFilter>
    {
        public string Command { get; set; }
        public IList<string> Args { get; set; } = new List<string>();

        public bool Equals(SearchFilter other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Args == null && other.Args == null) return true;
            return string.Equals(Command, other.Command) && Args == null ? false : Args.SequenceEqual(other.Args ?? new string[0]);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is SearchFilter && Equals((SearchFilter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Command != null ? Command.GetHashCode() : 0) * 397) ^ (Args != null ? Args.GetHashCode() : 0);
            }
        }

        public static bool operator ==(SearchFilter left, SearchFilter right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SearchFilter left, SearchFilter right)
        {
            return !Equals(left, right);
        }
    }
}