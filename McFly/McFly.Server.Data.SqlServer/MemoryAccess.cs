// ***********************************************************************
// Assembly         : McFly.Server.Data.SqlServer
// Author           : @tysmithnet
// Created          : 04-21-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-22-2018
// ***********************************************************************
// <copyright file="MemoryAccess.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    /// <summary>
    ///     Class MemoryAccess.
    /// </summary>
    /// <seealso cref="McFly.Server.Data.IMemoryAccess" />
    [Export(typeof(IMemoryAccess))]
    internal class MemoryAccess : IMemoryAccess
    {
        /// <summary>
        ///     Adds the memory chunk to the 
        /// </summary>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="memoryChunk">The memory chunk.</param>
        /// <returns>System.Int64.</returns>
        /// <inheritdoc />
        public long AddMemory(string projectName, MemoryChunk memoryChunk)
        {
            using (var context = ContextFactory.GetContext(projectName))
            {
                var newMem = memoryChunk.Bytes.ToHexString();
                var existing = context.ByteRangeEntities.FirstOrDefault(entity => entity.Bytes.Contains(newMem));
                if (existing == null)
                {
                    var newByteEntity = new ByteRangeEntity()
                    {
                        Bytes = newMem,
                    };
                    context.ByteRangeEntities.Add(newByteEntity);
                    existing = newByteEntity;
                }
                var index = 0;
                index = existing.Bytes.IndexOf(newMem, StringComparison.Ordinal);
                var loString = memoryChunk.MemoryRange.LowAddress.ToHexString();
                var hiString = memoryChunk.MemoryRange.HighAddress.ToHexString();
                var newEntity = new MemoryChunkEntity
                {
                    LowAddress = loString,
                    ByteRange = existing,
                    HighAddress = hiString,
                    PosHi = memoryChunk.Position.High,
                    PosLo = memoryChunk.Position.Low,
                    SubsectionLength = newMem.Length,
                    SubsectionStartIndex = index
                };
                context.MemoryChunkEntities.Add(newEntity);
                context.SaveChanges(); // todo: error check
                return newEntity.Id;


            }
        }

        /// <summary>
        ///     Gets the appended chunks.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="lowString">The low string.</param>
        /// <param name="highString">The high string.</param>
        /// <returns>List&lt;MemoryChunkEntity&gt;.</returns>
        internal static List<MemoryChunkEntity> GetAppendedChunks(IMcFlyContext context, string lowString,
            string highString)
        {
            var appended = (from e in context.MemoryChunkEntities
                where string.CompareOrdinal(e.LowAddress, lowString) <= 0
                      && string.CompareOrdinal(highString, e.HighAddress) >= 0
                select e).ToList();
            return appended;
        }

        /// <summary>
        ///     Gets the superset chunk.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="lowString">The low string.</param>
        /// <param name="highString">The high string.</param>
        /// <returns>MemoryChunkEntity.</returns>
        internal static MemoryChunkEntity GetSupersetChunk(IMcFlyContext context, string lowString, string highString)
        {
            var superset = context.MemoryChunkEntities.FirstOrDefault(e =>
                string.CompareOrdinal(e.LowAddress, lowString) <= 0 &&
                string.CompareOrdinal(e.HighAddress, highString) >= 0);
            return superset;
        }

        /// <summary>
        ///     Gets or sets the context factory.
        /// </summary>
        /// <value>The context factory.</value>
        [Import]
        protected internal IContextFactory ContextFactory { get; set; }
    }
}