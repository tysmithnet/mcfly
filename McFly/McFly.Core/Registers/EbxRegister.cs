namespace McFly.Core.Registers
{
    public class EbxRegister : Register
    {
        public override string Name { get; } = "ebx";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 281;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = 6;
        public override int? X86NumBits { get; } = 32;
    }
}