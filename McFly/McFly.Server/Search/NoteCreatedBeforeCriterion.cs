using System;

namespace McFly.Server.Search
{
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
}