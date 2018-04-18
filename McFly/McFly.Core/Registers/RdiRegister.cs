namespace McFly.Core.Registers
{
    public class RdiRegister : Register
    {
        public override string Name { get; } = "rdi";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 7;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}