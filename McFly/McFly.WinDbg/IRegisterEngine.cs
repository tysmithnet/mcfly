// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-17-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-25-2018
// ***********************************************************************
// <copyright file="IRegisterEngine.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core.Registers;
using McFly.WinDbg.Debugger;

namespace McFly.WinDbg
{
    /// <summary>
    ///     The sub engine that is responsible for get the value of registers
    /// </summary>
    public interface IRegisterEngine
    {
        /// <summary>
        ///     Gets the register value.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="register">The register.</param>
        /// <param name="registers">The registers COM interface.</param>
        /// <param name="debugEngine">The debug engine.</param>
        /// <returns>System.Byte[].</returns>
        byte[] GetRegisterValue(int threadId, Register register, IDebugRegisters2 registers,
            IDebugEngineProxy debugEngine);
    }
}