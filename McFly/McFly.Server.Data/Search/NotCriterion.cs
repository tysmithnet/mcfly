using System;

namespace McFly.Server.Data.Search
{
    public sealed class NotCriterion : ICriterion
    {
        public ICriterion Criterion { get; }

        public NotCriterion(ICriterion criterion)
        {
            Criterion = criterion ?? throw new ArgumentNullException(nameof(criterion));
        }

        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}