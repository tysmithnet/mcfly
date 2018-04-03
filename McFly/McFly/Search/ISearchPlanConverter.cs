using McFly.Server.Contract;

namespace McFly.Search
{
    internal interface ISearchPlanConverter
    {
        SearchCriterionDto Convert(ISearchPlan searchPlan);
    }
}