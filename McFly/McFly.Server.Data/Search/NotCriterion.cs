using System;

namespace McFly.Server.Data.Search
{
    public sealed class NotCriterion : ICriterion
    {
        public NotCriterion(ICriterion criterion)
        {
            Criterion = criterion ?? throw new ArgumentNullException(nameof(criterion));
        }

        public ICriterion Criterion { get; }

        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}