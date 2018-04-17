// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-07-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register128.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core
{
    /// <summary>
    ///     Class Register.
    /// </summary>
    public partial class Register
    {
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
        ///     Gets the YMM0.
        /// </summary>
        /// <value>The YMM0.</value>
        public static Ymm0Register Ymm0 { get; } = new Ymm0Register();

        /// <summary>
        ///     Gets the YMM1.
        /// </summary>
        /// <value>The YMM1.</value>
        public static Ymm1Register Ymm1 { get; } = new Ymm1Register();

        /// <summary>
        ///     Gets the YMM10.
        /// </summary>
        /// <value>The YMM10.</value>
        public static Ymm10Register Ymm10 { get; } = new Ymm10Register();

        /// <summary>
        ///     Gets the YMM11.
        /// </summary>
        /// <value>The YMM11.</value>
        public static Ymm11Register Ymm11 { get; } = new Ymm11Register();

        /// <summary>
        ///     Gets the YMM12.
        /// </summary>
        /// <value>The YMM12.</value>
        public static Ymm12Register Ymm12 { get; } = new Ymm12Register();

        /// <summary>
        ///     Gets the YMM13.
        /// </summary>
        /// <value>The YMM13.</value>
        public static Ymm13Register Ymm13 { get; } = new Ymm13Register();

        /// <summary>
        ///     Gets the YMM14.
        /// </summary>
        /// <value>The YMM14.</value>
        public static Ymm14Register Ymm14 { get; } = new Ymm14Register();

        /// <summary>
        ///     Gets the YMM15.
        /// </summary>
        /// <value>The YMM15.</value>
        public static Ymm15Register Ymm15 { get; } = new Ymm15Register();

        /// <summary>
        ///     Gets the YMM2.
        /// </summary>
        /// <value>The YMM2.</value>
        public static Ymm2Register Ymm2 { get; } = new Ymm2Register();

        /// <summary>
        ///     Gets the YMM3.
        /// </summary>
        /// <value>The YMM3.</value>
        public static Ymm3Register Ymm3 { get; } = new Ymm3Register();

        /// <summary>
        ///     Gets the YMM4.
        /// </summary>
        /// <value>The YMM4.</value>
        public static Ymm4Register Ymm4 { get; } = new Ymm4Register();

        /// <summary>
        ///     Gets the YMM5.
        /// </summary>
        /// <value>The YMM5.</value>
        public static Ymm5Register Ymm5 { get; } = new Ymm5Register();

        /// <summary>
        ///     Gets the YMM6.
        /// </summary>
        /// <value>The YMM6.</value>
        public static Ymm6Register Ymm6 { get; } = new Ymm6Register();

        /// <summary>
        ///     Gets the YMM7.
        /// </summary>
        /// <value>The YMM7.</value>
        public static Ymm7Register Ymm7 { get; } = new Ymm7Register();

        /// <summary>
        ///     Gets the YMM8.
        /// </summary>
        /// <value>The YMM8.</value>
        public static Ymm8Register Ymm8 { get; } = new Ymm8Register();

        /// <summary>
        ///     Gets the YMM9.
        /// </summary>
        /// <value>The YMM9.</value>
        public static Ymm9Register Ymm9 { get; } = new Ymm9Register();

        /// <summary>
        ///     Class Xmm0Register.
        /// </summary>
        /// <seealso cref="Register" />
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
        ///     Class Xmm10Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Xmm10Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm10";

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
        /// <seealso cref="Register" />
        public class Xmm11Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm11";

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
        /// <seealso cref="Register" />
        public class Xmm12Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm12";

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
        /// <seealso cref="Register" />
        public class Xmm13Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm13";

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
        /// <seealso cref="Register" />
        public class Xmm14Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm14";

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
        /// <seealso cref="Register" />
        public class Xmm15Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm15";

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
        /// <seealso cref="Register" />
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
        /// <seealso cref="Register" />
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
        /// <seealso cref="Register" />
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
        /// <seealso cref="Register" />
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
        /// <seealso cref="Register" />
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
        /// <seealso cref="Register" />
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
        /// <seealso cref="Register" />
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

        /// <summary>
        ///     Class Xmm8Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Xmm8Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm8";

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
        /// <seealso cref="Register" />
        public class Xmm9Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "xmm9";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm0Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm0Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm0";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm10Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm10Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm10";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm11Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm11Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm11";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm12Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm12Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm12";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm13Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm13Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm13";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm14Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm14Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm14";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm15Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm15Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm15";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm1Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm1Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm1";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm2Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm2Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm2";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm3Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm3Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm3";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm4Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm4Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm4";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm5Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm5Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm5";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm6Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm6Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm6";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm7Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm7Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm7";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm8Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm8Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm8";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }

        /// <summary>
        ///     Class Ymm9Register.
        /// </summary>
        /// <seealso cref="Register" />
        public class Ymm9Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ymm9";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 128;
        }
    }
}