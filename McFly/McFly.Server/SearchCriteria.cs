using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;

namespace McFly.Server
{
    public interface ICriterion
    {
        object Accept(ICriterionVisitor visitor);
    }

    public interface ICriterionVisitor
    {
        object Visit(ICriterion criterion);
    }

    public sealed class AndCriterion : ICriterion
    {
        public IEnumerable<ICriterion> Criteria { get; }

        public AndCriterion(IEnumerable<ICriterion> criteria)
        {
            Criteria = criteria?.ToList() ?? throw new ArgumentNullException(nameof(criteria));
        }

        public object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

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

    public abstract class RegisterCriterion : ICriterion
    {
        public IEnumerable<Register> Registers { get; set; }

        protected RegisterCriterion(IEnumerable<Register> registers)
        {
            Registers = registers?.ToList() ?? throw new ArgumentNullException(nameof(registers));
        }

        public abstract object Accept(ICriterionVisitor visitor);
    }

    public class RegisterEqualsCriterion : RegisterCriterion
    {
        public ulong Value { get; }

        public RegisterEqualsCriterion(IEnumerable<Register> registers, ulong value) : base(registers)
        {
            Value = value;
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class RegisterBetweenCriterion : RegisterCriterion
    {
        public ulong Low { get; }
        public ulong High { get; } // todo: bound checking

        public RegisterBetweenCriterion(IEnumerable<Register> registers, ulong low, ulong high) : base(registers)
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

    public class RegisterInCriterion : RegisterCriterion
    {
        public IEnumerable<ulong> Values { get; }

        public RegisterInCriterion(IEnumerable<Register> registers, IEnumerable<ulong> values) : base(registers)
        {
            Values = values?.ToList() ?? throw new ArgumentNullException(nameof(values));
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public abstract class NoteCriterion : ICriterion
    {
        public abstract object Accept(ICriterionVisitor visitor);
    }

    public class NoteCreatedBeforeCriterion : NoteCriterion
    {
        public DateTime DateTime { get; }

        public NoteCreatedBeforeCriterion(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class NoteCreatedAfterCriterion : NoteCriterion
    {
        public DateTime DateTime { get; }

        public NoteCreatedAfterCriterion(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class NoteCreatedBetweenCriterion : NoteCriterion
    {
        public DateTime Low { get; }
        public DateTime High { get; }

        public NoteCreatedBetweenCriterion(DateTime low, DateTime high)
        {
            if(low > high)
                throw new ArgumentOutOfRangeException("Low cannot be after High");
            Low = low;
            High = high;
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class NoteTextContainsCriterion : NoteCriterion
    {
        public string Substring { get; }

        public NoteTextContainsCriterion(string substring)
        {
            Substring = substring ?? throw new ArgumentNullException(nameof(substring));
        }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
