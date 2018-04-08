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