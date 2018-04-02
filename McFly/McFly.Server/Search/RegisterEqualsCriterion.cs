using McFly.Core;

namespace McFly.Server.Search
{
    public class RegisterEqualsCriterion : RegisterCriterion
    {
        public ulong Value { get; }

        public RegisterEqualsCriterion(Register register, ulong value) : base(register)
        {
            Value = value;
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}