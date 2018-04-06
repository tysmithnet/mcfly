// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-27-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="Register.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Typesafe Enum for Registers in the CPU
    /// </summary>
    public abstract partial class Register
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

        /// <summary>
        ///     Gets all 32 bit registers.
        /// </summary>
        /// <value>All registers32.</value>
        public static Register[] AllRegisters32 { get; }

        /// <summary>
        ///     Gets all registers.
        /// </summary>
        /// <value>All registers.</value>
        public static Register[] AllRegisters { get; }

        /// <summary>
        ///     Gets the name of the regiser, e.g. rip, rax, edi.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        /// <summary>
        ///     Gets the number bits for the register, e.g. 32, 64.
        /// </summary>
        /// <value>The number bits.</value>
        public abstract int NumBits { get; }

        /// <summary>
        ///     Lookups the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Register.</returns>
        public static Register Lookup(string name)
        {
            return AllRegisters.FirstOrDefault(x => Regex.IsMatch(name, x.Name, RegexOptions.IgnoreCase));
        }

        /// <summary>
        ///     Gets all 64 bit registers.
        /// </summary>
        /// <value>All registers64.</value>
        public static IReadOnlyCollection<Register> AllRegisters64 { get; }

        /// <summary>
        ///     Gets the core user 64 bit registers.
        /// </summary>
        /// <value>The core user registers64.</value>
        public static IReadOnlyCollection<Register> CoreUserRegisters64 { get; }
    }
}