using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
    [Table("byte_range")]
    public class ByteRangeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [RegularExpression("^[a-fA-F0-9]+$")]
        [Index("IX_byte_range_bytes")]
        public string Bytes { get; set; }
    }
}