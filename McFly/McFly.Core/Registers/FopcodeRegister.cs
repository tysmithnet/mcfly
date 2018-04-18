namespace McFly.Core.Registers
{
    public class FopcodeRegister : Register
    {
        public override string Name { get; } = "fopcode";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = null;
        public override int? X64NumBits { get; } = null;
        public override int? X86Index { get; } = 43;
        public override int? X86NumBits { get; } = 32;
    }
}