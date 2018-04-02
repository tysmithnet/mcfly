using System.Collections.Generic;

namespace McFly
{
    public interface ISearchPlan
    {
        IEnumerable<SearchFilter> SearchFilters { get; }
    }
}