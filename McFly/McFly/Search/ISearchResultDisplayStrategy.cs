using System.Collections.Generic;

namespace McFly.Search
{
    public interface ISearchResultDisplayStrategy : IInjectable
    {
        void Display(IEnumerable<ISearchResult> searchResults);
    }
}