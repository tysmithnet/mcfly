namespace McFly.Core.Registers
{
    public class BrtoRegister : Register
    {
        public override string Name { get; } = "brto";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 277;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}