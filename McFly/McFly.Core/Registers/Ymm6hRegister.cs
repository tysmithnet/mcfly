namespace McFly.Core.Registers
{
    public class Ymm6hRegister : Register
    {
        public override string Name { get; } = "ymm6h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 264;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 155;
        public override int? X86NumBits { get; } = 128;
    }
}