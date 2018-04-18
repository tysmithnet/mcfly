namespace McFly.Core.Registers
{
    public class St1Register : Register
    {
        public override string Name { get; } = "st1";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 34;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 49;
        public override int? X86NumBits { get; } = 80;
    }
}