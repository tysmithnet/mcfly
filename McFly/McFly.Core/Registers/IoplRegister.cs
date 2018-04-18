namespace McFly.Core.Registers
{
    public class IoplRegister : Register
    {
        public override string Name { get; } = "iopl";
        public override int NumBits { get; } = 2;
        public override int? X64Index { get; } = 333;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 73;
        public override int? X86NumBits { get; } = 32;
    }
}