using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace McFly.Server.Data.SqlServer.Entities
{
    [Table("note")]
    public partial class NoteEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NoteEntity()
        {
            frames = new HashSet<FrameEntity>();
        }

        public int id { get; set; }

        public DateTime create_dt { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string content { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FrameEntity> frames { get; set; }
    }
}
