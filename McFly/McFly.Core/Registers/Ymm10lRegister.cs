namespace McFly.Core.Registers
{
    public class Ymm10lRegister : Register
    {
        public override string Name { get; } = "ymm10l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 252;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}