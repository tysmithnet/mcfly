namespace McFly.Server.Data.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("frame")]
    public partial class frame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public frame()
        {
            notes = new HashSet<note>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pos_hi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pos_lo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int thread_id { get; set; }

        public long? rax { get; set; }

        public long? rbx { get; set; }

        public long? rcx { get; set; }

        public long? rdx { get; set; }

        [MaxLength(32)]
        public byte[] opcode { get; set; }

        [StringLength(32)]
        public string opcode_mnemonic { get; set; }

        [StringLength(256)]
        public string disassembly_note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes { get; set; }
    }
}
