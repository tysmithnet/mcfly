using System.Data.Entity;

namespace McFly.Server.Data.SqlServer
{
    internal class McFlyContext : DbContext, IMcFlyContext
    {
        public McFlyContext(string connectionString) : base(connectionString)
        {
        }
        

        public DbSet<FrameEntity> FrameEntities { get; set; }
        public DbSet<NoteEntity> NoteEntities { get; set; }
        public DbSet<StackFrameEntity> StackFrameEntities { get; set; }
        public DbSet<TraceInfoEntity> TraceInfoEntities { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FrameEntity>()
                .HasIndex(entity => new
                {
                    entity.PosHi,
                    entity.PosLo,
                    entity.ThreadId
                }).IsUnique(true);

            modelBuilder.Entity<TraceInfoEntity>()
                .HasIndex(entity => entity.Lock)
                .IsUnique(true);
        }
    }
}