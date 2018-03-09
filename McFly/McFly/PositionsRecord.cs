using System;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     One line of !positions
    /// </summary>
    public sealed class PositionsRecord
    {
        public PositionsRecord(int threadId, Position position, bool isThreadWithBreak)
        {
            ThreadId = threadId;
            Position = position ?? throw new ArgumentNullException(nameof(position));
            IsThreadWithBreak = isThreadWithBreak;
        }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId { get; internal set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is thread with break.
        /// </summary>
        /// <value><c>true</c> if this instance is thread with break; otherwise, <c>false</c>.</value>
        public bool IsThreadWithBreak { get; internal set; }

        private bool Equals(PositionsRecord other)
        {
            return ThreadId == other.ThreadId && Position.Equals(other.Position) && IsThreadWithBreak == other.IsThreadWithBreak;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is PositionsRecord && Equals((PositionsRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ThreadId;
                hashCode = (hashCode * 397) ^ Position.GetHashCode();
                hashCode = (hashCode * 397) ^ IsThreadWithBreak.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(PositionsRecord left, PositionsRecord right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PositionsRecord left, PositionsRecord right)
        {
            return !Equals(left, right);
        }
    }
}