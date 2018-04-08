// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-07-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="Register8.cs" company="">
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
        ///     Gets the ah.
        /// </summary>
        /// <value>The ah.</value>
        public static AhRegister Ah { get; } = new AhRegister();

        /// <summary>
        ///     Gets the al.
        /// </summary>
        /// <value>The al.</value>
        public static AlRegister Al { get; } = new AlRegister();

        /// <summary>
        ///     Gets the bh.
        /// </summary>
        /// <value>The bh.</value>
        public static BhRegister Bh { get; } = new BhRegister();

        /// <summary>
        ///     Gets the bl.
        /// </summary>
        /// <value>The bl.</value>
        public static BlRegister Bl { get; } = new BlRegister();

        /// <summary>
        ///     Gets the BPL.
        /// </summary>
        /// <value>The BPL.</value>
        public static BplRegister Bpl { get; } = new BplRegister();

        /// <summary>
        ///     Gets the ch.
        /// </summary>
        /// <value>The ch.</value>
        public static ChRegister Ch { get; } = new ChRegister();

        /// <summary>
        ///     Gets the cl.
        /// </summary>
        /// <value>The cl.</value>
        public static ClRegister Cl { get; } = new ClRegister();

        /// <summary>
        ///     Gets the dh.
        /// </summary>
        /// <value>The dh.</value>
        public static DhRegister Dh { get; } = new DhRegister();

        /// <summary>
        ///     Gets the dil.
        /// </summary>
        /// <value>The dil.</value>
        public static DilRegister Dil { get; } = new DilRegister();

        /// <summary>
        ///     Gets the dl.
        /// </summary>
        /// <value>The dl.</value>
        public static DlRegister Dl { get; } = new DlRegister();

        /// <summary>
        ///     Gets the R10B.
        /// </summary>
        /// <value>The R10B.</value>
        public static R10bRegister R10b { get; } = new R10bRegister();

        /// <summary>
        ///     Gets the R11B.
        /// </summary>
        /// <value>The R11B.</value>
        public static R11bRegister R11b { get; } = new R11bRegister();

        /// <summary>
        ///     Gets the R12B.
        /// </summary>
        /// <value>The R12B.</value>
        public static R12bRegister R12b { get; } = new R12bRegister();

        /// <summary>
        ///     Gets the R13B.
        /// </summary>
        /// <value>The R13B.</value>
        public static R13bRegister R13b { get; } = new R13bRegister();

        /// <summary>
        ///     Gets the R14B.
        /// </summary>
        /// <value>The R14B.</value>
        public static R14bRegister R14b { get; } = new R14bRegister();

        /// <summary>
        ///     Gets the R15B.
        /// </summary>
        /// <value>The R15B.</value>
        public static R15bRegister R15b { get; } = new R15bRegister();

        /// <summary>
        ///     Gets the R8B.
        /// </summary>
        /// <value>The R8B.</value>
        public static R8bRegister R8b { get; } = new R8bRegister();

        /// <summary>
        ///     Gets the R9B.
        /// </summary>
        /// <value>The R9B.</value>
        public static R9bRegister R9b { get; } = new R9bRegister();

        /// <summary>
        ///     Gets the sil.
        /// </summary>
        /// <value>The sil.</value>
        public static SilRegister Sil { get; } = new SilRegister();

        /// <summary>
        ///     Gets the SPL.
        /// </summary>
        /// <value>The SPL.</value>
        public static SplRegister Spl { get; } = new SplRegister();

        /// <summary>
        ///     Class AhRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class AhRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ah";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class AlRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class AlRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Al";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class BhRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BhRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Bh";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class BlRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BlRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Bl";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class BplRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class BplRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Bpl";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class ChRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class ChRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Ch";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class ClRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class ClRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Cl";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class DhRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DhRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Dh";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class DilRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DilRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Dil";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class DlRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DlRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Dl";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R10bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R10bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R10b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R11bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R11bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R11b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R12bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R12bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R12b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R13bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R13bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R13b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R14bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R14bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R14b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R15bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R15bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R15b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R8bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R8bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R8b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class R9bRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class R9bRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "R9b";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class SilRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class SilRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Sil";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }

        /// <summary>
        ///     Class SplRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class SplRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Spl";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
    }
}