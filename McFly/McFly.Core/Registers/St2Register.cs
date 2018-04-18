namespace McFly.Core.Registers
{
    public class St2Register : Register
    {
        public override string Name { get; } = "st2";
        public override int NumBits { get; } = 80;
        public override int? X64Index { get; } = 35;
        public override int? X64NumBits { get; } = 80;
        public override int? X86Index { get; } = 50;
        public override int? X86NumBits { get; } = 80;
    }
}