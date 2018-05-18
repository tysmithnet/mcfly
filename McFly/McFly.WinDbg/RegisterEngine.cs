// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-17-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-06-2018
// ***********************************************************************
// <copyright file="RegisterEngine.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;
using McFly.Core.Registers;
using McFly.WinDbg.Debugger;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Default implementation of <see cref="IRegisterEngine"/>
    /// </summary>
    /// <seealso cref="McFly.WinDbg.IRegisterEngine" />
    [Export(typeof(IRegisterEngine))]
    internal class RegisterEngine : IRegisterEngine
    {
        /// <summary>
        ///     Gets the register value for the specified thread
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="register">The register.</param>
        /// <param name="registers">The registers COM interface.</param>
        /// <param name="debugEngine">The debug engine.</param>
        /// <returns>System.Byte[].</returns>
        public byte[] GetRegisterValue(int threadId, Register register, IDebugRegisters2 registers,
            IDebugEngineProxy debugEngine)
        {
            var save = debugEngine.GetCurrentThreadId();
            debugEngine.SwitchToThread(threadId);
            if (debugEngine.Is32Bit)
            {
                debugEngine.SwitchToThread(save);
                return GetRegisterValue32(register, registers);
            }

            debugEngine.SwitchToThread(save);
            return GetRegisterValue64(register, registers);
        }

        /// <summary>
        ///     Gets the register value assuming a 32bit processor.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ApplicationException"></exception>
        internal virtual unsafe byte[] GetRegisterValue32(Register register, IDebugRegisters2 registers)
        {
            if (new Register[]
            {
                Register.Ymm0, Register.Ymm1, Register.Ymm2, Register.Ymm3, Register.Ymm4, Register.Ymm5, Register.Ymm6,
                Register.Ymm7
            }.Contains(register))
                return GetYmmRegister32(register, registers);

            var bytes = new List<byte>();
            var hr3 = registers.GetValue(register.X86Index.Value.ToUInt(), out var val);
            if (hr3 != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr3}");

            for (var i = 0; i < register.X86NumBits.Value; i++) bytes.Add(val.F128Bytes[i]);

            return bytes.Take(register.NumBits / 8 + Math.Min(register.NumBits % 8, 1)).ToArray();
        }

        /// <summary>
        ///     Gets the register value assuming a 64 bit processor
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ApplicationException"></exception>
        internal virtual unsafe byte[] GetRegisterValue64(Register register, IDebugRegisters2 registers)
        {
            var ymms = new Register[]
            {
                Register.Ymm0, Register.Ymm1, Register.Ymm2, Register.Ymm3, Register.Ymm4, Register.Ymm5, Register.Ymm6,
                Register.Ymm7, Register.Ymm8, Register.Ymm9, Register.Ymm10, Register.Ymm11, Register.Ymm12,
                Register.Ymm13, Register.Ymm14, Register.Ymm15
            };
            if (ymms.Contains(register))
                return GetYmmRegister64(register, registers);

            var bytes = new List<byte>();
            var hr3 = registers.GetValue(register.X64Index.Value.ToUInt(), out var val);
            if (hr3 != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr3}");

            for (var i = 0; i < register.X64NumBits.Value; i++) bytes.Add(val.F128Bytes[i]);

            return bytes.Take(register.NumBits / 8 + Math.Min(register.NumBits % 8, 1)).ToArray();
        }

        /// <summary>
        ///     Gets one the 32 bit SIMD registers
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        private static unsafe byte[] GetYmmRegister32(Register register, IDebugRegisters2 registers)
        {
            var hr = registers.GetValue(register.X86Index.Value.ToUInt(), out var value);
            if (hr != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr}");
            var hr2 = registers.GetValue(register.X86Index.Value.ToUInt(), out var debugValue);
            if (hr2 != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr2}");
            var list = new List<byte>();
            for (var i = 0; i < 16; i++)
                list.Add(debugValue.F128Bytes[i]);
            for (var i = 0; i < 16; i++)
                list.Add(value.F128Bytes[i]);
            return list.ToArray();
        }

        /// <summary>
        ///     Gets one of the 64 bit SIMD registers
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ApplicationException">
        /// </exception>
        private static unsafe byte[] GetYmmRegister64(Register register, IDebugRegisters2 registers)
        {
            var hr = registers.GetValue(register.X64Index.Value.ToUInt(), out var debugValue);
            if (hr != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr}");
            var hr2 = registers.GetValue(register.X64Index.Value.ToUInt(), out var value);
            if (hr2 != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr2}");
            var list = new List<byte>();
            for (var i = 0; i < 16; i++)
                list.Add(value.F128Bytes[i]);
            for (var i = 0; i < 16; i++)
                list.Add(debugValue.F128Bytes[i]);
            return list.ToArray();
        }
    }
}