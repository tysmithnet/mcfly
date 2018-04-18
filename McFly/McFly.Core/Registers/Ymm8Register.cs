namespace McFly.Core.Registers
{
    public class Ymm8Register : Register
    {
        public override string Name { get; } = "ymm8";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 170;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}