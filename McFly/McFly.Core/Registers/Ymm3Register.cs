namespace McFly.Core.Registers
{
    public class Ymm3Register : Register
    {
        public override string Name { get; } = "ymm3";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 165;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 136;
        public override int? X86NumBits { get; } = 128;
    }
}