using System.Collections.Generic;

namespace McFly
{
    public interface ISearchResultDisplayStrategy : IInjectable
    {
        void Display(IEnumerable<ISearchResult> searchResults);
    }
}