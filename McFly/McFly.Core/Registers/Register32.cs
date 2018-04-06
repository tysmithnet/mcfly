namespace McFly.Core.Registers
{
    public abstract partial class Register
    {
        /// <summary>
        ///     Gets the Eax.
        /// </summary>
        /// <value>The Eax.</value>
        public static Register Eax { get; } = new EaxRegister();

        /// <summary>
        ///     Gets the Ebx.
        /// </summary>
        /// <value>The Ebx.</value>
        public static Register Ebx { get; } = new EbxRegister();

        /// <summary>
        ///     Gets the Ecx.
        /// </summary>
        /// <value>The Ecx.</value>
        public static Register Ecx { get; } = new EcxRegister();

        /// <summary>
        ///     Gets the Edx.
        /// </summary>
        /// <value>The Edx.</value>
        public static Register Edx { get; } = new EdxRegister();

        /// <summary>
        ///     Class EaxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class EaxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Eax";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EbxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class EbxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Ebx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EcxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class EcxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Ecx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EdxRegister.
        /// </summary>
        /// <seealso cref="Register" />
        protected class EdxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Edx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

    }
}
