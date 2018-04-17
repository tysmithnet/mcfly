// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-16-2018
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
            Process(list, registerText, registerSet);
            return registerSet;
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

        /// <summary>
        ///     Gets the register regex.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>Regex.</returns>
        /// <exception cref="ArgumentOutOfRangeException">register</exception>
        public Regex GetRegisterRegex(Register register)
        {
            if (register == Register.Af)
                return new Regex(@"(^|[ ,])af=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ah)
                return new Regex(@"(^|[ ,])ah=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Al)
                return new Regex(@"(^|[ ,])al=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ax)
                return new Regex(@"(^|[ ,])ax=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Bh)
                return new Regex(@"(^|[ ,])bh=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Bl)
                return new Regex(@"(^|[ ,])bl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Bp)
                return new Regex(@"(^|[ ,])bp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Bpl)
                return new Regex(@"(^|[ ,])bpl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Brfrom)
                return new Regex(@"(^|[ ,])brfrom=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Brto)
                return new Regex(@"(^|[ ,])brto=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Bx)
                return new Regex(@"(^|[ ,])bx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Cf)
                return new Regex(@"(^|[ ,])cf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ch)
                return new Regex(@"(^|[ ,])ch=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Cl)
                return new Regex(@"(^|[ ,])cl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Cs)
                return new Regex(@"(^|[ ,])cs=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Cx)
                return new Regex(@"(^|[ ,])cx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Df)
                return new Regex(@"(^|[ ,])df=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dh)
                return new Regex(@"(^|[ ,])dh=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Di)
                return new Regex(@"(^|[ ,])di=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dil)
                return new Regex(@"(^|[ ,])dil=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dl)
                return new Regex(@"(^|[ ,])dl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dr0)
                return new Regex(@"(^|[ ,])dr0=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dr1)
                return new Regex(@"(^|[ ,])dr1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dr2)
                return new Regex(@"(^|[ ,])dr2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dr3)
                return new Regex(@"(^|[ ,])dr3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dr6)
                return new Regex(@"(^|[ ,])dr6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dr7)
                return new Regex(@"(^|[ ,])dr7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ds)
                return new Regex(@"(^|[ ,])ds=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Dx)
                return new Regex(@"(^|[ ,])dx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Eax)
                return new Regex(@"(^|[ ,])eax=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ebp)
                return new Regex(@"(^|[ ,])ebp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ebx)
                return new Regex(@"(^|[ ,])ebx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ecx)
                return new Regex(@"(^|[ ,])ecx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Edi)
                return new Regex(@"(^|[ ,])edi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Edx)
                return new Regex(@"(^|[ ,])edx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Efl)
                return new Regex(@"(^|[ ,])efl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Eip)
                return new Regex(@"(^|[ ,])eip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Es)
                return new Regex(@"(^|[ ,])es=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Esi)
                return new Regex(@"(^|[ ,])esi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Esp)
                return new Regex(@"(^|[ ,])esp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Exfrom)
                return new Regex(@"(^|[ ,])exfrom=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Exto)
                return new Regex(@"(^|[ ,])exto=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fl)
                return new Regex(@"(^|[ ,])fl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fpcw)
                return new Regex(@"(^|[ ,])fpcw=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fpsw)
                return new Regex(@"(^|[ ,])fpsw=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fptw)
                return new Regex(@"(^|[ ,])fptw=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fopcode)
                return new Regex(@"(^|[ ,])fopcode=(?<val>[a-f0-9]+)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fpip)
                return new Regex(@"(^|[ ,])fpip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fpipsel)
                return new Regex(@"(^|[ ,])fpipsel=(?<val>[a-f0-9]+)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fpdp)
                return new Regex(@"(^|[ ,])fpdp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fpdpsel)
                return new Regex(@"(^|[ ,])fpdpsel=(?<val>[a-f0-9]+)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Fs)
                return new Regex(@"(^|[ ,])fs=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Gs)
                return new Regex(@"(^|[ ,])gs=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.If)
                return new Regex(@"(^|[ ,])if=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Iopl)
                return new Regex(@"(^|[ ,])iopl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ip)
                return new Regex(@"(^|[ ,])ip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm0)
                return new Regex(@"(^|[ ,])mm0=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm1)
                return new Regex(@"(^|[ ,])mm1=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm2)
                return new Regex(@"(^|[ ,])mm2=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm3)
                return new Regex(@"(^|[ ,])mm3=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm4)
                return new Regex(@"(^|[ ,])mm4=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm5)
                return new Regex(@"(^|[ ,])mm5=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm6)
                return new Regex(@"(^|[ ,])mm6=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mm7)
                return new Regex(@"(^|[ ,])mm7=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Mxcsr)
                return new Regex(@"(^|[ ,])mxcsr=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Of)
                return new Regex(@"(^|[ ,])of=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Pf)
                return new Regex(@"(^|[ ,])pf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R10)
                return new Regex(@"(^|[ ,])r10=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R10b)
                return new Regex(@"(^|[ ,])r10b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R10d)
                return new Regex(@"(^|[ ,])r10d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R10w)
                return new Regex(@"(^|[ ,])r10w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R11)
                return new Regex(@"(^|[ ,])r11=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R11b)
                return new Regex(@"(^|[ ,])r11b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R11d)
                return new Regex(@"(^|[ ,])r11d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R11w)
                return new Regex(@"(^|[ ,])r11w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R12)
                return new Regex(@"(^|[ ,])r12=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R12b)
                return new Regex(@"(^|[ ,])r12b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R12d)
                return new Regex(@"(^|[ ,])r12d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R12w)
                return new Regex(@"(^|[ ,])r12w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R13)
                return new Regex(@"(^|[ ,])r13=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R13b)
                return new Regex(@"(^|[ ,])r13b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R13d)
                return new Regex(@"(^|[ ,])r13d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R13w)
                return new Regex(@"(^|[ ,])r13w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R14)
                return new Regex(@"(^|[ ,])r14=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R14b)
                return new Regex(@"(^|[ ,])r14b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R14d)
                return new Regex(@"(^|[ ,])r14d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R14w)
                return new Regex(@"(^|[ ,])r14w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R15)
                return new Regex(@"(^|[ ,])r15=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R15b)
                return new Regex(@"(^|[ ,])r15b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R15d)
                return new Regex(@"(^|[ ,])r15d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R15w)
                return new Regex(@"(^|[ ,])r15w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R8)
                return new Regex(@"(^|[ ,])r8=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R8b)
                return new Regex(@"(^|[ ,])r8b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R8d)
                return new Regex(@"(^|[ ,])r8d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R8w)
                return new Regex(@"(^|[ ,])r8w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R9)
                return new Regex(@"(^|[ ,])r9=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R9b)
                return new Regex(@"(^|[ ,])r9b=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R9d)
                return new Regex(@"(^|[ ,])r9d=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.R9w)
                return new Regex(@"(^|[ ,])r9w=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rax)
                return new Regex(@"(^|[ ,])rax=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rbp)
                return new Regex(@"(^|[ ,])rbp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rbx)
                return new Regex(@"(^|[ ,])rbx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rcx)
                return new Regex(@"(^|[ ,])rcx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rdi)
                return new Regex(@"(^|[ ,])rdi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rdx)
                return new Regex(@"(^|[ ,])rdx=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rip)
                return new Regex(@"(^|[ ,])rip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rsi)
                return new Regex(@"(^|[ ,])rsi=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Rsp)
                return new Regex(@"(^|[ ,])rsp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Sf)
                return new Regex(@"(^|[ ,])sf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Si)
                return new Regex(@"(^|[ ,])si=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Sil)
                return new Regex(@"(^|[ ,])sil=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Sp)
                return new Regex(@"(^|[ ,])sp=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Spl)
                return new Regex(@"(^|[ ,])spl=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ss)
                return new Regex(@"(^|[ ,])ss=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St0)
                return new Regex(
                    @"(^|[ ,])st0= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St1)
                return new Regex(
                    @"(^|[ ,])st1= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St2)
                return new Regex(
                    @"(^|[ ,])st2= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St3)
                return new Regex(
                    @"(^|[ ,])st3= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St4)
                return new Regex(
                    @"(^|[ ,])st4= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St5)
                return new Regex(
                    @"(^|[ ,])st5= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St6)
                return new Regex(
                    @"(^|[ ,])st6= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.St7)
                return new Regex(
                    @"(^|[ ,])st7= [a-f0-9-]+.[a-f0-9]+[a-f0-9]+e\+[a-f0-9]+ \(0:(?<val>[a-f0-9]{4}:[a-f0-9]{16})\)",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Tf)
                return new Regex(@"(^|[ ,])tf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Vif)
                return new Regex(@"(^|[ ,])vif=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Vip)
                return new Regex(@"(^|[ ,])vip=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm0)
                return new Regex(@"(^|[ ,])xmm0=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm0h)
                return new Regex(@"(^|[ ,])xmm0h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm0l)
                return new Regex(@"(^|[ ,])xmm0l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm1)
                return new Regex(@"(^|[ ,])xmm1=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm10)
                return new Regex(@"(^|[ ,])xmm10=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm10h)
                return new Regex(@"(^|[ ,])xmm10h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm10l)
                return new Regex(@"(^|[ ,])xmm10l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm11)
                return new Regex(@"(^|[ ,])xmm11=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm11h)
                return new Regex(@"(^|[ ,])xmm11h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm11l)
                return new Regex(@"(^|[ ,])xmm11l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm12)
                return new Regex(@"(^|[ ,])xmm12=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm12h)
                return new Regex(@"(^|[ ,])xmm12h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm12l)
                return new Regex(@"(^|[ ,])xmm12l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm13)
                return new Regex(@"(^|[ ,])xmm13=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm13h)
                return new Regex(@"(^|[ ,])xmm13h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm13l)
                return new Regex(@"(^|[ ,])xmm13l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm14)
                return new Regex(@"(^|[ ,])xmm14=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm14h)
                return new Regex(@"(^|[ ,])xmm14h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm14l)
                return new Regex(@"(^|[ ,])xmm14l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm15)
                return new Regex(@"(^|[ ,])xmm15=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm15h)
                return new Regex(@"(^|[ ,])xmm15h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm15l)
                return new Regex(@"(^|[ ,])xmm15l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm1h)
                return new Regex(@"(^|[ ,])xmm1h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm1l)
                return new Regex(@"(^|[ ,])xmm1l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm2)
                return new Regex(@"(^|[ ,])xmm2=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm2h)
                return new Regex(@"(^|[ ,])xmm2h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm2l)
                return new Regex(@"(^|[ ,])xmm2l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm3)
                return new Regex(@"(^|[ ,])xmm3=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm3h)
                return new Regex(@"(^|[ ,])xmm3h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm3l)
                return new Regex(@"(^|[ ,])xmm3l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm4)
                return new Regex(@"(^|[ ,])xmm4=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm4h)
                return new Regex(@"(^|[ ,])xmm4h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm4l)
                return new Regex(@"(^|[ ,])xmm4l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm5)
                return new Regex(@"(^|[ ,])xmm5=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm5h)
                return new Regex(@"(^|[ ,])xmm5h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm5l)
                return new Regex(@"(^|[ ,])xmm5l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm6)
                return new Regex(@"(^|[ ,])xmm6=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm6h)
                return new Regex(@"(^|[ ,])xmm6h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm6l)
                return new Regex(@"(^|[ ,])xmm6l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm7)
                return new Regex(@"(^|[ ,])xmm7=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm7h)
                return new Regex(@"(^|[ ,])xmm7h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm7l)
                return new Regex(@"(^|[ ,])xmm7l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm8)
                return new Regex(@"(^|[ ,])xmm8=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm8h)
                return new Regex(@"(^|[ ,])xmm8h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm8l)
                return new Regex(@"(^|[ ,])xmm8l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm9)
                return new Regex(@"(^|[ ,])xmm9=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm9h)
                return new Regex(@"(^|[ ,])xmm9h=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Xmm9l)
                return new Regex(@"(^|[ ,])xmm9l=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm0)
                return new Regex(@"(^|[ ,])ymm0=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm0h)
                return new Regex(@"(^|[ ,])ymm0h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm0l)
                return new Regex(@"(^|[ ,])ymm0l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm1)
                return new Regex(@"(^|[ ,])ymm1=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm10)
                return new Regex(@"(^|[ ,])ymm10=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm10h)
                return new Regex(@"(^|[ ,])ymm10h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm10l)
                return new Regex(@"(^|[ ,])ymm10l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm11)
                return new Regex(@"(^|[ ,])ymm11=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm11h)
                return new Regex(@"(^|[ ,])ymm11h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm11l)
                return new Regex(@"(^|[ ,])ymm11l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm12)
                return new Regex(@"(^|[ ,])ymm12=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm12h)
                return new Regex(@"(^|[ ,])ymm12h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm12l)
                return new Regex(@"(^|[ ,])ymm12l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm13)
                return new Regex(@"(^|[ ,])ymm13=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm13h)
                return new Regex(@"(^|[ ,])ymm13h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm13l)
                return new Regex(@"(^|[ ,])ymm13l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm14)
                return new Regex(@"(^|[ ,])ymm14=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm14h)
                return new Regex(@"(^|[ ,])ymm14h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm14l)
                return new Regex(@"(^|[ ,])ymm14l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm15)
                return new Regex(@"(^|[ ,])ymm15=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm15h)
                return new Regex(@"(^|[ ,])ymm15h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm15l)
                return new Regex(@"(^|[ ,])ymm15l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm1h)
                return new Regex(@"(^|[ ,])ymm1h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm1l)
                return new Regex(@"(^|[ ,])ymm1l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm2)
                return new Regex(@"(^|[ ,])ymm2=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm2h)
                return new Regex(@"(^|[ ,])ymm2h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm2l)
                return new Regex(@"(^|[ ,])ymm2l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm3)
                return new Regex(@"(^|[ ,])ymm3=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm3h)
                return new Regex(@"(^|[ ,])ymm3h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm3l)
                return new Regex(@"(^|[ ,])ymm3l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm4)
                return new Regex(@"(^|[ ,])ymm4=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm4h)
                return new Regex(@"(^|[ ,])ymm4h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm4l)
                return new Regex(@"(^|[ ,])ymm4l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm5)
                return new Regex(@"(^|[ ,])ymm5=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm5h)
                return new Regex(@"(^|[ ,])ymm5h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm5l)
                return new Regex(@"(^|[ ,])ymm5l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm6)
                return new Regex(@"(^|[ ,])ymm6=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm6h)
                return new Regex(@"(^|[ ,])ymm6h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm6l)
                return new Regex(@"(^|[ ,])ymm6l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm7)
                return new Regex(@"(^|[ ,])ymm7=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm7h)
                return new Regex(@"(^|[ ,])ymm7h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm7l)
                return new Regex(@"(^|[ ,])ymm7l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm8)
                return new Regex(@"(^|[ ,])ymm8=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm8h)
                return new Regex(@"(^|[ ,])ymm8h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm8l)
                return new Regex(@"(^|[ ,])ymm8l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm9)
                return new Regex(@"(^|[ ,])ymm9=(?<val>(\s+[a-f0-9]+){8})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm9h)
                return new Regex(@"(^|[ ,])ymm9h=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Ymm9l)
                return new Regex(@"(^|[ ,])ymm9l=(?<val>(\s+[a-f0-9]+){4})",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (register == Register.Zf)
                return new Regex(@"(^|[ ,])zf=(?<val>[a-f0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            throw new ArgumentOutOfRangeException(
                $"{nameof(register)} was not found in the factory, this is a programming error.");
        }

        /// <summary>
        ///     Processes the specified registers.
        /// </summary>
        /// <param name="registers">The registers.</param>
        /// <param name="registerText">The register text.</param>
        /// <param name="registerSet">The register set.</param>
        public void Process(IEnumerable<Register> registers, string registerText, RegisterSet registerSet)
        {
            foreach (var register in registers)
            {
                var regex = GetRegisterRegex(register);
                var match = regex.Match(registerText);
                var value = match.Groups["val"].Value;
                ProcessRegister(register, value, registerSet);
            }
        }

        /// <summary>
        ///     Processes the register.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="input">The input.</param>
        /// <param name="registerSet">The register set.</param>
        /// <param name="radix">The radix.</param>
        /// <exception cref="ArgumentNullException">
        ///     register
        ///     or
        ///     input
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">register</exception>
        public void ProcessRegister(Register register, string input, RegisterSet registerSet, int radix = 16)
        {
            register = register ?? throw new ArgumentNullException(nameof(register));
            input = input ?? throw new ArgumentNullException(nameof(input));

            var ymmRegex = new Regex(
                @"\s*(?<a>[a-z0-9]+)\s*(?<b>[a-z0-9]+)\s*(?<c>[a-z0-9]+)\s*(?<d>[a-z0-9]+)\s*(?<e>[a-z0-9]+)\s*(?<f>[a-z0-9]+)\s*(?<g>[a-z0-9]+)\s*(?<h>[a-z0-9]+)",
                RegexOptions.IgnoreCase);
            var stRegex = new Regex(@"(?<hi>[a-f0-9]+):(?<lo>[a-f0-9]+)", RegexOptions.IgnoreCase);
            var xmmRegex = new Regex(
                @"\s*(?<a>[a-z0-9]+)\s*(?<b>[a-z0-9]+)\s*(?<c>[a-z0-9]+)\s*(?<d>[a-z0-9]+)\s*",
                RegexOptions.IgnoreCase);
            switch (register.Name.ToLower())
            {
                case "rax":
                    registerSet.Rax = Convert.ToUInt64(input, radix);
                    break;
                case "rbx":
                    registerSet.Rbx = Convert.ToUInt64(input, radix);
                    break;
                case "rcx":
                    registerSet.Rcx = Convert.ToUInt64(input, radix);
                    break;
                case "rdx":
                    registerSet.Rdx = Convert.ToUInt64(input, radix);
                    break;
                case "rsp":
                    registerSet.Rsp = Convert.ToUInt64(input, radix);
                    break;
                case "rbp":
                    registerSet.Rbp = Convert.ToUInt64(input, radix);
                    break;
                case "rsi":
                    registerSet.Rsi = Convert.ToUInt64(input, radix);
                    break;
                case "rdi":
                    registerSet.Rdi = Convert.ToUInt64(input, radix);
                    break;
                case "r8":
                    registerSet.R8 = Convert.ToUInt64(input, radix);
                    break;
                case "r9":
                    registerSet.R9 = Convert.ToUInt64(input, radix);
                    break;
                case "r10":
                    registerSet.R10 = Convert.ToUInt64(input, radix);
                    break;
                case "r11":
                    registerSet.R11 = Convert.ToUInt64(input, radix);
                    break;
                case "r12":
                    registerSet.R12 = Convert.ToUInt64(input, radix);
                    break;
                case "r13":
                    registerSet.R13 = Convert.ToUInt64(input, radix);
                    break;
                case "r14":
                    registerSet.R14 = Convert.ToUInt64(input, radix);
                    break;
                case "r15":
                    registerSet.R15 = Convert.ToUInt64(input, radix);
                    break;
                case "rip":
                    registerSet.Rip = Convert.ToUInt64(input, radix);
                    break;
                case "efl":
                    registerSet.Efl = Convert.ToUInt32(input, radix);
                    break;
                case "cs":
                    registerSet.Cs = Convert.ToUInt16(input, radix);
                    break;
                case "ds":
                    registerSet.Ds = Convert.ToUInt16(input, radix);
                    break;
                case "es":
                    registerSet.Es = Convert.ToUInt16(input, radix);
                    break;
                case "fs":
                    registerSet.Fs = Convert.ToUInt16(input, radix);
                    break;
                case "gs":
                    registerSet.Gs = Convert.ToUInt16(input, radix);
                    break;
                case "ss":
                    registerSet.Ss = Convert.ToUInt16(input, radix);
                    break;
                case "dr0":
                    registerSet.Dr0 = Convert.ToUInt64(input, radix);
                    break;
                case "dr1":
                    registerSet.Dr1 = Convert.ToUInt64(input, radix);
                    break;
                case "dr2":
                    registerSet.Dr2 = Convert.ToUInt64(input, radix);
                    break;
                case "dr3":
                    registerSet.Dr3 = Convert.ToUInt64(input, radix);
                    break;
                case "dr6":
                    registerSet.Dr6 = Convert.ToUInt64(input, radix);
                    break;
                case "dr7":
                    registerSet.Dr7 = Convert.ToUInt64(input, radix);
                    break;
                case "fpcw":
                    registerSet.Fpcw = Convert.ToUInt16(input, radix);
                    break;
                case "fpsw":
                    registerSet.Fpsw = Convert.ToUInt16(input, radix);
                    break;
                case "fptw":
                    registerSet.Fptw = Convert.ToUInt16(input, radix);
                    break;
                case "fopcode":
                    registerSet.Fopcode = Convert.ToUInt32(input, radix);
                    break;
                case "fpip":
                    registerSet.Fpip = Convert.ToUInt32(input, radix);
                    break;
                case "fpipsel":
                    registerSet.Fpipsel = Convert.ToUInt32(input, radix);
                    break;
                case "fpdp":
                    registerSet.Fpdp = Convert.ToUInt32(input, radix);
                    break;
                case "fpdpsel":
                    registerSet.Fpdpsel = Convert.ToUInt32(input, radix);
                    break;
                case "st0":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St0 = bytes;
                    break;
                }
                case "st1":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St1 = bytes;
                    break;
                }
                case "st2":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St2 = bytes;
                    break;
                }
                case "st3":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St3 = bytes;
                    break;
                }
                case "st4":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St4 = bytes;
                    break;
                }
                case "st5":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St5 = bytes;
                    break;
                }
                case "st6":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St6 = bytes;
                    break;
                }
                case "st7":
                {
                    var regex = stRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    var high = match.Groups["hi"].Value;
                    var low = match.Groups["lo"].Value;
                    var builder = new ByteArrayBuilder();
                    var bytes = builder.AppdendHexString(high).AppdendHexString(low).Reverse().Build();
                    registerSet.St7 = bytes;
                    break;
                }
                case "mm0":
                    registerSet.Mm0 = Convert.ToUInt64(input, radix);
                    break;
                case "mm1":
                    registerSet.Mm1 = Convert.ToUInt64(input, radix);
                    break;
                case "mm2":
                    registerSet.Mm2 = Convert.ToUInt64(input, radix);
                    break;
                case "mm3":
                    registerSet.Mm3 = Convert.ToUInt64(input, radix);
                    break;
                case "mm4":
                    registerSet.Mm4 = Convert.ToUInt64(input, radix);
                    break;
                case "mm5":
                    registerSet.Mm5 = Convert.ToUInt64(input, radix);
                    break;
                case "mm6":
                    registerSet.Mm6 = Convert.ToUInt64(input, radix);
                    break;
                case "mm7":
                    registerSet.Mm7 = Convert.ToUInt64(input, radix);
                    break;
                case "mxcsr":
                    registerSet.Mxcsr = Convert.ToUInt32(input, radix);
                    break;
                case "ymm0":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm0 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm1":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm1 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm2":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm2 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm3":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm3 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm4":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm4 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm5":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm5 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm6":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm6 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm7":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm7 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm8":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm8 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm9":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm9 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm10":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm10 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm11":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm11 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm12":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm12 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm13":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm13 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm14":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm14 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "ymm15":
                {
                    var regex = ymmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Ymm15 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }

                case "xmm0":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm0 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm1":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm1 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm2":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm2 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm3":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm3 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm4":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm4 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm5":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm5 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm6":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm6 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm7":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm7 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm8":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm8 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm9":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm9 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm10":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm10 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm11":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm11 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm12":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm12 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm13":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm13 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm14":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm14 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm15":
                {
                    var regex = xmmRegex;
                    var match = regex.Match(input);
                    if (!match.Success)
                        break;
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    registerSet.Xmm15 = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    break;
                }
                case "xmm0l":
                    registerSet.Xmm0l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm1l":
                    registerSet.Xmm1l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm2l":
                    registerSet.Xmm2l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm3l":
                    registerSet.Xmm3l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm4l":
                    registerSet.Xmm4l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm5l":
                    registerSet.Xmm5l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm6l":
                    registerSet.Xmm6l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm7l":
                    registerSet.Xmm7l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm8l":
                    registerSet.Xmm8l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm9l":
                    registerSet.Xmm9l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm10l":
                    registerSet.Xmm10l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm11l":
                    registerSet.Xmm11l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm12l":
                    registerSet.Xmm12l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm13l":
                    registerSet.Xmm13l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm14l":
                    registerSet.Xmm14l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm15l":
                    registerSet.Xmm15l = Convert.ToUInt64(input, 16);
                    break;

                case "xmm0h":
                    registerSet.Xmm0h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm1h":
                    registerSet.Xmm1h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm2h":
                    registerSet.Xmm2h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm3h":
                    registerSet.Xmm3h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm4h":
                    registerSet.Xmm4h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm5h":
                    registerSet.Xmm5h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm6h":
                    registerSet.Xmm6h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm7h":
                    registerSet.Xmm7h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm8h":
                    registerSet.Xmm8h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm9h":
                    registerSet.Xmm9h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm10h":
                    registerSet.Xmm10h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm11h":
                    registerSet.Xmm11h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm12h":
                    registerSet.Xmm12h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm13h":
                    registerSet.Xmm13h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm14h":
                    registerSet.Xmm14h = Convert.ToUInt64(input, 16);
                    break;

                case "xmm15h":
                    registerSet.Xmm15h = Convert.ToUInt64(input, 16);
                    break;
                case "ymm0h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm0h = bytes;
                    break;
                }

                case "ymm1h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm1h = bytes;
                    break;
                }

                case "ymm2h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm2h = bytes;
                    break;
                }

                case "ymm3h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm3h = bytes;
                    break;
                }

                case "ymm4h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm4h = bytes;
                    break;
                }

                case "ymm5h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm5h = bytes;
                    break;
                }

                case "ymm6h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm6h = bytes;
                    break;
                }

                case "ymm7h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm7h = bytes;
                    break;
                }

                case "ymm8h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm8h = bytes;
                    break;
                }

                case "ymm9h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm9h = bytes;
                    break;
                }

                case "ymm10h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm10h = bytes;
                    break;
                }

                case "ymm11h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm11h = bytes;
                    break;
                }

                case "ymm12h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm12h = bytes;
                    break;
                }

                case "ymm13h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm13h = bytes;
                    break;
                }

                case "ymm14h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm14h = bytes;
                    break;
                }

                case "ymm15h":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm15h = bytes;
                    break;
                }
                case "ymm0l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm0l = bytes;
                    break;
                }

                case "ymm1l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm1l = bytes;
                    break;
                }

                case "ymm2l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm2l = bytes;
                    break;
                }

                case "ymm3l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm3l = bytes;
                    break;
                }

                case "ymm4l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm4l = bytes;
                    break;
                }

                case "ymm5l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm5l = bytes;
                    break;
                }

                case "ymm6l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm6l = bytes;
                    break;
                }

                case "ymm7l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm7l = bytes;
                    break;
                }

                case "ymm8l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm8l = bytes;
                    break;
                }

                case "ymm9l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm9l = bytes;
                    break;
                }

                case "ymm10l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm10l = bytes;
                    break;
                }

                case "ymm11l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm11l = bytes;
                    break;
                }

                case "ymm12l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm12l = bytes;
                    break;
                }

                case "ymm13l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm13l = bytes;
                    break;
                }

                case "ymm14l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm14l = bytes;
                    break;
                }

                case "ymm15l":
                {
                    input = PadYmmRegister(input);
                    var stripped = Regex.Replace(input, @"\s*", "");
                    var bytes = new ByteArrayBuilder().AppdendHexString(stripped).Reverse().Build();
                    registerSet.Ymm15l = bytes;
                    break;
                }
                case "exfrom":

                    registerSet.Exfrom = Convert.ToUInt64(input, 16);
                    break;

                case "exto":

                    registerSet.Exto = Convert.ToUInt64(input, 16);
                    break;

                case "brfrom":

                    registerSet.Brfrom = Convert.ToUInt64(input, 16);
                    break;

                case "brto":

                    registerSet.Brto = Convert.ToUInt64(input, 16);
                    break;

                case "eax":

                    registerSet.Eax = Convert.ToUInt32(input, 16);
                    break;

                case "ecx":

                    registerSet.Ecx = Convert.ToUInt32(input, 16);
                    break;

                case "edx":

                    registerSet.Edx = Convert.ToUInt32(input, 16);
                    break;

                case "ebx":

                    registerSet.Ebx = Convert.ToUInt32(input, 16);
                    break;

                case "esp":

                    registerSet.Esp = Convert.ToUInt32(input, 16);
                    break;

                case "ebp":

                    registerSet.Ebp = Convert.ToUInt32(input, 16);
                    break;

                case "esi":

                    registerSet.Esi = Convert.ToUInt32(input, 16);
                    break;

                case "edi":

                    registerSet.Edi = Convert.ToUInt32(input, 16);
                    break;

                case "r8d":
                    registerSet.R8d = Convert.ToUInt32(input, 16);
                    break;
                case "r9d":
                    registerSet.R9d = Convert.ToUInt32(input, 16);
                    break;
                case "r10d":
                    registerSet.R10d = Convert.ToUInt32(input, 16);
                    break;
                case "r11d":
                    registerSet.R11d = Convert.ToUInt32(input, 16);
                    break;
                case "r12d":
                    registerSet.R12d = Convert.ToUInt32(input, 16);
                    break;
                case "r13d":
                    registerSet.R13d = Convert.ToUInt32(input, 16);
                    break;
                case "r14d":
                    registerSet.R14d = Convert.ToUInt32(input, 16);
                    break;
                case "r15d":
                    registerSet.R15d = Convert.ToUInt32(input, 16);
                    break;
                case "eip":
                {
                    registerSet.Eip = Convert.ToUInt32(input, 16);
                    break;
                }
                case "ax":
                {
                    registerSet.Ax = Convert.ToUInt16(input, 16);
                    break;
                }
                case "cx":
                {
                    registerSet.Cx = Convert.ToUInt16(input, 16);
                    break;
                }
                case "dx":
                {
                    registerSet.Dx = Convert.ToUInt16(input, 16);
                    break;
                }
                case "bx":
                {
                    registerSet.Bx =
                        Convert.ToUInt16(input, 16);
                    break;
                }
                case "sp":
                {
                    registerSet.Sp = Convert.ToUInt16(input, 16);
                    break;
                }
                case "bp":
                {
                    registerSet.Bp = Convert.ToUInt16(input, 16);
                    break;
                }
                case "si":
                    registerSet.Si = Convert.ToUInt16(input, 16);
                    break;
                case "di":
                    registerSet.Di = Convert.ToUInt16(input, 16);
                    break;
                case "r8w":
                    registerSet.R8w = Convert.ToUInt16(input, 16);
                    break;
                case "r9w":
                    registerSet.R9w = Convert.ToUInt16(input, 16);
                    break;
                case "r10w":
                    registerSet.R10w = Convert.ToUInt16(input, 16);
                    break;
                case "r11w":
                    registerSet.R11w = Convert.ToUInt16(input, 16);
                    break;
                case "r12w":
                    registerSet.R12w = Convert.ToUInt16(input, 16);
                    break;
                case "r13w":
                    registerSet.R13w = Convert.ToUInt16(input, 16);
                    break;
                case "r14w":
                    registerSet.R14w = Convert.ToUInt16(input, 16);
                    break;
                case "r15w":
                    registerSet.R15w = Convert.ToUInt16(input, 16);
                    break;
                case "ip":
                    registerSet.Ip = Convert.ToUInt16(input, 16);
                    break;
                case "fl":
                    registerSet.Fl = Convert.ToUInt16(input, 16);
                    break;
                case "al":
                    registerSet.Al = Convert.ToByte(input, 16);
                    break;
                case "bl":
                    registerSet.Bl = Convert.ToByte(input, 16);
                    break;
                case "cl":
                    registerSet.Cl = Convert.ToByte(input, 16);
                    break;
                case "spl":
                    registerSet.Spl = Convert.ToByte(input, 16);
                    break;
                case "dl":
                    registerSet.Dl = Convert.ToByte(input, 16);
                    break;
                case "bpl":
                    registerSet.Bpl = Convert.ToByte(input, 16);
                    break;
                case "sil":
                    registerSet.Sil = Convert.ToByte(input, 16);
                    break;
                case "dil":
                    registerSet.Dil = Convert.ToByte(input, 16);
                    break;
                case "r8b":
                    registerSet.R8b = Convert.ToByte(input, 16);
                    break;
                case "r9b":
                    registerSet.R9b = Convert.ToByte(input, 16);
                    break;
                case "r10b":
                    registerSet.R10b = Convert.ToByte(input, 16);
                    break;
                case "r11b":
                    registerSet.R11b = Convert.ToByte(input, 16);
                    break;
                case "r12b":
                    registerSet.R12b = Convert.ToByte(input, 16);
                    break;
                case "r13b":
                    registerSet.R13b = Convert.ToByte(input, 16);
                    break;
                case "r14b":
                    registerSet.R14b = Convert.ToByte(input, 16);
                    break;
                case "r15b":
                    registerSet.R15b = Convert.ToByte(input, 16);
                    break;
                case "ah":
                    registerSet.Ah = Convert.ToByte(input, 16);
                    break;
                case "bh":
                    registerSet.Bh = Convert.ToByte(input, 16);
                    break;
                case "ch":
                    registerSet.Ch = Convert.ToByte(input, 16);
                    break;
                case "dh":
                    registerSet.Dh = Convert.ToByte(input, 16);
                    break;
                case "iopl":
                    registerSet.Iopl = Convert.ToByte(input, 16);
                    break;
                case "of":
                    registerSet.Of = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "df":
                    registerSet.Df = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "if":
                    registerSet.If = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "tf":
                    registerSet.Tf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "sf":
                    registerSet.Sf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "zf":
                    registerSet.Zf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "af":
                    registerSet.Af = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "pf":
                    registerSet.Pf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "cf":
                    registerSet.Cf = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "vip":
                    registerSet.Vip = Convert.ToUInt64(input, 16) > 0;
                    break;
                case "vif":
                    registerSet.Vif = Convert.ToUInt64(input, 16) > 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"{nameof(register)} has a value of {register} which is not a valid register");
            }
        }

        private static string PadYmmRegister(string input)
        {
            return string.Join("",
                Regex.Split(input, " ").Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.PadLeft(8, '0')));
        }

        /// <summary>
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }
    }
}