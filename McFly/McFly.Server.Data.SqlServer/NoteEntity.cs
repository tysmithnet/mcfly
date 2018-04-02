using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
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

        [Column("frame_id")]
        public long FrameId { get; set; }

        [ForeignKey("FrameId")]
        public FrameEntity Frame { get; set; }
    }
}