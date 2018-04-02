using System.Collections.Generic;

namespace McFly.Search
{
    public interface ISearchIndex : IInjectable
    {
        IEnumerable<ISearchResult> GeneralSearch(string searchText);
        IEnumerable<ISearchResult> Search(string[] args);
    }
}