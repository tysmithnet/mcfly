// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-04-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IDbgEngProxy.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly
{
    /// <summary>
    ///     Interface IDbgEngProxy
    /// </summary>
    /// <seealso cref="McFly.IInjectable" />
    public interface IDebugEngineProxy : IInjectable
    {
        /// <summary>
        ///     Gets a value indicating whether [is32 bit].
        /// </summary>
        /// <value><c>true</c> if [is32 bit]; otherwise, <c>false</c>.</value>
        bool Is32Bit { get; }

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
        /// <param name="message">The message.</param>
        void Write(string message);

        /// <summary>
        ///     Writes the line to output
        /// </summary>
        /// <param name="line">The line.</param>
        void WriteLine(string line);

        /// <summary>
        ///     Gets the current thread identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetCurrentThreadId();

        /// <summary>
        ///     Switches to thread.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        void SwitchToThread(int threadId);

        /// <summary>
        ///     Executes a command on the specified thread id
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="command">The v.</param>
        /// <returns>System.String.</returns>
        string Execute(int threadId, string command);
    }
}