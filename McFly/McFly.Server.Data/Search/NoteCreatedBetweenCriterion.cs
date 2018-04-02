using System;

namespace McFly.Server.Data.Search
{
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
}