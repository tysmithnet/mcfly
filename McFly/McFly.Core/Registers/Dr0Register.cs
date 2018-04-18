namespace McFly.Core.Registers
{
    public class Dr0Register : Register
    {
        public override string Name { get; } = "dr0";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 24;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 16;
        public override int? X86NumBits { get; } = 32;
    }
}