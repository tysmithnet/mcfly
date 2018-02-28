namespace McFly.Core
{
    public class Frame
    {                               
        public Position Position { get; set; }
        public int ThreadId { get; set; }
        public long? Rax { get; set; }
        public long? Rbx { get; set; }
        public long? Rcx { get; set; }
        public long? Rdx { get; set; }
        public long? OpcodeNmemonic { get; set; }
        public long? CodeAddress { get; set; }
        public string Module { get; set; }
        public string Function { get; set; }
        public int? FunctionOffset { get; set; }      
    }
}
