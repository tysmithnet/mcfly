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
        ///     Gets the brfrom.
        /// </summary>
        /// <value>The brfrom.</value>
        public static BrfromRegister Brfrom { get; } = new BrfromRegister();

        /// <summary>
        ///     Gets the brto.
        /// </summary>
        /// <value>The brto.</value>
        public static BrtoRegister Brto { get; } = new BrtoRegister();

        /// <summary>
        ///     Gets the DR0.
        /// </summary>
        /// <value>The DR0.</value>
        public static Dr0Register Dr0 { get; } = new Dr0Register();

        /// <summary>
        ///     Gets the DR1.
        /// </summary>
        /// <value>The DR1.</value>
        public static Dr1Register Dr1 { get; } = new Dr1Register();

        /// <summary>
        ///     Gets the DR2.
        /// </summary>
        /// <value>The DR2.</value>
        public static Dr2Register Dr2 { get; } = new Dr2Register();

        /// <summary>
        ///     Gets the DR3.
        /// </summary>
        /// <value>The DR3.</value>
        public static Dr3Register Dr3 { get; } = new Dr3Register();

        /// <summary>
        ///     Gets the DR4.
        /// </summary>
        /// <value>The DR4.</value>
        public static Dr4Register Dr4 { get; } = new Dr4Register();

        /// <summary>
        ///     Gets the DR5.
        /// </summary>
        /// <value>The DR5.</value>
        public static Dr5Register Dr5 { get; } = new Dr5Register();

        /// <summary>
        ///     Gets the DR6.
        /// </summary>
        /// <value>The DR6.</value>
        public static Dr6Register Dr6 { get; } = new Dr6Register();

        /// <summary>
        ///     Gets the DR7.
        /// </summary>
        /// <value>The DR7.</value>
        public static Dr7Register Dr7 { get; } = new Dr7Register();

        /// <summary>
        ///     Gets the exfrom.
        /// </summary>
        /// <value>The exfrom.</value>
        public static ExfromRegister Exfrom { get; } = new ExfromRegister();

        /// <summary>
        ///     Gets the exto.
        /// </summary>
        /// <value>The exto.</value>
        public static ExtoRegister Exto { get; } = new ExtoRegister();

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

        /// <summary>
        ///     Gets the XMM0H.
        /// </summary>
        /// <value>The XMM0H.</value>
        public static Xmm0hRegister Xmm0h { get; } = new Xmm0hRegister();

        /// <summary>
        ///     Gets the XMM0L.
        /// </summary>
        /// <value>The XMM0L.</value>
        public static Xmm0lRegister Xmm0l { get; } = new Xmm0lRegister();

        /// <summary>
        ///     Gets the XMM10H.
        /// </summary>
        /// <value>The XMM10H.</value>
        public static Xmm10hRegister Xmm10h { get; } = new Xmm10hRegister();

        /// <summary>
        ///     Gets the XMM10L.
        /// </summary>
        /// <value>The XMM10L.</value>
        public static Xmm10lRegister Xmm10l { get; } = new Xmm10lRegister();

        /// <summary>
        ///     Gets the XMM11H.
        /// </summary>
        /// <value>The XMM11H.</value>
        public static Xmm11hRegister Xmm11h { get; } = new Xmm11hRegister();

        /// <summary>
        ///     Gets the XMM11L.
        /// </summary>
        /// <value>The XMM11L.</value>
        public static Xmm11lRegister Xmm11l { get; } = new Xmm11lRegister();

        /// <summary>
        ///     Gets the XMM12H.
        /// </summary>
        /// <value>The XMM12H.</value>
        public static Xmm12hRegister Xmm12h { get; } = new Xmm12hRegister();

        /// <summary>
        ///     Gets the XMM12L.
        /// </summary>
        /// <value>The XMM12L.</value>
        public static Xmm12lRegister Xmm12l { get; } = new Xmm12lRegister();

        /// <summary>
        ///     Gets the XMM13H.
        /// </summary>
        /// <value>The XMM13H.</value>
        public static Xmm13hRegister Xmm13h { get; } = new Xmm13hRegister();

        /// <summary>
        ///     Gets the XMM13L.
        /// </summary>
        /// <value>The XMM13L.</value>
        public static Xmm13lRegister Xmm13l { get; } = new Xmm13lRegister();

        /// <summary>
        ///     Gets the XMM14H.
        /// </summary>
        /// <value>The XMM14H.</value>
        public static Xmm14hRegister Xmm14h { get; } = new Xmm14hRegister();

        /// <summary>
        ///     Gets the XMM14L.
        /// </summary>
        /// <value>The XMM14L.</value>
        public static Xmm14lRegister Xmm14l { get; } = new Xmm14lRegister();

        /// <summary>
        ///     Gets the XMM15H.
        /// </summary>
        /// <value>The XMM15H.</value>
        public static Xmm15hRegister Xmm15h { get; } = new Xmm15hRegister();

        /// <summary>
        ///     Gets the XMM15L.
        /// </summary>
        /// <value>The XMM15L.</value>
        public static Xmm15lRegister Xmm15l { get; } = new Xmm15lRegister();

        /// <summary>
        ///     Gets the XMM1H.
        /// </summary>
        /// <value>The XMM1H.</value>
        public static Xmm1hRegister Xmm1h { get; } = new Xmm1hRegister();

        /// <summary>
        ///     Gets the XMM1L.
        /// </summary>
        /// <value>The XMM1L.</value>
        public static Xmm1lRegister Xmm1l { get; } = new Xmm1lRegister();

        /// <summary>
        ///     Gets the XMM2H.
        /// </summary>
        /// <value>The XMM2H.</value>
        public static Xmm2hRegister Xmm2h { get; } = new Xmm2hRegister();

        /// <summary>
        ///     Gets the XMM2L.
        /// </summary>
        /// <value>The XMM2L.</value>
        public static Xmm2lRegister Xmm2l { get; } = new Xmm2lRegister();

        /// <summary>
        ///     Gets the XMM3H.
        /// </summary>
        /// <value>The XMM3H.</value>
        public static Xmm3hRegister Xmm3h { get; } = new Xmm3hRegister();

        /// <summary>
        ///     Gets the XMM3L.
        /// </summary>
        /// <value>The XMM3L.</value>
        public static Xmm3lRegister Xmm3l { get; } = new Xmm3lRegister();

        /// <summary>
        ///     Gets the XMM4H.
        /// </summary>
        /// <value>The XMM4H.</value>
        public static Xmm4hRegister Xmm4h { get; } = new Xmm4hRegister();

        /// <summary>
        ///     Gets the XMM4L.
        /// </summary>
        /// <value>The XMM4L.</value>
        public static Xmm4lRegister Xmm4l { get; } = new Xmm4lRegister();

        /// <summary>
        ///     Gets the XMM5H.
        /// </summary>
        /// <value>The XMM5H.</value>
        public static Xmm5hRegister Xmm5h { get; } = new Xmm5hRegister();

        /// <summary>
        ///     Gets the XMM5L.
        /// </summary>
        /// <value>The XMM5L.</value>
        public static Xmm5lRegister Xmm5l { get; } = new Xmm5lRegister();

        /// <summary>
        ///     Gets the XMM6H.
        /// </summary>
        /// <value>The XMM6H.</value>
        public static Xmm6hRegister Xmm6h { get; } = new Xmm6hRegister();

        /// <summary>
        ///     Gets the XMM6L.
        /// </summary>
        /// <value>The XMM6L.</value>
        public static Xmm6lRegister Xmm6l { get; } = new Xmm6lRegister();

        /// <summary>
        ///     Gets the XMM7H.
        /// </summary>
        /// <value>The XMM7H.</value>
        public static Xmm7hRegister Xmm7h { get; } = new Xmm7hRegister();

        /// <summary>
        ///     Gets the XMM7L.
        /// </summary>
        /// <value>The XMM7L.</value>
        public static Xmm7lRegister Xmm7l { get; } = new Xmm7lRegister();

        /// <summary>
        ///     Gets the XMM8H.
        /// </summary>
        /// <value>The XMM8H.</value>
        public static Xmm8hRegister Xmm8h { get; } = new Xmm8hRegister();

        /// <summary>
        ///     Gets the XMM8L.
        /// </summary>
        /// <value>The XMM8L.</value>
        public static Xmm8lRegister Xmm8l { get; } = new Xmm8lRegister();

        /// <summary>
        ///     Gets the XMM9H.
        /// </summary>
        /// <value>The XMM9H.</value>
        public static Xmm9hRegister Xmm9h { get; } = new Xmm9hRegister();

        /// <summary>
        ///     Gets the XMM9L.
        /// </summary>
        /// <value>The XMM9L.</value>
        public static Xmm9lRegister Xmm9l { get; } = new Xmm9lRegister();

        /// <summary>
        ///     Gets the ymm0h.
        /// </summary>
        /// <value>The ymm0h.</value>
        public static Ymm0hRegister Ymm0h { get; } = new Ymm0hRegister();

        /// <summary>
        ///     Gets the ymm0l.
        /// </summary>
        /// <value>The ymm0l.</value>
        public static Ymm0lRegister Ymm0l { get; } = new Ymm0lRegister();

        /// <summary>
        ///     Gets the ymm10h.
        /// </summary>
        /// <value>The ymm10h.</value>
        public static Ymm10hRegister Ymm10h { get; } = new Ymm10hRegister();

        /// <summary>
        ///     Gets the ymm10l.
        /// </summary>
        /// <value>The ymm10l.</value>
        public static Ymm10lRegister Ymm10l { get; } = new Ymm10lRegister();

        /// <summary>
        ///     Gets the ymm11h.
        /// </summary>
        /// <value>The ymm11h.</value>
        public static Ymm11hRegister Ymm11h { get; } = new Ymm11hRegister();

        /// <summary>
        ///     Gets the ymm11l.
        /// </summary>
        /// <value>The ymm11l.</value>
        public static Ymm11lRegister Ymm11l { get; } = new Ymm11lRegister();

        /// <summary>
        ///     Gets the ymm12h.
        /// </summary>
        /// <value>The ymm12h.</value>
        public static Ymm12hRegister Ymm12h { get; } = new Ymm12hRegister();

        /// <summary>
        ///     Gets the ymm12l.
        /// </summary>
        /// <value>The ymm12l.</value>
        public static Ymm12lRegister Ymm12l { get; } = new Ymm12lRegister();

        /// <summary>
        ///     Gets the ymm13h.
        /// </summary>
        /// <value>The ymm13h.</value>
        public static Ymm13hRegister Ymm13h { get; } = new Ymm13hRegister();

        /// <summary>
        ///     Gets the ymm13l.
        /// </summary>
        /// <value>The ymm13l.</value>
        public static Ymm13lRegister Ymm13l { get; } = new Ymm13lRegister();

        /// <summary>
        ///     Gets the ymm14h.
        /// </summary>
        /// <value>The ymm14h.</value>
        public static Ymm14hRegister Ymm14h { get; } = new Ymm14hRegister();

        /// <summary>
        ///     Gets the ymm14l.
        /// </summary>
        /// <value>The ymm14l.</value>
        public static Ymm14lRegister Ymm14l { get; } = new Ymm14lRegister();

        /// <summary>
        ///     Gets the ymm15h.
        /// </summary>
        /// <value>The ymm15h.</value>
        public static Ymm15hRegister Ymm15h { get; } = new Ymm15hRegister();

        /// <summary>
        ///     Gets the ymm15l.
        /// </summary>
        /// <value>The ymm15l.</value>
        public static Ymm15lRegister Ymm15l { get; } = new Ymm15lRegister();

        /// <summary>
        ///     Gets the ymm1h.
        /// </summary>
        /// <value>The ymm1h.</value>
        public static Ymm1hRegister Ymm1h { get; } = new Ymm1hRegister();

        /// <summary>
        ///     Gets the ymm1l.
        /// </summary>
        /// <value>The ymm1l.</value>
        public static Ymm1lRegister Ymm1l { get; } = new Ymm1lRegister();

        /// <summary>
        ///     Gets the ymm2h.
        /// </summary>
        /// <value>The ymm2h.</value>
        public static Ymm2hRegister Ymm2h { get; } = new Ymm2hRegister();

        /// <summary>
        ///     Gets the ymm2l.
        /// </summary>
        /// <value>The ymm2l.</value>
        public static Ymm2lRegister Ymm2l { get; } = new Ymm2lRegister();

        /// <summary>
        ///     Gets the ymm3h.
        /// </summary>
        /// <value>The ymm3h.</value>
        public static Ymm3hRegister Ymm3h { get; } = new Ymm3hRegister();

        /// <summary>
        ///     Gets the ymm3l.
        /// </summary>
        /// <value>The ymm3l.</value>
        public static Ymm3lRegister Ymm3l { get; } = new Ymm3lRegister();

        /// <summary>
        ///     Gets the ymm4h.
        /// </summary>
        /// <value>The ymm4h.</value>
        public static Ymm4hRegister Ymm4h { get; } = new Ymm4hRegister();

        /// <summary>
        ///     Gets the ymm4l.
        /// </summary>
        /// <value>The ymm4l.</value>
        public static Ymm4lRegister Ymm4l { get; } = new Ymm4lRegister();

        /// <summary>
        ///     Gets the ymm5h.
        /// </summary>
        /// <value>The ymm5h.</value>
        public static Ymm5hRegister Ymm5h { get; } = new Ymm5hRegister();

        /// <summary>
        ///     Gets the ymm5l.
        /// </summary>
        /// <value>The ymm5l.</value>
        public static Ymm5lRegister Ymm5l { get; } = new Ymm5lRegister();

        /// <summary>
        ///     Gets the ymm6h.
        /// </summary>
        /// <value>The ymm6h.</value>
        public static Ymm6hRegister Ymm6h { get; } = new Ymm6hRegister();

        /// <summary>
        ///     Gets the ymm6l.
        /// </summary>
        /// <value>The ymm6l.</value>
        public static Ymm6lRegister Ymm6l { get; } = new Ymm6lRegister();

        /// <summary>
        ///     Gets the ymm7h.
        /// </summary>
        /// <value>The ymm7h.</value>
        public static Ymm7hRegister Ymm7h { get; } = new Ymm7hRegister();

        /// <summary>
        ///     Gets the ymm7l.
        /// </summary>
        /// <value>The ymm7l.</value>
        public static Ymm7lRegister Ymm7l { get; } = new Ymm7lRegister();

        /// <summary>
        ///     Gets the ymm8h.
        /// </summary>
        /// <value>The ymm8h.</value>
        public static Ymm8hRegister Ymm8h { get; } = new Ymm8hRegister();

        /// <summary>
        ///     Gets the ymm8l.
        /// </summary>
        /// <value>The ymm8l.</value>
        public static Ymm8lRegister Ymm8l { get; } = new Ymm8lRegister();

        /// <summary>
        ///     Gets the ymm9h.
        /// </summary>
        /// <value>The ymm9h.</value>
        public static Ymm9hRegister Ymm9h { get; } = new Ymm9hRegister();

        /// <summary>
        ///     Gets the ymm9l.
        /// </summary>
        /// <value>The ymm9l.</value>
        public static Ymm9lRegister Ymm9l { get; } = new Ymm9lRegister();

        /// <summary>
        ///     Class BrfromRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BrfromRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "brfrom";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class BrtoRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BrtoRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "brto";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class ExfromRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class ExfromRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "exfrom";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class ExtoRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class ExtoRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "exto";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

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

        /// <summary>
        ///     Class Xmm0hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm0hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm0h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm0lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm0lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm0l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm10hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm10hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm10h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm10lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm10lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm10l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm11hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm11hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm11h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm11lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm11lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm11l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm12hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm12hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm12h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm12lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm12lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm12l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm13hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm13hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm13h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm13lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm13lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm13l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm14hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm14hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm14h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm14lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm14lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm14l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm15hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm15hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm15h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm15lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm15lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm15l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm1hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm1hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm1h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm1lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm1lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm1l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm2hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm2hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm2h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm2lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm2lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm2l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm3hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm3hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm3h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm3lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm3lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm3l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm4hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm4hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm4h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm4lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm4lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm4l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm5hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm5hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm5h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm5lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm5lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm5l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm6hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm6hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm6h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm6lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm6lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm6l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm7hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm7hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm7h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm7lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm7lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm7l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm8hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm8hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm8h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm8lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm8lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm8l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm9hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm9hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm9h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Xmm9lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Xmm9lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Xmm9l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm0hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm0hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm0h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm0lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm0lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm0l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm10hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm10hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm10h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm10lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm10lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm10l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm11hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm11hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm11h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm11lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm11lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm11l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm12hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm12hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm12h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm12lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm12lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm12l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm13hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm13hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm13h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm13lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm13lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm13l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm14hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm14hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm14h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm14lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm14lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm14l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm15hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm15hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm15h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm15lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm15lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm15l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm1hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm1hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm1h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm1lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm1lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm1l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm2hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm2hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm2h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm2lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm2lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm2l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm3hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm3hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm3h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm3lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm3lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm3l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm4hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm4hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm4h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm4lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm4lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm4l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm5hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm5hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm5h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm5lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm5lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm5l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm6hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm6hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm6h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm6lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm6lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm6l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm7hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm7hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm7h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm7lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm7lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm7l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm8hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm8hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm8h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm8lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm8lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm8l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm9hRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm9hRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm9h";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }

        /// <summary>
        ///     Class Ymm9lRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class Ymm9lRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ymm9l";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 64;
        }
    }

    /// <summary>
    ///     Class Dr0Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr0Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr0";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr1Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr1Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr1";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr2Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr2Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr2";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr3Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr3Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr3";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr4Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr4Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr4";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr5Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr5Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr5";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr6Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr6Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr6";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }

    /// <summary>
    ///     Class Dr7Register.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class Dr7Register : Register
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <inheritdoc />
        public override string Name { get; } = "dr7";

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        /// <inheritdoc />
        public override int NumBits { get; } = 64;
    }
}