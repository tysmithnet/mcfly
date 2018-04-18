namespace McFly.Core.Registers
{
    public class SiRegister : Register
    {
        public override string Name { get; } = "si";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 301;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 23;
        public override int? X86NumBits { get; } = 32;
    }
}