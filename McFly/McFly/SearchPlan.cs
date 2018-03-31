using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly
{
    public class SearchPlan : ISearchPlan, IEquatable<SearchPlan>
    {
        private readonly List<SearchFilter> _searchFilters;

        public SearchPlan()
        {
            InitialSearch = new InitialSearch();
            _searchFilters = new List<SearchFilter>();
        }

        public SearchPlan(InitialSearch initialSearch, IEnumerable<SearchFilter> searchFilters)
        {
            InitialSearch = initialSearch;
            _searchFilters = searchFilters.ToList();
        }

        public void AddSearchFilter(SearchFilter filter)
        {
            _searchFilters.Add(filter);
        }

        public bool Equals(SearchPlan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (SearchFilters == null && other.SearchFilters == null) return true;
            return Equals(InitialSearch, other.InitialSearch) &&
                   (SearchFilters?.SequenceEqual(other.SearchFilters ?? new SearchFilter[0])).GetValueOrDefault();
        }

        public InitialSearch InitialSearch { get; }

        public IEnumerable<SearchFilter> SearchFilters => _searchFilters;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((SearchPlan) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((InitialSearch != null ? InitialSearch.GetHashCode() : 0) * 397) ^
                       (SearchFilters != null ? SearchFilters.GetHashCode() : 0);
            }
        }

        public static bool operator ==(SearchPlan left, SearchPlan right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SearchPlan left, SearchPlan right)
        {
            return !Equals(left, right);
        }
    }
}