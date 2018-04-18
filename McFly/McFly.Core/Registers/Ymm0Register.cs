namespace McFly.Core.Registers
{
    public class Ymm0Register : Register
    {
        public override string Name { get; } = "ymm0";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 162;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 133;
        public override int? X86NumBits { get; } = 128;
    }
}