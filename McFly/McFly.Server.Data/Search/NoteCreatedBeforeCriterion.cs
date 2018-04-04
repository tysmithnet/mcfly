using System;

namespace McFly.Server.Data.Search
{
    public class NoteCreatedBeforeCriterion : NoteCriterion
    {
        public NoteCreatedBeforeCriterion(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}