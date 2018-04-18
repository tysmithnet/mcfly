namespace McFly.Core.Registers
{
    public class AlRegister : Register
    {
        public override string Name { get; } = "al";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 313;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 35;
        public override int? X86NumBits { get; } = 32;
    }
}