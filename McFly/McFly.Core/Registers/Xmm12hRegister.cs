namespace McFly.Core.Registers
{
    public class Xmm12hRegister : Register
    {
        public override string Name { get; } = "xmm12h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 158;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}