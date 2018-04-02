using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual List<NoteEntity> Notes { get; set; } = new List<NoteEntity>();

        public virtual List<StackFrameEntity> StackFrames { get; set; } = new List<StackFrameEntity>();
    }
}