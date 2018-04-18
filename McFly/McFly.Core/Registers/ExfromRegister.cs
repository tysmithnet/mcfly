namespace McFly.Core.Registers
{
    public class ExfromRegister : Register
    {
        public override string Name { get; } = "exfrom";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 274;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}