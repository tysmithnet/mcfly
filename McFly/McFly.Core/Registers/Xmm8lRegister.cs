namespace McFly.Core.Registers
{
    public class Xmm8lRegister : Register
    {
        public override string Name { get; } = "xmm8l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 138;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}