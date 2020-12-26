namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModeTransport")]
    public partial class ModeTransport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModeTransport()
        {
            Transporteurs = new HashSet<Transporteur>();
        }

        public int ModeTransportID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transporteur> Transporteurs { get; set; }
    }
}
