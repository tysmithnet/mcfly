namespace McFly.Core.Registers
{
    public class BlRegister : Register
    {
        public override string Name { get; } = "bl";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 316;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 32;
        public override int? X86NumBits { get; } = 32;
    }
}