using System.Data.Entity;

namespace McFly.Server.Data.SqlServer.Test.Builders
{
    internal class TestMcFlyContext : IMcFlyContext
    {
        public TestMcFlyContext()
        {
            FrameEntities = new TestDbSet<FrameEntity>();
            NoteEntities = new TestDbSet<NoteEntity>();
            StackFrameEntities = new TestDbSet<StackFrameEntity>();
            TraceInfoEntities = new TestDbSet<TraceInfoEntity>();
            MemoryChunkEntities = new TestDbSet<MemoryChunkEntity>();
            ByteRangeEntities = new TestDbSet<ByteRangeEntity>();
        }

        public DbSet<FrameEntity> FrameEntities { get; set; }
        public DbSet<NoteEntity> NoteEntities { get; set; }
        public DbSet<StackFrameEntity> StackFrameEntities { get; set; }
        public DbSet<TraceInfoEntity> TraceInfoEntities { get; set; }

        /// <inheritdoc />
        public DbSet<MemoryChunkEntity> MemoryChunkEntities { get; set; }

        /// <inheritdoc />
        public DbSet<ByteRangeEntity> ByteRangeEntities { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
            ;
        }
    }
}