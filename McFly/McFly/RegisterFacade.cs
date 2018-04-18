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
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        public RegisterSet GetCurrentRegisterSet(int threadId, IEnumerable<Register> registers)
        {
            var registerSet = new RegisterSet();
            foreach (var register in registers)
            {
                var bytes = DebugEngineProxy.GetRegisterValue(threadId, register);
                if (register == Register.Af)
                {
                    registerSet.Af = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Ah)
                {
                    registerSet.Ah = bytes[0];
                }
                else if (register == Register.Al)
                {
                    registerSet.Al = bytes[0];
                }
                else if (register == Register.Ax)
                {
                    registerSet.Ax = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Bh)
                {
                    registerSet.Bh = bytes[0];
                }
                else if (register == Register.Bl)
                {
                    registerSet.Bl = bytes[0];
                }
                else if (register == Register.Bp)
                {
                    registerSet.Bp = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Bpl)
                {
                    registerSet.Bpl = bytes[0];
                }
                else if (register == Register.Brfrom)
                {
                    registerSet.Brfrom = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Brto)
                {
                    registerSet.Brto = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Bx)
                {
                    registerSet.Bx = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Cf)
                {
                    registerSet.Cf = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Ch)
                {
                    registerSet.Ch = bytes[0];
                }
                else if (register == Register.Cl)
                {
                    registerSet.Cl = bytes[0];
                }
                else if (register == Register.Cs)
                {
                    registerSet.Cs = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Cx)
                {
                    registerSet.Cx = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Df)
                {
                    registerSet.Df = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Dh)
                {
                    registerSet.Dh =bytes[0];
                }
                else if (register == Register.Di)
                {
                    registerSet.Di = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Dil)
                {
                    registerSet.Dil = bytes[0];
                }
                else if (register == Register.Dl)
                {
                    registerSet.Dl = bytes[0];
                }
                else if (register == Register.Dr0)
                {
                    registerSet.Dr0 = DebugEngineProxy.Is32Bit ? BitConverter.ToUInt32(bytes, 0) : BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Dr1)
                {
                    registerSet.Dr1 = DebugEngineProxy.Is32Bit ? BitConverter.ToUInt32(bytes, 0) : BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Dr2)
                {
                    registerSet.Dr2 = DebugEngineProxy.Is32Bit ? BitConverter.ToUInt32(bytes, 0) : BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Dr3)
                {
                    registerSet.Dr3 = DebugEngineProxy.Is32Bit ? BitConverter.ToUInt32(bytes, 0) : BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Dr6)
                {
                    registerSet.Dr6 = DebugEngineProxy.Is32Bit ? BitConverter.ToUInt32(bytes, 0) : BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Dr7)
                {
                    registerSet.Dr7 = DebugEngineProxy.Is32Bit ? BitConverter.ToUInt32(bytes, 0) : BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Ds)
                {
                    registerSet.Ds = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Dx)
                {
                    registerSet.Dx = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Eax)
                {
                    registerSet.Eax = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Ebp)
                {
                    registerSet.Ebp = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Ebx)
                {
                    registerSet.Ebx = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Ecx)
                {
                    registerSet.Ecx = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Edi)
                {
                    registerSet.Edi = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Edx)
                {
                    registerSet.Edx = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Efl)
                {
                    registerSet.Efl = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Eip)
                {
                    registerSet.Eip = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Es)
                {
                    registerSet.Es = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Esi)
                {
                    registerSet.Esi = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Esp)
                {
                    registerSet.Esp = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Exfrom)
                {
                    registerSet.Exfrom = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Exto)
                {
                    registerSet.Exto = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Fl)
                {
                    registerSet.Fl = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Fopcode)
                {
                    registerSet.Fopcode = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Fpcw)
                {
                    registerSet.Fpcw = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Fpdp)
                {
                    registerSet.Fpdp = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Fpdpsel)
                {
                    registerSet.Fpdpsel = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Fpip)
                {
                    registerSet.Fpip = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Fpipsel)
                {
                    registerSet.Fpipsel = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Fpsw)
                {
                    registerSet.Fpsw = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Fptw)
                {
                    registerSet.Fptw = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Fs)
                {
                    registerSet.Fs = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Gs)
                {
                    registerSet.Gs = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.If)
                {
                    registerSet.If = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Iopl)
                {
                    registerSet.Iopl = bytes[0];
                }
                else if (register == Register.Ip)
                {
                    registerSet.Ip = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Mm0)
                {
                    registerSet.Mm0 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm1)
                {
                    registerSet.Mm1 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm2)
                {
                    registerSet.Mm2 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm3)
                {
                    registerSet.Mm3 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm4)
                {
                    registerSet.Mm4 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm5)
                {
                    registerSet.Mm5 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm6)
                {
                    registerSet.Mm6 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mm7)
                {
                    registerSet.Mm7 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Mxcsr)
                {
                    registerSet.Mxcsr = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.Of)
                {
                    registerSet.Of = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Pf)
                {
                    registerSet.Pf = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.R10)
                {
                    registerSet.R10 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R10b)
                {
                    registerSet.R10b = bytes[0];
                }
                else if (register == Register.R10d)
                {
                    registerSet.R10d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R10w)
                {
                    registerSet.R10w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R11)
                {
                    registerSet.R11 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R11b)
                {
                    registerSet.R11b = bytes[0];
                }
                else if (register == Register.R11d)
                {
                    registerSet.R11d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R11w)
                {
                    registerSet.R11w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R12)
                {
                    registerSet.R12 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R12b)
                {
                    registerSet.R12b = bytes[0];
                }
                else if (register == Register.R12d)
                {
                    registerSet.R12d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R12w)
                {
                    registerSet.R12w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R13)
                {
                    registerSet.R13 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R13b)
                {
                    registerSet.R13b = bytes[0];
                }
                else if (register == Register.R13d)
                {
                    registerSet.R13d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R13w)
                {
                    registerSet.R13w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R14)
                {
                    registerSet.R14 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R14b)
                {
                    registerSet.R14b = bytes[0];
                }
                else if (register == Register.R14d)
                {
                    registerSet.R14d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R14w)
                {
                    registerSet.R14w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R15)
                {
                    registerSet.R15 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R15b)
                {
                    registerSet.R15b = bytes[0];
                }
                else if (register == Register.R15d)
                {
                    registerSet.R15d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R15w)
                {
                    registerSet.R15w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R8)
                {
                    registerSet.R8 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R8b)
                {
                    registerSet.R8b = bytes[0];
                }                              
                else if (register == Register.R8d)
                {
                    registerSet.R8d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R8w)
                {
                    registerSet.R8w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.R9)
                {
                    registerSet.R9 = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.R9b)
                {
                    registerSet.R9b = bytes[0];
                }
                else if (register == Register.R9d)
                {
                    registerSet.R9d = BitConverter.ToUInt32(bytes, 0);
                }
                else if (register == Register.R9w)
                {
                    registerSet.R9w = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Rax)
                {
                    registerSet.Rax = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rbp)
                {
                    registerSet.Rbp = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rbx)
                {
                    registerSet.Rbx = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rcx)
                {
                    registerSet.Rcx = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rdi)
                {
                    registerSet.Rdi = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rdx)
                {
                    registerSet.Rdx = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rip)
                {
                    registerSet.Rip = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rsi)
                {
                    registerSet.Rsi = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Rsp)
                {
                    registerSet.Rsp = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Sf)
                {
                    registerSet.Sf = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Si)
                {
                    registerSet.Si = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Sil)
                {
                    registerSet.Sil = bytes[0];
                }
                else if (register == Register.Sp)
                {
                    registerSet.Sp = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.Spl)
                {
                    registerSet.Spl = bytes[0];
                }
                else if (register == Register.Ss)
                {
                    registerSet.Ss = BitConverter.ToUInt16(bytes, 0);
                }
                else if (register == Register.St0)
                {
                    registerSet.St0 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St1)
                {
                    registerSet.St1 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St2)
                {
                    registerSet.St2 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St3)
                {
                    registerSet.St3 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St4)
                {
                    registerSet.St4 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St5)
                {
                    registerSet.St5 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St6)
                {
                    registerSet.St6 = bytes.Take(10).ToArray();
                }
                else if (register == Register.St7)
                {
                    registerSet.St7 = bytes.Take(10).ToArray();
                }
                else if (register == Register.Tf)
                {
                    registerSet.Tf = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Vif)
                {
                    registerSet.Vif = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Vip)
                {
                    registerSet.Vip = Convert.ToBoolean(bytes[0]);
                }
                else if (register == Register.Xmm0)
                {
                    registerSet.Xmm0 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm0h)
                {
                    registerSet.Xmm0h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm0l)
                {
                    registerSet.Xmm0l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm1)
                {
                    registerSet.Xmm1 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm10)
                {
                    registerSet.Xmm10 = bytes.Take(16).ToArray();
                }

                else if (register == Register.Xmm10h)
                {
                    registerSet.Xmm10h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm10l)
                {
                    registerSet.Xmm10l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm11)
                {
                    registerSet.Xmm11 = bytes.Take(16).ToArray(); ;
                }
                else if (register == Register.Xmm11h)
                {
                    registerSet.Xmm11h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm11l)
                {
                    registerSet.Xmm11l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm12)
                {
                    registerSet.Xmm12 = bytes.Take(16).ToArray(); 
                }
                else if (register == Register.Xmm12h)
                {
                    registerSet.Xmm12h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm12l)
                {
                    registerSet.Xmm12l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm13)
                {
                    registerSet.Xmm13 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm13h)
                {
                    registerSet.Xmm13h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm13l)
                {
                    registerSet.Xmm13l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm14)
                {
                    registerSet.Xmm14 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm14h)
                {
                    registerSet.Xmm14h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm14l)
                {
                    registerSet.Xmm14l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm15)
                {
                    registerSet.Xmm15 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm15h)
                {
                    registerSet.Xmm15h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm15l)
                {
                    registerSet.Xmm15l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm1h)
                {
                    registerSet.Xmm1h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm1l)
                {
                    registerSet.Xmm1l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm2)
                {
                    registerSet.Xmm2 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm2h)
                {
                    registerSet.Xmm2h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm2l)
                {
                    registerSet.Xmm2l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm3)
                {
                    registerSet.Xmm3 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm3h)
                {
                    registerSet.Xmm3h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm3l)
                {
                    registerSet.Xmm3l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm4)
                {
                    registerSet.Xmm4 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm4h)
                {
                    registerSet.Xmm4h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm4l)
                {
                    registerSet.Xmm4l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm5)
                {
                    registerSet.Xmm5 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm5h)
                {
                    registerSet.Xmm5h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm5l)
                {
                    registerSet.Xmm5l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm6)
                {
                    registerSet.Xmm6 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm6h)
                {
                    registerSet.Xmm6h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm6l)
                {
                    registerSet.Xmm6l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm7)
                {
                    registerSet.Xmm7 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm7h)
                {
                    registerSet.Xmm7h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm7l)
                {
                    registerSet.Xmm7l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm8)
                {
                    registerSet.Xmm8 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm8h)
                {
                    registerSet.Xmm8h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm8l)
                {
                    registerSet.Xmm8l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm9)
                {
                    registerSet.Xmm9 = bytes.Take(16).ToArray();
                }
                else if (register == Register.Xmm9h)
                {
                    registerSet.Xmm9h = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Xmm9l)
                {
                    registerSet.Xmm9l = BitConverter.ToUInt64(bytes, 0);
                }
                else if (register == Register.Ymm0)
                {
                    registerSet.Ymm0 = bytes;
                }
                else if (register == Register.Ymm0h)
                {
                    registerSet.Ymm0h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm0l)
                {
                    registerSet.Ymm0l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm1)
                {
                    registerSet.Ymm1 = bytes;
                }
                else if (register == Register.Ymm10)
                {
                    registerSet.Ymm10 = bytes;
                }
                else if (register == Register.Ymm10h)
                {
                    registerSet.Ymm10h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm10l)
                {
                    registerSet.Ymm10l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm11)
                {
                    registerSet.Ymm11 = bytes;
                }
                else if (register == Register.Ymm11h)
                {
                    registerSet.Ymm11h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm11l)
                {
                    registerSet.Ymm11l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm12)
                {
                    registerSet.Ymm12 = bytes;
                }
                else if (register == Register.Ymm12h)
                {
                    registerSet.Ymm12h = bytes.Take(16).ToArray(); 
                }
                else if (register == Register.Ymm12l)
                {
                    registerSet.Ymm12l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm13)
                {
                    registerSet.Ymm13 = bytes;
                }
                else if (register == Register.Ymm13h)
                {
                    registerSet.Ymm13h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm13l)
                {
                    registerSet.Ymm13l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm14)
                {
                    registerSet.Ymm14 = bytes;
                }
                else if (register == Register.Ymm14h)
                {
                    registerSet.Ymm14h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm14l)
                {
                    registerSet.Ymm14l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm15)
                {
                    registerSet.Ymm15 = bytes;
                }
                else if (register == Register.Ymm15h)
                {
                    registerSet.Ymm15h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm15l)
                {
                    registerSet.Ymm15l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm1h)
                {
                    registerSet.Ymm1h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm1l)
                {
                    registerSet.Ymm1l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm2)
                {
                    registerSet.Ymm2 = bytes;
                }
                else if (register == Register.Ymm2h)
                {
                    registerSet.Ymm2h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm2l)
                {
                    registerSet.Ymm2l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm3)
                {
                    registerSet.Ymm3 = bytes;
                }
                else if (register == Register.Ymm3h)
                {
                    registerSet.Ymm3h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm3l)
                {
                    registerSet.Ymm3l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm4)
                {
                    registerSet.Ymm4 = bytes;
                }
                else if (register == Register.Ymm4h)
                {
                    registerSet.Ymm4h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm4l)
                {
                    registerSet.Ymm4l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm5)
                {
                    registerSet.Ymm5 = bytes;
                }
                else if (register == Register.Ymm5h)
                {
                    registerSet.Ymm5h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm5l)
                {
                    registerSet.Ymm5l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm6)
                {
                    registerSet.Ymm6 = bytes;
                }
                else if (register == Register.Ymm6h)
                {
                    registerSet.Ymm6h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm6l)
                {
                    registerSet.Ymm6l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm7)
                {
                    registerSet.Ymm7 = bytes;
                }
                else if (register == Register.Ymm7h)
                {
                    registerSet.Ymm7h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm7l)
                {
                    registerSet.Ymm7l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm8)
                {
                    registerSet.Ymm8 = bytes;
                }
                else if (register == Register.Ymm8h)
                {
                    registerSet.Ymm8h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm8l)
                {
                    registerSet.Ymm8l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm9)
                {
                    registerSet.Ymm9 = bytes;
                }
                else if (register == Register.Ymm9h)
                {
                    registerSet.Ymm9h = bytes.Take(16).ToArray();
                }
                else if (register == Register.Ymm9l)
                {
                    registerSet.Ymm9l = bytes.Take(16).ToArray();
                }
                else if (register == Register.Zf)
                {
                    registerSet.Zf = Convert.ToBoolean(bytes[0]);
                }

            }
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
        ///     Gets or sets the debug eng proxy.
        /// </summary>
        /// <value>The debug eng proxy.</value>
        [Import]
        public IDebugEngineProxy DebugEngineProxy { get; set; }
    }
}