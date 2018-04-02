using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer
{
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
}