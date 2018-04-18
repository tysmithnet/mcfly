namespace McFly.Core.Registers
{
    public class Ymm1lRegister : Register
    {
        public override string Name { get; } = "ymm1l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 243;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 142;
        public override int? X86NumBits { get; } = 128;
    }
}