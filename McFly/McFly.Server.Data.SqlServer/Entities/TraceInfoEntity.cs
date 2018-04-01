using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer.Entities
{
    public partial class TraceInfoEntity
    {
        [Key]
        [Column("lock")]
        [StringLength(1)]
        public string Lock { get; set; }

        public int StartPosHi { get; set; }

        public int StartPosLo { get; set; }

        public int EndPosHi { get; set; }

        public int EndPosLo { get; set; }
    }
}
