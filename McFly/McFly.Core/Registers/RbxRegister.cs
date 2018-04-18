namespace McFly.Core.Registers
{
    public class RbxRegister : Register
    {
        public override string Name { get; } = "rbx";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 3;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}