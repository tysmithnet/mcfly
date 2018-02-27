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
        public static Register Rsi { get; } = new RsiRegister();
        public static Register Rdi { get; } = new RdiRegister();
        public static Register Rsp { get; } = new RspRegister();
        public static Register Rbp { get; } = new RbpRegister();
        public static Register Rip { get; } = new RipRegister();
        public static Register Efl { get; } = new EflRegister();
        public static Register R8 { get; } = new R8Register();
        public static Register R9 { get; } = new R9Register();
        public static Register R10 { get; } = new R10Register();
        public static Register R11 { get; } = new R11Register();
        public static Register R12 { get; } = new R12Register();
        public static Register R13 { get; } = new R13Register();
        public static Register R14 { get; } = new R14Register();
        public static Register R15 { get; } = new R15Register();

        public static Register[] CoreUserRegisters64 = {Rax, Rbx, Rcx, Rdx, Rsi, Rdi, Rsp, Rbp, Rip, Efl, R8, R9, R10, R11, R12, R13, R14, R15};

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

        protected class RsiRegister : Register
        {
            public override string Name { get; } = "rsi";
            public override int NumBits { get; } = 64;
        }

        protected class RdiRegister : Register
        {
            public override string Name { get; } = "rdi";
            public override int NumBits { get; } = 64;
        }

        protected class RspRegister : Register
        {
            public override string Name { get; } = "rsp";
            public override int NumBits { get; } = 64;
        }

        protected class RbpRegister : Register
        {
            public override string Name { get; } = "rbp";
            public override int NumBits { get; } = 64;
        }

        protected class RipRegister : Register
        {
            public override string Name { get; } = "rip";
            public override int NumBits { get; } = 64;
        }

        protected class EflRegister : Register
        {
            public override string Name { get; } = "efl";
            public override int NumBits { get; } = 32;
        }

        protected class R8Register : Register
        {
            public override string Name { get; } = "r8";
            public override int NumBits { get; } = 64;
        }

        protected class R9Register : Register
        {
            public override string Name { get; } = "r9";
            public override int NumBits { get; } = 64;
        }

        protected class R10Register : Register
        {
            public override string Name { get; } = "r10";
            public override int NumBits { get; } = 64;
        }

        protected class R11Register : Register
        {
            public override string Name { get; } = "r11";
            public override int NumBits { get; } = 64;
        }

        protected class R12Register : Register
        {
            public override string Name { get; } = "r12";
            public override int NumBits { get; } = 64;
        }

        protected class R13Register : Register
        {
            public override string Name { get; } = "r13";
            public override int NumBits { get; } = 64;
        }

        protected class R14Register : Register
        {
            public override string Name { get; } = "r14";
            public override int NumBits { get; } = 64;
        }

        protected class R15Register : Register
        {
            public override string Name { get; } = "r15";
            public override int NumBits { get; } = 64;
        }
    }
}
