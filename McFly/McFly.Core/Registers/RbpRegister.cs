namespace McFly.Core.Registers
{
    public class RbpRegister : Register
    {
        public override string Name { get; } = "rbp";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 5;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}