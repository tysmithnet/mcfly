using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly.Server.Data.Search
{
    public sealed class AndCriterion : ICriterion
    {
        public AndCriterion(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria?.ToList() ?? throw new ArgumentNullException(nameof(criteria));
        }

        public IEnumerable<ICriterion> Criteria { get; }

        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}