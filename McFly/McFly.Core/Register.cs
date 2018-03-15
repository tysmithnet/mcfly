// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-27-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="Register.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

namespace McFly.Core
{
    /// <summary>
    ///     Class Register.
    /// </summary>
    public abstract class Register
    {
        /// <summary>
        ///     Initializes static members of the <see cref="Register" /> class.
        /// </summary>
        static Register()
        {
            AllRegisters64 = new[] {Rax, Rbx, Rcx, Rdx};
            AllRegisters32 = new[] {Eax, Ebx, Ecx, Edx};
            AllRegisters = AllRegisters64.Concat(AllRegisters32).ToArray();
            CoreUserRegisters64 = new[] {Rax, Rbx, Rcx, Rdx};
        }

        public static Register[] AllRegisters32 { get; }

        public static Register[] AllRegisters { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        public abstract int NumBits { get; }

        #region 64 Bit Registers

        /// <summary>
        ///     Gets the rax.
        /// </summary>
        /// <value>The rax.</value>
        public static Register Rax { get; } = new RaxRegister();

        /// <summary>
        ///     Gets the RBX.
        /// </summary>
        /// <value>The RBX.</value>
        public static Register Rbx { get; } = new RbxRegister();

        /// <summary>
        ///     Gets the RCX.
        /// </summary>
        /// <value>The RCX.</value>
        public static Register Rcx { get; } = new RcxRegister();

        /// <summary>
        ///     Gets the RDX.
        /// </summary>
        /// <value>The RDX.</value>
        public static Register Rdx { get; } = new RdxRegister();

        #endregion

        #region 32 Bit Registers

        /// <summary>
        ///     Gets the Eax.
        /// </summary>
        /// <value>The Eax.</value>
        public static Register Eax { get; } = new EaxRegister();

        /// <summary>
        ///     Gets the Ebx.
        /// </summary>
        /// <value>The Ebx.</value>
        public static Register Ebx { get; } = new EbxRegister();

        /// <summary>
        ///     Gets the Ecx.
        /// </summary>
        /// <value>The Ecx.</value>
        public static Register Ecx { get; } = new EcxRegister();

        /// <summary>
        ///     Gets the Edx.
        /// </summary>
        /// <value>The Edx.</value>
        public static Register Edx { get; } = new EdxRegister();

        #endregion

        #region Common Register Groupings

        /// <summary>
        ///     Gets all registers64.
        /// </summary>
        /// <value>All registers64.</value>
        public static IReadOnlyCollection<Register> AllRegisters64 { get; }

        /// <summary>
        ///     Gets the core user registers64.
        /// </summary>
        /// <value>The core user registers64.</value>
        public static IReadOnlyCollection<Register> CoreUserRegisters64 { get; }

        #endregion

        #region 64 Bit Register Classes

        /// <summary>
        ///     Class RaxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class RaxRegister : Register
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
        ///     Class RbxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class RbxRegister : Register
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
        /// <seealso cref="McFly.Core.Register" />
        protected class RcxRegister : Register
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
        ///     Class RdxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class RdxRegister : Register
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

        #endregion

        #region 32 Bit Register Classes

        /// <summary>
        ///     Class EaxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class EaxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Eax";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EbxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class EbxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Ebx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EcxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class EcxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Ecx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        /// <summary>
        ///     Class EdxRegister.
        /// </summary>
        /// <seealso cref="McFly.Core.Register" />
        protected class EdxRegister : Register
        {
            /// <summary>
            ///     Gets the name.
            /// </summary>
            /// <value>The name.</value>
            public override string Name { get; } = "Edx";

            /// <summary>
            ///     Gets the number bits.
            /// </summary>
            /// <value>The number bits.</value>
            public override int NumBits { get; } = 32;
        }

        #endregion
    }
}