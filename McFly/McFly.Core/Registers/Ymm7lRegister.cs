namespace McFly.Core.Registers
{
    public class Ymm7lRegister : Register
    {
        public override string Name { get; } = "ymm7l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 249;
        public override int? X64NumBits { get; } = 128;
        public override int? X86Index { get; } = 148;
        public override int? X86NumBits { get; } = 128;
    }
}