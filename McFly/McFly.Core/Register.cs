namespace McFly.Core
{
    public abstract class Register
    {
        public abstract string Name { get; }
        public abstract int NumBits { get; }

        public static Register Rax { get; } = new RaxRegister();
        public static Register Rbx { get; } = new RbxRegister();
        public static Register Rcx { get; } = new RcxRegister();
        public static Register Rdx { get; } = new RdxRegister();
        public static Register[] CoreUserRegisters64 = {Rax, Rbx, Rcx, Rdx};

        protected class RaxRegister : Register
        {
            public override string Name { get; } = "rax";
            public override int NumBits { get; } = 64;
        }

        protected class RbxRegister : Register
        {
            public override string Name { get; } = "rbx";
            public override int NumBits { get; } = 64;
        }

        protected class RcxRegister : Register
        {
            public override string Name { get; } = "rcx";
            public override int NumBits { get; } = 64;
        }

        protected class RdxRegister : Register
        {
            public override string Name { get; } = "rdx";
            public override int NumBits { get; } = 64;
        }
    }
}
