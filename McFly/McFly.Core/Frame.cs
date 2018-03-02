using System.Collections.Generic;

namespace McFly.Core
{
    public class Frame
    {                               
        public Position Position { get; set; }
        public uint ThreadId { get; set; }
        public RegisterSet RegisterSet { get; set; }
        public string OpcodeNmemonic { get; set; }
        public IList<StackFrame> StackFrames { get; set; }
        public string DisassemblyNote { get; set; }
    }
}
