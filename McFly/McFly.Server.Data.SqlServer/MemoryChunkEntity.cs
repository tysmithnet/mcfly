using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    [Table("memory_chunk")]
    public class MemoryChunkEntity
    {
        [ForeignKey("ByteRangeId")]
        public virtual ByteRangeEntity ByteRange { get; set; }

        [Column("byte_range_id")]
        public long ByteRangeId { get; set; }

        /// <summary>
        /// Gets or sets the start index of the subsection. This should be used
        /// in conjunction with the byte range to get the memory chunks bytes.
        /// memoryChunkBytes = entity.Bytes.Substring(SubsectionStartIndex, SubsectionLength)
        /// </summary>
        /// <value>The start index of the subsection.</value>
        [Column("subsection_start_index")]
        public long SubsectionStartIndex { get; set; }

        [Column("subsection_length")]
        public long SubsectionLength { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        [Column("high_address")]
        public string HighAddress { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        [Column("low_address")]
        public string LowAddress { get; set; }

        [Column("pos_hi")]
        public int PosHi { get; set; }     // todo: index over position columns

        [Column("pos_lo")]
        public int PosLo { get; set; }
    }
}