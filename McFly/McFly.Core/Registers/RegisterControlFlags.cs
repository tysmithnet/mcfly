// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-07-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-07-2018
// ***********************************************************************
// <copyright file="RegisterControlFlags.cs" company="">
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
        ///     Gets the af.
        /// </summary>
        /// <value>The af.</value>
        public static AfRegister Af { get; } = new AfRegister();

        /// <summary>
        ///     Gets the cf.
        /// </summary>
        /// <value>The cf.</value>
        public static CfRegister Cf { get; } = new CfRegister();

        /// <summary>
        ///     Gets the df.
        /// </summary>
        /// <value>The df.</value>
        public static DfRegister Df { get; } = new DfRegister();

        /// <summary>
        ///     Gets if.
        /// </summary>
        /// <value>If.</value>
        public static IfRegister If { get; } = new IfRegister();

        /// <summary>
        ///     Gets the iopl.
        /// </summary>
        /// <value>The iopl.</value>
        public static IoplRegister Iopl { get; } = new IoplRegister();

        /// <summary>
        ///     Gets the of.
        /// </summary>
        /// <value>The of.</value>
        public static OfRegister Of { get; } = new OfRegister();

        /// <summary>
        ///     Gets the pf.
        /// </summary>
        /// <value>The pf.</value>
        public static PfRegister Pf { get; } = new PfRegister();

        /// <summary>
        ///     Gets the sf.
        /// </summary>
        /// <value>The sf.</value>
        public static SfRegister Sf { get; } = new SfRegister();

        /// <summary>
        ///     Gets the tf.
        /// </summary>
        /// <value>The tf.</value>
        public static TfRegister Tf { get; } = new TfRegister();

        /// <summary>
        ///     Gets the vif.
        /// </summary>
        /// <value>The vif.</value>
        public static VifRegister Vif { get; } = new VifRegister();

        /// <summary>
        ///     Gets the vip.
        /// </summary>
        /// <value>The vip.</value>
        public static VipRegister Vip { get; } = new VipRegister();

        /// <summary>
        ///     Gets the zf.
        /// </summary>
        /// <value>The zf.</value>
        public static ZfRegister Zf { get; } = new ZfRegister();

        /// <summary>
        ///     Class AfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class AfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Af";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class CfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class CfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Cf";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class DfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class DfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Df";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class IfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class IfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "If";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class IoplRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class IoplRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "iopl";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 2;
        }

        /// <summary>
        ///     Class OfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class OfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Of";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class PfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class PfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Pf";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class SfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class SfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Sf";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class TfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class TfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Tf";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class VifRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class VifRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Vif";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class VipRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class VipRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Vip";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }

        /// <summary>
        ///     Class ZfRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Registers.Register" />
        public class ZfRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            /// <inheritdoc />
            public override string Name { get; } = "Zf";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
    }
}