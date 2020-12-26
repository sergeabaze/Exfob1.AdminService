namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Parc")]
    public partial class Parc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Parc()
        {
            Ports = new HashSet<Port>();
        }

        public int ParcID { get; set; }

        public int SiteOperattionID { get; set; }

        public int NatureParcID { get; set; }

        [Required]
        [StringLength(3)]
        public string CodeParc { get; set; }

        [Required]
        [StringLength(20)]
        public string Libelle { get; set; }

        public bool CodeVolume { get; set; }

        [Required]
        [StringLength(1)]
        public string CodeArbre { get; set; }

        [Required]
        [StringLength(1)]
        public string CodeStockSechoir { get; set; }

        [StringLength(10)]
        public string CodeParcBois { get; set; }

        public int? LieuTransitID { get; set; }

        public virtual LieuTransit LieuTransit { get; set; }

        public virtual NatureParc NatureParc { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Port> Ports { get; set; }
    }
}
