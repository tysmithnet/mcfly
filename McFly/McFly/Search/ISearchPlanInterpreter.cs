using System.Collections.Generic;

namespace McFly.Search
{
    public interface ISearchPlanInterpreter
    {
        IEnumerable<ISearchResult> Interpret(ISearchPlan searchPlan);
    }
}