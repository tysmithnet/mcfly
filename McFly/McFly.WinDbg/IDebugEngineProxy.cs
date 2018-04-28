// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="IDbgEngProxy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;
using McFly.Core.Registers;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Proxy to the basic functionality of the debugging engine. This includes writing
    ///     to the command output, setting breakpoints, reading memeory, executing commands, etc
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface IDebugEngineProxy : IInjectable
    {
        /// <summary>
        ///     Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>System.String.</returns>
        string Execute(string command);

        /// <summary>
        ///     Executes a command on the specified thread id
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="command">The v.</param>
        /// <returns>System.String.</returns>
        string Execute(int threadId, string command);

        /// <summary>
        ///     Gets the current thread identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetCurrentThreadId();

        /// <summary>
        ///     Gets the register value.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="register">The register.</param>
        /// <returns>System.Byte[].</returns>
        byte[] GetRegisterValue(int threadId, Register register);

        /// <summary>
        ///     Reads the virtual memory.
        /// </summary>
        /// <param name="memoryRange">The memory range.</param>
        /// <returns>System.Byte[].</returns>
        byte[] ReadVirtualMemory(MemoryRange memoryRange);

        /// <summary>
        ///     Runs the until break.
        /// </summary>
        void RunUntilBreak();

        /// <summary>
        ///     Changes the thread context of the debugger
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        void SwitchToThread(int threadId);

        /// <summary>
        ///     Writes the text to output
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(string message);

        /// <summary>
        ///     Writes the line to output
        /// </summary>
        /// <param name="line">The line.</param>
        void WriteLine(string line);

        /// <summary>
        ///     Gets a value indicating whether the trace is of a 32 bit process. False indicates 64 bits.
        /// </summary>
        /// <value><c>true</c> if the trace is of a 32 bit process; otherwise, <c>false</c>.</value>
        bool Is32Bit { get; }
    }
}