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

using System.Linq;
using System.Text.RegularExpressions;

namespace McFly.Core
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
            X64 = new Register[]
            {
                Af, Ah, Al, Ax, Bh, Bl, Bp, Bpl, Brfrom, Brto, Bx, Cf, Ch, Cl, Cs, Cx, Df, Dh, Di, Dil, Dl, Dr0, Dr1,
                Dr2, Dr3, Dr6, Dr7, Ds, Dx, Eax, Ebp, Ebx, Ecx, Edi, Edx, Efl, Eip, Es, Esi, Esp, Exfrom, Exto, Fl,
                Fpcw, Fpsw, Fptw, Fs, Gs, If, Iopl, Ip, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7, Mxcsr, Of, Pf, R10,
                R10b, R10d, R10w, R11, R11b, R11d, R11w, R12, R12b, R12d, R12w, R13, R13b, R13d, R13w, R14, R14b, R14d,
                R14w, R15, R15b, R15d, R15w, R8, R8b, R8d, R8w, R9, R9b, R9d, R9w, Rax, Rbp, Rbx, Rcx, Rdi, Rdx, Rip,
                Rsi, Rsp, Sf, Si, Sil, Sp, Spl, Ss, St0, St1, St2, St3, St4, St5, St6, St7, Tf, Vif, Vip, Xmm0, Xmm0h,
                Xmm0l, Xmm1, Xmm10, Xmm10h, Xmm10l, Xmm11, Xmm11h, Xmm11l, Xmm12, Xmm12h, Xmm12l, Xmm13, Xmm13h, Xmm13l,
                Xmm14, Xmm14h, Xmm14l, Xmm15, Xmm15h, Xmm15l, Xmm1h, Xmm1l, Xmm2, Xmm2h, Xmm2l, Xmm3, Xmm3h, Xmm3l,
                Xmm4, Xmm4h, Xmm4l, Xmm5, Xmm5h, Xmm5l, Xmm6, Xmm6h, Xmm6l, Xmm7, Xmm7h, Xmm7l, Xmm8, Xmm8h, Xmm8l,
                Xmm9, Xmm9h, Xmm9l, Ymm0, Ymm0h, Ymm0l, Ymm1, Ymm10, Ymm10h, Ymm10l, Ymm11, Ymm11h, Ymm11l, Ymm12,
                Ymm12h, Ymm12l, Ymm13, Ymm13h, Ymm13l, Ymm14, Ymm14h, Ymm14l, Ymm15, Ymm15h, Ymm15l, Ymm1h, Ymm1l, Ymm2,
                Ymm2h, Ymm2l, Ymm3, Ymm3h, Ymm3l, Ymm4, Ymm4h, Ymm4l, Ymm5, Ymm5h, Ymm5l, Ymm6, Ymm6h, Ymm6l, Ymm7,
                Ymm7h, Ymm7l, Ymm8, Ymm8h, Ymm8l, Ymm9, Ymm9h, Ymm9l, Zf
            };
            X86 = new Register[]
            {
                Af, Ah, Al, Ax, Bh, Bl, Bp, Bx, Cf, Ch, Cl, Cs, Cx, Df, Dh, Di, Dl, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7, Ds,
                Dx, Eax, Ebp, Ebx, Ecx, Edi, Edx, Efl, Eip, Es, Esi, Esp, Fl, Fopcode, Fpcw, Fpdp, Fpdpsel, Fpip,
                Fpipsel, Fpsw, Fptw, Fs, Gs, If, Iopl, Ip, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7, Mxcsr, Of, Pf, Sf,
                Si, Sp, Ss, St0, St1, St2, St3, St4, St5, St6, St7, Tf, Vif, Vip, Xmm0, Xmm0h, Xmm0l, Xmm1, Xmm1h,
                Xmm1l, Xmm2, Xmm2h, Xmm2l, Xmm3, Xmm3h, Xmm3l, Xmm4, Xmm4h, Xmm4l, Xmm5, Xmm5h, Xmm5l, Xmm6, Xmm6h,
                Xmm6l, Xmm7, Xmm7h, Xmm7l, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Zf
            };
            All = X64.Concat(X86).Distinct().ToArray();
        }

        /// <summary>
        ///     Lookups the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Register.</returns>
        public static Register Lookup(string name)
        {
            return X64.FirstOrDefault(x => Regex.IsMatch(name, x.Name, RegexOptions.IgnoreCase));
        }

        public static Register[] All { get; }

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
        ///     Gets all registers.
        /// </summary>
        /// <value>All registers.</value>
        public static Register[] X64 { get; }

        public static Register[] X86 { get; }
    }
}