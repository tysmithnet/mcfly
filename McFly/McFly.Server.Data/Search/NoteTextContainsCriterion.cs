using System;

namespace McFly.Server.Data.Search
{
    public class NoteTextContainsCriterion : NoteCriterion
    {
        public NoteTextContainsCriterion(string substring)
        {
            Substring = substring ?? throw new ArgumentNullException(nameof(substring));
        }

        public string Substring { get; }

        public override object Accept(ICriterionVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}