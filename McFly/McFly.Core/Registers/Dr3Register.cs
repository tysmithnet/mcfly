namespace McFly.Core.Registers
{
    public class Dr3Register : Register
    {
        public override string Name { get; } = "dr3";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 27;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 19;
        public override int? X86NumBits { get; } = 32;
    }
}