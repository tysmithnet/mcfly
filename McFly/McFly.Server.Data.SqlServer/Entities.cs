using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using McFly.Core;

namespace McFly.Server.Data.SqlServer
{
    [Table("frame")]
    internal class FrameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("frame_id")]
        public long FrameId { get; set; }

        [Column("pos_hi")]
        public int PosHi { get; set; }

        [Column("pos_lo")]
        public int PosLo { get; set; }

        [Column("thread_id")]
        public int ThreadId { get; set; }

        [Column("rax")]
        public long? Rax { get; set; }

        [Column("rbx")]
        public long? Rbx { get; set; }

        [Column("rcx")]
        public long? Rcx { get; set; }

        [Column("rdx")]
        public long? Rdx { get; set; }

        [Column("address")]
        public long? Address { get; set; }

        [Column("opcode")]
        public byte[] OpCode { get; set; }

        [Column("opcode_mnemonic")]
        public string OpCodeMnemonic { get; set; }

        [Column("disassembly_note")]
        public string DisassemblyNote { get; set; }

        public virtual List<NoteEntity> Notes { get; set; }

        public virtual List<StackFrameEntity> StackFrames { get; set; }
    }

    [Table("note")]
    internal class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("note_id")]
        public long NoteId { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("text")]
        public string Text { get; set; }
    }

    [Table("stack_frame")]
    internal class StackFrameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? StackFrameId { get; set; }
                                            
        [Column("stack_pointer")]
        public long StackPointer { get; set; }

        [Column("return_address")]
        public long? ReturnAddress { get; set; }

        [Column("module_name")]
        public string ModuleName { get; set; }

        [Column("function")]
        public string Function { get; set; }

        [Column("offset")]
        public long? Offset { get; set; }

        [Column("frame_id")]
        public long FrameId { get; set; }

        [ForeignKey("FrameId")]
        public FrameEntity Frame { get; set; }
    }

    [Table("trace_info")]
    public class TraceInfoEntity
    {
        [Column("lock")]
        [Range(1,1)]
        [Key]
        public int Lock { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("start_pos_hi")]
        public int StartPosHi { get; set; }

        [Column("start_pos_lo")]
        public int StartPosLo { get; set; }

        [Column("end_pos_hi")]
        public int EndPosHi { get; set; }

        [Column("end_pos_lo")]
        public int EndPosLo { get; set; }
    }

    internal class McFlyContext : DbContext
    {
        public McFlyContext(string connectionString) : base(connectionString)
        {
        }

        public McFlyContext(DbConnection connection) : base(connection, true)
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

    internal static class DomainEntityConversion
    {
        public static FrameEntity ToFrameEntity(this Frame frame)
        {
            return new FrameEntity
            {
                PosHi = frame.Position.High,
                PosLo = frame.Position.Low,
                ThreadId = frame.ThreadId,
                Rax = frame.RegisterSet.Rax?.ToLong(),
                Rbx = frame.RegisterSet.Rbx?.ToLong(),
                Rcx = frame.RegisterSet.Rcx?.ToLong(),
                Rdx = frame.RegisterSet.Rdx?.ToLong(),
                OpCode = frame.DisassemblyLine?.OpCode,
                OpCodeMnemonic = frame.DisassemblyLine?.OpCodeMnemonic,
                DisassemblyNote = frame.DisassemblyLine?.DisassemblyNote,
                StackFrames = frame.StackTrace.StackFrames.Select(x => x.ToStackFrameEntity()).ToList(),
                Notes = frame.Notes.Select(x => x.ToNoteEntity()).ToList()
            };    
        }

        public static Frame ToFrame(this FrameEntity entity)
        {
            return new Frame
            {
                Position = new Position(entity.PosHi, entity.PosLo),
                ThreadId = entity.ThreadId,
                DisassemblyLine = new DisassemblyLine(entity.Address?.ToULong(), entity.OpCode, entity.OpCodeMnemonic, entity.DisassemblyNote),
                RegisterSet = new RegisterSet
                {
                    Rax = entity.Rax?.ToULong(),
                    Rbx = entity.Rbx?.ToULong(),
                    Rcx = entity.Rcx?.ToULong(),
                    Rdx = entity.Rdx?.ToULong(),
                },
                Notes = entity.Notes.Select(x => x.ToNote()).ToList(),
                
            };
        }

        public static Note ToNote(this NoteEntity entity)
        {
            return new Note
            {
                CreateDate = entity.CreateDate,
                Text = entity.Text
            };
        }

        public static NoteEntity ToNoteEntity(this Note note)
        {
            return new NoteEntity
            {
                CreateDate = note.CreateDate,
                Text = note.Text
            };
        }

        public static StackFrame ToStackFrame(this StackFrameEntity entity)
        {
            return new StackFrame(entity.StackPointer.ToULong(), entity.ReturnAddress?.ToULong(), entity.ModuleName, entity.Function, entity.Offset?.ToULong());
        }

        public static StackFrameEntity ToStackFrameEntity(this StackFrame stackFrame)
        {
            return new StackFrameEntity
            {                     
                StackPointer = stackFrame.StackPointer.ToLong(),
                ReturnAddress = stackFrame.ReturnAddress?.ToLong(),
                ModuleName = stackFrame.Module,
                Function = stackFrame.FunctionName,
                Offset = stackFrame.Offset?.ToLong()
            };
        }   
    }
}