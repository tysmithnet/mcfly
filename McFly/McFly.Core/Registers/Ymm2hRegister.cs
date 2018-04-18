namespace McFly.Core.Registers
{
    public class Ymm2hRegister : Register
    {
        public override string Name { get; } = "ymm2h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 260;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 151;
        public override int? X86NumBits { get; } = 128;
    }
}