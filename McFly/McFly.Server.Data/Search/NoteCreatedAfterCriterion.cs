using System;

namespace McFly.Server.Data.Search
{
    public class NoteCreatedAfterCriterion : NoteCriterion
    {
        public NoteCreatedAfterCriterion(DateTime dateTime)
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