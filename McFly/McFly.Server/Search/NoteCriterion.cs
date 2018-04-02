namespace McFly.Server.Search
{
    public abstract class NoteCriterion : ICriterion
    {
        public abstract object Accept(ICriterionVisitor visitor);
    }
}