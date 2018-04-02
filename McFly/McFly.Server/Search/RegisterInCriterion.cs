using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Search
{
    public class RegisterInCriterion : RegisterCriterion
    {
        public IEnumerable<ulong> Values { get; }

        public RegisterInCriterion(Register register, IEnumerable<ulong> values) : base(register)
        {
            Values = values?.ToList() ?? throw new ArgumentNullException(nameof(values));
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}