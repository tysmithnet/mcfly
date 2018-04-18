namespace McFly.Core.Registers
{
    public class ExtoRegister : Register
    {
        public override string Name { get; } = "exto";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 275;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}