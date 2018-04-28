// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="IMemoryEngine.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.WinDbg.Debugger;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Represents an objec that is capable of performing memory related actions
    /// </summary>
    internal interface IMemoryEngine
    {
        /// <summary>
        ///     Reads virtual memory from the trace file
        /// </summary>
        /// <param name="low">The low memory address of the range</param>
        /// <param name="high">The high memory address of the range</param>
        /// <param name="dataSpaces">The data spaces COM interface allowing access to the memory</param>
        /// <returns>System.Byte[].</returns>
        byte[] ReadMemory(ulong low, ulong high, IDebugDataSpaces dataSpaces);
    }
}