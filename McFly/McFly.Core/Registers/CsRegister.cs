namespace McFly.Core.Registers
{
    public class CsRegister : Register
    {
        public override string Name { get; } = "cs";
        public override int NumBits { get; } = 16;
        public override int? X64Index { get; } = 18;
        public override int? X64NumBits { get; } = 16;
        public override int? X86Index { get; } = 12;
        public override int? X86NumBits { get; } = 32;
    }
}