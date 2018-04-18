namespace McFly.Core.Registers
{
    public class Ymm9Register : Register
    {
        public override string Name { get; } = "ymm9";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 171;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}