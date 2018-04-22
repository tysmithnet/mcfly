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
        public void AddMemory(string projectName, MemoryChunk memoryChunk)
        {
            using (var context = ContextFactory.GetContext(projectName))
            {
                
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