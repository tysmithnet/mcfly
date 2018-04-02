using System;
using System.Data.Entity;

namespace McFly.Server.Data.SqlServer
{
    internal interface IMcFlyContext : IDisposable
    {
        DbSet<FrameEntity> FrameEntities { get; set; }
        DbSet<NoteEntity> NoteEntities { get; set; }
        DbSet<StackFrameEntity> StackFrameEntities { get; set; }
        DbSet<TraceInfoEntity> TraceInfoEntities { get; set; }
        int SaveChanges();
    }
}