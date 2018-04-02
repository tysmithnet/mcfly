using System.Collections.Generic;

namespace McFly.Search
{
    public class SearchPlanInterpreter : ISearchPlanInterpreter // todo: rename this and all the other default stuff to ___Sql
    {
        public IEnumerable<ISearchResult> Interpret(ISearchPlan searchPlan)
        {
            return null;
        }
    }
}