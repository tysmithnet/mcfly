using System;
using System.Collections.Generic;
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
    }
}
