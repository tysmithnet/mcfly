// ***********************************************************************
// Assembly         : McFly.Server.Contract
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-21-2018
// ***********************************************************************
// <copyright file="AddMemoryRequeset.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;

namespace McFly.Server.Contract
{
    /// <summary>
    ///     Request DTO for adding memory ranges
    /// </summary>
    public class AddMemoryRequeset
    {
        public AddMemoryRequeset(Position position, MemoryChunk memoryChunk)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            MemoryChunk = memoryChunk ?? throw new ArgumentNullException(nameof(memoryChunk));
        }

        public Position Position { get; private set; }
        public MemoryChunk MemoryChunk { get; private set; }
    }
}