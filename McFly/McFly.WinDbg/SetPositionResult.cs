using McFly.Core;

namespace McFly.WinDbg
{
    public class SetPositionResult
    {
        public Position ActualPosition { get; set; }
        public int? BreakpointHit { get; set; }
    }
}