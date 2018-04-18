namespace McFly.Core.Registers
{
    public class DlRegister : Register
    {
        public override string Name { get; } = "dl";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 315;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 33;
        public override int? X86NumBits { get; } = 32;
    }
}