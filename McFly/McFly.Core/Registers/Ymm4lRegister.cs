namespace McFly.Core.Registers
{
    public class Ymm4lRegister : Register
    {
        public override string Name { get; } = "ymm4l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 246;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 145;
        public override int? X86NumBits { get; } = 128;
    }
}