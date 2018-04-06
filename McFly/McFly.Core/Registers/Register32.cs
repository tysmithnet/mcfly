// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-06-2018
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
        ///     Gets the XMM0.
        /// </summary>
        /// <value>The XMM0.</value>
        public static Xmm0Register Xmm0 { get; } = new Xmm0Register();

        /// <summary>
        ///     Gets the XMM1.
        /// </summary>
        /// <value>The XMM1.</value>
        public static Xmm1Register Xmm1 { get; } = new Xmm1Register();

        /// <summary>
        ///     Gets the XMM2.
        /// </summary>
        /// <value>The XMM2.</value>
        public static Xmm2Register Xmm2 { get; } = new Xmm2Register();

        /// <summary>
        ///     Gets the XMM3.
        /// </summary>
        /// <value>The XMM3.</value>
        public static Xmm3Register Xmm3 { get; } = new Xmm3Register();

        /// <summary>
        ///     Gets the XMM4.
        /// </summary>
        /// <value>The XMM4.</value>
        public static Xmm4Register Xmm4 { get; } = new Xmm4Register();

        /// <summary>
        ///     Gets the XMM5.
        /// </summary>
        /// <value>The XMM5.</value>
        public static Xmm5Register Xmm5 { get; } = new Xmm5Register();

        /// <summary>
        ///     Gets the XMM6.
        /// </summary>
        /// <value>The XMM6.</value>
        public static Xmm6Register Xmm6 { get; } = new Xmm6Register();

        /// <summary>
        ///     Gets the XMM7.
        /// </summary>
        /// <value>The XMM7.</value>
        public static Xmm7Register Xmm7 { get; } = new Xmm7Register();

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
        ///     Class Xmm0Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm0Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm0";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm1Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm1Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm1";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm2Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm2Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm2";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm3Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm3Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm3";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm4Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm4Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm4";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm5Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm5Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm5";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm6Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm6Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm6";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm7Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm7Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm7";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }
    }
}