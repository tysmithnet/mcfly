namespace McFly.Core.Registers
{
    public class Ymm4hRegister : Register
    {
        public override string Name { get; } = "ymm4h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 262;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 153;
        public override int? X86NumBits { get; } = 128;
    }
}