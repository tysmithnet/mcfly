// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-27-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-07-2018
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
            AllRegisters128 = new Register[]
            {
                Xmm0, Xmm1, Xmm2, Xmm3, Xmm4, Xmm5, Xmm6, Xmm7, Xmm8, Xmm9, Xmm10, Xmm11, Xmm12, Xmm13, Xmm14, Xmm15,
                Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Ymm8, Ymm9, Ymm10, Ymm11, Ymm12, Ymm13, Ymm14, Ymm15
            };
            AllRegisters80 = new Register[] {St0, St1, St2, St3, St4, St5, St6, St7};
            AllRegisters64 = new Register[]
            {
                Brfrom, Brto, Dr0, Dr1, Dr2, Dr3, Dr4, Dr5, Dr6, Dr7, Exfrom, Exto, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6,
                Mm7, R10, R11, R12, R13, R14, R15, R8, R9, Rax, Rbp, Rbx, Rcx, Rdi, Rdx, Rip, Rsi, Rsp, Xmm0h, Xmm0l,
                Xmm10h, Xmm10l, Xmm11h, Xmm11l, Xmm12h, Xmm12l, Xmm13h, Xmm13l, Xmm14h, Xmm14l, Xmm15h, Xmm15l, Xmm1h,
                Xmm1l, Xmm2h, Xmm2l, Xmm3h, Xmm3l, Xmm4h, Xmm4l, Xmm5h, Xmm5l, Xmm6h, Xmm6l, Xmm7h, Xmm7l, Xmm8h, Xmm8l,
                Xmm9h, Xmm9l, Ymm0h, Ymm0l, Ymm10h, Ymm10l, Ymm11h, Ymm11l, Ymm12h, Ymm12l, Ymm13h, Ymm13l, Ymm14h,
                Ymm14l, Ymm15h, Ymm15l, Ymm1h, Ymm1l, Ymm2h, Ymm2l, Ymm3h, Ymm3l, Ymm4h, Ymm4l, Ymm5h, Ymm5l, Ymm6h,
                Ymm6l, Ymm7h, Ymm7l, Ymm8h, Ymm8l, Ymm9h, Ymm9l
            };
            AllRegisters32 = new Register[]
                {Eax, Ebp, Ebx, Ecx, Edi, Edx, Efl, Eip, Esi, Esp, Mxcsr, R10d, R11d, R12d, R13d, R14d, R15d, R8d, R9d};
            AllRegisters16 = new Register[]
            {
                Ax, Bp, Bx, Cs, Cx, Di, Ds, Dx, Es, Fl, Fs, Gs, Ip, R10w, R11w, R12w, R13w, R14w, R15w, R8w, R9w, Si, Sp, Ss
            };
            AllRegisters8 = new Register[]
                {Ah, Al, Bh, Bl, Bpl, Ch, Cl, Dh, Dil, Dl, R10b, R11b, R12b, R13b, R14b, R15b, R8b, R9b, Sil, Spl};
            AllRegistersFlags = new Register[] {Af, Cf, Df, Fpcw, Fpsw, Fptw, If, Iopl, Of, Pf, Sf, Tf, Vif, Vip, Zf};
            AllRegisters = AllRegisters64.Concat(AllRegisters32).ToArray();
            CoreUserRegisters64 = new Register[] {Rax, Rbx, Rcx, Rdx};
        }

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
        ///     Gets all registers.
        /// </summary>
        /// <value>All registers.</value>
        public static Register[] AllRegisters { get; }

        /// <summary>
        ///     Gets all registers128.
        /// </summary>
        /// <value>All registers128.</value>
        public static Register[] AllRegisters128 { get; }

        /// <summary>
        ///     Gets all registers16.
        /// </summary>
        /// <value>All registers16.</value>
        public static Register[] AllRegisters16 { get; }

        /// <summary>
        ///     Gets all 32 bit registers.
        /// </summary>
        /// <value>All registers32.</value>
        public static Register[] AllRegisters32 { get; }

        /// <summary>
        ///     Gets all 64 bit registers.
        /// </summary>
        /// <value>All registers64.</value>
        public static IReadOnlyCollection<Register> AllRegisters64 { get; }

        /// <summary>
        ///     Gets or sets all registers8.
        /// </summary>
        /// <value>All registers8.</value>
        public static Register[] AllRegisters8 { get; set; }

        /// <summary>
        ///     Gets all registers80.
        /// </summary>
        /// <value>All registers80.</value>
        public static Register[] AllRegisters80 { get; }

        /// <summary>
        ///     Gets or sets all registers flags.
        /// </summary>
        /// <value>All registers flags.</value>
        public static Register[] AllRegistersFlags { get; set; }

        /// <summary>
        ///     Gets the core user 64 bit registers.
        /// </summary>
        /// <value>The core user registers64.</value>
        public static IReadOnlyCollection<Register> CoreUserRegisters64 { get; }

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
    }
}