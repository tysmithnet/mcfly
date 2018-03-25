using System;
using McFly.Core;

namespace McFly
{
    public class BreakpointHitEventArgs : EventArgs
    {
        public BreakpointHitEventArgs(Position position, int threadId)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            ThreadId = threadId;
        }

        public Position Position { get; internal set; }
        public int ThreadId { get; set; }
    }
}