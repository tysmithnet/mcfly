namespace McFly.Core
{
    public class Frame
    {                               
        public Position Position { get; set; }
        public uint ThreadId { get; set; }
        public RegisterSet RegisterSet { get; set; }
        public string OpcodeNmemonic { get; set; }
        public long CodeAddress { get; set; }
        public string Module { get; set; }
        public string Function { get; set; }
        public uint? FunctionOffset { get; set; }      
    }
}
