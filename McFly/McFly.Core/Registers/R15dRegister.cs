namespace McFly.Core.Registers
{
    public class R15dRegister : Register
    {
        public override string Name { get; } = "r15d";
        public override int NumBits { get; } = 32;
        public override int? X64Index { get; } = 293;
        public override int? X64NumBits { get; } = 64;
        public override int? X86Index { get; } = null;
        public override int? X86NumBits { get; } = null;
    }
}