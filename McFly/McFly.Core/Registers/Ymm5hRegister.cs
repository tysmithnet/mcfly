namespace McFly.Core.Registers
{
    public class Ymm5hRegister : Register
    {
        public override string Name { get; } = "ymm5h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 263;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 154;
        public override int? X86NumBits { get; } = 128;
    }
}