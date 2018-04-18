// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-18-2018
// ***********************************************************************
// <copyright file="EsiRegister.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace McFly.Core.Registers
{
    /// <summary>
    /// Class EsiRegister.
    /// </summary>
    /// <seealso cref="McFly.Core.Registers.Register" />
    public class EsiRegister : Register
    {
        /// <summary>
        /// Gets the name of the regiser, e.g. rip, rax, edi.
        /// </summary>
        /// <value>The name.</value>
        public override string Name { get; } = "esi";
        /// <summary>
        /// Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        public override int NumBits { get; } = 32;
        /// <summary>
        /// Gets the index of the X64.
        /// </summary>
        /// <value>The index of the X64.</value>
        public override int? X64Index { get; } = 284;
        /// <summary>
        /// Gets the X64 number bits.
        /// </summary>
        /// <value>The X64 number bits.</value>
        public override int? X64NumBits { get; } = 64;
        /// <summary>
        /// Gets the index of the X86.
        /// </summary>
        /// <value>The index of the X86.</value>
        public override int? X86Index { get; } = 5;
        /// <summary>
        /// Gets the number bits for the register, e.g. 32, 64.
        /// </summary>
        /// <value>The number bits.</value>
        public override int? X86NumBits { get; } = 32;
    }
}