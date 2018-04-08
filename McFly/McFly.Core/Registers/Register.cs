// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-27-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-06-2018
// ***********************************************************************
// <copyright file="Register.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
            AllRegisters128 = new Register[] {Xmm0, Xmm1, Xmm2, Xmm3, Xmm4, Xmm5, Xmm6, Xmm7, Xmm8, Xmm9, Xmm10, Xmm11, Xmm12, Xmm13, Xmm14, Xmm15, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Ymm8, Ymm9, Ymm10, Ymm11, Ymm12, Ymm13, Ymm14, Ymm15, };
            AllRegisters80 = new Register[]{St0, St1, St2, St3, St4, St5, St6, St7};
            AllRegisters64 = new Register[]
            {
                Rax, Rbx, Rcx, Rdx, Rsi, Rdi, Rsp, Rbp, Rip, R8, R9, R10, R11, R12, R13, R14, R15, Dr0, Dr1, Dr2, Dr3, Dr4, Dr5, Dr6,Dr7, Exfrom, Exto, Brfrom, Brto, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7,
                Xmm0l, Xmm1l, Xmm2l, Xmm3l, Xmm4l, Xmm5l, Xmm6l, Xmm7l, Xmm8l, Xmm9l, Xmm10l, Xmm11l, Xmm12l, Xmm13l, Xmm14l, Xmm15l, Ymm0l, Ymm1l, Ymm2l, Ymm3l, Ymm4l, Ymm5l, Ymm6l, Ymm7l, Ymm8l, Ymm9l, Ymm10l, Ymm11l, Ymm12l, Ymm13l, Ymm14l, Ymm15l,
                Xmm0h, Xmm1h, Xmm2h, Xmm3h, Xmm4h, Xmm5h, Xmm6h, Xmm7h, Xmm8h, Xmm9h, Xmm10h, Xmm11h, Xmm12h, Xmm13h, Xmm14h, Xmm15h, Ymm0h, Ymm1h, Ymm2h, Ymm3h, Ymm4h, Ymm5h, Ymm6h, Ymm7h, Ymm8h, Ymm9h, Ymm10h, Ymm11h, Ymm12h, Ymm13h, Ymm14h, Ymm15h
            };
            AllRegisters32 = new Register[] {Eax, Ebx, Ecx, Edx, Efl, Esp, Ebp, Esi, Edi, R8d, R9d, R10d, R11d, R12d, R13d, R14d, R15d, Eip, Mxcsr};
            AllRegisters16 = new Register[] {Cs, Ds, Es, Fs, Gs, Ss, Ax, Cx, Dx, Bx, Sp, Bp, Si, Di, R8w, R9w, R10w, R11w, R12w, R13w, R14w, R15w, Ip, Fl, };
            AllRegisters8 = new Register[] { Al, Cl, Dl, Bl, Spl, Bpl, Sil, Dil, Ah, Bh, Ch, Dh, R8b, R9b, R10b, R11b, R12b, R13b, R14b, R15b };
            AllRegistersFlags = new Register[] {Iopl, Of, Df, If, Tf, Sf, Zf, Af, Pf, Cf, Vip, Vif, Fpcw, Fpsw, Fptw };
            AllRegisters = AllRegisters64.Concat(AllRegisters32).ToArray();
            CoreUserRegisters64 = new Register[] {Rax, Rbx, Rcx, Rdx};
        }

        public static Register[] AllRegistersFlags { get; set; }

        public static Register[] AllRegisters8 { get; set; }

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
        ///     Gets all 32 bit registers.
        /// </summary>
        /// <value>All registers32.</value>
        public static Register[] AllRegisters32 { get; }

         public static Register[] AllRegisters16 { get; }
        public static Register[] AllRegisters80 { get; }
        public static Register[] AllRegisters128 { get; }

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