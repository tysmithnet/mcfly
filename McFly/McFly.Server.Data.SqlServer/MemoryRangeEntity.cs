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
    [Table("memory_range")]
    public class MemoryRangeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [MaxLength(16)]
        [RegularExpression("^[a-fA-F0-9]+$")]
        public string Address { get; set; }

        public virtual ByteRangeEntity ByteRange { get; set; }
    }
}
