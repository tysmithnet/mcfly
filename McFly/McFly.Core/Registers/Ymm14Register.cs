namespace McFly.Core.Registers
{
    public class Ymm14Register : Register
    {
        public override string Name { get; } = "ymm14";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 176;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}