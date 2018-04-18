namespace McFly.Core.Registers
{
    public class R10bRegister : Register
    {
        public override string Name { get; } = "r10b";
        public override int NumBits { get; } = 8;
        public override int? X64Index { get; } = 323;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}