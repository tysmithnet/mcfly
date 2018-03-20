using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Core
{
    public class StackTrace
    {
        public int ThreadId { get; }
        public IEnumerable<StackFrame> StackFrames { get; }
        public int NumFrames { get; }

        public StackTrace(int threadId, IEnumerable<StackFrame> stackFrames)
        {
            if(threadId < 0)
                throw new ArgumentOutOfRangeException($"Thread id cannot be negative");
            ThreadId = threadId;
            StackFrames = stackFrames?.ToList() ?? throw new ArgumentNullException(nameof(stackFrames));
            NumFrames = StackFrames.Count();
        }

        protected bool Equals(StackTrace other)
        {
            bool tid = ThreadId == other.ThreadId;
            var frames = StackFrames.SequenceEqual(other.StackFrames);
            return tid && frames;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StackTrace) obj);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ThreadId;
                hashCode = (hashCode * 397) ^ (StackFrames != null ? StackFrames.Select(x => x.GetHashCode()).Aggregate((l, r) => l.GetHashCode() ^ r.GetHashCode()): 0);
                hashCode = (hashCode * 397) ^ NumFrames;
                return hashCode;
            }
        }
    }
}
