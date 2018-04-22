using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    [Export(typeof(IMemoryAccess))]
    internal class MemoryAccess : IMemoryAccess
    {
        [Import]
        protected internal IContextFactory ContextFactory { get; set; }

        /// <inheritdoc />
        public void AddMemory(string projectName, Position position, MemoryChunk memoryChunk)
        {
            using (var context = ContextFactory.GetContext(projectName))
            {
                var superset = context.MemoryChunkEntities.FirstOrDefault(e => e.)
            }
        }
    }
}
