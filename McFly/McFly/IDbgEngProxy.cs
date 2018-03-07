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
        ///     Gets the registers.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="registers">The registers.</param>
        /// <returns>RegisterSet.</returns>
        RegisterSet GetRegisters(int threadId, IEnumerable<Register> registers);
    }
}