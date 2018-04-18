namespace McFly.Core.Registers
{
    public class Xmm7Register : Register
    {
        public override string Name { get; } = "xmm7";
        public override int NumBits { get; } = 128;
        public override int? X64Index { get; } = 57;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 72;
        public override int? X86NumBits { get; } = 128;
    }
}