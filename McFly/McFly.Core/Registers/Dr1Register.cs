namespace McFly.Core.Registers
{
    public class Dr1Register : Register
    {
        public override string Name { get; } = "dr1";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 25;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 17;
        public override int? X86NumBits { get; } = 32;
    }
}