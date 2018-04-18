namespace McFly.Core.Registers
{
    public class VifRegister : Register
    {
        public override string Name { get; } = "vif";
        public override int NumBits { get; } = 1;
        public override int? X64Index { get; } = 344;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 84;
        public override int? X86NumBits { get; } = 32;
    }
}