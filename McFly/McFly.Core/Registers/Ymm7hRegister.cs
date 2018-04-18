namespace McFly.Core.Registers
{
    public class Ymm7hRegister : Register
    {
        public override string Name { get; } = "ymm7h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 265;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 156;
        public override int? X86NumBits { get; } = 128;
    }
}