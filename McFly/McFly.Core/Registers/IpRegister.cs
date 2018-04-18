namespace McFly.Core.Registers
{
    public class IpRegister : Register
    {
        public override string Name { get; } = "ip";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 311;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 29;
        public override int? X86NumBits { get; } = 32;
    }
}