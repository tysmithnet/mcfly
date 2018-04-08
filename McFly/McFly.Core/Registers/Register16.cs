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
        ///     Gets the ax.
        /// </summary>
        /// <value>The ax.</value>
        public static AxRegister Ax { get; } = new AxRegister();

        /// <summary>
        ///     Gets the bp.
        /// </summary>
        /// <value>The bp.</value>
        public static BpRegister Bp { get; } = new BpRegister();

        /// <summary>
        ///     Gets the bx.
        /// </summary>
        /// <value>The bx.</value>
        public static BxRegister Bx { get; } = new BxRegister();

        /// <summary>
        ///     Gets the cs.
        /// </summary>
        /// <value>The cs.</value>
        public static CsRegister Cs { get; } = new CsRegister();

        /// <summary>
        ///     Gets the cx.
        /// </summary>
        /// <value>The cx.</value>
        public static CxRegister Cx { get; } = new CxRegister();

        /// <summary>
        ///     Gets the di.
        /// </summary>
        /// <value>The di.</value>
        public static DiRegister Di { get; } = new DiRegister();

        /// <summary>
        ///     Gets the ds.
        /// </summary>
        /// <value>The ds.</value>
        public static DsRegister Ds { get; } = new DsRegister();

        /// <summary>
        ///     Gets the dx.
        /// </summary>
        /// <value>The dx.</value>
        public static DxRegister Dx { get; } = new DxRegister();

        /// <summary>
        ///     Gets the es.
        /// </summary>
        /// <value>The es.</value>
        public static EsRegister Es { get; } = new EsRegister();

        /// <summary>
        ///     Gets the fl.
        /// </summary>
        /// <value>The fl.</value>
        public static FlRegister Fl { get; } = new FlRegister();

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
        ///     Gets the fs.
        /// </summary>
        /// <value>The fs.</value>
        public static FsRegister Fs { get; } = new FsRegister();

        /// <summary>
        ///     Gets the gs.
        /// </summary>
        /// <value>The gs.</value>
        public static GsRegister Gs { get; } = new GsRegister();

        /// <summary>
        ///     Gets the ip.
        /// </summary>
        /// <value>The ip.</value>
        public static IpRegister Ip { get; } = new IpRegister();

        /// <summary>
        ///     Gets the R10W.
        /// </summary>
        /// <value>The R10W.</value>
        public static R10wRegister R10w { get; } = new R10wRegister();

        /// <summary>
        ///     Gets the R11W.
        /// </summary>
        /// <value>The R11W.</value>
        public static R11wRegister R11w { get; } = new R11wRegister();

        /// <summary>
        ///     Gets the R12W.
        /// </summary>
        /// <value>The R12W.</value>
        public static R12wRegister R12w { get; } = new R12wRegister();

        /// <summary>
        ///     Gets the R13W.
        /// </summary>
        /// <value>The R13W.</value>
        public static R13wRegister R13w { get; } = new R13wRegister();

        /// <summary>
        ///     Gets the R14W.
        /// </summary>
        /// <value>The R14W.</value>
        public static R14wRegister R14w { get; } = new R14wRegister();

        /// <summary>
        ///     Gets the R15W.
        /// </summary>
        /// <value>The R15W.</value>
        public static R15wRegister R15w { get; } = new R15wRegister();

        /// <summary>
        ///     Gets the R8W.
        /// </summary>
        /// <value>The R8W.</value>
        public static R8wRegister R8w { get; } = new R8wRegister();

        /// <summary>
        ///     Gets the R9W.
        /// </summary>
        /// <value>The R9W.</value>
        public static R9wRegister R9w { get; } = new R9wRegister();

        /// <summary>
        ///     Gets the si.
        /// </summary>
        /// <value>The si.</value>
        public static SiRegister Si { get; } = new SiRegister();

        /// <summary>
        ///     Gets the sp.
        /// </summary>
        /// <value>The sp.</value>
        public static SpRegister Sp { get; } = new SpRegister();

        /// <summary>
        ///     Gets the ss.
        /// </summary>
        /// <value>The ss.</value>
        public static SsRegister Ss { get; } = new SsRegister();

        /// <summary>
        ///     Class AxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class AxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ax";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class BpRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BpRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Bp";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class BxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Bx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

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

        /// <summary>
        ///     Class CxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class CxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Cx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class DiRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DiRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Di";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

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
        ///     Class DxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Dx";

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
        ///     Class FlRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class FlRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Fl";

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
        ///     Class FsRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class FsRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "fs";

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
        ///     Class IpRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class IpRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ip";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R10wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R10wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R10w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R11wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R11wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R11w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R12wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R12wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R12w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R13wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R13wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R13w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R14wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R14wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R14w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R15wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R15wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R15w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R8wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R8wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R8w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R9wRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R9wRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R9w";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class SiRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class SiRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Si";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class SpRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class SpRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Sp";

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