using McFly.Core;

namespace McFly.Server.Data.Search
{
    public class RegisterEqualsCriterion : RegisterCriterion
    {
        public RegisterEqualsCriterion(Register register, ulong value) : base(register)
        {
            Value = value;
        }

        public ulong Value { get; }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}