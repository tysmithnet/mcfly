namespace McFly.Core.Registers
{
    public class Ymm10hRegister : Register
    {
        public override string Name { get; } = "ymm10h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 268;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}