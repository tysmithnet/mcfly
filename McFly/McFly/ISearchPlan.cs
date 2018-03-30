using System.Collections.Generic;

namespace McFly
{
    public interface ISearchPlan
    {
        InitialSearch InitialSearch { get; set; }
        IEnumerable<SearchFilter> SearchFilters { get; set; }
    }
}