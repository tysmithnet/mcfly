namespace McFly.Core.Registers
{
    public class Xmm6lRegister : Register
    {
        public override string Name { get; } = "xmm6l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 136;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 91;
        public override int? X86NumBits { get; } = 64;
    }
}