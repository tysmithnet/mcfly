namespace McFly
{
    public interface ISearchParser
    {
        SearchPlan Parse(string[] args);
    }
}