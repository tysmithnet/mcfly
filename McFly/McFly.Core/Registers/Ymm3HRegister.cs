namespace McFly.Core.Registers
{
    public class Ymm3HRegister : Register
    {
        public override string Name { get; } = "ymm3h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 261;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 152;
        public override int? X86NumBits { get; } = 128;
    }
}