namespace McFly.Core.Registers
{
    public class Xmm7hRegister : Register
    {
        public override string Name { get; } = "xmm7h";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 153;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 100;
        public override int? X86NumBits { get; } = 64;
    }
}