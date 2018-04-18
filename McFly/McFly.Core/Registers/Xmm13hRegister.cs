namespace McFly.Core.Registers
{
    public class Xmm13hRegister : Register
    {
        public override string Name { get; } = "xmm13h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 159;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}