namespace McFly.Server.Data.Search
{
    public interface ICriterion
    {
        object Accept(ICriterionVisitor visitor);
    }
}