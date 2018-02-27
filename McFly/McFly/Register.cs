using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly
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

        public static Register[] UserRegisters64 = {Rax, Rbx, Rcx, Rdx, Rsi, Rdi, Rsp, Rbp, Rip, Efl};

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
    }
}
