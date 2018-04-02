namespace McFly
{
    public interface ISearchPlanFactory
    {
        ISearchPlan Create(string[] args);
    }
}