namespace McFly.Server.Data.Search
{
    public interface ICriterionVisitor
    {
        object Visit(ICriterion criterion);
    }
}