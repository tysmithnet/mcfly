using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    [Export(typeof(IMemoryAccess))]
    internal class MemoryAccess : IMemoryAccess
    {
        /// <inheritdoc />
        public long AddMemory(string projectName, MemoryChunk memoryChunk)
        {
            using (var context = ContextFactory.GetContext(projectName))
            {
                string newMem = memoryChunk.Bytes.ToHexString();
                var existing = context.ByteRangeEntities.FirstOrDefault(entity => entity.Bytes.Contains(newMem));
                int index = 0;
                if (existing != null)
                {
                     index = existing.Bytes.IndexOf(newMem, StringComparison.Ordinal);
                }
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
                return newEntity.Id;
            }
        }

        internal static List<MemoryChunkEntity> GetAppendedChunks(IMcFlyContext context, string lowString, string highString)
        {
            var appended = (from e in context.MemoryChunkEntities
                where string.CompareOrdinal(e.LowAddress, lowString) <= 0
                      && string.CompareOrdinal(highString, e.HighAddress) >= 0
                select e).ToList();
            return appended;
        }

        internal static MemoryChunkEntity GetSupersetChunk(IMcFlyContext context, string lowString, string highString)
        {
            var superset = context.MemoryChunkEntities.FirstOrDefault(e =>
                string.CompareOrdinal(e.LowAddress, lowString) <= 0 &&
                string.CompareOrdinal(e.HighAddress, highString) >= 0);
            return superset;
        }

        [Import]
        protected internal IContextFactory ContextFactory { get; set; }
    }
}