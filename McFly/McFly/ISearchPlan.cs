using System.Collections.Generic;

namespace McFly
{
    public interface ISearchPlan
    {
        string Index { get; }
        IEnumerable<SearchFilter> SearchFilters { get; }
    }
}