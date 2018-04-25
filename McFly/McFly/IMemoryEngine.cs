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

using McFly.Debugger;

namespace McFly
{
    /// <summary>
    ///     Interface IMemoryEngine
    /// </summary>
    public interface IMemoryEngine
    {
        /// <summary>
        ///     Reads the memory.
        /// </summary>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <param name="dataSpaces">The data spaces.</param>
        /// <param name="is32Bit">if set to <c>true</c> [is32 bit].</param>
        /// <returns>System.Byte[].</returns>
        byte[] ReadMemory(ulong low, ulong high, IDebugDataSpaces dataSpaces, bool is32Bit);
    }
}