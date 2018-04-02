namespace McFly.Search
{
    public interface ISearchPlanFactory
    {
        ISearchPlan Create(string[] args);
    }
}