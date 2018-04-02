using System;
using System.Collections.Generic;
using System.Linq;

namespace McFly.Server.Search
{
    public sealed class OrCriterion : ICriterion
    {
        public IEnumerable<ICriterion> Criteria { get; }

        public OrCriterion(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria?.ToList() ?? throw new ArgumentNullException(nameof(criteria));
        }

        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}