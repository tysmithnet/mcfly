namespace McFly.Core.Registers
{
    public abstract partial class Register
    {
        /// <summary>
        ///     Gets the rax.
        /// </summary>
        /// <value>The rax.</value>
        public static Register Rax { get; } = new RaxRegister();

        /// <summary>
        ///     Gets the RBX.
        /// </summary>
        /// <value>The RBX.</value>
        public static Register Rbx { get; } = new RbxRegister();

        /// <summary>
        ///     Gets the RCX.
        /// </summary>
        /// <value>The RCX.</value>
        public static Register Rcx { get; } = new RcxRegister();

        /// <summary>
        ///     Gets the RDX.
        /// </summary>
        /// <value>The RDX.</value>
        public static Register Rdx { get; } = new RdxRegister();

        //public static Register Rdx { get; } = new RdxRegister();

        //public static Register Rdx { get; } = new RdxRegister();

        //public static Register Rdx { get; } = new RdxRegister();

        //public static Register Rdx { get; } = new RdxRegister();

        /// <summary>
        ///     Class RaxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class RaxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rax";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RbxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class RbxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rbx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RcxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class RcxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rcx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RdxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class RdxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rdx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }
    }
}