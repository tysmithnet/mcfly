// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-06-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-06-2018
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
        ///     Gets the rsi.
        /// </summary>
        /// <value>The rsi.</value>
        public static RsiRegister Rsi { get; } = new RsiRegister();

        /// <summary>
        ///     Gets the RSP.
        /// </summary>
        /// <value>The RSP.</value>
        public static RspRegister Rsp { get; } = new RspRegister();

        /// <summary>
        ///     Gets the XMM10.
        /// </summary>
        /// <value>The XMM10.</value>
        public static Xmm10Register Xmm10 { get; } = new Xmm10Register();

        /// <summary>
        ///     Gets the XMM11.
        /// </summary>
        /// <value>The XMM11.</value>
        public static Xmm11Register Xmm11 { get; } = new Xmm11Register();

        /// <summary>
        ///     Gets the XMM12.
        /// </summary>
        /// <value>The XMM12.</value>
        public static Xmm12Register Xmm12 { get; } = new Xmm12Register();

        /// <summary>
        ///     Gets the XMM13.
        /// </summary>
        /// <value>The XMM13.</value>
        public static Xmm13Register Xmm13 { get; } = new Xmm13Register();

        /// <summary>
        ///     Gets the XMM14.
        /// </summary>
        /// <value>The XMM14.</value>
        public static Xmm14Register Xmm14 { get; } = new Xmm14Register();

        /// <summary>
        ///     Gets the XMM15.
        /// </summary>
        /// <value>The XMM15.</value>
        public static Xmm15Register Xmm15 { get; } = new Xmm15Register();

        /// <summary>
        ///     Gets the XMM8.
        /// </summary>
        /// <value>The XMM8.</value>
        public static Xmm8Register Xmm8 { get; } = new Xmm8Register();

        /// <summary>
        ///     Gets the XMM9.
        /// </summary>
        /// <value>The XMM9.</value>
        public static Xmm9Register Xmm9 { get; } = new Xmm9Register();

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

        /// <summary>
        ///     Class Xmm10Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm10Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm10";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm11Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm11Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm11";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm12Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm12Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm12";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm13Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm13Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm13";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm14Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm14Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm14";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm15Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm15Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm15";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm8Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm8Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm8";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Xmm9Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm9Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm9";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }
    }
}