// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-07-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register80.cs" company="">
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
        public static St0Register St0 { get; } = new St0Register();
        public static St1Register St1 { get; } = new St1Register();
        public static St2Register St2 { get; } = new St2Register();
        public static St3Register St3 { get; } = new St3Register();
        public static St4Register St4 { get; } = new St4Register();
        public static St5Register St5 { get; } = new St5Register();
        public static St6Register St6 { get; } = new St6Register();
        public static St7Register St7 { get; } = new St7Register();


        /// <summary>
        ///     Class St0Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St0Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st0";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St1Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St1Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st1";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St2Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St2Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st2";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St3Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St3Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st3";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St4Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St4Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st4";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St5Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St5Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st5";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St6Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St6Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st6";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }

        /// <summary>
        ///     Class St7Register.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class St7Register : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "st7";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 80;
        }
    }
}