using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer.Entities
{
    [Table("stackframe")]
    public partial class StackFrameEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PosHi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PosLo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ThreadId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Depth { get; set; }

        public long? StackPointer { get; set; }

        public long? ReturnAddress { get; set; }

        [StringLength(256)]
        public string Module { get; set; }

        [StringLength(512)]
        public string FunctionName { get; set; }

        public long? Offset { get; set; }
    }
}
