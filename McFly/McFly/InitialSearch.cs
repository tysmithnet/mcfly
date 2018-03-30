using System;
using McFly.Core;

namespace McFly
{
    public sealed class InitialSearch : IEquatable<InitialSearch>
    {
        public string SearchTerm { get; set; } = "";
        public Position Start { get; set; }
        public Position End { get; set; }

        public bool Equals(InitialSearch other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(SearchTerm, other.SearchTerm);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is InitialSearch && Equals((InitialSearch) obj);
        }

        public override int GetHashCode()
        {
            return (SearchTerm != null ? SearchTerm.GetHashCode() : 0);
        }

        public static bool operator ==(InitialSearch left, InitialSearch right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InitialSearch left, InitialSearch right)
        {
            return !Equals(left, right);
        }
    }
}