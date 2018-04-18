namespace McFly.Core.Registers
{
    public class EsiRegister : Register
    {
        public override string Name { get; } = "esi";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 284;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 5;
        public override int? X86NumBits { get; } = 32;
    }
}