namespace McFly.Core.Registers
{
    public class Xmm7lRegister : Register
    {
        public override string Name { get; } = "xmm7l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 137;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 92;
        public override int? X86NumBits { get; } = 64;
    }
}