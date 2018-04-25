// ***********************************************************************
// Assembly         : McFly.Server.Data
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="IMemoryAccess.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using McFly.Core;

namespace McFly.Server.Data
{
    /// <summary>
    ///     Interface IMemoryAccess
    /// </summary>
    public interface IMemoryAccess
    {
        /// <summary>
        ///     Adds the memory.
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="memoryChunk">The memory chunk.</param>
        /// <returns>System.Int64.</returns>
        long AddMemory(string projectName, MemoryChunk memoryChunk);
    }
}