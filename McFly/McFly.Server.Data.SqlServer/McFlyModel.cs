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

        public virtual DbSet<frame> frames { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<stackframe> stackframes { get; set; }
        public virtual DbSet<trace_info> trace_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<frame>()
                .Property(e => e.opcode_mnemonic)
                .IsUnicode(false);

            modelBuilder.Entity<frame>()
                .Property(e => e.disassembly_note)
                .IsUnicode(false);

            modelBuilder.Entity<frame>()
                .HasMany(e => e.notes)
                .WithMany(e => e.frames)
                .Map(m => m.ToTable("frame_note").MapLeftKey(new[] { "pos_hi", "pos_lo", "thread_id" }));

            modelBuilder.Entity<note>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<stackframe>()
                .Property(e => e.module)
                .IsUnicode(false);

            modelBuilder.Entity<stackframe>()
                .Property(e => e.function_name)
                .IsUnicode(false);

            modelBuilder.Entity<trace_info>()
                .Property(e => e._lock)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
