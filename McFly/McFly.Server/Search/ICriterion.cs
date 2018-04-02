namespace McFly.Server.Search
{
    public interface ICriterion
    {
        object Accept(ICriterionVisitor visitor);
    }
}