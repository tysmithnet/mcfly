namespace McFly.Core.Registers
{
    public class Dr2Register : Register
    {
        public override string Name { get; } = "dr2";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 26;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 18;
        public override int? X86NumBits { get; } = 32;
    }
}