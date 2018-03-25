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

namespace McFly
{
    /// <summary>
    ///     Interface IDbgEngProxy
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IDbgEngProxy : IInjectable
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
        ///     Writes the line to output
        /// </summary>                          
        /// <param name="message"></param>
        void Write(string message);

        /// <summary>
        ///     Writes the line to output
        /// </summary>
        /// <param name="line">The line.</param>
        void WriteLine(string line);
        int GetCurrentThreadId();
        void SwitchToThread(int threadId);

        bool Is32Bit { get; }
    }
}