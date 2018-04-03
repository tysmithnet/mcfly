using System.Collections.Generic;

namespace McFly.Search
{
    public interface ISearchIndex : IInjectable
    {
        string ShortName { get; }
        
    }
}