using System;

namespace McFly.Server.Search
{
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
}