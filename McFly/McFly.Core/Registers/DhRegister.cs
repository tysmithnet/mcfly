namespace McFly.Core.Registers
{
    public class DhRegister : Register
    {
        public override string Name { get; } = "dh";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 331;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 37;
        public override int? X86NumBits { get; } = 32;
    }
}