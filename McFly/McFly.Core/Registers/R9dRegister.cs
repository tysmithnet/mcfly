namespace McFly.Core.Registers
{
    public class R9dRegister : Register
    {
        public override string Name { get; } = "r9d";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 287;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}