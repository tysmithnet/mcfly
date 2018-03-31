using System.Collections.Generic;

namespace McFly
{
    public interface ISearchIndex : IInjectable
    {
        IEnumerable<ISearchResult> GeneralSearch(string searchText);
        IEnumerable<ISearchResult> Search(string[] args);
    }
}