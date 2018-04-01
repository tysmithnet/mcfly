using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace McFly.Server.Data.SqlServer.Entities
{
    [Table("frame")]
    public class FrameEntity
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FrameEntity()
        {
            Notes = new HashSet<NoteEntity>();
        }

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

        public long? Rax { get; set; }

        public long? Rbx { get; set; }

        public long? Rcx { get; set; }

        public long? Rdx { get; set; }

        [MaxLength(32)]
        public byte[] OpCode { get; set; }

        [StringLength(32)]
        public string OpcodeMnemonic { get; set; }

        [StringLength(256)]
        public string DisassemblyNote { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NoteEntity> Notes { get; set; }
    }
}