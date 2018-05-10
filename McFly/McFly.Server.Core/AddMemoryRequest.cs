// ***********************************************************************
// Assembly         : McFly.Server.Core
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="AddMemoryRequeset.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using McFly.Core;

namespace McFly.Server.Core
{
    /// <summary>
    ///     Request DTO for adding memory ranges
    /// </summary>
    public sealed class AddMemoryRequest : IEquatable<AddMemoryRequest>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AddMemoryRequest" /> class.
        /// </summary>
        public AddMemoryRequest()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddMemoryRequest" /> class.
        /// </summary>
        /// <param name="memoryChunk">The memory chunk.</param>
        /// <exception cref="ArgumentNullException">memoryChunk</exception>
        public AddMemoryRequest(MemoryChunk memoryChunk)
        {
            MemoryChunk = memoryChunk ?? throw new ArgumentNullException(nameof(memoryChunk));
        }

        /// <summary>
        ///     Gets the memory chunk.
        /// </summary>
        /// <value>The memory chunk.</value>
        public MemoryChunk MemoryChunk { get; }

        /// <inheritdoc />
        public bool Equals(AddMemoryRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return MemoryChunk.ValueEquals(other.MemoryChunk);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is AddMemoryRequest && Equals((AddMemoryRequest) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (MemoryChunk != null ? MemoryChunk.GetHashCode() : 0);
        }
    }
}