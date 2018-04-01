namespace McFly.Server.Data.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("note")]
    public partial class note
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public note()
        {
            frames = new HashSet<frame>();
        }

        public int id { get; set; }

        public DateTime create_dt { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string content { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<frame> frames { get; set; }
    }
}
