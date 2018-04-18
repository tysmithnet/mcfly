namespace McFly.Core.Registers
{
    public class Ymm9hRegister : Register
    {
        public override string Name { get; } = "ymm9h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 267;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}