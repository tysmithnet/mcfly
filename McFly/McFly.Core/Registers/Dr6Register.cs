namespace McFly.Core.Registers
{
    public class Dr6Register : Register
    {
        public override string Name { get; } = "dr6";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 28;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 20;
        public override int? X86NumBits { get; } = 32;
    }
}