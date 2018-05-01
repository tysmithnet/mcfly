// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 04-20-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 05-01-2018
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
    ///     Default implementation of <see cref="IMemoryEngine" />
    /// </summary>
    /// <seealso cref="McFly.WinDbg.IMemoryEngine" />
    /// <seealso cref="IMemoryEngine" />
    [Export(typeof(IMemoryEngine))]
    public class MemoryEngine : IMemoryEngine
    {
        /// <summary>
        ///     Reads virtual memory from the trace file
        /// </summary>
        /// <param name="low">The low memory address of the range</param>
        /// <param name="high">The high memory address of the range</param>
        /// <param name="dataSpaces">The data spaces COM interface allowing access to the memory</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="ArgumentOutOfRangeException">When low >= high</exception>
        /// <exception cref="ApplicationException">If the debugging engine cannot perform the request</exception>
        public byte[] ReadMemory(ulong low, ulong high, IDebugDataSpaces dataSpaces)
        {
            if (low >= high)
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