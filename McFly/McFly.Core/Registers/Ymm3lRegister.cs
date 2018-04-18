namespace McFly.Core.Registers
{
    public class Ymm3lRegister : Register
    {
        public override string Name { get; } = "ymm3l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 245;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 144;
        public override int? X86NumBits { get; } = 128;
    }
}