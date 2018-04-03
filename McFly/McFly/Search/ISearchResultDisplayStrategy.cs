using System.Collections.Generic;
using McFly.Core;

namespace McFly.Search
{
    public interface ISearchResultDisplayStrategy : IInjectable
    {
        void Display(IEnumerable<Frame> searchResults);
    }
}