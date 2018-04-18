namespace McFly.Core.Registers
{
    public class Ymm1Register : Register
    {
        public override string Name { get; } = "ymm1";
        public override int NumBits { get; } = 256;
        public override int? X64Index { get; } = 163;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 134;
        public override int? X86NumBits { get; } = 128;
    }
}