namespace McFly.Core.Registers
{
    public class Dr7Register : Register
    {
        public override string Name { get; } = "dr7";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 29;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 21;
        public override int? X86NumBits { get; } = 32;
    }
}