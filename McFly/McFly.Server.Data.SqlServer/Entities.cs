using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Server.Data.SqlServer
{
    internal class FrameEntity
    {
        public int PosHi { get; set; }
        public int PosLo { get; set; }
        public int ThreadId { get; set; }
        public long Rax { get; set; }
        public long Rbx { get; set; }
        public long Rcx { get; set; }
        public long Rdx { get; set; }
        public byte[] OpCode { get; set; }
        public string OpCodeMnemonic { get; set; }
        public string DisassemblyNote { get; set; }
        public virtual List<NoteEntity> Notes { get; set; }
        public virtual List<StackFrameEntity> StackFrames { get; set; }
    }

    internal class NoteEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
    }

    internal class StackFrameEntity
    {
        public long StackPointer { get; set; }
        public long ReturnAddress { get; set; }
        public string ModuleName { get; set; }
        public string Function { get; set; }
        public long Offset { get; set; }
    }

    internal class McFlyContext : DbContext
    {
        public DbSet<FrameEntity> FrameEntities { get; set; }
        public DbSet<NoteEntity> NoteEntities { get; set; }
        public DbSet<StackFrameEntity> StackFrameEntities { get; set; }

        public McFlyContext(string connectionString) : base(connectionString)
        {
            
        }
    }                                                                  
}
