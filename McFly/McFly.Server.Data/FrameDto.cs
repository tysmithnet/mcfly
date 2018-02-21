namespace McFly.Server.Data
{
    public class FrameDto
    {                               
        public int KeyMajor { get; set; }
        public int KeyMinor { get; set; }
        public int ThreadId { get; set; }
        public int? ThreadIndex { get; set; }
        public long? Rax { get; set; }
        public long? Rbx { get; set; }
        public long? Rcx { get; set; }
        public long? Rdx { get; set; }
        public long? Rsi { get; set; }
        public long? Rdi { get; set; }
        public long? Rsp { get; set; }
        public long? Rbp { get; set; }
        public long? Rip { get; set; }
        public long? Efl { get; set; }
        public long? Cs { get; set; }
        public long? Ds { get; set; }
        public long? Es { get; set; }
        public long? Fs { get; set; }
        public long? Gs { get; set; }
        public long? Ss { get; set; }
        public long? R8 { get; set; }
        public long? R9 { get; set; }
        public long? R10 { get; set; }
        public long? R11 { get; set; }
        public long? R12 { get; set; }
        public long? R13 { get; set; }
        public long? R14 { get; set; }
        public long? R15 { get; set; }
        public long? Dr0 { get; set; }
        public long? Dr1 { get; set; }
        public long? Dr2 { get; set; }
        public long? Dr3 { get; set; }
        public long? Dr6 { get; set; }
        public long? Dr7 { get; set; }
        public long? Exfrom { get; set; }
        public long? Exto { get; set; }
        public long? Brfrom { get; set; }
        public long? Brto { get; set; }
        public long? OpcodeNmemonic { get; set; }
        public long? CodeAddress { get; set; }
        public string Module { get; set; }
        public string Function { get; set; }
        public int? FunctionOffset { get; set; }      
    }
}
