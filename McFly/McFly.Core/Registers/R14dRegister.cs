namespace McFly.Core.Registers
{
    public class R14dRegister : Register
    {
        public override string Name { get; } = "r14d";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 292;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}