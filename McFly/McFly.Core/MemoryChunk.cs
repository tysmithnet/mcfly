// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-21-2018
// ***********************************************************************
// <copyright file="MemoryChunk.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core
{
    /// <summary>
    ///     Represents an arbitrary selection of virtual memory. What you would expect if
    ///     you were to examine raw memory.
    /// </summary>
    public class MemoryChunk
    {
        /// <summary>
        ///     Gets or sets the bytes.
        /// </summary>
        /// <value>The bytes.</value>
        public byte[] Bytes { get; set; }

        /// <summary>
        ///     Gets or sets the memory range.
        /// </summary>
        /// <value>The memory range.</value>
        public MemoryRange MemoryRange { get; set; }
    }
}