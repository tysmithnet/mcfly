namespace McFly.Core.Registers
{
    public class BhRegister : Register
    {
        public override string Name { get; } = "bh";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 332;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 36;
        public override int? X86NumBits { get; } = 32;
    }
}