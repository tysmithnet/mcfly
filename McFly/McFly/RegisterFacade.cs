// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="RegisterFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Core.Registers;

namespace McFly
{
    /// <summary>
    ///     Class RegisterFacade.
    /// </summary>
    /// <seealso cref="McFly.IRegisterFacade" />
    [Export(typeof(IRegisterFacade))]
    public class RegisterFacade : IRegisterFacade
    {
        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }

        /// <summary>
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        public RegisterSet GetCurrentRegisterSet(int threadId, IEnumerable<Register> registers)
        {
            var list = registers.ToList();
            if (list.Count == 0)
                return new RegisterSet();
            var registerSet = new RegisterSet();
            var registerNames = string.Join(",", list.Select(x => x.Name));
            var registerText = DebugEngineProxy.Execute(threadId, $"r {registerNames}");
            foreach (var register in list)
            {
                var match = Regex.Match(registerText, $"\\b{register.Name}=(?<val>[a-fA-F0-9]+)");
                if(!match.Success)
                    throw new ApplicationException($"Register '{register.Name}' was requested, but was not found in the results");
                var val = match.Groups["val"].Value;
                registerSet.Process(register.Name, val, 16);
            }

            return registerSet;
        }
        public Regex Get(Register register)
        {
            if (register == Register.Af) return new Regex(@"(^|[ ,])af=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ah) return new Regex(@"(^|[ ,])ah=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Al) return new Regex(@"(^|[ ,])al=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ax) return new Regex(@"(^|[ ,])ax=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Bh) return new Regex(@"(^|[ ,])bh=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Bl) return new Regex(@"(^|[ ,])bl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Bp) return new Regex(@"(^|[ ,])bp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Bpl) return new Regex(@"(^|[ ,])bpl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Brfrom) return new Regex(@"(^|[ ,])brfrom=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Brto) return new Regex(@"(^|[ ,])brto=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Bx) return new Regex(@"(^|[ ,])bx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Cf) return new Regex(@"(^|[ ,])cf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ch) return new Regex(@"(^|[ ,])ch=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Cl) return new Regex(@"(^|[ ,])cl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Cs) return new Regex(@"(^|[ ,])cs=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Cx) return new Regex(@"(^|[ ,])cx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Df) return new Regex(@"(^|[ ,])df=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dh) return new Regex(@"(^|[ ,])dh=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Di) return new Regex(@"(^|[ ,])di=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dil) return new Regex(@"(^|[ ,])dil=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dl) return new Regex(@"(^|[ ,])dl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dr0) return new Regex(@"(^|[ ,])dr0=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dr1) return new Regex(@"(^|[ ,])dr1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dr2) return new Regex(@"(^|[ ,])dr2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dr3) return new Regex(@"(^|[ ,])dr3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dr6) return new Regex(@"(^|[ ,])dr6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dr7) return new Regex(@"(^|[ ,])dr7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ds) return new Regex(@"(^|[ ,])ds=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Dx) return new Regex(@"(^|[ ,])dx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Eax) return new Regex(@"(^|[ ,])eax=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ebp) return new Regex(@"(^|[ ,])ebp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ebx) return new Regex(@"(^|[ ,])ebx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ecx) return new Regex(@"(^|[ ,])ecx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Edi) return new Regex(@"(^|[ ,])edi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Edx) return new Regex(@"(^|[ ,])edx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Efl) return new Regex(@"(^|[ ,])efl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Eip) return new Regex(@"(^|[ ,])eip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Es) return new Regex(@"(^|[ ,])es=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Esi) return new Regex(@"(^|[ ,])esi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Esp) return new Regex(@"(^|[ ,])esp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Exfrom) return new Regex(@"(^|[ ,])exfrom=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Exto) return new Regex(@"(^|[ ,])exto=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Fl) return new Regex(@"(^|[ ,])fl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Fpcw) return new Regex(@"(^|[ ,])fpcw=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Fpsw) return new Regex(@"(^|[ ,])fpsw=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Fptw) return new Regex(@"(^|[ ,])fptw=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Fs) return new Regex(@"(^|[ ,])fs=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Gs) return new Regex(@"(^|[ ,])gs=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.If) return new Regex(@"(^|[ ,])if=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Iopl) return new Regex(@"(^|[ ,])iopl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ip) return new Regex(@"(^|[ ,])ip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm0) return new Regex(@"(^|[ ,])mm0=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm1) return new Regex(@"(^|[ ,])mm1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm2) return new Regex(@"(^|[ ,])mm2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm3) return new Regex(@"(^|[ ,])mm3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm4) return new Regex(@"(^|[ ,])mm4=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm5) return new Regex(@"(^|[ ,])mm5=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm6) return new Regex(@"(^|[ ,])mm6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mm7) return new Regex(@"(^|[ ,])mm7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Mxcsr) return new Regex(@"(^|[ ,])mxcsr=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Of) return new Regex(@"(^|[ ,])of=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Pf) return new Regex(@"(^|[ ,])pf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R10) return new Regex(@"(^|[ ,])r10=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R10b) return new Regex(@"(^|[ ,])r10b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R10d) return new Regex(@"(^|[ ,])r10d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R10w) return new Regex(@"(^|[ ,])r10w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R11) return new Regex(@"(^|[ ,])r11=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R11b) return new Regex(@"(^|[ ,])r11b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R11d) return new Regex(@"(^|[ ,])r11d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R11w) return new Regex(@"(^|[ ,])r11w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R12) return new Regex(@"(^|[ ,])r12=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R12b) return new Regex(@"(^|[ ,])r12b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R12d) return new Regex(@"(^|[ ,])r12d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R12w) return new Regex(@"(^|[ ,])r12w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R13) return new Regex(@"(^|[ ,])r13=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R13b) return new Regex(@"(^|[ ,])r13b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R13d) return new Regex(@"(^|[ ,])r13d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R13w) return new Regex(@"(^|[ ,])r13w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R14) return new Regex(@"(^|[ ,])r14=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R14b) return new Regex(@"(^|[ ,])r14b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R14d) return new Regex(@"(^|[ ,])r14d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R14w) return new Regex(@"(^|[ ,])r14w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R15) return new Regex(@"(^|[ ,])r15=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R15b) return new Regex(@"(^|[ ,])r15b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R15d) return new Regex(@"(^|[ ,])r15d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R15w) return new Regex(@"(^|[ ,])r15w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R8) return new Regex(@"(^|[ ,])r8=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R8b) return new Regex(@"(^|[ ,])r8b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R8d) return new Regex(@"(^|[ ,])r8d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R8w) return new Regex(@"(^|[ ,])r8w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R9) return new Regex(@"(^|[ ,])r9=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R9b) return new Regex(@"(^|[ ,])r9b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R9d) return new Regex(@"(^|[ ,])r9d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.R9w) return new Regex(@"(^|[ ,])r9w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rax) return new Regex(@"(^|[ ,])rax=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rbp) return new Regex(@"(^|[ ,])rbp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rbx) return new Regex(@"(^|[ ,])rbx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rcx) return new Regex(@"(^|[ ,])rcx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rdi) return new Regex(@"(^|[ ,])rdi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rdx) return new Regex(@"(^|[ ,])rdx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rip) return new Regex(@"(^|[ ,])rip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rsi) return new Regex(@"(^|[ ,])rsi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Rsp) return new Regex(@"(^|[ ,])rsp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Sf) return new Regex(@"(^|[ ,])sf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Si) return new Regex(@"(^|[ ,])si=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Sil) return new Regex(@"(^|[ ,])sil=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Sp) return new Regex(@"(^|[ ,])sp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Spl) return new Regex(@"(^|[ ,])spl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ss) return new Regex(@"(^|[ ,])ss=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St0) return new Regex(@"(^|[ ,])st0= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ (0:0000:0000000000000000)", RegexOptions.IgnoreCase);
            if (register == Register.St1) return new Regex(@"(^|[ ,])st1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St2) return new Regex(@"(^|[ ,])st2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St3) return new Regex(@"(^|[ ,])st3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St4) return new Regex(@"(^|[ ,])st4=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St5) return new Regex(@"(^|[ ,])st5=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St6) return new Regex(@"(^|[ ,])st6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.St7) return new Regex(@"(^|[ ,])st7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Tf) return new Regex(@"(^|[ ,])tf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Vif) return new Regex(@"(^|[ ,])vif=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Vip) return new Regex(@"(^|[ ,])vip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm0) return new Regex(@"(^|[ ,])xmm0=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm0h) return new Regex(@"(^|[ ,])xmm0h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm0l) return new Regex(@"(^|[ ,])xmm0l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm1) return new Regex(@"(^|[ ,])xmm1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm10) return new Regex(@"(^|[ ,])xmm10=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm10h) return new Regex(@"(^|[ ,])xmm10h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm10l) return new Regex(@"(^|[ ,])xmm10l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm11) return new Regex(@"(^|[ ,])xmm11=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm11h) return new Regex(@"(^|[ ,])xmm11h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm11l) return new Regex(@"(^|[ ,])xmm11l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm12) return new Regex(@"(^|[ ,])xmm12=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm12h) return new Regex(@"(^|[ ,])xmm12h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm12l) return new Regex(@"(^|[ ,])xmm12l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm13) return new Regex(@"(^|[ ,])xmm13=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm13h) return new Regex(@"(^|[ ,])xmm13h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm13l) return new Regex(@"(^|[ ,])xmm13l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm14) return new Regex(@"(^|[ ,])xmm14=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm14h) return new Regex(@"(^|[ ,])xmm14h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm14l) return new Regex(@"(^|[ ,])xmm14l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm15) return new Regex(@"(^|[ ,])xmm15=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm15h) return new Regex(@"(^|[ ,])xmm15h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm15l) return new Regex(@"(^|[ ,])xmm15l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm1h) return new Regex(@"(^|[ ,])xmm1h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm1l) return new Regex(@"(^|[ ,])xmm1l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm2) return new Regex(@"(^|[ ,])xmm2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm2h) return new Regex(@"(^|[ ,])xmm2h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm2l) return new Regex(@"(^|[ ,])xmm2l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm3) return new Regex(@"(^|[ ,])xmm3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm3h) return new Regex(@"(^|[ ,])xmm3h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm3l) return new Regex(@"(^|[ ,])xmm3l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm4) return new Regex(@"(^|[ ,])xmm4=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm4h) return new Regex(@"(^|[ ,])xmm4h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm4l) return new Regex(@"(^|[ ,])xmm4l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm5) return new Regex(@"(^|[ ,])xmm5=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm5h) return new Regex(@"(^|[ ,])xmm5h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm5l) return new Regex(@"(^|[ ,])xmm5l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm6) return new Regex(@"(^|[ ,])xmm6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm6h) return new Regex(@"(^|[ ,])xmm6h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm6l) return new Regex(@"(^|[ ,])xmm6l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm7) return new Regex(@"(^|[ ,])xmm7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm7h) return new Regex(@"(^|[ ,])xmm7h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm7l) return new Regex(@"(^|[ ,])xmm7l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm8) return new Regex(@"(^|[ ,])xmm8=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm8h) return new Regex(@"(^|[ ,])xmm8h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm8l) return new Regex(@"(^|[ ,])xmm8l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm9) return new Regex(@"(^|[ ,])xmm9=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm9h) return new Regex(@"(^|[ ,])xmm9h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Xmm9l) return new Regex(@"(^|[ ,])xmm9l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm0) return new Regex(@"(^|[ ,])ymm0=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm0h) return new Regex(@"(^|[ ,])ymm0h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm0l) return new Regex(@"(^|[ ,])ymm0l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm1) return new Regex(@"(^|[ ,])ymm1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm10) return new Regex(@"(^|[ ,])ymm10=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm10h) return new Regex(@"(^|[ ,])ymm10h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm10l) return new Regex(@"(^|[ ,])ymm10l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm11) return new Regex(@"(^|[ ,])ymm11=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm11h) return new Regex(@"(^|[ ,])ymm11h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm11l) return new Regex(@"(^|[ ,])ymm11l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm12) return new Regex(@"(^|[ ,])ymm12=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm12h) return new Regex(@"(^|[ ,])ymm12h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm12l) return new Regex(@"(^|[ ,])ymm12l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm13) return new Regex(@"(^|[ ,])ymm13=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm13h) return new Regex(@"(^|[ ,])ymm13h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm13l) return new Regex(@"(^|[ ,])ymm13l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm14) return new Regex(@"(^|[ ,])ymm14=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm14h) return new Regex(@"(^|[ ,])ymm14h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm14l) return new Regex(@"(^|[ ,])ymm14l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm15) return new Regex(@"(^|[ ,])ymm15=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm15h) return new Regex(@"(^|[ ,])ymm15h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm15l) return new Regex(@"(^|[ ,])ymm15l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm1h) return new Regex(@"(^|[ ,])ymm1h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm1l) return new Regex(@"(^|[ ,])ymm1l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm2) return new Regex(@"(^|[ ,])ymm2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm2h) return new Regex(@"(^|[ ,])ymm2h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm2l) return new Regex(@"(^|[ ,])ymm2l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm3) return new Regex(@"(^|[ ,])ymm3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm3h) return new Regex(@"(^|[ ,])ymm3h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm3l) return new Regex(@"(^|[ ,])ymm3l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm4) return new Regex(@"(^|[ ,])ymm4=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm4h) return new Regex(@"(^|[ ,])ymm4h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm4l) return new Regex(@"(^|[ ,])ymm4l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm5) return new Regex(@"(^|[ ,])ymm5=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm5h) return new Regex(@"(^|[ ,])ymm5h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm5l) return new Regex(@"(^|[ ,])ymm5l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm6) return new Regex(@"(^|[ ,])ymm6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm6h) return new Regex(@"(^|[ ,])ymm6h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm6l) return new Regex(@"(^|[ ,])ymm6l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm7) return new Regex(@"(^|[ ,])ymm7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm7h) return new Regex(@"(^|[ ,])ymm7h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm7l) return new Regex(@"(^|[ ,])ymm7l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm8) return new Regex(@"(^|[ ,])ymm8=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm8h) return new Regex(@"(^|[ ,])ymm8h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm8l) return new Regex(@"(^|[ ,])ymm8l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm9) return new Regex(@"(^|[ ,])ymm9=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm9h) return new Regex(@"(^|[ ,])ymm9h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Ymm9l) return new Regex(@"(^|[ ,])ymm9l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (register == Register.Zf) return new Regex(@"(^|[ ,])zf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase);
            throw new ArgumentOutOfRangeException(
                $"{nameof(register)} was not found in the factory, this is a programming error.");
        }
        /// <summary>
        ///     Gets the current register set.
        /// </summary>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        public RegisterSet GetCurrentRegisterSet(IEnumerable<Register> registers)
        {
            return GetCurrentRegisterSet(DebugEngineProxy.GetCurrentThreadId(), registers);
        }
    }
}