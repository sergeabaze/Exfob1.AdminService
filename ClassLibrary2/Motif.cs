namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Motif")]
    public partial class Motif
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motif()
        {
            StockArbreForets = new HashSet<StockArbreForet>();
        }

        public int MotifID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(100)]
        public string Observation { get; set; }

        [StringLength(50)]
        public string Nature { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockArbreForet> StockArbreForets { get; set; }
    }
}
