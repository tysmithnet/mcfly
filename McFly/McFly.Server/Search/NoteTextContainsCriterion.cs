using System;

namespace McFly.Server.Search
{
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
