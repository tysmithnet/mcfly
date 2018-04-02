namespace McFly.Server.Search
{
    public interface ICriterionVisitor
    {
        object Visit(ICriterion criterion);
    }
}