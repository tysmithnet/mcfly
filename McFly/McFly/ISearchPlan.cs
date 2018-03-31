using System.Collections.Generic;

namespace McFly
{
    public interface ISearchPlan
    {
        InitialSearch InitialSearch { get; }
        IEnumerable<SearchFilter> SearchFilters { get; }
    }
}