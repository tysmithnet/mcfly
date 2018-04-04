using McFly.Core;

namespace McFly.Server.Data.Search
{
    public abstract class RegisterCriterion : ICriterion
    {
        protected RegisterCriterion(Register register)
        {
            Register = register;
        }

        public Register Register { get; set; }

        public abstract object Accept(ICriterionVisitor visitor);
    }
}