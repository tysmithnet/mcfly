// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 02-27-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-18-2018
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
            DefaultX86Registers = new Register[]
            {
                Gs, Fs, Es, Ds, Edi, Esi, Ebx, Edx, Ecx, Eax, Ebp, Eip, Cs, Efl, Esp, Ss, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7,
                Fpcw, Fpsw, Fptw, Fopcode, Fpip, Fpipsel, Fpdp, Fpdpsel, St0, St1, St2, St3, St4, St5, St6, St7, Mm0, Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7,
                Mxcsr, Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5,
                Ymm6, Ymm7
            };
            DefaultX64Registers = new Register[]
            {
                Rax, Rcx, Rdx, Rbx, Rsp, Rbp, Rsi, Rdi, R8, R9, R10, R11, R12, R13, R14, R15, Rip, Efl, Cs, Ds, Es, Fs,
                Gs, Ss, Dr0, Dr1, Dr2, Dr3, Dr6, Dr7, Fpcw, Fpsw, Fptw, St0, St1, St2, St3, St4, St5, St6, St7, Mm0,
                Mm1, Mm2, Mm3, Mm4, Mm5, Mm6, Mm7, Mxcsr,
                Ymm0, Ymm1, Ymm2, Ymm3, Ymm4, Ymm5, Ymm6, Ymm7, Ymm8, Ymm9, Ymm10, Ymm11, Ymm12, Ymm13, Ymm14, Ymm15
            };
            All = X64.Concat(X86).Distinct().ToArray();
        }

        public static Register[] DefaultX64Registers { get; }

        public static Register[] DefaultX86Registers { get; }

        /// <summary>
        ///     Lookups the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Register.</returns>
        public static Register Lookup(string name)
        {
            return All.FirstOrDefault(x => Regex.IsMatch(name, x.Name, RegexOptions.IgnoreCase)); 
        }

        /// <summary>
        ///     Gets the af.
        /// </summary>
        /// <value>The af.</value>
        public static AfRegister Af { get; } = new AfRegister();

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
        ///     Gets all.
        /// </summary>
        /// <value>All.</value>
        public static Register[] All { get; }

        /// <summary>
        ///     Gets the ax.
        /// </summary>
        /// <value>The ax.</value>
        public static AxRegister Ax { get; } = new AxRegister();

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
        ///     Gets the bp.
        /// </summary>
        /// <value>The bp.</value>
        public static BpRegister Bp { get; } = new BpRegister();

        /// <summary>
        ///     Gets the BPL.
        /// </summary>
        /// <value>The BPL.</value>
        public static BplRegister Bpl { get; } = new BplRegister();

        /// <summary>
        ///     Gets the brfrom.
        /// </summary>
        /// <value>The brfrom.</value>
        public static BrfromRegister Brfrom { get; } = new BrfromRegister();

        /// <summary>
        ///     Gets the brto.
        /// </summary>
        /// <value>The brto.</value>
        public static BrtoRegister Brto { get; } = new BrtoRegister();

        /// <summary>
        ///     Gets the bx.
        /// </summary>
        /// <value>The bx.</value>
        public static BxRegister Bx { get; } = new BxRegister();

        /// <summary>
        ///     Gets the cf.
        /// </summary>
        /// <value>The cf.</value>
        public static CfRegister Cf { get; } = new CfRegister();

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
        ///     Gets the cs.
        /// </summary>
        /// <value>The cs.</value>
        public static CsRegister Cs { get; } = new CsRegister();

        /// <summary>
        ///     Gets the cx.
        /// </summary>
        /// <value>The cx.</value>
        public static CxRegister Cx { get; } = new CxRegister();

        /// <summary>
        ///     Gets the df.
        /// </summary>
        /// <value>The df.</value>
        public static DfRegister Df { get; } = new DfRegister();

        /// <summary>
        ///     Gets the dh.
        /// </summary>
        /// <value>The dh.</value>
        public static DhRegister Dh { get; } = new DhRegister();

        /// <summary>
        ///     Gets the di.
        /// </summary>
        /// <value>The di.</value>
        public static DiRegister Di { get; } = new DiRegister();

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
        ///     Gets the DR0.
        /// </summary>
        /// <value>The DR0.</value>
        public static Dr0Register Dr0 { get; } = new Dr0Register();

        /// <summary>
        ///     Gets the DR1.
        /// </summary>
        /// <value>The DR1.</value>
        public static Dr1Register Dr1 { get; } = new Dr1Register();

        /// <summary>
        ///     Gets the DR2.
        /// </summary>
        /// <value>The DR2.</value>
        public static Dr2Register Dr2 { get; } = new Dr2Register();

        /// <summary>
        ///     Gets the DR3.
        /// </summary>
        /// <value>The DR3.</value>
        public static Dr3Register Dr3 { get; } = new Dr3Register();

        /// <summary>
        ///     Gets the DR6.
        /// </summary>
        /// <value>The DR6.</value>
        public static Dr6Register Dr6 { get; } = new Dr6Register();

        /// <summary>
        ///     Gets the DR7.
        /// </summary>
        /// <value>The DR7.</value>
        public static Dr7Register Dr7 { get; } = new Dr7Register();

        /// <summary>
        ///     Gets the ds.
        /// </summary>
        /// <value>The ds.</value>
        public static DsRegister Ds { get; } = new DsRegister();

        /// <summary>
        ///     Gets the dx.
        /// </summary>
        /// <value>The dx.</value>
        public static DxRegister Dx { get; } = new DxRegister();

        /// <summary>
        ///     Gets the eax.
        /// </summary>
        /// <value>The eax.</value>
        public static EaxRegister Eax { get; } = new EaxRegister();

        /// <summary>
        ///     Gets the ebp.
        /// </summary>
        /// <value>The ebp.</value>
        public static EbpRegister Ebp { get; } = new EbpRegister();

        /// <summary>
        ///     Gets the ebx.
        /// </summary>
        /// <value>The ebx.</value>
        public static EbxRegister Ebx { get; } = new EbxRegister();

        /// <summary>
        ///     Gets the ecx.
        /// </summary>
        /// <value>The ecx.</value>
        public static EcxRegister Ecx { get; } = new EcxRegister();

        /// <summary>
        ///     Gets the edi.
        /// </summary>
        /// <value>The edi.</value>
        public static EdiRegister Edi { get; } = new EdiRegister();

        /// <summary>
        ///     Gets the edx.
        /// </summary>
        /// <value>The edx.</value>
        public static EdxRegister Edx { get; } = new EdxRegister();

        /// <summary>
        ///     Gets the efl.
        /// </summary>
        /// <value>The efl.</value>
        public static EflRegister Efl { get; } = new EflRegister();

        /// <summary>
        ///     Gets the eip.
        /// </summary>
        /// <value>The eip.</value>
        public static EipRegister Eip { get; } = new EipRegister();

        /// <summary>
        ///     Gets the es.
        /// </summary>
        /// <value>The es.</value>
        public static EsRegister Es { get; } = new EsRegister();

        /// <summary>
        ///     Gets the esi.
        /// </summary>
        /// <value>The esi.</value>
        public static EsiRegister Esi { get; } = new EsiRegister();

        /// <summary>
        ///     Gets the esp.
        /// </summary>
        /// <value>The esp.</value>
        public static EspRegister Esp { get; } = new EspRegister();

        /// <summary>
        ///     Gets the exfrom.
        /// </summary>
        /// <value>The exfrom.</value>
        public static ExfromRegister Exfrom { get; } = new ExfromRegister();

        /// <summary>
        ///     Gets the exto.
        /// </summary>
        /// <value>The exto.</value>
        public static ExtoRegister Exto { get; } = new ExtoRegister();

        /// <summary>
        ///     Gets the fl.
        /// </summary>
        /// <value>The fl.</value>
        public static FlRegister Fl { get; } = new FlRegister();

        /// <summary>
        ///     Gets the fopcode.
        /// </summary>
        /// <value>The fopcode.</value>
        public static FopcodeRegister Fopcode { get; } = new FopcodeRegister();

        /// <summary>
        ///     Gets the FPCW.
        /// </summary>
        /// <value>The FPCW.</value>
        public static FpcwRegister Fpcw { get; } = new FpcwRegister();

        /// <summary>
        ///     Gets the FPDP.
        /// </summary>
        /// <value>The FPDP.</value>
        public static FpdpRegister Fpdp { get; } = new FpdpRegister();

        /// <summary>
        ///     Gets the fpdpsel.
        /// </summary>
        /// <value>The fpdpsel.</value>
        public static FpdpselRegister Fpdpsel { get; } = new FpdpselRegister();

        /// <summary>
        ///     Gets the fpip.
        /// </summary>
        /// <value>The fpip.</value>
        public static FpipRegister Fpip { get; } = new FpipRegister();

        /// <summary>
        ///     Gets the fpipsel.
        /// </summary>
        /// <value>The fpipsel.</value>
        public static FpipselRegister Fpipsel { get; } = new FpipselRegister();

        /// <summary>
        ///     Gets the FPSW.
        /// </summary>
        /// <value>The FPSW.</value>
        public static FpswRegister Fpsw { get; } = new FpswRegister();

        /// <summary>
        ///     Gets the FPTW.
        /// </summary>
        /// <value>The FPTW.</value>
        public static FptwRegister Fptw { get; } = new FptwRegister();

        /// <summary>
        ///     Gets the fs.
        /// </summary>
        /// <value>The fs.</value>
        public static FsRegister Fs { get; } = new FsRegister();

        /// <summary>
        ///     Gets the gs.
        /// </summary>
        /// <value>The gs.</value>
        public static GsRegister Gs { get; } = new GsRegister();

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
        ///     Gets the ip.
        /// </summary>
        /// <value>The ip.</value>
        public static IpRegister Ip { get; } = new IpRegister();

        /// <summary>
        ///     Gets the MM0.
        /// </summary>
        /// <value>The MM0.</value>
        public static Mm0Register Mm0 { get; } = new Mm0Register();

        /// <summary>
        ///     Gets the MM1.
        /// </summary>
        /// <value>The MM1.</value>
        public static Mm1Register Mm1 { get; } = new Mm1Register();

        /// <summary>
        ///     Gets the MM2.
        /// </summary>
        /// <value>The MM2.</value>
        public static Mm2Register Mm2 { get; } = new Mm2Register();

        /// <summary>
        ///     Gets the MM3.
        /// </summary>
        /// <value>The MM3.</value>
        public static Mm3Register Mm3 { get; } = new Mm3Register();

        /// <summary>
        ///     Gets the MM4.
        /// </summary>
        /// <value>The MM4.</value>
        public static Mm4Register Mm4 { get; } = new Mm4Register();

        /// <summary>
        ///     Gets the MM5.
        /// </summary>
        /// <value>The MM5.</value>
        public static Mm5Register Mm5 { get; } = new Mm5Register();

        /// <summary>
        ///     Gets the MM6.
        /// </summary>
        /// <value>The MM6.</value>
        public static Mm6Register Mm6 { get; } = new Mm6Register();

        /// <summary>
        ///     Gets the MM7.
        /// </summary>
        /// <value>The MM7.</value>
        public static Mm7Register Mm7 { get; } = new Mm7Register();

        /// <summary>
        ///     Gets the MXCSR.
        /// </summary>
        /// <value>The MXCSR.</value>
        public static MxcsrRegister Mxcsr { get; } = new MxcsrRegister();

        /// <summary>
        ///     Gets the name of the regiser, e.g. rip, rax, edi.
        /// </summary>
        /// <value>The name.</value>
        public abstract string Name { get; }

        /// <summary>
        ///     Gets the number bits.
        /// </summary>
        /// <value>The number bits.</value>
        public abstract int NumBits { get; }

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
        ///     Gets the R10.
        /// </summary>
        /// <value>The R10.</value>
        public static R10Register R10 { get; } = new R10Register();

        /// <summary>
        ///     Gets the R10B.
        /// </summary>
        /// <value>The R10B.</value>
        public static R10bRegister R10b { get; } = new R10bRegister();

        /// <summary>
        ///     Gets the R10D.
        /// </summary>
        /// <value>The R10D.</value>
        public static R10dRegister R10d { get; } = new R10dRegister();

        /// <summary>
        ///     Gets the R10W.
        /// </summary>
        /// <value>The R10W.</value>
        public static R10wRegister R10w { get; } = new R10wRegister();

        /// <summary>
        ///     Gets the R11.
        /// </summary>
        /// <value>The R11.</value>
        public static R11Register R11 { get; } = new R11Register();

        /// <summary>
        ///     Gets the R11B.
        /// </summary>
        /// <value>The R11B.</value>
        public static R11bRegister R11b { get; } = new R11bRegister();

        /// <summary>
        ///     Gets the R11D.
        /// </summary>
        /// <value>The R11D.</value>
        public static R11dRegister R11d { get; } = new R11dRegister();

        /// <summary>
        ///     Gets the R11W.
        /// </summary>
        /// <value>The R11W.</value>
        public static R11wRegister R11w { get; } = new R11wRegister();

        /// <summary>
        ///     Gets the R12.
        /// </summary>
        /// <value>The R12.</value>
        public static R12Register R12 { get; } = new R12Register();

        /// <summary>
        ///     Gets the R12B.
        /// </summary>
        /// <value>The R12B.</value>
        public static R12bRegister R12b { get; } = new R12bRegister();

        /// <summary>
        ///     Gets the R12D.
        /// </summary>
        /// <value>The R12D.</value>
        public static R12dRegister R12d { get; } = new R12dRegister();

        /// <summary>
        ///     Gets the R12W.
        /// </summary>
        /// <value>The R12W.</value>
        public static R12wRegister R12w { get; } = new R12wRegister();

        /// <summary>
        ///     Gets the R13.
        /// </summary>
        /// <value>The R13.</value>
        public static R13Register R13 { get; } = new R13Register();

        /// <summary>
        ///     Gets the R13B.
        /// </summary>
        /// <value>The R13B.</value>
        public static R13bRegister R13b { get; } = new R13bRegister();

        /// <summary>
        ///     Gets the R13D.
        /// </summary>
        /// <value>The R13D.</value>
        public static R13dRegister R13d { get; } = new R13dRegister();

        /// <summary>
        ///     Gets the R13W.
        /// </summary>
        /// <value>The R13W.</value>
        public static R13wRegister R13w { get; } = new R13wRegister();

        /// <summary>
        ///     Gets the R14.
        /// </summary>
        /// <value>The R14.</value>
        public static R14Register R14 { get; } = new R14Register();

        /// <summary>
        ///     Gets the R14B.
        /// </summary>
        /// <value>The R14B.</value>
        public static R14bRegister R14b { get; } = new R14bRegister();

        /// <summary>
        ///     Gets the R14D.
        /// </summary>
        /// <value>The R14D.</value>
        public static R14dRegister R14d { get; } = new R14dRegister();

        /// <summary>
        ///     Gets the R14W.
        /// </summary>
        /// <value>The R14W.</value>
        public static R14wRegister R14w { get; } = new R14wRegister();

        /// <summary>
        ///     Gets the R15.
        /// </summary>
        /// <value>The R15.</value>
        public static R15Register R15 { get; } = new R15Register();

        /// <summary>
        ///     Gets the R15B.
        /// </summary>
        /// <value>The R15B.</value>
        public static R15bRegister R15b { get; } = new R15bRegister();

        /// <summary>
        ///     Gets the R15D.
        /// </summary>
        /// <value>The R15D.</value>
        public static R15dRegister R15d { get; } = new R15dRegister();

        /// <summary>
        ///     Gets the R15W.
        /// </summary>
        /// <value>The R15W.</value>
        public static R15wRegister R15w { get; } = new R15wRegister();

        /// <summary>
        ///     Gets the r8.
        /// </summary>
        /// <value>The r8.</value>
        public static R8Register R8 { get; } = new R8Register();

        /// <summary>
        ///     Gets the R8B.
        /// </summary>
        /// <value>The R8B.</value>
        public static R8bRegister R8b { get; } = new R8bRegister();

        /// <summary>
        ///     Gets the R8D.
        /// </summary>
        /// <value>The R8D.</value>
        public static R8dRegister R8d { get; } = new R8dRegister();

        /// <summary>
        ///     Gets the R8W.
        /// </summary>
        /// <value>The R8W.</value>
        public static R8wRegister R8w { get; } = new R8wRegister();

        /// <summary>
        ///     Gets the r9.
        /// </summary>
        /// <value>The r9.</value>
        public static R9Register R9 { get; } = new R9Register();

        /// <summary>
        ///     Gets the R9B.
        /// </summary>
        /// <value>The R9B.</value>
        public static R9bRegister R9b { get; } = new R9bRegister();

        /// <summary>
        ///     Gets the R9D.
        /// </summary>
        /// <value>The R9D.</value>
        public static R9dRegister R9d { get; } = new R9dRegister();

        /// <summary>
        ///     Gets the R9W.
        /// </summary>
        /// <value>The R9W.</value>
        public static R9wRegister R9w { get; } = new R9wRegister();

        /// <summary>
        ///     Gets the rax.
        /// </summary>
        /// <value>The rax.</value>
        public static RaxRegister Rax { get; } = new RaxRegister();

        /// <summary>
        ///     Gets the RBP.
        /// </summary>
        /// <value>The RBP.</value>
        public static RbpRegister Rbp { get; } = new RbpRegister();

        /// <summary>
        ///     Gets the RBX.
        /// </summary>
        /// <value>The RBX.</value>
        public static RbxRegister Rbx { get; } = new RbxRegister();

        /// <summary>
        ///     Gets the RCX.
        /// </summary>
        /// <value>The RCX.</value>
        public static RcxRegister Rcx { get; } = new RcxRegister();

        /// <summary>
        ///     Gets the rdi.
        /// </summary>
        /// <value>The rdi.</value>
        public static RdiRegister Rdi { get; } = new RdiRegister();

        /// <summary>
        ///     Gets the RDX.
        /// </summary>
        /// <value>The RDX.</value>
        public static RdxRegister Rdx { get; } = new RdxRegister();

        /// <summary>
        ///     Gets the rip.
        /// </summary>
        /// <value>The rip.</value>
        public static RipRegister Rip { get; } = new RipRegister();

        /// <summary>
        ///     Gets the rsi.
        /// </summary>
        /// <value>The rsi.</value>
        public static RsiRegister Rsi { get; } = new RsiRegister();

        /// <summary>
        ///     Gets the RSP.
        /// </summary>
        /// <value>The RSP.</value>
        public static RspRegister Rsp { get; } = new RspRegister();

        /// <summary>
        ///     Gets the sf.
        /// </summary>
        /// <value>The sf.</value>
        public static SfRegister Sf { get; } = new SfRegister();

        /// <summary>
        ///     Gets the si.
        /// </summary>
        /// <value>The si.</value>
        public static SiRegister Si { get; } = new SiRegister();

        /// <summary>
        ///     Gets the sil.
        /// </summary>
        /// <value>The sil.</value>
        public static SilRegister Sil { get; } = new SilRegister();

        /// <summary>
        ///     Gets the sp.
        /// </summary>
        /// <value>The sp.</value>
        public static SpRegister Sp { get; } = new SpRegister();

        /// <summary>
        ///     Gets the SPL.
        /// </summary>
        /// <value>The SPL.</value>
        public static SplRegister Spl { get; } = new SplRegister();

        /// <summary>
        ///     Gets the ss.
        /// </summary>
        /// <value>The ss.</value>
        public static SsRegister Ss { get; } = new SsRegister();

        /// <summary>
        ///     Gets the ST0.
        /// </summary>
        /// <value>The ST0.</value>
        public static St0Register St0 { get; } = new St0Register();

        /// <summary>
        ///     Gets the ST1.
        /// </summary>
        /// <value>The ST1.</value>
        public static St1Register St1 { get; } = new St1Register();

        /// <summary>
        ///     Gets the ST2.
        /// </summary>
        /// <value>The ST2.</value>
        public static St2Register St2 { get; } = new St2Register();

        /// <summary>
        ///     Gets the ST3.
        /// </summary>
        /// <value>The ST3.</value>
        public static St3Register St3 { get; } = new St3Register();

        /// <summary>
        ///     Gets the ST4.
        /// </summary>
        /// <value>The ST4.</value>
        public static St4Register St4 { get; } = new St4Register();

        /// <summary>
        ///     Gets the ST5.
        /// </summary>
        /// <value>The ST5.</value>
        public static St5Register St5 { get; } = new St5Register();

        /// <summary>
        ///     Gets the ST6.
        /// </summary>
        /// <value>The ST6.</value>
        public static St6Register St6 { get; } = new St6Register();

        /// <summary>
        ///     Gets the ST7.
        /// </summary>
        /// <value>The ST7.</value>
        public static St7Register St7 { get; } = new St7Register();

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
        ///     Gets all registers.
        /// </summary>
        /// <value>All registers.</value>
        public static Register[] X64 { get; }

        /// <summary>
        ///     Gets the index of the X64.
        /// </summary>
        /// <value>The index of the X64.</value>
        public abstract int? X64Index { get; }

        /// <summary>
        ///     Gets the X64 number bits.
        /// </summary>
        /// <value>The X64 number bits.</value>
        public abstract int? X64NumBits { get; }

        /// <summary>
        ///     Gets the X86.
        /// </summary>
        /// <value>The X86.</value>
        public static Register[] X86 { get; }

        /// <summary>
        ///     Gets the index of the X86.
        /// </summary>
        /// <value>The index of the X86.</value>
        public abstract int? X86Index { get; }

        /// <summary>
        ///     Gets the number bits for the register, e.g. 32, 64.
        /// </summary>
        /// <value>The number bits.</value>
        public abstract int? X86NumBits { get; }

        /// <summary>
        ///     Gets the XMM0.
        /// </summary>
        /// <value>The XMM0.</value>
        public static Xmm0Register Xmm0 { get; } = new Xmm0Register();

        /// <summary>
        ///     Gets the XMM0H.
        /// </summary>
        /// <value>The XMM0H.</value>
        public static Xmm0hRegister Xmm0h { get; } = new Xmm0hRegister();

        /// <summary>
        ///     Gets the XMM0L.
        /// </summary>
        /// <value>The XMM0L.</value>
        public static Xmm0lRegister Xmm0l { get; } = new Xmm0lRegister();

        /// <summary>
        ///     Gets the XMM1.
        /// </summary>
        /// <value>The XMM1.</value>
        public static Xmm1Register Xmm1 { get; } = new Xmm1Register();

        /// <summary>
        ///     Gets the XMM10.
        /// </summary>
        /// <value>The XMM10.</value>
        public static Xmm10Register Xmm10 { get; } = new Xmm10Register();

        /// <summary>
        ///     Gets the XMM10H.
        /// </summary>
        /// <value>The XMM10H.</value>
        public static Xmm10hRegister Xmm10h { get; } = new Xmm10hRegister();

        /// <summary>
        ///     Gets the XMM10L.
        /// </summary>
        /// <value>The XMM10L.</value>
        public static Xmm10lRegister Xmm10l { get; } = new Xmm10lRegister();

        /// <summary>
        ///     Gets the XMM11.
        /// </summary>
        /// <value>The XMM11.</value>
        public static Xmm11Register Xmm11 { get; } = new Xmm11Register();

        /// <summary>
        ///     Gets the XMM11H.
        /// </summary>
        /// <value>The XMM11H.</value>
        public static Xmm11hRegister Xmm11h { get; } = new Xmm11hRegister();

        /// <summary>
        ///     Gets the XMM11L.
        /// </summary>
        /// <value>The XMM11L.</value>
        public static Xmm11lRegister Xmm11l { get; } = new Xmm11lRegister();

        /// <summary>
        ///     Gets the XMM12.
        /// </summary>
        /// <value>The XMM12.</value>
        public static Xmm12Register Xmm12 { get; } = new Xmm12Register();

        /// <summary>
        ///     Gets the XMM12H.
        /// </summary>
        /// <value>The XMM12H.</value>
        public static Xmm12hRegister Xmm12h { get; } = new Xmm12hRegister();

        /// <summary>
        ///     Gets the XMM12L.
        /// </summary>
        /// <value>The XMM12L.</value>
        public static Xmm12lRegister Xmm12l { get; } = new Xmm12lRegister();

        /// <summary>
        ///     Gets the XMM13.
        /// </summary>
        /// <value>The XMM13.</value>
        public static Xmm13Register Xmm13 { get; } = new Xmm13Register();

        /// <summary>
        ///     Gets the XMM13H.
        /// </summary>
        /// <value>The XMM13H.</value>
        public static Xmm13hRegister Xmm13h { get; } = new Xmm13hRegister();

        /// <summary>
        ///     Gets the XMM13L.
        /// </summary>
        /// <value>The XMM13L.</value>
        public static Xmm13lRegister Xmm13l { get; } = new Xmm13lRegister();

        /// <summary>
        ///     Gets the XMM14.
        /// </summary>
        /// <value>The XMM14.</value>
        public static Xmm14Register Xmm14 { get; } = new Xmm14Register();

        /// <summary>
        ///     Gets the XMM14H.
        /// </summary>
        /// <value>The XMM14H.</value>
        public static Xmm14hRegister Xmm14h { get; } = new Xmm14hRegister();

        /// <summary>
        ///     Gets the XMM14L.
        /// </summary>
        /// <value>The XMM14L.</value>
        public static Xmm14lRegister Xmm14l { get; } = new Xmm14lRegister();

        /// <summary>
        ///     Gets the XMM15.
        /// </summary>
        /// <value>The XMM15.</value>
        public static Xmm15Register Xmm15 { get; } = new Xmm15Register();

        /// <summary>
        ///     Gets the XMM15H.
        /// </summary>
        /// <value>The XMM15H.</value>
        public static Xmm15hRegister Xmm15h { get; } = new Xmm15hRegister();

        /// <summary>
        ///     Gets the XMM15L.
        /// </summary>
        /// <value>The XMM15L.</value>
        public static Xmm15lRegister Xmm15l { get; } = new Xmm15lRegister();

        /// <summary>
        ///     Gets the XMM1H.
        /// </summary>
        /// <value>The XMM1H.</value>
        public static Xmm1hRegister Xmm1h { get; } = new Xmm1hRegister();

        /// <summary>
        ///     Gets the XMM1L.
        /// </summary>
        /// <value>The XMM1L.</value>
        public static Xmm1lRegister Xmm1l { get; } = new Xmm1lRegister();

        /// <summary>
        ///     Gets the XMM2.
        /// </summary>
        /// <value>The XMM2.</value>
        public static Xmm2Register Xmm2 { get; } = new Xmm2Register();

        /// <summary>
        ///     Gets the XMM2H.
        /// </summary>
        /// <value>The XMM2H.</value>
        public static Xmm2hRegister Xmm2h { get; } = new Xmm2hRegister();

        /// <summary>
        ///     Gets the XMM2L.
        /// </summary>
        /// <value>The XMM2L.</value>
        public static Xmm2lRegister Xmm2l { get; } = new Xmm2lRegister();

        /// <summary>
        ///     Gets the XMM3.
        /// </summary>
        /// <value>The XMM3.</value>
        public static Xmm3Register Xmm3 { get; } = new Xmm3Register();

        /// <summary>
        ///     Gets the XMM3H.
        /// </summary>
        /// <value>The XMM3H.</value>
        public static Xmm3hRegister Xmm3h { get; } = new Xmm3hRegister();

        /// <summary>
        ///     Gets the XMM3L.
        /// </summary>
        /// <value>The XMM3L.</value>
        public static Xmm3lRegister Xmm3l { get; } = new Xmm3lRegister();

        /// <summary>
        ///     Gets the XMM4.
        /// </summary>
        /// <value>The XMM4.</value>
        public static Xmm4Register Xmm4 { get; } = new Xmm4Register();

        /// <summary>
        ///     Gets the XMM4H.
        /// </summary>
        /// <value>The XMM4H.</value>
        public static Xmm4hRegister Xmm4h { get; } = new Xmm4hRegister();

        /// <summary>
        ///     Gets the XMM4L.
        /// </summary>
        /// <value>The XMM4L.</value>
        public static Xmm4lRegister Xmm4l { get; } = new Xmm4lRegister();

        /// <summary>
        ///     Gets the XMM5.
        /// </summary>
        /// <value>The XMM5.</value>
        public static Xmm5Register Xmm5 { get; } = new Xmm5Register();

        /// <summary>
        ///     Gets the XMM5H.
        /// </summary>
        /// <value>The XMM5H.</value>
        public static Xmm5hRegister Xmm5h { get; } = new Xmm5hRegister();

        /// <summary>
        ///     Gets the XMM5L.
        /// </summary>
        /// <value>The XMM5L.</value>
        public static Xmm5lRegister Xmm5l { get; } = new Xmm5lRegister();

        /// <summary>
        ///     Gets the XMM6.
        /// </summary>
        /// <value>The XMM6.</value>
        public static Xmm6Register Xmm6 { get; } = new Xmm6Register();

        /// <summary>
        ///     Gets the XMM6H.
        /// </summary>
        /// <value>The XMM6H.</value>
        public static Xmm6hRegister Xmm6h { get; } = new Xmm6hRegister();

        /// <summary>
        ///     Gets the XMM6L.
        /// </summary>
        /// <value>The XMM6L.</value>
        public static Xmm6lRegister Xmm6l { get; } = new Xmm6lRegister();

        /// <summary>
        ///     Gets the XMM7.
        /// </summary>
        /// <value>The XMM7.</value>
        public static Xmm7Register Xmm7 { get; } = new Xmm7Register();

        /// <summary>
        ///     Gets the XMM7H.
        /// </summary>
        /// <value>The XMM7H.</value>
        public static Xmm7hRegister Xmm7h { get; } = new Xmm7hRegister();

        /// <summary>
        ///     Gets the XMM7L.
        /// </summary>
        /// <value>The XMM7L.</value>
        public static Xmm7lRegister Xmm7l { get; } = new Xmm7lRegister();

        /// <summary>
        ///     Gets the XMM8.
        /// </summary>
        /// <value>The XMM8.</value>
        public static Xmm8Register Xmm8 { get; } = new Xmm8Register();

        /// <summary>
        ///     Gets the XMM8H.
        /// </summary>
        /// <value>The XMM8H.</value>
        public static Xmm8hRegister Xmm8h { get; } = new Xmm8hRegister();

        /// <summary>
        ///     Gets the XMM8L.
        /// </summary>
        /// <value>The XMM8L.</value>
        public static Xmm8lRegister Xmm8l { get; } = new Xmm8lRegister();

        /// <summary>
        ///     Gets the XMM9.
        /// </summary>
        /// <value>The XMM9.</value>
        public static Xmm9Register Xmm9 { get; } = new Xmm9Register();

        /// <summary>
        ///     Gets the XMM9H.
        /// </summary>
        /// <value>The XMM9H.</value>
        public static Xmm9hRegister Xmm9h { get; } = new Xmm9hRegister();

        /// <summary>
        ///     Gets the XMM9L.
        /// </summary>
        /// <value>The XMM9L.</value>
        public static Xmm9lRegister Xmm9l { get; } = new Xmm9lRegister();

        /// <summary>
        ///     Gets the ymm0.
        /// </summary>
        /// <value>The ymm0.</value>
        public static Ymm0Register Ymm0 { get; } = new Ymm0Register();

        /// <summary>
        ///     Gets the ymm0h.
        /// </summary>
        /// <value>The ymm0h.</value>
        public static Ymm0hRegister Ymm0h { get; } = new Ymm0hRegister();

        /// <summary>
        ///     Gets the ymm0l.
        /// </summary>
        /// <value>The ymm0l.</value>
        public static Ymm0lRegister Ymm0l { get; } = new Ymm0lRegister();

        /// <summary>
        ///     Gets the ymm1.
        /// </summary>
        /// <value>The ymm1.</value>
        public static Ymm1Register Ymm1 { get; } = new Ymm1Register();

        /// <summary>
        ///     Gets the ymm10.
        /// </summary>
        /// <value>The ymm10.</value>
        public static Ymm10Register Ymm10 { get; } = new Ymm10Register();

        /// <summary>
        ///     Gets the ymm10h.
        /// </summary>
        /// <value>The ymm10h.</value>
        public static Ymm10hRegister Ymm10h { get; } = new Ymm10hRegister();

        /// <summary>
        ///     Gets the ymm10l.
        /// </summary>
        /// <value>The ymm10l.</value>
        public static Ymm10lRegister Ymm10l { get; } = new Ymm10lRegister();

        /// <summary>
        ///     Gets the ymm11.
        /// </summary>
        /// <value>The ymm11.</value>
        public static Ymm11Register Ymm11 { get; } = new Ymm11Register();

        /// <summary>
        ///     Gets the ymm11h.
        /// </summary>
        /// <value>The ymm11h.</value>
        public static Ymm11hRegister Ymm11h { get; } = new Ymm11hRegister();

        /// <summary>
        ///     Gets the ymm11l.
        /// </summary>
        /// <value>The ymm11l.</value>
        public static Ymm11lRegister Ymm11l { get; } = new Ymm11lRegister();

        /// <summary>
        ///     Gets the ymm12.
        /// </summary>
        /// <value>The ymm12.</value>
        public static Ymm12Register Ymm12 { get; } = new Ymm12Register();

        /// <summary>
        ///     Gets the ymm12h.
        /// </summary>
        /// <value>The ymm12h.</value>
        public static Ymm12hRegister Ymm12h { get; } = new Ymm12hRegister();

        /// <summary>
        ///     Gets the ymm12l.
        /// </summary>
        /// <value>The ymm12l.</value>
        public static Ymm12lRegister Ymm12l { get; } = new Ymm12lRegister();

        /// <summary>
        ///     Gets the ymm13.
        /// </summary>
        /// <value>The ymm13.</value>
        public static Ymm13Register Ymm13 { get; } = new Ymm13Register();

        /// <summary>
        ///     Gets the ymm13h.
        /// </summary>
        /// <value>The ymm13h.</value>
        public static Ymm13hRegister Ymm13h { get; } = new Ymm13hRegister();

        /// <summary>
        ///     Gets the ymm13l.
        /// </summary>
        /// <value>The ymm13l.</value>
        public static Ymm13lRegister Ymm13l { get; } = new Ymm13lRegister();

        /// <summary>
        ///     Gets the ymm14.
        /// </summary>
        /// <value>The ymm14.</value>
        public static Ymm14Register Ymm14 { get; } = new Ymm14Register();

        /// <summary>
        ///     Gets the ymm14h.
        /// </summary>
        /// <value>The ymm14h.</value>
        public static Ymm14hRegister Ymm14h { get; } = new Ymm14hRegister();

        /// <summary>
        ///     Gets the ymm14l.
        /// </summary>
        /// <value>The ymm14l.</value>
        public static Ymm14lRegister Ymm14l { get; } = new Ymm14lRegister();

        /// <summary>
        ///     Gets the ymm15.
        /// </summary>
        /// <value>The ymm15.</value>
        public static Ymm15Register Ymm15 { get; } = new Ymm15Register();

        /// <summary>
        ///     Gets the ymm15h.
        /// </summary>
        /// <value>The ymm15h.</value>
        public static Ymm15hRegister Ymm15h { get; } = new Ymm15hRegister();

        /// <summary>
        ///     Gets the ymm15l.
        /// </summary>
        /// <value>The ymm15l.</value>
        public static Ymm15lRegister Ymm15l { get; } = new Ymm15lRegister();

        /// <summary>
        ///     Gets the ymm1h.
        /// </summary>
        /// <value>The ymm1h.</value>
        public static Ymm1hRegister Ymm1h { get; } = new Ymm1hRegister();

        /// <summary>
        ///     Gets the ymm1l.
        /// </summary>
        /// <value>The ymm1l.</value>
        public static Ymm1lRegister Ymm1l { get; } = new Ymm1lRegister();

        /// <summary>
        ///     Gets the ymm2.
        /// </summary>
        /// <value>The ymm2.</value>
        public static Ymm2Register Ymm2 { get; } = new Ymm2Register();

        /// <summary>
        ///     Gets the ymm2h.
        /// </summary>
        /// <value>The ymm2h.</value>
        public static Ymm2hRegister Ymm2h { get; } = new Ymm2hRegister();

        /// <summary>
        ///     Gets the ymm2l.
        /// </summary>
        /// <value>The ymm2l.</value>
        public static Ymm2lRegister Ymm2l { get; } = new Ymm2lRegister();

        /// <summary>
        ///     Gets the ymm3.
        /// </summary>
        /// <value>The ymm3.</value>
        public static Ymm3Register Ymm3 { get; } = new Ymm3Register();

        /// <summary>
        ///     Gets the ymm3h.
        /// </summary>
        /// <value>The ymm3h.</value>
        public static Ymm3HRegister Ymm3h { get; } = new Ymm3HRegister();

        /// <summary>
        ///     Gets the ymm3l.
        /// </summary>
        /// <value>The ymm3l.</value>
        public static Ymm3lRegister Ymm3l { get; } = new Ymm3lRegister();

        /// <summary>
        ///     Gets the ymm4.
        /// </summary>
        /// <value>The ymm4.</value>
        public static Ymm4Register Ymm4 { get; } = new Ymm4Register();

        /// <summary>
        ///     Gets the ymm4h.
        /// </summary>
        /// <value>The ymm4h.</value>
        public static Ymm4hRegister Ymm4h { get; } = new Ymm4hRegister();

        /// <summary>
        ///     Gets the ymm4l.
        /// </summary>
        /// <value>The ymm4l.</value>
        public static Ymm4lRegister Ymm4l { get; } = new Ymm4lRegister();

        /// <summary>
        ///     Gets the ymm5.
        /// </summary>
        /// <value>The ymm5.</value>
        public static Ymm5Register Ymm5 { get; } = new Ymm5Register();

        /// <summary>
        ///     Gets the ymm5h.
        /// </summary>
        /// <value>The ymm5h.</value>
        public static Ymm5hRegister Ymm5h { get; } = new Ymm5hRegister();

        /// <summary>
        ///     Gets the ymm5l.
        /// </summary>
        /// <value>The ymm5l.</value>
        public static Ymm5lRegister Ymm5l { get; } = new Ymm5lRegister();

        /// <summary>
        ///     Gets the ymm6.
        /// </summary>
        /// <value>The ymm6.</value>
        public static Ymm6Register Ymm6 { get; } = new Ymm6Register();

        /// <summary>
        ///     Gets the ymm6h.
        /// </summary>
        /// <value>The ymm6h.</value>
        public static Ymm6hRegister Ymm6h { get; } = new Ymm6hRegister();

        /// <summary>
        ///     Gets the ymm6l.
        /// </summary>
        /// <value>The ymm6l.</value>
        public static Ymm6lRegister Ymm6l { get; } = new Ymm6lRegister();

        /// <summary>
        ///     Gets the ymm7.
        /// </summary>
        /// <value>The ymm7.</value>
        public static Ymm7Register Ymm7 { get; } = new Ymm7Register();

        /// <summary>
        ///     Gets the ymm7h.
        /// </summary>
        /// <value>The ymm7h.</value>
        public static Ymm7hRegister Ymm7h { get; } = new Ymm7hRegister();

        /// <summary>
        ///     Gets the ymm7l.
        /// </summary>
        /// <value>The ymm7l.</value>
        public static Ymm7lRegister Ymm7l { get; } = new Ymm7lRegister();

        /// <summary>
        ///     Gets the ymm8.
        /// </summary>
        /// <value>The ymm8.</value>
        public static Ymm8Register Ymm8 { get; } = new Ymm8Register();

        /// <summary>
        ///     Gets the ymm8h.
        /// </summary>
        /// <value>The ymm8h.</value>
        public static Ymm8hRegister Ymm8h { get; } = new Ymm8hRegister();

        /// <summary>
        ///     Gets the ymm8l.
        /// </summary>
        /// <value>The ymm8l.</value>
        public static Ymm8lRegister Ymm8l { get; } = new Ymm8lRegister();

        /// <summary>
        ///     Gets the ymm9.
        /// </summary>
        /// <value>The ymm9.</value>
        public static Ymm9Register Ymm9 { get; } = new Ymm9Register();

        /// <summary>
        ///     Gets the ymm9h.
        /// </summary>
        /// <value>The ymm9h.</value>
        public static Ymm9hRegister Ymm9h { get; } = new Ymm9hRegister();

        /// <summary>
        ///     Gets the ymm9l.
        /// </summary>
        /// <value>The ymm9l.</value>
        public static Ymm9lRegister Ymm9l { get; } = new Ymm9lRegister();

        /// <summary>
        ///     Gets the zf.
        /// </summary>
        /// <value>The zf.</value>
        public static ZfRegister Zf { get; } = new ZfRegister();
    }
}