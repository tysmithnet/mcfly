using McFly.Server.Contract;

namespace McFly.Search
{
    internal interface ISearchPlanConverter : IInjectable
    {
        SearchCriterionDto Convert(ISearchPlan searchPlan);
    }
}