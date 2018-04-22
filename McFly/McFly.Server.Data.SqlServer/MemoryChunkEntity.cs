using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    [Table("memory_chunk")]
    public class MemoryChunkEntity
    {
        public virtual ByteRangeEntity ByteRange { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        public string HighAddress { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        public string LowAddress { get; set; }

        public int PosHi { get; set; }     // todo: index over position columns
        public int PosLo { get; set; }
    }
}