namespace McFly.Core.Registers
{
    public class IfRegister : Register
    {
        public override string Name { get; } = "if";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 336;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 76;
        public override int? X86NumBits { get; } = 32;
    }
}