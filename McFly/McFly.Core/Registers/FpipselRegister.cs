namespace McFly.Core.Registers
{
    public class FpipselRegister : Register
    {
        public override string Name { get; } = "fpipsel";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = null;
        public override int? X64NumBits { get; } = null;
        public override int? X86Index { get; } = 45;
        public override int? X86NumBits { get; } = 32;
    }
}