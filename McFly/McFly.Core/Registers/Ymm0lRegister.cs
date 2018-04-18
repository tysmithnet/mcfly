namespace McFly.Core.Registers
{
    public class Ymm0lRegister : Register
    {
        public override string Name { get; } = "ymm0l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 242;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 141;
        public override int? X86NumBits { get; } = 128;
    }
}