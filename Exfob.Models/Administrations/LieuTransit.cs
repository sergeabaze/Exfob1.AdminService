namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("LieuTransit")]
    public partial class LieuTransit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LieuTransit()
        {
            Parcs = new HashSet<Parc>();
        }

        public int LieuTransitID { get; set; }

        public int SiteOperattionID { get; set; }

        public int PortID { get; set; }

        [StringLength(50)]
        public string TypeSiteParc { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        public virtual Port Port { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parc> Parcs { get; set; }
    }
}
