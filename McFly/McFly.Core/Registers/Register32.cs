// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register32.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Class Register.
    /// </summary>
    public abstract partial class Register
    {
        /// <summary>
        ///     Gets the Eax.
        /// </summary>
        /// <value>The Eax.</value>
        public static EaxRegister Eax { get; } = new EaxRegister();

        /// <summary>
        ///     Gets the ebp.
        /// </summary>
        /// <value>The ebp.</value>
        public static EbpRegister Ebp { get; } = new EbpRegister();

        /// <summary>
        ///     Gets the Ebx.
        /// </summary>
        /// <value>The Ebx.</value>
        public static EbxRegister Ebx { get; } = new EbxRegister();

        /// <summary>
        ///     Gets the Ecx.
        /// </summary>
        /// <value>The Ecx.</value>
        public static EcxRegister Ecx { get; } = new EcxRegister();

        /// <summary>
        ///     Gets the edi.
        /// </summary>
        /// <value>The edi.</value>
        public static EdiRegister Edi { get; } = new EdiRegister();

        /// <summary>
        ///     Gets the Edx.
        /// </summary>
        /// <value>The Edx.</value>
        public static EdxRegister Edx { get; } = new EdxRegister();

        /// <summary>
        ///     Gets the efl.
        /// </summary>
        /// <value>The efl.</value>
        public static EflRegister Efl { get; } = new EflRegister();

        /// <summary>
        ///     Gets the eip.
        /// </summary>
        /// <value>The eip.</value>
        public static EipRegister Eip { get; } = new EipRegister();

        /// <summary>
        ///     Gets the esi.
        /// </summary>
        /// <value>The esi.</value>
        public static EsiRegister Esi { get; } = new EsiRegister();

        /// <summary>
        ///     Gets the esp.
        /// </summary>
        /// <value>The esp.</value>
        public static EspRegister Esp { get; } = new EspRegister();

        /// <summary>
        ///     Gets the MXCSR.
        /// </summary>
        /// <value>The MXCSR.</value>
        public static MxcsrRegister Mxcsr { get; } = new MxcsrRegister();

        /// <summary>
        ///     Gets the R10D.
        /// </summary>
        /// <value>The R10D.</value>
        public static R10dRegister R10d { get; } = new R10dRegister();

        /// <summary>
        ///     Gets the R11D.
        /// </summary>
        /// <value>The R11D.</value>
        public static R11dRegister R11d { get; } = new R11dRegister();

        /// <summary>
        ///     Gets the R12D.
        /// </summary>
        /// <value>The R12D.</value>
        public static R12dRegister R12d { get; } = new R12dRegister();

        /// <summary>
        ///     Gets the R13D.
        /// </summary>
        /// <value>The R13D.</value>
        public static R13dRegister R13d { get; } = new R13dRegister();

        /// <summary>
        ///     Gets the R14D.
        /// </summary>
        /// <value>The R14D.</value>
        public static R14dRegister R14d { get; } = new R14dRegister();

        /// <summary>
        ///     Gets the R15D.
        /// </summary>
        /// <value>The R15D.</value>
        public static R15dRegister R15d { get; } = new R15dRegister();

        /// <summary>
        ///     Gets the R8D.
        /// </summary>
        /// <value>The R8D.</value>
        public static R8dRegister R8d { get; } = new R8dRegister();

        /// <summary>
        ///     Gets the R9D.
        /// </summary>
        /// <value>The R9D.</value>
        public static R9dRegister R9d { get; } = new R9dRegister();

        /// <summary>
        ///     Class EaxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class EaxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "eax";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EbpRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class EbpRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "ebp";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EbxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class EbxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "ebx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EcxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class EcxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "ecx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EdiRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class EdiRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "edi";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EdxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class EdxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "edx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EdxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class EflRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "elf";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EipRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class EipRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "eip";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EsiRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class EsiRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "esi";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EspRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class EspRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "esp";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class MxcsrRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class MxcsrRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mxcsr";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class R10dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R10dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r10d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R11dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R11dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r11d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R12dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R12dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r12d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R13dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R13dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r13d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R14dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R14dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r14d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R15dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R15dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r15d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R8dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R8dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r8d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R9dRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R9dRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "r9d";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }
    }
}