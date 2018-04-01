using McFly.Server.Data.SqlServer.Entities;

namespace McFly.Server.Data.SqlServer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class McFlyModel : DbContext
    {
        public McFlyModel()
            : base("name=McFlyModel")
        {
        }

        public virtual DbSet<FrameEntity> frames { get; set; }
        public virtual DbSet<NoteEntity> notes { get; set; }
        public virtual DbSet<StackFrameEntity> stackframes { get; set; }
        public virtual DbSet<TraceInfoEntity> trace_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FrameEntity>()
                .Property(e => e.OpcodeMnemonic)
                .IsUnicode(false);

            modelBuilder.Entity<FrameEntity>()
                .Property(e => e.DisassemblyNote)
                .IsUnicode(false);

            modelBuilder.Entity<FrameEntity>()
                .HasMany(e => e.Notes)
                .WithMany(e => e.frames)
                .Map(m => m.ToTable("frame_note").MapLeftKey(new[] { "pos_hi", "pos_lo", "thread_id" }));

            modelBuilder.Entity<NoteEntity>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<StackFrameEntity>()
                .Property(e => e.Module)
                .IsUnicode(false);

            modelBuilder.Entity<StackFrameEntity>()
                .Property(e => e.FunctionName)
                .IsUnicode(false);

            modelBuilder.Entity<TraceInfoEntity>()
                .Property(e => e.Lock)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
