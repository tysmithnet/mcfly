using System.Collections.Generic;
using System.Linq;

namespace McFly.Search
{
    public class SearchPlan : ISearchPlan
    {
        private readonly List<SearchFilter> _searchFilters;

        public SearchPlan(string index)
        {
            Index = index;
            _searchFilters = new List<SearchFilter>();
        }

        public SearchPlan(string index, IEnumerable<SearchFilter> searchFilters)
        {
            Index = index;
            _searchFilters = searchFilters.ToList();
        }

        public void AddSearchFilter(SearchFilter filter)
        {
            _searchFilters.Add(filter);
        }

        /// <inheritdoc />
        public string Index { get; }

        /// <inheritdoc />
        public IEnumerable<SearchFilter> SearchFilters => _searchFilters;
    }
}