namespace McFly.Core.Registers
{
    public class Ymm1hRegister : Register
    {
        public override string Name { get; } = "ymm1h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 259;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 150;
        public override int? X86NumBits { get; } = 128;
    }
}