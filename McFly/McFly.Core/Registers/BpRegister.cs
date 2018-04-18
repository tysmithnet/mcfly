namespace McFly.Core.Registers
{
    public class BpRegister : Register
    {
        public override string Name { get; } = "bp";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 300;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 28;
        public override int? X86NumBits { get; } = 32;
    }
}