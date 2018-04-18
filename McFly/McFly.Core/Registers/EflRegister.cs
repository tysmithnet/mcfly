namespace McFly.Core.Registers
{
    public class EflRegister : Register
    {
        public override string Name { get; } = "efl";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 17;
        public override int? X64NumBits { get; } = 32;
        public override int? X86Index { get; } = 13;
        public override int? X86NumBits { get; } = 32;
    }
}