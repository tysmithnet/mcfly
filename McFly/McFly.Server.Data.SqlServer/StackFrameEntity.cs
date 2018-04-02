using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
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
}