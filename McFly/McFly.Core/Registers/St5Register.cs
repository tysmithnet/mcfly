namespace McFly.Core.Registers
{
    public class St5Register : Register
    {
        public override string Name { get; } = "st5";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 38;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 53;
        public override int? X86NumBits { get; } = 80;
    }
}