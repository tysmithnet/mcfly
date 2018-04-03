using System.Collections.Generic;
using McFly.Core;

namespace McFly.Search
{
    public interface ISearchResultDisplayStrategy : IInjectable
    {
        bool CanDisplay(object obj);
        void Display(object obj);
    }
}