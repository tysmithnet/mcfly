namespace McFly.Core.Registers
{
    public class RaxRegister : Register
    {
        public override string Name { get; } = "rax";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 0;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}