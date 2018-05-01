// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-20-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="MemoryEngine.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;
using McFly.WinDbg.Debugger;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Default implementation of <see cref="IMemoryEngine"/>
    /// </summary>
    /// <seealso cref="IMemoryEngine" />
    [Export(typeof(IMemoryEngine))]
    public class MemoryEngine : IMemoryEngine
    {
        /// <summary>
        ///     Reads the memory.
        /// </summary>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <param name="dataSpaces">The data spaces.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ApplicationException"></exception>
        public byte[] ReadMemory(ulong low, ulong high, IDebugDataSpaces dataSpaces)
        {
            if(low >= high)
                throw new ArgumentOutOfRangeException($"Low must be less than high, but {low} >= {high}");
            var length = high - low;
            var buffer = new byte[length];
            var hr = dataSpaces.ReadVirtual(low, buffer, buffer.Length.ToUInt(), out var bytesRead);
            if (hr != 0)
                throw new ApplicationException($"Unable to read virtual memory at {low:X16}, error code: {hr}");

            return buffer.Take(bytesRead.ToInt()).ToArray(); // todo: bounds checking
        }
    }
}