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
    ///     Access layer for interacting with the virtual memory of the process during a trace
    /// </summary>
    public interface IMemoryAccess
    {
        /// <summary>
        ///     Indexes a <see cref="MemoryChunk"/>
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="memoryChunk">The memory chunk.</param>
        void AddMemory(string projectName, MemoryChunk memoryChunk);
    }
}