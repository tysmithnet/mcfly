namespace McFly.Core.Registers
{
    public class R14Register : Register
    {
        public override string Name { get; } = "r14";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 14;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}