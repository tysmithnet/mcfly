using System.Collections.Generic;

namespace McFly.Search
{
    public interface ISearchPlan
    {
        string Index { get; }
        IEnumerable<SearchFilter> SearchFilters { get; }
    }
}