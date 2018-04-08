// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-07-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register16.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Class Register.
    /// </summary>
    public partial class Register
    {
        /// <summary>
        ///     Gets the cs.
        /// </summary>
        /// <value>The cs.</value>
        public static CsRegister Cs { get; } = new CsRegister();

        /// <summary>
        ///     Gets the ds.
        /// </summary>
        /// <value>The ds.</value>
        public static DsRegister Ds { get; } = new DsRegister();

        /// <summary>
        ///     Gets the es.
        /// </summary>
        /// <value>The es.</value>
        public static EsRegister Es { get; } = new EsRegister();

        /// <summary>
        ///     Gets the FPCW.
        /// </summary>
        /// <value>The FPCW.</value>
        public static FpcwRegister Fpcw { get; } = new FpcwRegister();

        /// <summary>
        ///     Gets the FPSW.
        /// </summary>
        /// <value>The FPSW.</value>
        public static FpswRegister Fpsw { get; } = new FpswRegister();

        /// <summary>
        ///     Gets the FPTW.
        /// </summary>
        /// <value>The FPTW.</value>
        public static FptwRegister Fptw { get; } = new FptwRegister();

        /// <summary>
        ///     Gets the gs.
        /// </summary>
        /// <value>The gs.</value>
        public static GsRegister Gs { get; } = new GsRegister();

        /// <summary>
        ///     Gets the ss.
        /// </summary>
        /// <value>The ss.</value>
        public static SsRegister Ss { get; } = new SsRegister();

        /// <summary>
        ///     Class CsRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class CsRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "cs";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        public class FsRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "fs";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static FsRegister Fs { get; } = new FsRegister();

        public class AxRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Ax";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static AxRegister Ax { get; } = new AxRegister();
        public class CxRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Cx";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static CxRegister Cx { get; } = new CxRegister();
        public class DxRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Dx";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static DxRegister Dx { get; } = new DxRegister();
        public class BxRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Bx";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static BxRegister Bx { get; } = new BxRegister();
        public class SpRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Sp";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static SpRegister Sp { get; } = new SpRegister();
        public class BpRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Bp";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static BpRegister Bp { get; } = new BpRegister();
        public class SiRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Si";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static SiRegister Si { get; } = new SiRegister();
        public class DiRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Di";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static DiRegister Di { get; } = new DiRegister();


        public class R8wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R8w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R8wRegister R8w { get; } = new R8wRegister();
        public class R9wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R9w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R9wRegister R9w { get; } = new R9wRegister();
        public class R10wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R10w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R10wRegister R10w { get; } = new R10wRegister();
        public class R11wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R11w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R11wRegister R11w { get; } = new R11wRegister();
        public class R12wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R12w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R12wRegister R12w { get; } = new R12wRegister();
        public class R13wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R13w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R13wRegister R13w { get; } = new R13wRegister();
        public class R14wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R14w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R14wRegister R14w { get; } = new R14wRegister();
        public class R15wRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R15w";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R15wRegister R15w { get; } = new R15wRegister();

        public class IpRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Ip";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static IpRegister Ip { get; } = new IpRegister();
        public class FlRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Fl";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static FlRegister Fl { get; } = new FlRegister();
 
        
        /// <summary>
        ///     Class DsRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DsRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ds";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class EsRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class EsRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "es";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class FpcwRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class FpcwRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "fpcw";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class FpswRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class FpswRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "fpsw";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class FptwRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class FptwRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "fptw";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class GsRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class GsRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "gs";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class SsRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class SsRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "ss";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
    }
}