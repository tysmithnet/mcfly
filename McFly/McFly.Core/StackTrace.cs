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
        public IEnumerable<StackFrame> StackFrames { get; internal set; }
        public int NumFrames { get; internal set; }

        public StackTrace(IEnumerable<StackFrame> stackFrames)
        {
            StackFrames = stackFrames?.ToList() ?? throw new ArgumentNullException(nameof(stackFrames));
            NumFrames = StackFrames.Count();
        }

        protected bool Equals(StackTrace other)
        {
        return StackFrames.SequenceEqual(other.StackFrames);
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
                int hashCode = 455627;
                hashCode = (hashCode * 397) ^ (StackFrames != null ? StackFrames.Select(x => x.GetHashCode()).Aggregate((l, r) => l.GetHashCode() ^ r.GetHashCode()): 0);
                hashCode = (hashCode * 397) ^ NumFrames;
                return hashCode;
            }
        }
    }
}
