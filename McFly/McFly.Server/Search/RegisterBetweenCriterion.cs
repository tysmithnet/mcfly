using System;
using McFly.Core;

namespace McFly.Server.Search
{
    public class RegisterBetweenCriterion : RegisterCriterion
    {
        public ulong Low { get; }
        public ulong High { get; } // todo: bound checking

        public RegisterBetweenCriterion(Register register, ulong low, ulong high) : base(register)
        {
            if(low > high)
                throw new IndexOutOfRangeException("Low cannot be bigger than High");
            Low = low;
            High = high;
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}