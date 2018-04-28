// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="IDisassemblyFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using McFly.Core;

namespace McFly.WinDbg
{
    /// <summary>
    ///     Facade over getting disassembly information
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface IDisassemblyFacade : IInjectable
    {
        /// <summary>
        ///     Gets numInstructions lines of disassembly at the current position on the current thread
        /// </summary>
        /// <param name="numInstructions">The number instructions.</param>
        /// <returns>IEnumerable&lt;DisassemblyLine&gt;.</returns>
        IEnumerable<DisassemblyLine> GetDisassemblyLines(int numInstructions);

        /// <summary>
        ///     Gets numInstructions lines of disassembly at the current position on the specified thread
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="numInstructions">The number instructions.</param>
        /// <returns>IEnumerable&lt;DisassemblyLine&gt;.</returns>
        IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions);
    }
}