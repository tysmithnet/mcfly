namespace McFly.Search
{
    public interface ISearchPlanFactory : IInjectable
    {
        ISearchPlan Create(string[] args);
    }
}