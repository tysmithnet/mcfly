// ***********************************************************************
// Assembly         : mcfly
// Author           : master
// Created          : 03-04-2018
//
// Last Modified By : master
// Last Modified On : 03-04-2018
// ***********************************************************************
// <copyright file="IDbgEngProxy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;

namespace McFly
{
    /// <summary>
    ///     Interface IDbgEngProxy
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IDbgEngProxy : IInjectable    // todo: break up interface
    {
        /// <summary>
        ///     Runs the until break.
        /// </summary>
        void RunUntilBreak();

        /// <summary>
        ///     Executes the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>System.String.</returns>
        string Execute(string command);

        /// <summary>
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetRegisters(int threadId, IEnumerable<Register> registers); // todo: add overload without thread id

        /// <summary>
        ///     Gets the starting position of the trace. Many times this is 35:0
        /// </summary>
        /// <returns>Position.</returns>
        Position GetStartingPosition();

        /// <summary>
        ///     Gets the ending position
        /// </summary>
        /// <returns>Position.</returns>
        Position GetEndingPosition();

        /// <summary>
        ///     Writes the line to output
        /// </summary>                          
        /// <param name="message"></param>
        void Write(string message);

        /// <summary>
        ///     Writes the line to output
        /// </summary>
        /// <param name="line">The line.</param>
        void WriteLine(string line);

        StackTrace GetStackTrace();

        StackTrace GetStackTrace(int threadId);

        int GetCurrentThreadId();

        IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions);
        void SetCurrentPosition(Position startingPosition);
        void SetBreakpointByMask(string breakpointMask);
        void SetReadAccessBreakpoint(int length, ulong address);
        void SetWriteAccessBreakpoint(int length, ulong address);
        void ClearBreakpoints();
    }
}