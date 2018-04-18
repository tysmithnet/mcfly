namespace McFly.Core.Registers
{
    public class Ymm0hRegister : Register
    {
        public override string Name { get; } = "ymm0h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 258;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 149;
        public override int? X86NumBits { get; } = 128;
    }
}