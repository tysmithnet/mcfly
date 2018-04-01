namespace McFly.Server.Data.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trace_info
    {
        [Key]
        [Column("lock")]
        [StringLength(1)]
        public string _lock { get; set; }

        public int start_pos_hi { get; set; }

        public int start_pos_lo { get; set; }

        public int end_pos_hi { get; set; }

        public int end_pos_lo { get; set; }
    }
}
