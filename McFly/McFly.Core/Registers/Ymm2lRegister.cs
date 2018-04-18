namespace McFly.Core.Registers
{
    public class Ymm2lRegister : Register
    {
        public override string Name { get; } = "ymm2l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 244;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 143;
        public override int? X86NumBits { get; } = 128;
    }
}