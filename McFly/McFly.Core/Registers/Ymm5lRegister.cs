namespace McFly.Core.Registers
{
    public class Ymm5lRegister : Register
    {
        public override string Name { get; } = "ymm5l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 247;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 146;
        public override int? X86NumBits { get; } = 128;
    }
}