// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register64.cs" company="">
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
        ///     Gets the MM0.
        /// </summary>
        /// <value>The MM0.</value>
        public static Mm0Register Mm0 { get; } = new Mm0Register();

        /// <summary>
        ///     Gets the MM1.
        /// </summary>
        /// <value>The MM1.</value>
        public static Mm1Register Mm1 { get; } = new Mm1Register();

        /// <summary>
        ///     Gets the MM2.
        /// </summary>
        /// <value>The MM2.</value>
        public static Mm2Register Mm2 { get; } = new Mm2Register();

        /// <summary>
        ///     Gets the MM3.
        /// </summary>
        /// <value>The MM3.</value>
        public static Mm3Register Mm3 { get; } = new Mm3Register();

        /// <summary>
        ///     Gets the MM4.
        /// </summary>
        /// <value>The MM4.</value>
        public static Mm4Register Mm4 { get; } = new Mm4Register();

        /// <summary>
        ///     Gets the MM5.
        /// </summary>
        /// <value>The MM5.</value>
        public static Mm5Register Mm5 { get; } = new Mm5Register();

        /// <summary>
        ///     Gets the MM6.
        /// </summary>
        /// <value>The MM6.</value>
        public static Mm6Register Mm6 { get; } = new Mm6Register();

        /// <summary>
        ///     Gets the MM7.
        /// </summary>
        /// <value>The MM7.</value>
        public static Mm7Register Mm7 { get; } = new Mm7Register();

        /// <summary>
        ///     Gets the R10.
        /// </summary>
        /// <value>The R10.</value>
        public static R10Register R10 { get; } = new R10Register();

        /// <summary>
        ///     Gets the R11.
        /// </summary>
        /// <value>The R11.</value>
        public static R11Register R11 { get; } = new R11Register();

        /// <summary>
        ///     Gets the R12.
        /// </summary>
        /// <value>The R12.</value>
        public static R12Register R12 { get; } = new R12Register();

        /// <summary>
        ///     Gets the R13.
        /// </summary>
        /// <value>The R13.</value>
        public static R13Register R13 { get; } = new R13Register();

        /// <summary>
        ///     Gets the R14.
        /// </summary>
        /// <value>The R14.</value>
        public static R14Register R14 { get; } = new R14Register();

        /// <summary>
        ///     Gets the R15.
        /// </summary>
        /// <value>The R15.</value>
        public static R15Register R15 { get; } = new R15Register();

        /// <summary>
        ///     Gets the r8.
        /// </summary>
        /// <value>The r8.</value>
        public static R8Register R8 { get; } = new R8Register();

        /// <summary>
        ///     Gets the r9.
        /// </summary>
        /// <value>The r9.</value>
        public static R9Register R9 { get; } = new R9Register();

        /// <summary>
        ///     Gets the rax.
        /// </summary>
        /// <value>The rax.</value>
        public static RaxRegister Rax { get; } = new RaxRegister();

        /// <summary>
        ///     Gets the RBP.
        /// </summary>
        /// <value>The RBP.</value>
        public static RbpRegister Rbp { get; } = new RbpRegister();

        /// <summary>
        ///     Gets the RBX.
        /// </summary>
        /// <value>The RBX.</value>
        public static RbxRegister Rbx { get; } = new RbxRegister();

        /// <summary>
        ///     Gets the RCX.
        /// </summary>
        /// <value>The RCX.</value>
        public static RcxRegister Rcx { get; } = new RcxRegister();

        /// <summary>
        ///     Gets the rdi.
        /// </summary>
        /// <value>The rdi.</value>
        public static RdiRegister Rdi { get; } = new RdiRegister();

        /// <summary>
        ///     Gets the Rbp.
        /// </summary>
        /// <value>The Rbp.</value>
        public static RdxRegister Rdx { get; } = new RdxRegister();

        /// <summary>
        ///     Gets the rip.
        /// </summary>
        /// <value>The rip.</value>
        public static RipRegister Rip { get; } = new RipRegister();

        /// <summary>
        ///     Gets the rsi.
        /// </summary>
        /// <value>The rsi.</value>
        public static RsiRegister Rsi { get; } = new RsiRegister();

        /// <summary>
        ///     Gets the RSP.
        /// </summary>
        /// <value>The RSP.</value>
        public static RspRegister Rsp { get; } = new RspRegister();

        public static Dr0Register Dr0 { get; } = new Dr0Register();
        public static Dr1Register Dr1 { get; } = new Dr1Register();
        public static Dr2Register Dr2 { get; } = new Dr2Register();
        public static Dr3Register Dr3 { get; } = new Dr3Register();
        public static Dr4Register Dr4 { get; } = new Dr4Register();
        public static Dr5Register Dr5 { get; } = new Dr5Register();
        public static Dr6Register Dr6 { get; } = new Dr6Register();
        public static Dr7Register Dr7 { get; } = new Dr7Register();


        /// <summary>
        ///     Class Mm0Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm0Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm0";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm1Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm1Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm1";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm2Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm2Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm2";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm3Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm3Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm3";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm4Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm4Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm4";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm5Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm5Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm5";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm6Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm6Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm6";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Mm7Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Mm7Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "mm7";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R10Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R10Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r10";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R11Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R11Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r11";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R12Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R12Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r12";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R13Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R13Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r13";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R14Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R14Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r14";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R15Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R15Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r15";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R8Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R8Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r8";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class R9Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R9Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "r9";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RaxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class RaxRegister : Register
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
        ///     Class RbpRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class RbpRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rbp";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RbxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class RbxRegister : Register
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
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class RcxRegister : Register
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
        ///     Class RbpRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        /// <seealso cref="Register" />
        public class RdiRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rdi";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RdxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class RdxRegister : Register
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

        /// <summary>
        ///     Class RipRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class RipRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rip";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RsiRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class RsiRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rsi";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class RspRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class RspRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "rsp";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 64;
        }
    }

    public class Dr0Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr0";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr1Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr1";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr2Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr2";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr3Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr3";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr4Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr4";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr5Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr5";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr6Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr6";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    public class Dr7Register : Register
    {
        /// <inheritdoc />
        public override string Name { get; } = "dr7";

        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }
}