using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Server.Data.SqlServer
{
    [Table("memory_chunk")]
    public class MemoryChunkEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        public string StartAddress { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        public string EndAddress { get; set; }

        public virtual ByteRangeEntity ByteRange { get; set; }
    }
}
