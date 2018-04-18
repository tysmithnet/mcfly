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

namespace McFly.Core
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
                Xmm10, Xmm11, Xmm12, Xmm13, Xmm14, Xmm15, Xmm0_0, Xmm0_1, Xmm0_2, Xmm0_3, Xmm1_0, Xmm1_1, Xmm1_2,
                Xmm1_3, Xmm2_0, Xmm2_1, Xmm2_2, Xmm2_3, Xmm3_0, Xmm3_1, Xmm3_2, Xmm3_3, Xmm4_0, Xmm4_1, Xmm4_2, Xmm4_3,
                Xmm5_0, Xmm5_1, Xmm5_2, Xmm5_3, Xmm6_0, Xmm6_1, Xmm6_2, Xmm6_3, Xmm7_0, Xmm7_1, Xmm7_2, Xmm7_3, Xmm8_0,
                Xmm8_1, Xmm8_2, Xmm8_3, Xmm9_0, Xmm9_1, Xmm9_2, Xmm9_3, Xmm10_0, Xmm10_1, Xmm10_2, Xmm10_3, Xmm11_0,
                Xmm11_1, Xmm11_2, Xmm11_3, Xmm12_0, Xmm12_1, Xmm12_2, Xmm12_3, Xmm13_0, Xmm13_1, Xmm13_2, Xmm13_3,
                Xmm14_0, Xmm14_1, Xmm14_2, Xmm14_3, Xmm15_0, Xmm15_1, Xmm15_2, Xmm15_3, Xmm0l, Xmm1l, Xmm2l, Xmm3l,
                Xmm4l, Xmm5l, Xmm6l, Xmm7l, Xmm8l, Xmm9l, Xmm10l, Xmm11l, Xmm12l, Xmm13l, Xmm14l, Xmm15l, Xmm0h, Xmm1h,
                Xmm2h, Xmm3h, Xmm4h, Xmm5h, Xmm6h, Xmm7h, Xmm8h, Xmm9h, Xmm10h, Xmm11h, Xmm12h, Xmm13h, Xmm14h, Xmm15h,
                Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Ymm8, Ymm9, Ymm10, Ymm11, Ymm12, Ymm13, Ymm14, Ymm15,
                Ymm0_0, Ymm0_1, Ymm0_2, Ymm0_3, Ymm1_0, Ymm1_1, Ymm1_2, Ymm1_3, Ymm2_0, Ymm2_1, Ymm2_2, Ymm2_3, Ymm3_0,
                Ymm3_1, Ymm3_2, Ymm3_3, Ymm4_0, Ymm4_1, Ymm4_2, Ymm4_3, Ymm5_0, Ymm5_1, Ymm5_2, Ymm5_3, Ymm6_0, Ymm6_1,
                Ymm6_2, Ymm6_3, Ymm7_0, Ymm7_1, Ymm7_2, Ymm7_3, Ymm8_0, Ymm8_1, Ymm8_2, Ymm8_3, Ymm9_0, Ymm9_1, Ymm9_2,
                Ymm9_3, Ymm10_0, Ymm10_1, Ymm10_2, Ymm10_3, Ymm11_0, Ymm11_1, Ymm11_2, Ymm11_3, Ymm12_0, Ymm12_1,
                Ymm12_2, Ymm12_3, Ymm13_0, Ymm13_1, Ymm13_2, Ymm13_3, Ymm14_0, Ymm14_1, Ymm14_2, Ymm14_3, Ymm15_0,
                Ymm15_1, Ymm15_2, Ymm15_3, Ymm0l, Ymm1l, Ymm2l, Ymm3l, Ymm4l, Ymm5l, Ymm6l, Ymm7l, Ymm8l, Ymm9l, Ymm10l,
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
                Xmm6h, Xmm7h, Xmm0_0, Xmm0_1, Xmm0_2, Xmm0_3, Xmm1_0, Xmm1_1, Xmm1_2, Xmm1_3, Xmm2_0, Xmm2_1, Xmm2_2,
                Xmm2_3, Xmm3_0, Xmm3_1, Xmm3_2, Xmm3_3, Xmm4_0, Xmm4_1, Xmm4_2, Xmm4_3, Xmm5_0, Xmm5_1, Xmm5_2, Xmm5_3,
                Xmm6_0, Xmm6_1, Xmm6_2, Xmm6_3, Xmm7_0, Xmm7_1, Xmm7_2, Xmm7_3, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5,
                Ymm6, Ymm7, Ymm0l, Ymm1l, Ymm2l, Ymm3l, Ymm4l, Ymm5l, Ymm6l, Ymm7l, Ymm0h, Ymm1h, Ymm2h, Ymm3h, Ymm4h,
                Ymm5h, Ymm6h, Ymm7h, Ymm0_0, Ymm0_1, Ymm0_2, Ymm0_3, Ymm1_0, Ymm1_1, Ymm1_2, Ymm1_3, Ymm2_0, Ymm2_1,
                Ymm2_2, Ymm2_3, Ymm3_0, Ymm3_1, Ymm3_2, Ymm3_3, Ymm4_0, Ymm4_1, Ymm4_2, Ymm4_3, Ymm5_0, Ymm5_1, Ymm5_2,
                Ymm5_3, Ymm6_0, Ymm6_1, Ymm6_2, Ymm6_3, Ymm7_0, Ymm7_1, Ymm7_2, Ymm7_3
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
        public static Xmm0_0Register Xmm0_0 { get; } = new Xmm0_0Register();
        public static Xmm0_1Register Xmm0_1 { get; } = new Xmm0_1Register();
        public static Xmm0_2Register Xmm0_2 { get; } = new Xmm0_2Register();
        public static Xmm0_3Register Xmm0_3 { get; } = new Xmm0_3Register();
        public static Xmm0hRegister Xmm0h { get; } = new Xmm0hRegister();
        public static Xmm0lRegister Xmm0l { get; } = new Xmm0lRegister();
        public static Xmm1Register Xmm1 { get; } = new Xmm1Register();
        public static Xmm1_0Register Xmm1_0 { get; } = new Xmm1_0Register();
        public static Xmm1_1Register Xmm1_1 { get; } = new Xmm1_1Register();
        public static Xmm1_2Register Xmm1_2 { get; } = new Xmm1_2Register();
        public static Xmm1_3Register Xmm1_3 { get; } = new Xmm1_3Register();
        public static Xmm10Register Xmm10 { get; } = new Xmm10Register();
        public static Xmm10_0Register Xmm10_0 { get; } = new Xmm10_0Register();
        public static Xmm10_1Register Xmm10_1 { get; } = new Xmm10_1Register();
        public static Xmm10_2Register Xmm10_2 { get; } = new Xmm10_2Register();
        public static Xmm10_3Register Xmm10_3 { get; } = new Xmm10_3Register();
        public static Xmm10hRegister Xmm10h { get; } = new Xmm10hRegister();
        public static Xmm10lRegister Xmm10l { get; } = new Xmm10lRegister();
        public static Xmm11Register Xmm11 { get; } = new Xmm11Register();
        public static Xmm11_0Register Xmm11_0 { get; } = new Xmm11_0Register();
        public static Xmm11_1Register Xmm11_1 { get; } = new Xmm11_1Register();
        public static Xmm11_2Register Xmm11_2 { get; } = new Xmm11_2Register();
        public static Xmm11_3Register Xmm11_3 { get; } = new Xmm11_3Register();
        public static Xmm11hRegister Xmm11h { get; } = new Xmm11hRegister();
        public static Xmm11lRegister Xmm11l { get; } = new Xmm11lRegister();
        public static Xmm12Register Xmm12 { get; } = new Xmm12Register();
        public static Xmm12_0Register Xmm12_0 { get; } = new Xmm12_0Register();
        public static Xmm12_1Register Xmm12_1 { get; } = new Xmm12_1Register();
        public static Xmm12_2Register Xmm12_2 { get; } = new Xmm12_2Register();
        public static Xmm12_3Register Xmm12_3 { get; } = new Xmm12_3Register();
        public static Xmm12hRegister Xmm12h { get; } = new Xmm12hRegister();
        public static Xmm12lRegister Xmm12l { get; } = new Xmm12lRegister();
        public static Xmm13Register Xmm13 { get; } = new Xmm13Register();
        public static Xmm13_0Register Xmm13_0 { get; } = new Xmm13_0Register();
        public static Xmm13_1Register Xmm13_1 { get; } = new Xmm13_1Register();
        public static Xmm13_2Register Xmm13_2 { get; } = new Xmm13_2Register();
        public static Xmm13_3Register Xmm13_3 { get; } = new Xmm13_3Register();
        public static Xmm13hRegister Xmm13h { get; } = new Xmm13hRegister();
        public static Xmm13lRegister Xmm13l { get; } = new Xmm13lRegister();
        public static Xmm14Register Xmm14 { get; } = new Xmm14Register();
        public static Xmm14_0Register Xmm14_0 { get; } = new Xmm14_0Register();
        public static Xmm14_1Register Xmm14_1 { get; } = new Xmm14_1Register();
        public static Xmm14_2Register Xmm14_2 { get; } = new Xmm14_2Register();
        public static Xmm14_3Register Xmm14_3 { get; } = new Xmm14_3Register();
        public static Xmm14hRegister Xmm14h { get; } = new Xmm14hRegister();
        public static Xmm14lRegister Xmm14l { get; } = new Xmm14lRegister();
        public static Xmm15Register Xmm15 { get; } = new Xmm15Register();
        public static Xmm15_0Register Xmm15_0 { get; } = new Xmm15_0Register();
        public static Xmm15_1Register Xmm15_1 { get; } = new Xmm15_1Register();
        public static Xmm15_2Register Xmm15_2 { get; } = new Xmm15_2Register();
        public static Xmm15_3Register Xmm15_3 { get; } = new Xmm15_3Register();
        public static Xmm15hRegister Xmm15h { get; } = new Xmm15hRegister();
        public static Xmm15lRegister Xmm15l { get; } = new Xmm15lRegister();
        public static Xmm1hRegister Xmm1h { get; } = new Xmm1hRegister();
        public static Xmm1lRegister Xmm1l { get; } = new Xmm1lRegister();
        public static Xmm2Register Xmm2 { get; } = new Xmm2Register();
        public static Xmm2_0Register Xmm2_0 { get; } = new Xmm2_0Register();
        public static Xmm2_1Register Xmm2_1 { get; } = new Xmm2_1Register();
        public static Xmm2_2Register Xmm2_2 { get; } = new Xmm2_2Register();
        public static Xmm2_3Register Xmm2_3 { get; } = new Xmm2_3Register();
        public static Xmm2hRegister Xmm2h { get; } = new Xmm2hRegister();
        public static Xmm2lRegister Xmm2l { get; } = new Xmm2lRegister();
        public static Xmm3Register Xmm3 { get; } = new Xmm3Register();
        public static Xmm3_0Register Xmm3_0 { get; } = new Xmm3_0Register();
        public static Xmm3_1Register Xmm3_1 { get; } = new Xmm3_1Register();
        public static Xmm3_2Register Xmm3_2 { get; } = new Xmm3_2Register();
        public static Xmm3_3Register Xmm3_3 { get; } = new Xmm3_3Register();
        public static Xmm3hRegister Xmm3h { get; } = new Xmm3hRegister();
        public static Xmm3lRegister Xmm3l { get; } = new Xmm3lRegister();
        public static Xmm4Register Xmm4 { get; } = new Xmm4Register();
        public static Xmm4_0Register Xmm4_0 { get; } = new Xmm4_0Register();
        public static Xmm4_1Register Xmm4_1 { get; } = new Xmm4_1Register();
        public static Xmm4_2Register Xmm4_2 { get; } = new Xmm4_2Register();
        public static Xmm4_3Register Xmm4_3 { get; } = new Xmm4_3Register();
        public static Xmm4hRegister Xmm4h { get; } = new Xmm4hRegister();
        public static Xmm4lRegister Xmm4l { get; } = new Xmm4lRegister();
        public static Xmm5Register Xmm5 { get; } = new Xmm5Register();
        public static Xmm5_0Register Xmm5_0 { get; } = new Xmm5_0Register();
        public static Xmm5_1Register Xmm5_1 { get; } = new Xmm5_1Register();
        public static Xmm5_2Register Xmm5_2 { get; } = new Xmm5_2Register();
        public static Xmm5_3Register Xmm5_3 { get; } = new Xmm5_3Register();
        public static Xmm5hRegister Xmm5h { get; } = new Xmm5hRegister();
        public static Xmm5lRegister Xmm5l { get; } = new Xmm5lRegister();
        public static Xmm6Register Xmm6 { get; } = new Xmm6Register();
        public static Xmm6_0Register Xmm6_0 { get; } = new Xmm6_0Register();
        public static Xmm6_1Register Xmm6_1 { get; } = new Xmm6_1Register();
        public static Xmm6_2Register Xmm6_2 { get; } = new Xmm6_2Register();
        public static Xmm6_3Register Xmm6_3 { get; } = new Xmm6_3Register();
        public static Xmm6hRegister Xmm6h { get; } = new Xmm6hRegister();
        public static Xmm6lRegister Xmm6l { get; } = new Xmm6lRegister();
        public static Xmm7Register Xmm7 { get; } = new Xmm7Register();
        public static Xmm7_0Register Xmm7_0 { get; } = new Xmm7_0Register();
        public static Xmm7_1Register Xmm7_1 { get; } = new Xmm7_1Register();
        public static Xmm7_2Register Xmm7_2 { get; } = new Xmm7_2Register();
        public static Xmm7_3Register Xmm7_3 { get; } = new Xmm7_3Register();
        public static Xmm7hRegister Xmm7h { get; } = new Xmm7hRegister();
        public static Xmm7lRegister Xmm7l { get; } = new Xmm7lRegister();
        public static Xmm8Register Xmm8 { get; } = new Xmm8Register();
        public static Xmm8_0Register Xmm8_0 { get; } = new Xmm8_0Register();
        public static Xmm8_1Register Xmm8_1 { get; } = new Xmm8_1Register();
        public static Xmm8_2Register Xmm8_2 { get; } = new Xmm8_2Register();
        public static Xmm8_3Register Xmm8_3 { get; } = new Xmm8_3Register();
        public static Xmm8hRegister Xmm8h { get; } = new Xmm8hRegister();
        public static Xmm8lRegister Xmm8l { get; } = new Xmm8lRegister();
        public static Xmm9Register Xmm9 { get; } = new Xmm9Register();
        public static Xmm9_0Register Xmm9_0 { get; } = new Xmm9_0Register();
        public static Xmm9_1Register Xmm9_1 { get; } = new Xmm9_1Register();
        public static Xmm9_2Register Xmm9_2 { get; } = new Xmm9_2Register();
        public static Xmm9_3Register Xmm9_3 { get; } = new Xmm9_3Register();
        public static Xmm9hRegister Xmm9h { get; } = new Xmm9hRegister();
        public static Xmm9lRegister Xmm9l { get; } = new Xmm9lRegister();
        public static Ymm0Register Ymm0 { get; } = new Ymm0Register();
        public static Ymm0_0Register Ymm0_0 { get; } = new Ymm0_0Register();
        public static Ymm0_1Register Ymm0_1 { get; } = new Ymm0_1Register();
        public static Ymm0_2Register Ymm0_2 { get; } = new Ymm0_2Register();
        public static Ymm0_3Register Ymm0_3 { get; } = new Ymm0_3Register();
        public static Ymm0hRegister Ymm0h { get; } = new Ymm0hRegister();
        public static Ymm0lRegister Ymm0l { get; } = new Ymm0lRegister();
        public static Ymm1Register Ymm1 { get; } = new Ymm1Register();
        public static Ymm1_0Register Ymm1_0 { get; } = new Ymm1_0Register();
        public static Ymm1_1Register Ymm1_1 { get; } = new Ymm1_1Register();
        public static Ymm1_2Register Ymm1_2 { get; } = new Ymm1_2Register();
        public static Ymm1_3Register Ymm1_3 { get; } = new Ymm1_3Register();
        public static Ymm10Register Ymm10 { get; } = new Ymm10Register();
        public static Ymm10_0Register Ymm10_0 { get; } = new Ymm10_0Register();
        public static Ymm10_1Register Ymm10_1 { get; } = new Ymm10_1Register();
        public static Ymm10_2Register Ymm10_2 { get; } = new Ymm10_2Register();
        public static Ymm10_3Register Ymm10_3 { get; } = new Ymm10_3Register();
        public static Ymm10hRegister Ymm10h { get; } = new Ymm10hRegister();
        public static Ymm10lRegister Ymm10l { get; } = new Ymm10lRegister();
        public static Ymm11Register Ymm11 { get; } = new Ymm11Register();
        public static Ymm11_0Register Ymm11_0 { get; } = new Ymm11_0Register();
        public static Ymm11_1Register Ymm11_1 { get; } = new Ymm11_1Register();
        public static Ymm11_2Register Ymm11_2 { get; } = new Ymm11_2Register();
        public static Ymm11_3Register Ymm11_3 { get; } = new Ymm11_3Register();
        public static Ymm11hRegister Ymm11h { get; } = new Ymm11hRegister();
        public static Ymm11lRegister Ymm11l { get; } = new Ymm11lRegister();
        public static Ymm12Register Ymm12 { get; } = new Ymm12Register();
        public static Ymm12_0Register Ymm12_0 { get; } = new Ymm12_0Register();
        public static Ymm12_1Register Ymm12_1 { get; } = new Ymm12_1Register();
        public static Ymm12_2Register Ymm12_2 { get; } = new Ymm12_2Register();
        public static Ymm12_3Register Ymm12_3 { get; } = new Ymm12_3Register();
        public static Ymm12hRegister Ymm12h { get; } = new Ymm12hRegister();
        public static Ymm12lRegister Ymm12l { get; } = new Ymm12lRegister();
        public static Ymm13Register Ymm13 { get; } = new Ymm13Register();
        public static Ymm13_0Register Ymm13_0 { get; } = new Ymm13_0Register();
        public static Ymm13_1Register Ymm13_1 { get; } = new Ymm13_1Register();
        public static Ymm13_2Register Ymm13_2 { get; } = new Ymm13_2Register();
        public static Ymm13_3Register Ymm13_3 { get; } = new Ymm13_3Register();
        public static Ymm13hRegister Ymm13h { get; } = new Ymm13hRegister();
        public static Ymm13lRegister Ymm13l { get; } = new Ymm13lRegister();
        public static Ymm14Register Ymm14 { get; } = new Ymm14Register();
        public static Ymm14_0Register Ymm14_0 { get; } = new Ymm14_0Register();
        public static Ymm14_1Register Ymm14_1 { get; } = new Ymm14_1Register();
        public static Ymm14_2Register Ymm14_2 { get; } = new Ymm14_2Register();
        public static Ymm14_3Register Ymm14_3 { get; } = new Ymm14_3Register();
        public static Ymm14hRegister Ymm14h { get; } = new Ymm14hRegister();
        public static Ymm14lRegister Ymm14l { get; } = new Ymm14lRegister();
        public static Ymm15Register Ymm15 { get; } = new Ymm15Register();
        public static Ymm15_0Register Ymm15_0 { get; } = new Ymm15_0Register();
        public static Ymm15_1Register Ymm15_1 { get; } = new Ymm15_1Register();
        public static Ymm15_2Register Ymm15_2 { get; } = new Ymm15_2Register();
        public static Ymm15_3Register Ymm15_3 { get; } = new Ymm15_3Register();
        public static Ymm15hRegister Ymm15h { get; } = new Ymm15hRegister();
        public static Ymm15lRegister Ymm15l { get; } = new Ymm15lRegister();
        public static Ymm1hRegister Ymm1h { get; } = new Ymm1hRegister();
        public static Ymm1lRegister Ymm1l { get; } = new Ymm1lRegister();
        public static Ymm2Register Ymm2 { get; } = new Ymm2Register();
        public static Ymm2_0Register Ymm2_0 { get; } = new Ymm2_0Register();
        public static Ymm2_1Register Ymm2_1 { get; } = new Ymm2_1Register();
        public static Ymm2_2Register Ymm2_2 { get; } = new Ymm2_2Register();
        public static Ymm2_3Register Ymm2_3 { get; } = new Ymm2_3Register();
        public static Ymm2hRegister Ymm2h { get; } = new Ymm2hRegister();
        public static Ymm2lRegister Ymm2l { get; } = new Ymm2lRegister();
        public static Ymm3Register Ymm3 { get; } = new Ymm3Register();
        public static Ymm3_0Register Ymm3_0 { get; } = new Ymm3_0Register();
        public static Ymm3_1Register Ymm3_1 { get; } = new Ymm3_1Register();
        public static Ymm3_2Register Ymm3_2 { get; } = new Ymm3_2Register();
        public static Ymm3_3Register Ymm3_3 { get; } = new Ymm3_3Register();
        public static Ymm3hRegister Ymm3h { get; } = new Ymm3hRegister();
        public static Ymm3lRegister Ymm3l { get; } = new Ymm3lRegister();
        public static Ymm4Register Ymm4 { get; } = new Ymm4Register();
        public static Ymm4_0Register Ymm4_0 { get; } = new Ymm4_0Register();
        public static Ymm4_1Register Ymm4_1 { get; } = new Ymm4_1Register();
        public static Ymm4_2Register Ymm4_2 { get; } = new Ymm4_2Register();
        public static Ymm4_3Register Ymm4_3 { get; } = new Ymm4_3Register();
        public static Ymm4hRegister Ymm4h { get; } = new Ymm4hRegister();
        public static Ymm4lRegister Ymm4l { get; } = new Ymm4lRegister();
        public static Ymm5Register Ymm5 { get; } = new Ymm5Register();
        public static Ymm5_0Register Ymm5_0 { get; } = new Ymm5_0Register();
        public static Ymm5_1Register Ymm5_1 { get; } = new Ymm5_1Register();
        public static Ymm5_2Register Ymm5_2 { get; } = new Ymm5_2Register();
        public static Ymm5_3Register Ymm5_3 { get; } = new Ymm5_3Register();
        public static Ymm5hRegister Ymm5h { get; } = new Ymm5hRegister();
        public static Ymm5lRegister Ymm5l { get; } = new Ymm5lRegister();
        public static Ymm6Register Ymm6 { get; } = new Ymm6Register();
        public static Ymm6_0Register Ymm6_0 { get; } = new Ymm6_0Register();
        public static Ymm6_1Register Ymm6_1 { get; } = new Ymm6_1Register();
        public static Ymm6_2Register Ymm6_2 { get; } = new Ymm6_2Register();
        public static Ymm6_3Register Ymm6_3 { get; } = new Ymm6_3Register();
        public static Ymm6hRegister Ymm6h { get; } = new Ymm6hRegister();
        public static Ymm6lRegister Ymm6l { get; } = new Ymm6lRegister();
        public static Ymm7Register Ymm7 { get; } = new Ymm7Register();
        public static Ymm7_0Register Ymm7_0 { get; } = new Ymm7_0Register();
        public static Ymm7_1Register Ymm7_1 { get; } = new Ymm7_1Register();
        public static Ymm7_2Register Ymm7_2 { get; } = new Ymm7_2Register();
        public static Ymm7_3Register Ymm7_3 { get; } = new Ymm7_3Register();
        public static Ymm7hRegister Ymm7h { get; } = new Ymm7hRegister();
        public static Ymm7lRegister Ymm7l { get; } = new Ymm7lRegister();
        public static Ymm8Register Ymm8 { get; } = new Ymm8Register();
        public static Ymm8_0Register Ymm8_0 { get; } = new Ymm8_0Register();
        public static Ymm8_1Register Ymm8_1 { get; } = new Ymm8_1Register();
        public static Ymm8_2Register Ymm8_2 { get; } = new Ymm8_2Register();
        public static Ymm8_3Register Ymm8_3 { get; } = new Ymm8_3Register();
        public static Ymm8hRegister Ymm8h { get; } = new Ymm8hRegister();
        public static Ymm8lRegister Ymm8l { get; } = new Ymm8lRegister();
        public static Ymm9Register Ymm9 { get; } = new Ymm9Register();
        public static Ymm9_0Register Ymm9_0 { get; } = new Ymm9_0Register();
        public static Ymm9_1Register Ymm9_1 { get; } = new Ymm9_1Register();
        public static Ymm9_2Register Ymm9_2 { get; } = new Ymm9_2Register();
        public static Ymm9_3Register Ymm9_3 { get; } = new Ymm9_3Register();
        public static Ymm9hRegister Ymm9h { get; } = new Ymm9hRegister();
        public static Ymm9lRegister Ymm9l { get; } = new Ymm9lRegister();
        public static ZfRegister Zf { get; } = new ZfRegister();

        public class AfRegister : Register
        {
            public override string Name { get; } = "af";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 340;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 80;
            public override int? X86NumBits { get; } = 32;
        }

        public class AhRegister : Register
        {
            public override string Name { get; } = "ah";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 329;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 39;
            public override int? X86NumBits { get; } = 32;
        }

        public class AlRegister : Register
        {
            public override string Name { get; } = "al";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 313;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 35;
            public override int? X86NumBits { get; } = 32;
        }

        public class AxRegister : Register
        {
            public override string Name { get; } = "ax";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 295;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 27;
            public override int? X86NumBits { get; } = 32;
        }

        public class BhRegister : Register
        {
            public override string Name { get; } = "bh";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 332;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 36;
            public override int? X86NumBits { get; } = 32;
        }

        public class BlRegister : Register
        {
            public override string Name { get; } = "bl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 316;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 32;
            public override int? X86NumBits { get; } = 32;
        }

        public class BplRegister : Register
        {
            public override string Name { get; } = "bpl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 318;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class BpRegister : Register
        {
            public override string Name { get; } = "bp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 300;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 28;
            public override int? X86NumBits { get; } = 32;
        }

        public class BrfromRegister : Register
        {
            public override string Name { get; } = "brfrom";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 276;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class BrtoRegister : Register
        {
            public override string Name { get; } = "brto";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 277;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class BxRegister : Register
        {
            public override string Name { get; } = "bx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 298;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 24;
            public override int? X86NumBits { get; } = 32;
        }

        public class CfRegister : Register
        {
            public override string Name { get; } = "cf";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 342;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 82;
            public override int? X86NumBits { get; } = 32;
        }

        public class ChRegister : Register
        {
            public override string Name { get; } = "ch";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 330;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 38;
            public override int? X86NumBits { get; } = 32;
        }

        public class ClRegister : Register
        {
            public override string Name { get; } = "cl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 314;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 34;
            public override int? X86NumBits { get; } = 32;
        }

        public class CsRegister : Register
        {
            public override string Name { get; } = "cs";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 18;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 12;
            public override int? X86NumBits { get; } = 32;
        }

        public class CxRegister : Register
        {
            public override string Name { get; } = "cx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 296;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 26;
            public override int? X86NumBits { get; } = 32;
        }

        public class DfRegister : Register
        {
            public override string Name { get; } = "df";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 335;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 75;
            public override int? X86NumBits { get; } = 32;
        }

        public class DhRegister : Register
        {
            public override string Name { get; } = "dh";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 331;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 37;
            public override int? X86NumBits { get; } = 32;
        }

        public class DilRegister : Register
        {
            public override string Name { get; } = "dil";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 320;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class DiRegister : Register
        {
            public override string Name { get; } = "di";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 302;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 22;
            public override int? X86NumBits { get; } = 32;
        }

        public class DlRegister : Register
        {
            public override string Name { get; } = "dl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 315;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 33;
            public override int? X86NumBits { get; } = 32;
        }

        public class Dr0Register : Register
        {
            public override string Name { get; } = "dr0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 24;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 16;
            public override int? X86NumBits { get; } = 32;
        }

        public class Dr1Register : Register
        {
            public override string Name { get; } = "dr1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 25;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 17;
            public override int? X86NumBits { get; } = 32;
        }

        public class Dr2Register : Register
        {
            public override string Name { get; } = "dr2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 26;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 18;
            public override int? X86NumBits { get; } = 32;
        }

        public class Dr3Register : Register
        {
            public override string Name { get; } = "dr3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 27;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 19;
            public override int? X86NumBits { get; } = 32;
        }

        public class Dr6Register : Register
        {
            public override string Name { get; } = "dr6";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 28;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 20;
            public override int? X86NumBits { get; } = 32;
        }

        public class Dr7Register : Register
        {
            public override string Name { get; } = "dr7";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 29;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 21;
            public override int? X86NumBits { get; } = 32;
        }

        public class DsRegister : Register
        {
            public override string Name { get; } = "ds";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 19;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 3;
            public override int? X86NumBits { get; } = 32;
        }

        public class DxRegister : Register
        {
            public override string Name { get; } = "dx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 297;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 25;
            public override int? X86NumBits { get; } = 32;
        }

        public class EaxRegister : Register
        {
            public override string Name { get; } = "eax";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 278;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 9;
            public override int? X86NumBits { get; } = 32;
        }

        public class EbpRegister : Register
        {
            public override string Name { get; } = "ebp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 283;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 10;
            public override int? X86NumBits { get; } = 32;
        }

        public class EbxRegister : Register
        {
            public override string Name { get; } = "ebx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 281;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 6;
            public override int? X86NumBits { get; } = 32;
        }

        public class EcxRegister : Register
        {
            public override string Name { get; } = "ecx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 279;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 8;
            public override int? X86NumBits { get; } = 32;
        }

        public class EdiRegister : Register
        {
            public override string Name { get; } = "edi";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 285;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 4;
            public override int? X86NumBits { get; } = 32;
        }

        public class EdxRegister : Register
        {
            public override string Name { get; } = "edx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 280;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 7;
            public override int? X86NumBits { get; } = 32;
        }

        public class EflRegister : Register
        {
            public override string Name { get; } = "efl";
            public override int NumBits { get; } = 32;
            public override int? X64Index { get; } = 17;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 13;
            public override int? X86NumBits { get; } = 32;
        }

        public class EipRegister : Register
        {
            public override string Name { get; } = "eip";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 294;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 11;
            public override int? X86NumBits { get; } = 32;
        }

        public class EsiRegister : Register
        {
            public override string Name { get; } = "esi";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 284;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 5;
            public override int? X86NumBits { get; } = 32;
        }

        public class EspRegister : Register
        {
            public override string Name { get; } = "esp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 282;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 14;
            public override int? X86NumBits { get; } = 32;
        }

        public class EsRegister : Register
        {
            public override string Name { get; } = "es";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 20;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 2;
            public override int? X86NumBits { get; } = 32;
        }

        public class ExfromRegister : Register
        {
            public override string Name { get; } = "exfrom";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 274;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class ExtoRegister : Register
        {
            public override string Name { get; } = "exto";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 275;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class FlRegister : Register
        {
            public override string Name { get; } = "fl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 312;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 30;
            public override int? X86NumBits { get; } = 32;
        }

        public class FopcodeRegister : Register
        {
            public override string Name { get; } = "fopcode";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = null;
            public override int? X64NumBits { get; } = null;
            public override int? X86Index { get; } = 43;
            public override int? X86NumBits { get; } = 32;
        }

        public class FpcwRegister : Register
        {
            public override string Name { get; } = "fpcw";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 30;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 40;
            public override int? X86NumBits { get; } = 32;
        }

        public class FpdpRegister : Register
        {
            public override string Name { get; } = "fpdp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = null;
            public override int? X64NumBits { get; } = null;
            public override int? X86Index { get; } = 46;
            public override int? X86NumBits { get; } = 32;
        }

        public class FpdpselRegister : Register
        {
            public override string Name { get; } = "fpdpsel";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = null;
            public override int? X64NumBits { get; } = null;
            public override int? X86Index { get; } = 47;
            public override int? X86NumBits { get; } = 32;
        }

        public class FpipRegister : Register
        {
            public override string Name { get; } = "fpip";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = null;
            public override int? X64NumBits { get; } = null;
            public override int? X86Index { get; } = 44;
            public override int? X86NumBits { get; } = 32;
        }

        public class FpipselRegister : Register
        {
            public override string Name { get; } = "fpipsel";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = null;
            public override int? X64NumBits { get; } = null;
            public override int? X86Index { get; } = 45;
            public override int? X86NumBits { get; } = 32;
        }

        public class FpswRegister : Register
        {
            public override string Name { get; } = "fpsw";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 31;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 41;
            public override int? X86NumBits { get; } = 32;
        }

        public class FptwRegister : Register
        {
            public override string Name { get; } = "fptw";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 32;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 42;
            public override int? X86NumBits { get; } = 32;
        }

        public class FsRegister : Register
        {
            public override string Name { get; } = "fs";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 21;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 1;
            public override int? X86NumBits { get; } = 32;
        }

        public class GsRegister : Register
        {
            public override string Name { get; } = "gs";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 22;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 0;
            public override int? X86NumBits { get; } = 32;
        }

        public class IfRegister : Register
        {
            public override string Name { get; } = "if";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 336;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 76;
            public override int? X86NumBits { get; } = 32;
        }

        public class IoplRegister : Register
        {
            public override string Name { get; } = "iopl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 333;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 73;
            public override int? X86NumBits { get; } = 32;
        }

        public class IpRegister : Register
        {
            public override string Name { get; } = "ip";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 311;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 29;
            public override int? X86NumBits { get; } = 32;
        }

        public class Mm0Register : Register
        {
            public override string Name { get; } = "mm0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 41;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 56;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm1Register : Register
        {
            public override string Name { get; } = "mm1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 42;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 57;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm2Register : Register
        {
            public override string Name { get; } = "mm2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 43;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 58;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm3Register : Register
        {
            public override string Name { get; } = "mm3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 44;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 59;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm4Register : Register
        {
            public override string Name { get; } = "mm4";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 45;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 60;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm5Register : Register
        {
            public override string Name { get; } = "mm5";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 46;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 61;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm6Register : Register
        {
            public override string Name { get; } = "mm6";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 47;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 62;
            public override int? X86NumBits { get; } = 64;
        }

        public class Mm7Register : Register
        {
            public override string Name { get; } = "mm7";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 48;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 63;
            public override int? X86NumBits { get; } = 64;
        }

        public class MxcsrRegister : Register
        {
            public override string Name { get; } = "mxcsr";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 49;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 64;
            public override int? X86NumBits { get; } = 32;
        }

        public class OfRegister : Register
        {
            public override string Name { get; } = "of";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 334;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 74;
            public override int? X86NumBits { get; } = 32;
        }

        public class PfRegister : Register
        {
            public override string Name { get; } = "pf";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 341;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 81;
            public override int? X86NumBits { get; } = 32;
        }

        public class R10bRegister : Register
        {
            public override string Name { get; } = "r10b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 323;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R10dRegister : Register
        {
            public override string Name { get; } = "r10d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 288;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R10Register : Register
        {
            public override string Name { get; } = "r10";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 10;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R10wRegister : Register
        {
            public override string Name { get; } = "r10w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 305;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R11bRegister : Register
        {
            public override string Name { get; } = "r11b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 324;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R11dRegister : Register
        {
            public override string Name { get; } = "r11d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 289;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R11Register : Register
        {
            public override string Name { get; } = "r11";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 11;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R11wRegister : Register
        {
            public override string Name { get; } = "r11w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 306;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R12bRegister : Register
        {
            public override string Name { get; } = "r12b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 325;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R12dRegister : Register
        {
            public override string Name { get; } = "r12d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 290;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R12Register : Register
        {
            public override string Name { get; } = "r12";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 12;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R12wRegister : Register
        {
            public override string Name { get; } = "r12w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 307;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R13bRegister : Register
        {
            public override string Name { get; } = "r13b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 326;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R13dRegister : Register
        {
            public override string Name { get; } = "r13d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 291;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R13Register : Register
        {
            public override string Name { get; } = "r13";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 13;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R13wRegister : Register
        {
            public override string Name { get; } = "r13w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 308;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R14bRegister : Register
        {
            public override string Name { get; } = "r14b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 327;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R14dRegister : Register
        {
            public override string Name { get; } = "r14d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 292;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R14Register : Register
        {
            public override string Name { get; } = "r14";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 14;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R14wRegister : Register
        {
            public override string Name { get; } = "r14w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 309;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R15bRegister : Register
        {
            public override string Name { get; } = "r15b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 328;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R15dRegister : Register
        {
            public override string Name { get; } = "r15d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 293;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R15Register : Register
        {
            public override string Name { get; } = "r15";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 15;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R15wRegister : Register
        {
            public override string Name { get; } = "r15w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 310;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R8bRegister : Register
        {
            public override string Name { get; } = "r8b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 321;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R8dRegister : Register
        {
            public override string Name { get; } = "r8d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 286;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R8Register : Register
        {
            public override string Name { get; } = "r8";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 8;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R8wRegister : Register
        {
            public override string Name { get; } = "r8w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 303;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R9bRegister : Register
        {
            public override string Name { get; } = "r9b";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 322;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R9dRegister : Register
        {
            public override string Name { get; } = "r9d";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 287;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R9Register : Register
        {
            public override string Name { get; } = "r9";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 9;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class R9wRegister : Register
        {
            public override string Name { get; } = "r9w";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 304;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RaxRegister : Register
        {
            public override string Name { get; } = "rax";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 0;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RbpRegister : Register
        {
            public override string Name { get; } = "rbp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 5;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RbxRegister : Register
        {
            public override string Name { get; } = "rbx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 3;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RcxRegister : Register
        {
            public override string Name { get; } = "rcx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 1;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RdiRegister : Register
        {
            public override string Name { get; } = "rdi";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 7;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RdxRegister : Register
        {
            public override string Name { get; } = "rdx";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 2;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RipRegister : Register
        {
            public override string Name { get; } = "rip";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 16;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RsiRegister : Register
        {
            public override string Name { get; } = "rsi";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 6;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class RspRegister : Register
        {
            public override string Name { get; } = "rsp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 4;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class SfRegister : Register
        {
            public override string Name { get; } = "sf";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 338;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 78;
            public override int? X86NumBits { get; } = 32;
        }

        public class SilRegister : Register
        {
            public override string Name { get; } = "sil";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 319;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class SiRegister : Register
        {
            public override string Name { get; } = "si";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 301;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 23;
            public override int? X86NumBits { get; } = 32;
        }

        public class SplRegister : Register
        {
            public override string Name { get; } = "spl";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 317;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class SpRegister : Register
        {
            public override string Name { get; } = "sp";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 299;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 31;
            public override int? X86NumBits { get; } = 32;
        }

        public class SsRegister : Register
        {
            public override string Name { get; } = "ss";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 23;
            public override int? X64NumBits { get; } = 16;
            public override int? X86Index { get; } = 15;
            public override int? X86NumBits { get; } = 32;
        }

        public class St0Register : Register
        {
            public override string Name { get; } = "st0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 33;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 48;
            public override int? X86NumBits { get; } = 80;
        }

        public class St1Register : Register
        {
            public override string Name { get; } = "st1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 34;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 49;
            public override int? X86NumBits { get; } = 80;
        }

        public class St2Register : Register
        {
            public override string Name { get; } = "st2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 35;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 50;
            public override int? X86NumBits { get; } = 80;
        }

        public class St3Register : Register
        {
            public override string Name { get; } = "st3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 36;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 51;
            public override int? X86NumBits { get; } = 80;
        }

        public class St4Register : Register
        {
            public override string Name { get; } = "st4";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 37;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 52;
            public override int? X86NumBits { get; } = 80;
        }

        public class St5Register : Register
        {
            public override string Name { get; } = "st5";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 38;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 53;
            public override int? X86NumBits { get; } = 80;
        }

        public class St6Register : Register
        {
            public override string Name { get; } = "st6";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 39;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 54;
            public override int? X86NumBits { get; } = 80;
        }

        public class St7Register : Register
        {
            public override string Name { get; } = "st7";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 40;
            public override int? X64NumBits { get; } = 80;
            public override int? X86Index { get; } = 55;
            public override int? X86NumBits { get; } = 80;
        }

        public class TfRegister : Register
        {
            public override string Name { get; } = "tf";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 337;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 77;
            public override int? X86NumBits { get; } = 32;
        }

        public class VifRegister : Register
        {
            public override string Name { get; } = "vif";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 344;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 84;
            public override int? X86NumBits { get; } = 32;
        }

        public class VipRegister : Register
        {
            public override string Name { get; } = "vip";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 343;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 83;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm0_0Register : Register
        {
            public override string Name { get; } = "xmm0/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 66;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 101;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm0_1Register : Register
        {
            public override string Name { get; } = "xmm0/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 67;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 102;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm0_2Register : Register
        {
            public override string Name { get; } = "xmm0/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 68;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 103;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm0_3Register : Register
        {
            public override string Name { get; } = "xmm0/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 69;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 104;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm0hRegister : Register
        {
            public override string Name { get; } = "xmm0h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 146;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 93;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm0lRegister : Register
        {
            public override string Name { get; } = "xmm0l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 130;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 85;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm0Register : Register
        {
            public override string Name { get; } = "xmm0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 50;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 65;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm1_0Register : Register
        {
            public override string Name { get; } = "xmm1/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 70;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 105;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm1_1Register : Register
        {
            public override string Name { get; } = "xmm1/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 71;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 106;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm1_2Register : Register
        {
            public override string Name { get; } = "xmm1/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 72;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 107;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm1_3Register : Register
        {
            public override string Name { get; } = "xmm1/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 73;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 108;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm10_0Register : Register
        {
            public override string Name { get; } = "xmm10/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 106;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm10_1Register : Register
        {
            public override string Name { get; } = "xmm10/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 107;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm10_2Register : Register
        {
            public override string Name { get; } = "xmm10/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 108;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm10_3Register : Register
        {
            public override string Name { get; } = "xmm10/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 109;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm10hRegister : Register
        {
            public override string Name { get; } = "xmm10h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 156;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm10lRegister : Register
        {
            public override string Name { get; } = "xmm10l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 140;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm10Register : Register
        {
            public override string Name { get; } = "xmm10";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 60;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11_0Register : Register
        {
            public override string Name { get; } = "xmm11/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 110;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11_1Register : Register
        {
            public override string Name { get; } = "xmm11/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 111;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11_2Register : Register
        {
            public override string Name { get; } = "xmm11/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 112;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11_3Register : Register
        {
            public override string Name { get; } = "xmm11/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 113;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11hRegister : Register
        {
            public override string Name { get; } = "xmm11h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 157;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11lRegister : Register
        {
            public override string Name { get; } = "xmm11l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 141;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm11Register : Register
        {
            public override string Name { get; } = "xmm11";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 61;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12_0Register : Register
        {
            public override string Name { get; } = "xmm12/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 114;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12_1Register : Register
        {
            public override string Name { get; } = "xmm12/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 115;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12_2Register : Register
        {
            public override string Name { get; } = "xmm12/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 116;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12_3Register : Register
        {
            public override string Name { get; } = "xmm12/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 117;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12hRegister : Register
        {
            public override string Name { get; } = "xmm12h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 158;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12lRegister : Register
        {
            public override string Name { get; } = "xmm12l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 142;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm12Register : Register
        {
            public override string Name { get; } = "xmm12";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 62;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13_0Register : Register
        {
            public override string Name { get; } = "xmm13/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 118;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13_1Register : Register
        {
            public override string Name { get; } = "xmm13/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 119;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13_2Register : Register
        {
            public override string Name { get; } = "xmm13/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 120;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13_3Register : Register
        {
            public override string Name { get; } = "xmm13/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 121;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13hRegister : Register
        {
            public override string Name { get; } = "xmm13h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 159;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13lRegister : Register
        {
            public override string Name { get; } = "xmm13l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 143;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm13Register : Register
        {
            public override string Name { get; } = "xmm13";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 63;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14_0Register : Register
        {
            public override string Name { get; } = "xmm14/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 122;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14_1Register : Register
        {
            public override string Name { get; } = "xmm14/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 123;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14_2Register : Register
        {
            public override string Name { get; } = "xmm14/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 124;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14_3Register : Register
        {
            public override string Name { get; } = "xmm14/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 125;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14hRegister : Register
        {
            public override string Name { get; } = "xmm14h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 160;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14lRegister : Register
        {
            public override string Name { get; } = "xmm14l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 144;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm14Register : Register
        {
            public override string Name { get; } = "xmm14";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 64;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15_0Register : Register
        {
            public override string Name { get; } = "xmm15/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 126;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15_1Register : Register
        {
            public override string Name { get; } = "xmm15/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 127;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15_2Register : Register
        {
            public override string Name { get; } = "xmm15/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 128;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15_3Register : Register
        {
            public override string Name { get; } = "xmm15/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 129;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15hRegister : Register
        {
            public override string Name { get; } = "xmm15h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 161;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15lRegister : Register
        {
            public override string Name { get; } = "xmm15l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 145;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm15Register : Register
        {
            public override string Name { get; } = "xmm15";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 65;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm1hRegister : Register
        {
            public override string Name { get; } = "xmm1h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 147;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 94;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm1lRegister : Register
        {
            public override string Name { get; } = "xmm1l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 131;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 86;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm1Register : Register
        {
            public override string Name { get; } = "xmm1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 51;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 66;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm2_0Register : Register
        {
            public override string Name { get; } = "xmm2/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 74;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 109;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm2_1Register : Register
        {
            public override string Name { get; } = "xmm2/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 75;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 110;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm2_2Register : Register
        {
            public override string Name { get; } = "xmm2/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 76;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 111;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm2_3Register : Register
        {
            public override string Name { get; } = "xmm2/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 77;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 112;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm2hRegister : Register
        {
            public override string Name { get; } = "xmm2h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 148;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 95;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm2lRegister : Register
        {
            public override string Name { get; } = "xmm2l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 132;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 87;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm2Register : Register
        {
            public override string Name { get; } = "xmm2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 52;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 67;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm3_0Register : Register
        {
            public override string Name { get; } = "xmm3/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 78;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 113;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm3_1Register : Register
        {
            public override string Name { get; } = "xmm3/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 79;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 114;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm3_2Register : Register
        {
            public override string Name { get; } = "xmm3/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 80;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 115;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm3_3Register : Register
        {
            public override string Name { get; } = "xmm3/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 81;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 116;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm3hRegister : Register
        {
            public override string Name { get; } = "xmm3h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 149;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 96;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm3lRegister : Register
        {
            public override string Name { get; } = "xmm3l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 133;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 88;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm3Register : Register
        {
            public override string Name { get; } = "xmm3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 53;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 68;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm4_0Register : Register
        {
            public override string Name { get; } = "xmm4/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 82;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 117;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm4_1Register : Register
        {
            public override string Name { get; } = "xmm4/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 83;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 118;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm4_2Register : Register
        {
            public override string Name { get; } = "xmm4/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 84;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 119;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm4_3Register : Register
        {
            public override string Name { get; } = "xmm4/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 85;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 120;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm4hRegister : Register
        {
            public override string Name { get; } = "xmm4h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 150;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 97;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm4lRegister : Register
        {
            public override string Name { get; } = "xmm4l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 134;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 89;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm4Register : Register
        {
            public override string Name { get; } = "xmm4";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 54;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 69;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm5_0Register : Register
        {
            public override string Name { get; } = "xmm5/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 86;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 121;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm5_1Register : Register
        {
            public override string Name { get; } = "xmm5/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 87;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 122;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm5_2Register : Register
        {
            public override string Name { get; } = "xmm5/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 88;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 123;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm5_3Register : Register
        {
            public override string Name { get; } = "xmm5/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 89;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 124;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm5hRegister : Register
        {
            public override string Name { get; } = "xmm5h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 151;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 98;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm5lRegister : Register
        {
            public override string Name { get; } = "xmm5l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 135;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 90;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm5Register : Register
        {
            public override string Name { get; } = "xmm5";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 55;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 70;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm6_0Register : Register
        {
            public override string Name { get; } = "xmm6/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 90;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 125;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm6_1Register : Register
        {
            public override string Name { get; } = "xmm6/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 91;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 126;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm6_2Register : Register
        {
            public override string Name { get; } = "xmm6/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 92;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 127;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm6_3Register : Register
        {
            public override string Name { get; } = "xmm6/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 93;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 128;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm6hRegister : Register
        {
            public override string Name { get; } = "xmm6h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 152;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 99;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm6lRegister : Register
        {
            public override string Name { get; } = "xmm6l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 136;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 91;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm6Register : Register
        {
            public override string Name { get; } = "xmm6";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 56;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 71;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm7_0Register : Register
        {
            public override string Name { get; } = "xmm7/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 94;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 129;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm7_1Register : Register
        {
            public override string Name { get; } = "xmm7/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 95;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 130;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm7_2Register : Register
        {
            public override string Name { get; } = "xmm7/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 96;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 131;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm7_3Register : Register
        {
            public override string Name { get; } = "xmm7/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 97;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 132;
            public override int? X86NumBits { get; } = 32;
        }

        public class Xmm7hRegister : Register
        {
            public override string Name { get; } = "xmm7h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 153;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 100;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm7lRegister : Register
        {
            public override string Name { get; } = "xmm7l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 137;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 92;
            public override int? X86NumBits { get; } = 64;
        }

        public class Xmm7Register : Register
        {
            public override string Name { get; } = "xmm7";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 57;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 72;
            public override int? X86NumBits { get; } = 128;
        }

        public class Xmm8_0Register : Register
        {
            public override string Name { get; } = "xmm8/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 98;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm8_1Register : Register
        {
            public override string Name { get; } = "xmm8/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 99;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm8_2Register : Register
        {
            public override string Name { get; } = "xmm8/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 100;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm8_3Register : Register
        {
            public override string Name { get; } = "xmm8/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 101;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm8hRegister : Register
        {
            public override string Name { get; } = "xmm8h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 154;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm8lRegister : Register
        {
            public override string Name { get; } = "xmm8l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 138;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm8Register : Register
        {
            public override string Name { get; } = "xmm8";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 58;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9_0Register : Register
        {
            public override string Name { get; } = "xmm9/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 102;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9_1Register : Register
        {
            public override string Name { get; } = "xmm9/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 103;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9_2Register : Register
        {
            public override string Name { get; } = "xmm9/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 104;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9_3Register : Register
        {
            public override string Name { get; } = "xmm9/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 105;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9hRegister : Register
        {
            public override string Name { get; } = "xmm9h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 155;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9lRegister : Register
        {
            public override string Name { get; } = "xmm9l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 139;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Xmm9Register : Register
        {
            public override string Name { get; } = "xmm9";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 59;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm0_0Register : Register
        {
            public override string Name { get; } = "ymm0/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 178;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 157;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm0_1Register : Register
        {
            public override string Name { get; } = "ymm0/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 179;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 158;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm0_2Register : Register
        {
            public override string Name { get; } = "ymm0/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 180;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 159;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm0_3Register : Register
        {
            public override string Name { get; } = "ymm0/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 181;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 160;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm0hRegister : Register
        {
            public override string Name { get; } = "ymm0h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 258;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 149;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm0lRegister : Register
        {
            public override string Name { get; } = "ymm0l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 242;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 141;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm0Register : Register
        {
            public override string Name { get; } = "ymm0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 162;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 133;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm1_0Register : Register
        {
            public override string Name { get; } = "ymm1/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 182;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 161;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm1_1Register : Register
        {
            public override string Name { get; } = "ymm1/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 183;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 162;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm1_2Register : Register
        {
            public override string Name { get; } = "ymm1/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 184;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 163;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm1_3Register : Register
        {
            public override string Name { get; } = "ymm1/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 185;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 164;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm10_0Register : Register
        {
            public override string Name { get; } = "ymm10/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 218;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm10_1Register : Register
        {
            public override string Name { get; } = "ymm10/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 219;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm10_2Register : Register
        {
            public override string Name { get; } = "ymm10/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 220;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm10_3Register : Register
        {
            public override string Name { get; } = "ymm10/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 221;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm10hRegister : Register
        {
            public override string Name { get; } = "ymm10h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 268;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm10lRegister : Register
        {
            public override string Name { get; } = "ymm10l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 252;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm10Register : Register
        {
            public override string Name { get; } = "ymm10";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 172;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11_0Register : Register
        {
            public override string Name { get; } = "ymm11/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 222;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11_1Register : Register
        {
            public override string Name { get; } = "ymm11/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 223;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11_2Register : Register
        {
            public override string Name { get; } = "ymm11/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 224;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11_3Register : Register
        {
            public override string Name { get; } = "ymm11/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 225;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11hRegister : Register
        {
            public override string Name { get; } = "ymm11h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 269;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11lRegister : Register
        {
            public override string Name { get; } = "ymm11l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 253;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm11Register : Register
        {
            public override string Name { get; } = "ymm11";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 173;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12_0Register : Register
        {
            public override string Name { get; } = "ymm12/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 226;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12_1Register : Register
        {
            public override string Name { get; } = "ymm12/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 227;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12_2Register : Register
        {
            public override string Name { get; } = "ymm12/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 228;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12_3Register : Register
        {
            public override string Name { get; } = "ymm12/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 229;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12hRegister : Register
        {
            public override string Name { get; } = "ymm12h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 270;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12lRegister : Register
        {
            public override string Name { get; } = "ymm12l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 254;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm12Register : Register
        {
            public override string Name { get; } = "ymm12";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 174;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13_0Register : Register
        {
            public override string Name { get; } = "ymm13/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 230;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13_1Register : Register
        {
            public override string Name { get; } = "ymm13/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 231;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13_2Register : Register
        {
            public override string Name { get; } = "ymm13/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 232;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13_3Register : Register
        {
            public override string Name { get; } = "ymm13/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 233;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13hRegister : Register
        {
            public override string Name { get; } = "ymm13h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 271;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13lRegister : Register
        {
            public override string Name { get; } = "ymm13l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 255;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm13Register : Register
        {
            public override string Name { get; } = "ymm13";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 175;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14_0Register : Register
        {
            public override string Name { get; } = "ymm14/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 234;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14_1Register : Register
        {
            public override string Name { get; } = "ymm14/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 235;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14_2Register : Register
        {
            public override string Name { get; } = "ymm14/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 236;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14_3Register : Register
        {
            public override string Name { get; } = "ymm14/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 237;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14hRegister : Register
        {
            public override string Name { get; } = "ymm14h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 272;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14lRegister : Register
        {
            public override string Name { get; } = "ymm14l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 256;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm14Register : Register
        {
            public override string Name { get; } = "ymm14";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 176;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15_0Register : Register
        {
            public override string Name { get; } = "ymm15/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 238;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15_1Register : Register
        {
            public override string Name { get; } = "ymm15/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 239;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15_2Register : Register
        {
            public override string Name { get; } = "ymm15/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 240;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15_3Register : Register
        {
            public override string Name { get; } = "ymm15/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 241;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15hRegister : Register
        {
            public override string Name { get; } = "ymm15h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 273;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15lRegister : Register
        {
            public override string Name { get; } = "ymm15l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 257;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm15Register : Register
        {
            public override string Name { get; } = "ymm15";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 177;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm1hRegister : Register
        {
            public override string Name { get; } = "ymm1h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 259;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 150;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm1lRegister : Register
        {
            public override string Name { get; } = "ymm1l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 243;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 142;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm1Register : Register
        {
            public override string Name { get; } = "ymm1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 163;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 134;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm2_0Register : Register
        {
            public override string Name { get; } = "ymm2/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 186;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 165;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm2_1Register : Register
        {
            public override string Name { get; } = "ymm2/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 187;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 166;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm2_2Register : Register
        {
            public override string Name { get; } = "ymm2/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 188;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 167;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm2_3Register : Register
        {
            public override string Name { get; } = "ymm2/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 189;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 168;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm2hRegister : Register
        {
            public override string Name { get; } = "ymm2h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 260;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 151;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm2lRegister : Register
        {
            public override string Name { get; } = "ymm2l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 244;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 143;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm2Register : Register
        {
            public override string Name { get; } = "ymm2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 164;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 135;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm3_0Register : Register
        {
            public override string Name { get; } = "ymm3/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 190;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 169;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm3_1Register : Register
        {
            public override string Name { get; } = "ymm3/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 191;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 170;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm3_2Register : Register
        {
            public override string Name { get; } = "ymm3/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 192;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 171;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm3_3Register : Register
        {
            public override string Name { get; } = "ymm3/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 193;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 172;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm3hRegister : Register
        {
            public override string Name { get; } = "ymm3h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 261;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 152;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm3lRegister : Register
        {
            public override string Name { get; } = "ymm3l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 245;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 144;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm3Register : Register
        {
            public override string Name { get; } = "ymm3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 165;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 136;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm4_0Register : Register
        {
            public override string Name { get; } = "ymm4/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 194;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 173;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm4_1Register : Register
        {
            public override string Name { get; } = "ymm4/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 195;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 174;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm4_2Register : Register
        {
            public override string Name { get; } = "ymm4/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 196;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 175;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm4_3Register : Register
        {
            public override string Name { get; } = "ymm4/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 197;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 176;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm4hRegister : Register
        {
            public override string Name { get; } = "ymm4h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 262;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 153;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm4lRegister : Register
        {
            public override string Name { get; } = "ymm4l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 246;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 145;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm4Register : Register
        {
            public override string Name { get; } = "ymm4";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 166;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 137;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm5_0Register : Register
        {
            public override string Name { get; } = "ymm5/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 198;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 177;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm5_1Register : Register
        {
            public override string Name { get; } = "ymm5/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 199;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 178;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm5_2Register : Register
        {
            public override string Name { get; } = "ymm5/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 200;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 179;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm5_3Register : Register
        {
            public override string Name { get; } = "ymm5/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 201;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 180;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm5hRegister : Register
        {
            public override string Name { get; } = "ymm5h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 263;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 154;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm5lRegister : Register
        {
            public override string Name { get; } = "ymm5l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 247;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 146;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm5Register : Register
        {
            public override string Name { get; } = "ymm5";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 167;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 138;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm6_0Register : Register
        {
            public override string Name { get; } = "ymm6/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 202;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 181;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm6_1Register : Register
        {
            public override string Name { get; } = "ymm6/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 203;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 182;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm6_2Register : Register
        {
            public override string Name { get; } = "ymm6/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 204;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 183;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm6_3Register : Register
        {
            public override string Name { get; } = "ymm6/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 205;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 184;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm6hRegister : Register
        {
            public override string Name { get; } = "ymm6h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 264;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 155;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm6lRegister : Register
        {
            public override string Name { get; } = "ymm6l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 248;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 147;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm6Register : Register
        {
            public override string Name { get; } = "ymm6";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 168;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 139;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm7_0Register : Register
        {
            public override string Name { get; } = "ymm7/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 206;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 185;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm7_1Register : Register
        {
            public override string Name { get; } = "ymm7/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 207;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 186;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm7_2Register : Register
        {
            public override string Name { get; } = "ymm7/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 208;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 187;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm7_3Register : Register
        {
            public override string Name { get; } = "ymm7/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 209;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = 188;
            public override int? X86NumBits { get; } = 32;
        }

        public class Ymm7hRegister : Register
        {
            public override string Name { get; } = "ymm7h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 265;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 156;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm7lRegister : Register
        {
            public override string Name { get; } = "ymm7l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 249;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 148;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm7Register : Register
        {
            public override string Name { get; } = "ymm7";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 169;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = 140;
            public override int? X86NumBits { get; } = 128;
        }

        public class Ymm8_0Register : Register
        {
            public override string Name { get; } = "ymm8/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 210;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm8_1Register : Register
        {
            public override string Name { get; } = "ymm8/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 211;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm8_2Register : Register
        {
            public override string Name { get; } = "ymm8/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 212;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm8_3Register : Register
        {
            public override string Name { get; } = "ymm8/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 213;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm8hRegister : Register
        {
            public override string Name { get; } = "ymm8h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 266;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm8lRegister : Register
        {
            public override string Name { get; } = "ymm8l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 250;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm8Register : Register
        {
            public override string Name { get; } = "ymm8";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 170;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9_0Register : Register
        {
            public override string Name { get; } = "ymm9/0";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 214;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9_1Register : Register
        {
            public override string Name { get; } = "ymm9/1";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 215;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9_2Register : Register
        {
            public override string Name { get; } = "ymm9/2";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 216;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9_3Register : Register
        {
            public override string Name { get; } = "ymm9/3";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 217;
            public override int? X64NumBits { get; } = 32;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9hRegister : Register
        {
            public override string Name { get; } = "ymm9h";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 267;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9lRegister : Register
        {
            public override string Name { get; } = "ymm9l";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 251;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class Ymm9Register : Register
        {
            public override string Name { get; } = "ymm9";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 171;
            public override int? X64NumBits { get; } = 128;
            public override int? X86Index { get; } = null;
            public override int? X86NumBits { get; } = null;
        }

        public class ZfRegister : Register
        {
            public override string Name { get; } = "zf";
            public override int NumBits { get; } = 64;
            public override int? X64Index { get; } = 339;
            public override int? X64NumBits { get; } = 64;
            public override int? X86Index { get; } = 79;
            public override int? X86NumBits { get; } = 32;
        }
    }
}