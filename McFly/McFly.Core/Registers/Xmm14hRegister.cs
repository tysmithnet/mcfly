namespace McFly.Core.Registers
{
    public class Xmm14hRegister : Register
    {
        public override string Name { get; } = "xmm14h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 160;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}