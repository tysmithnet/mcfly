namespace McFly.Core.Registers
{
    public class Xmm5lRegister : Register
    {
        public override string Name { get; } = "xmm5l";
        public override int NumBits { get; } = 64;
        public override int? X64Index { get; } = 135;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 90;
        public override int? X86NumBits { get; } = 64;
    }
}