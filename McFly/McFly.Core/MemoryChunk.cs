// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-29-2018
// ***********************************************************************
// <copyright file="MemoryChunk.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;

namespace McFly.Core
{
    /// <summary>
    ///     Represents an arbitrary cross section of virtual memory. What you would expect if
    ///     you were to examine raw memory.
    /// </summary>
    /// <seealso cref="McFly.Core.DomainEntity{McFly.Core.MemoryChunk}" />
    public class MemoryChunk : DomainEntity<MemoryChunk>
    {
        /// <summary>
        ///     Determines if this instance is value-type equal with another instance.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns><c>true</c> if this instance is value-type equal with the other instance, <c>false</c> otherwise.</returns>
        /// <inheritdoc />
        /// <remarks>Typically this is a field by field equality operation, but does NOT consider the ID</remarks>
        public override bool ValueEquals(MemoryChunk other)
        {
            var memRangeSame = MemoryRange.Equals(other.MemoryRange);
            if (!memRangeSame) return false;
            var positionSame = Position.Equals(other.Position);
            if (!positionSame) return false;
            var bytesBothNull = Bytes == null && other.Bytes == null;
            var bytesSame = Bytes != null && other.Bytes != null && Bytes.SequenceEqual(other.Bytes);
            if (!bytesSame && !bytesBothNull) return false;
            return true;
        }

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

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public Position Position { get; set; }
    }
}