// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-27-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-16-2018
// ***********************************************************************
// <copyright file="Register.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.Text.RegularExpressions;

namespace McFly.Core.Registers
{
    /// <summary>
    ///     Typesafe Enum for Registers in the CPU
    /// </summary>
    public abstract class Register
    {
        /// <summary>
        ///     Initializes static members of the <see cref="Register" /> class.
        /// </summary>
        static Register()
        {
            X64 = new Register[]
            {
                Rax, Rcx, Rdx, Rbx, Rsp, Rbp, Rsi, Rdi, R8, R9, R10, R11, R12, R13, R14, R15, Rip, Efl, Cs, Ds, Es, Fs,
                Gs, Ss, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7, Fpcw, Fpsw, Fptw, St0, St1, St2, St3, St4, St5, St6, St7, Mm0,
                Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7, Mxcsr, Xmm0, Xmm1, Xmm2, Xmm3, Xmm4, Xmm5, Xmm6, Xmm7, Xmm8, Xmm9,
                Xmm10, Xmm11, Xmm12, Xmm13, Xmm14, Xmm15, Xmm0l, Xmm1l, Xmm2l, Xmm3l,
                Xmm4l, Xmm5l, Xmm6l, Xmm7l, Xmm8l, Xmm9l, Xmm10l, Xmm11l, Xmm12l, Xmm13l, Xmm14l, Xmm15l, Xmm0h, Xmm1h,
                Xmm2h, Xmm3h, Xmm4h, Xmm5h, Xmm6h, Xmm7h, Xmm8h, Xmm9h, Xmm10h, Xmm11h, Xmm12h, Xmm13h, Xmm14h, Xmm15h,
                Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Ymm8, Ymm9, Ymm10, Ymm11, Ymm12, Ymm13, Ymm14, Ymm15,
                Ymm0l, Ymm1l, Ymm2l, Ymm3l, Ymm4l, Ymm5l, Ymm6l, Ymm7l, Ymm8l, Ymm9l, Ymm10l,
                Ymm11l, Ymm12l, Ymm13l, Ymm14l, Ymm15l, Ymm0h, Ymm1h, Ymm2h, Ymm3h, Ymm4h, Ymm5h, Ymm6h, Ymm7h, Ymm8h,
                Ymm9h, Ymm10h, Ymm11h, Ymm12h, Ymm13h, Ymm14h, Ymm15h, Exfrom, Exto, Brfrom, Brto, Eax, Ecx, Edx, Ebx,
                Esp, Ebp, Esi, Edi, R8d, R9d, R10d, R11d, R12d, R13d, R14d, R15d, Eip, Ax, Cx, Dx, Bx, Sp, Bp, Si, Di,
                R8w, R9w, R10w, R11w, R12w, R13w, R14w, R15w, Ip, Fl, Al, Cl, Dl, Bl, Spl, Bpl, Sil, Dil, R8b, R9b,
                R10b, R11b, R12b, R13b, R14b, R15b, Ah, Ch, Dh, Bh, Iopl, Of, Df, If, Tf, Sf, Zf, Af, Pf, Cf, Vip, Vif
            };
            X86 = new Register[]
            {
                Gs, Fs, Es, Ds, Edi, Esi, Ebx, Edx, Ecx, Eax, Ebp, Eip, Cs, Efl, Esp, Ss, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7,
                Di, Si, Bx, Dx, Cx, Ax, Bp, Ip, Fl, Sp, Bl, Dl, Cl, Al, Bh, Dh, Ch, Ah, Fpcw, Fpsw, Fptw, Fopcode, Fpip,
                Fpipsel, Fpdp, Fpdpsel, St0, St1, St2, St3, St4, St5, St6, St7, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7,
                Mxcsr, Xmm0, Xmm1, Xmm2, Xmm3, Xmm4, Xmm5, Xmm6, Xmm7, Iopl, Of, Df, If, Tf, Sf, Zf, Af, Pf, Cf, Vip,
                Vif, Xmm0l, Xmm1l, Xmm2l, Xmm3l, Xmm4l, Xmm5l, Xmm6l, Xmm7l, Xmm0h, Xmm1h, Xmm2h, Xmm3h, Xmm4h, Xmm5h,
                Xmm6h, Xmm7h, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5,
                Ymm6, Ymm7, Ymm0l, Ymm1l, Ymm2l, Ymm3l, Ymm4l, Ymm5l, Ymm6l, Ymm7l, Ymm0h, Ymm1h, Ymm2h, Ymm3h, Ymm4h,
                Ymm5h, Ymm6h, Ymm7h
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
            return X64.FirstOrDefault(x => Regex.IsMatch(name, x.Name, RegexOptions.IgnoreCase)); // todo: uhhh x86???
        }

        public static AfRegister Af { get; } = new AfRegister();
        public static AhRegister Ah { get; } = new AhRegister();
        public static AlRegister Al { get; } = new AlRegister();

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <value>All.</value>
        public static Register[] All { get; }

        public static AxRegister Ax { get; } = new AxRegister();
        public static BhRegister Bh { get; } = new BhRegister();
        public static BlRegister Bl { get; } = new BlRegister();
        public static BpRegister Bp { get; } = new BpRegister();
        public static BplRegister Bpl { get; } = new BplRegister();
        public static BrfromRegister Brfrom { get; } = new BrfromRegister();
        public static BrtoRegister Brto { get; } = new BrtoRegister();
        public static BxRegister Bx { get; } = new BxRegister();
        public static CfRegister Cf { get; } = new CfRegister();
        public static ChRegister Ch { get; } = new ChRegister();
        public static ClRegister Cl { get; } = new ClRegister();
        public static CsRegister Cs { get; } = new CsRegister();
        public static CxRegister Cx { get; } = new CxRegister();
        public static DfRegister Df { get; } = new DfRegister();
        public static DhRegister Dh { get; } = new DhRegister();
        public static DiRegister Di { get; } = new DiRegister();
        public static DilRegister Dil { get; } = new DilRegister();
        public static DlRegister Dl { get; } = new DlRegister();
        public static Dr0Register Dr0 { get; } = new Dr0Register();
        public static Dr1Register Dr1 { get; } = new Dr1Register();
        public static Dr2Register Dr2 { get; } = new Dr2Register();
        public static Dr3Register Dr3 { get; } = new Dr3Register();
        public static Dr6Register Dr6 { get; } = new Dr6Register();
        public static Dr7Register Dr7 { get; } = new Dr7Register();
        public static DsRegister Ds { get; } = new DsRegister();
        public static DxRegister Dx { get; } = new DxRegister();
        public static EaxRegister Eax { get; } = new EaxRegister();
        public static EbpRegister Ebp { get; } = new EbpRegister();
        public static EbxRegister Ebx { get; } = new EbxRegister();
        public static EcxRegister Ecx { get; } = new EcxRegister();
        public static EdiRegister Edi { get; } = new EdiRegister();
        public static EdxRegister Edx { get; } = new EdxRegister();
        public static EflRegister Efl { get; } = new EflRegister();
        public static EipRegister Eip { get; } = new EipRegister();
        public static EsRegister Es { get; } = new EsRegister();
        public static EsiRegister Esi { get; } = new EsiRegister();
        public static EspRegister Esp { get; } = new EspRegister();
        public static ExfromRegister Exfrom { get; } = new ExfromRegister();
        public static ExtoRegister Exto { get; } = new ExtoRegister();
        public static FlRegister Fl { get; } = new FlRegister();
        public static FopcodeRegister Fopcode { get; } = new FopcodeRegister();
        public static FpcwRegister Fpcw { get; } = new FpcwRegister();
        public static FpdpRegister Fpdp { get; } = new FpdpRegister();
        public static FpdpselRegister Fpdpsel { get; } = new FpdpselRegister();
        public static FpipRegister Fpip { get; } = new FpipRegister();
        public static FpipselRegister Fpipsel { get; } = new FpipselRegister();
        public static FpswRegister Fpsw { get; } = new FpswRegister();
        public static FptwRegister Fptw { get; } = new FptwRegister();
        public static FsRegister Fs { get; } = new FsRegister();
        public static GsRegister Gs { get; } = new GsRegister();
        public static IfRegister If { get; } = new IfRegister();
        public static IoplRegister Iopl { get; } = new IoplRegister();
        public static IpRegister Ip { get; } = new IpRegister();
        public static Mm0Register Mm0 { get; } = new Mm0Register();
        public static Mm1Register Mm1 { get; } = new Mm1Register();
        public static Mm2Register Mm2 { get; } = new Mm2Register();
        public static Mm3Register Mm3 { get; } = new Mm3Register();
        public static Mm4Register Mm4 { get; } = new Mm4Register();
        public static Mm5Register Mm5 { get; } = new Mm5Register();
        public static Mm6Register Mm6 { get; } = new Mm6Register();
        public static Mm7Register Mm7 { get; } = new Mm7Register();
        public static MxcsrRegister Mxcsr { get; } = new MxcsrRegister();

        /// <summary>
        ///     Gets the name of the regiser, e.g. rip, rax, edi.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        public abstract int NumBits { get; }

        public static OfRegister Of { get; } = new OfRegister();
        public static PfRegister Pf { get; } = new PfRegister();
        public static R10Register R10 { get; } = new R10Register();
        public static R10bRegister R10b { get; } = new R10bRegister();
        public static R10dRegister R10d { get; } = new R10dRegister();
        public static R10wRegister R10w { get; } = new R10wRegister();
        public static R11Register R11 { get; } = new R11Register();
        public static R11bRegister R11b { get; } = new R11bRegister();
        public static R11dRegister R11d { get; } = new R11dRegister();
        public static R11wRegister R11w { get; } = new R11wRegister();
        public static R12Register R12 { get; } = new R12Register();
        public static R12bRegister R12b { get; } = new R12bRegister();
        public static R12dRegister R12d { get; } = new R12dRegister();
        public static R12wRegister R12w { get; } = new R12wRegister();
        public static R13Register R13 { get; } = new R13Register();
        public static R13bRegister R13b { get; } = new R13bRegister();
        public static R13dRegister R13d { get; } = new R13dRegister();
        public static R13wRegister R13w { get; } = new R13wRegister();
        public static R14Register R14 { get; } = new R14Register();
        public static R14bRegister R14b { get; } = new R14bRegister();
        public static R14dRegister R14d { get; } = new R14dRegister();
        public static R14wRegister R14w { get; } = new R14wRegister();
        public static R15Register R15 { get; } = new R15Register();
        public static R15bRegister R15b { get; } = new R15bRegister();
        public static R15dRegister R15d { get; } = new R15dRegister();
        public static R15wRegister R15w { get; } = new R15wRegister();
        public static R8Register R8 { get; } = new R8Register();
        public static R8bRegister R8b { get; } = new R8bRegister();
        public static R8dRegister R8d { get; } = new R8dRegister();
        public static R8wRegister R8w { get; } = new R8wRegister();
        public static R9Register R9 { get; } = new R9Register();
        public static R9bRegister R9b { get; } = new R9bRegister();
        public static R9dRegister R9d { get; } = new R9dRegister();
        public static R9wRegister R9w { get; } = new R9wRegister();
        public static RaxRegister Rax { get; } = new RaxRegister();
        public static RbpRegister Rbp { get; } = new RbpRegister();
        public static RbxRegister Rbx { get; } = new RbxRegister();
        public static RcxRegister Rcx { get; } = new RcxRegister();
        public static RdiRegister Rdi { get; } = new RdiRegister();
        public static RdxRegister Rdx { get; } = new RdxRegister();
        public static RipRegister Rip { get; } = new RipRegister();
        public static RsiRegister Rsi { get; } = new RsiRegister();
        public static RspRegister Rsp { get; } = new RspRegister();
        public static SfRegister Sf { get; } = new SfRegister();
        public static SiRegister Si { get; } = new SiRegister();
        public static SilRegister Sil { get; } = new SilRegister();
        public static SpRegister Sp { get; } = new SpRegister();
        public static SplRegister Spl { get; } = new SplRegister();
        public static SsRegister Ss { get; } = new SsRegister();
        public static St0Register St0 { get; } = new St0Register();
        public static St1Register St1 { get; } = new St1Register();
        public static St2Register St2 { get; } = new St2Register();
        public static St3Register St3 { get; } = new St3Register();
        public static St4Register St4 { get; } = new St4Register();
        public static St5Register St5 { get; } = new St5Register();
        public static St6Register St6 { get; } = new St6Register();
        public static St7Register St7 { get; } = new St7Register();
        public static TfRegister Tf { get; } = new TfRegister();
        public static VifRegister Vif { get; } = new VifRegister();
        public static VipRegister Vip { get; } = new VipRegister();

        /// <summary>
        ///     Gets all registers.
        /// </summary>
        /// <value>All registers.</value>
        public static Register[] X64 { get; }

        public abstract int? X64Index { get; }
        public abstract int? X64NumBits { get; }

        /// <summary>
        ///     Gets the X86.
        /// </summary>
        /// <value>The X86.</value>
        public static Register[] X86 { get; }

        public abstract int? X86Index { get; }

        /// <summary>
        ///     Gets the number bits for the register, e.g. 32, 64.
        /// </summary>
        /// <value>The number bits.</value>
        public abstract int? X86NumBits { get; }

        public static Xmm0Register Xmm0 { get; } = new Xmm0Register();
        public static Xmm0hRegister Xmm0h { get; } = new Xmm0hRegister();
        public static Xmm0lRegister Xmm0l { get; } = new Xmm0lRegister();
        public static Xmm1Register Xmm1 { get; } = new Xmm1Register();
        public static Xmm10Register Xmm10 { get; } = new Xmm10Register();
        public static Xmm10hRegister Xmm10h { get; } = new Xmm10hRegister();
        public static Xmm10lRegister Xmm10l { get; } = new Xmm10lRegister();
        public static Xmm11Register Xmm11 { get; } = new Xmm11Register();
        public static Xmm11hRegister Xmm11h { get; } = new Xmm11hRegister();
        public static Xmm11lRegister Xmm11l { get; } = new Xmm11lRegister();
        public static Xmm12Register Xmm12 { get; } = new Xmm12Register();
        public static Xmm12hRegister Xmm12h { get; } = new Xmm12hRegister();
        public static Xmm12lRegister Xmm12l { get; } = new Xmm12lRegister();
        public static Xmm13Register Xmm13 { get; } = new Xmm13Register();
        public static Xmm13hRegister Xmm13h { get; } = new Xmm13hRegister();
        public static Xmm13lRegister Xmm13l { get; } = new Xmm13lRegister();
        public static Xmm14Register Xmm14 { get; } = new Xmm14Register();
        public static Xmm14hRegister Xmm14h { get; } = new Xmm14hRegister();
        public static Xmm14lRegister Xmm14l { get; } = new Xmm14lRegister();
        public static Xmm15Register Xmm15 { get; } = new Xmm15Register();
        public static Xmm15hRegister Xmm15h { get; } = new Xmm15hRegister();
        public static Xmm15lRegister Xmm15l { get; } = new Xmm15lRegister();
        public static Xmm1hRegister Xmm1h { get; } = new Xmm1hRegister();
        public static Xmm1lRegister Xmm1l { get; } = new Xmm1lRegister();
        public static Xmm2Register Xmm2 { get; } = new Xmm2Register();
        public static Xmm2hRegister Xmm2h { get; } = new Xmm2hRegister();
        public static Xmm2lRegister Xmm2l { get; } = new Xmm2lRegister();
        public static Xmm3Register Xmm3 { get; } = new Xmm3Register();
        public static Xmm3hRegister Xmm3h { get; } = new Xmm3hRegister();
        public static Xmm3lRegister Xmm3l { get; } = new Xmm3lRegister();
        public static Xmm4Register Xmm4 { get; } = new Xmm4Register();
        public static Xmm4hRegister Xmm4h { get; } = new Xmm4hRegister();
        public static Xmm4lRegister Xmm4l { get; } = new Xmm4lRegister();
        public static Xmm5Register Xmm5 { get; } = new Xmm5Register();
        public static Xmm5hRegister Xmm5h { get; } = new Xmm5hRegister();
        public static Xmm5lRegister Xmm5l { get; } = new Xmm5lRegister();
        public static Xmm6Register Xmm6 { get; } = new Xmm6Register();
        public static Xmm6hRegister Xmm6h { get; } = new Xmm6hRegister();
        public static Xmm6lRegister Xmm6l { get; } = new Xmm6lRegister();
        public static Xmm7Register Xmm7 { get; } = new Xmm7Register();
        public static Xmm7hRegister Xmm7h { get; } = new Xmm7hRegister();
        public static Xmm7lRegister Xmm7l { get; } = new Xmm7lRegister();
        public static Xmm8Register Xmm8 { get; } = new Xmm8Register();
        public static Xmm8hRegister Xmm8h { get; } = new Xmm8hRegister();
        public static Xmm8lRegister Xmm8l { get; } = new Xmm8lRegister();
        public static Xmm9Register Xmm9 { get; } = new Xmm9Register();
        public static Xmm9hRegister Xmm9h { get; } = new Xmm9hRegister();
        public static Xmm9lRegister Xmm9l { get; } = new Xmm9lRegister();
        public static Ymm0Register Ymm0 { get; } = new Ymm0Register();
        public static Ymm0hRegister Ymm0h { get; } = new Ymm0hRegister();
        public static Ymm0lRegister Ymm0l { get; } = new Ymm0lRegister();
        public static Ymm1Register Ymm1 { get; } = new Ymm1Register();
        public static Ymm10Register Ymm10 { get; } = new Ymm10Register();
        public static Ymm10hRegister Ymm10h { get; } = new Ymm10hRegister();
        public static Ymm10lRegister Ymm10l { get; } = new Ymm10lRegister();
        public static Ymm11Register Ymm11 { get; } = new Ymm11Register();
        public static Ymm11hRegister Ymm11h { get; } = new Ymm11hRegister();
        public static Ymm11lRegister Ymm11l { get; } = new Ymm11lRegister();
        public static Ymm12Register Ymm12 { get; } = new Ymm12Register();
        public static Ymm12hRegister Ymm12h { get; } = new Ymm12hRegister();
        public static Ymm12lRegister Ymm12l { get; } = new Ymm12lRegister();
        public static Ymm13Register Ymm13 { get; } = new Ymm13Register();
        public static Ymm13hRegister Ymm13h { get; } = new Ymm13hRegister();
        public static Ymm13lRegister Ymm13l { get; } = new Ymm13lRegister();
        public static Ymm14Register Ymm14 { get; } = new Ymm14Register();
        public static Ymm14hRegister Ymm14h { get; } = new Ymm14hRegister();
        public static Ymm14lRegister Ymm14l { get; } = new Ymm14lRegister();
        public static Ymm15Register Ymm15 { get; } = new Ymm15Register();
        public static Ymm15hRegister Ymm15h { get; } = new Ymm15hRegister();
        public static Ymm15lRegister Ymm15l { get; } = new Ymm15lRegister();
        public static Ymm1hRegister Ymm1h { get; } = new Ymm1hRegister();
        public static Ymm1lRegister Ymm1l { get; } = new Ymm1lRegister();
        public static Ymm2Register Ymm2 { get; } = new Ymm2Register();
        public static Ymm2hRegister Ymm2h { get; } = new Ymm2hRegister();
        public static Ymm2lRegister Ymm2l { get; } = new Ymm2lRegister();
        public static Ymm3Register Ymm3 { get; } = new Ymm3Register();
        public static Ymm3HRegister Ymm3h { get; } = new Ymm3HRegister();
        public static Ymm3lRegister Ymm3l { get; } = new Ymm3lRegister();
        public static Ymm4Register Ymm4 { get; } = new Ymm4Register();
        public static Ymm4hRegister Ymm4h { get; } = new Ymm4hRegister();
        public static Ymm4lRegister Ymm4l { get; } = new Ymm4lRegister();
        public static Ymm5Register Ymm5 { get; } = new Ymm5Register();
        public static Ymm5hRegister Ymm5h { get; } = new Ymm5hRegister();
        public static Ymm5lRegister Ymm5l { get; } = new Ymm5lRegister();
        public static Ymm6Register Ymm6 { get; } = new Ymm6Register();
        public static Ymm6hRegister Ymm6h { get; } = new Ymm6hRegister();
        public static Ymm6lRegister Ymm6l { get; } = new Ymm6lRegister();
        public static Ymm7Register Ymm7 { get; } = new Ymm7Register();
        public static Ymm7hRegister Ymm7h { get; } = new Ymm7hRegister();
        public static Ymm7lRegister Ymm7l { get; } = new Ymm7lRegister();
        public static Ymm8Register Ymm8 { get; } = new Ymm8Register();
        public static Ymm8hRegister Ymm8h { get; } = new Ymm8hRegister();
        public static Ymm8lRegister Ymm8l { get; } = new Ymm8lRegister();
        public static Ymm9Register Ymm9 { get; } = new Ymm9Register();
        public static Ymm9hRegister Ymm9h { get; } = new Ymm9hRegister();
        public static Ymm9lRegister Ymm9l { get; } = new Ymm9lRegister();
        public static ZfRegister Zf { get; } = new ZfRegister();
    }
}