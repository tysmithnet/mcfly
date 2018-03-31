using System.Collections.Generic;

namespace McFly
{
    public interface ISearchPlanInterpreter
    {
        IEnumerable<ISearchResult> Interpret(SearchPlan searchPlan);
    }
}