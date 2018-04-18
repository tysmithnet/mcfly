namespace McFly.Core.Registers
{
    public class BrfromRegister : Register
    {
        public override string Name { get; } = "brfrom";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 276;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}