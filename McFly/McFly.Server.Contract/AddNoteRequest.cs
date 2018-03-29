using System;
using McFly.Core;

namespace McFly.Server.Contract
{
    public class AddNoteRequest : IEquatable<AddNoteRequest>
    {
        public AddNoteRequest(Position position, int? threadId, string text)
        {
            Position = position;
            ThreadId = threadId;
            Text = text;
        }

        public Position Position { get; set; }
        public int? ThreadId { get; set; }
        public string Text { get; set; }

        public bool Equals(AddNoteRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Position, other.Position) && ThreadId == other.ThreadId && string.Equals(Text, other.Text);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddNoteRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Position != null ? Position.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ThreadId.GetHashCode();
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