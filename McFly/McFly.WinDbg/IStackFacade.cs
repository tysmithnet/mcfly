// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IStackFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Facade over getting stack traces
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface IStackFacade : IInjectable
    {
        /// <summary>
        ///     Gets the current stack trace.
        /// </summary>
        /// <returns>StackTrace.</returns>
        StackTrace GetCurrentStackTrace();

        /// <summary>
        ///     Gets stack trace for the specified thread id
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns>StackTrace.</returns>
        StackTrace GetCurrentStackTrace(int threadId);
    }
}