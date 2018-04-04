using System;
using System.Collections.Generic;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Contract
{
    public class AddNoteRequest : IEquatable<AddNoteRequest>
    {
        public AddNoteRequest(Position position, IEnumerable<int> threadIds, string text)
        {
            Position = position;
            ThreadIds = threadIds ?? throw new ArgumentNullException(nameof(threadIds));
            Text = text;
        }

        public Position Position { get; set; }
        public IEnumerable<int> ThreadIds { get; set; }
        public string Text { get; set; }

        public bool Equals(AddNoteRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Position, other.Position) && ThreadIds.SequenceEqual(other.ThreadIds) &&
                   string.Equals(Text, other.Text);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AddNoteRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Position != null ? Position.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ ThreadIds.GetHashCode();
                hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(AddNoteRequest left, AddNoteRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AddNoteRequest left, AddNoteRequest right)
        {
            return !Equals(left, right);
        }
    }
}