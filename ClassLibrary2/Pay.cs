namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pay()
        {
            Clients = new HashSet<Client>();
            CompteTiers = new HashSet<CompteTier>();
            Destinations = new HashSet<Destination>();
            SiteArrives = new HashSet<SiteArrive>();
            Villes = new HashSet<Ville>();
        }

        [Key]
        public short PaysID { get; set; }

        [Required]
        [StringLength(50)]
        public string CodePays { get; set; }

        [Required]
        [StringLength(50)]
        public string NomPays { get; set; }

        [StringLength(20)]
        public string CodePostal { get; set; }

        public int? SocieteID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompteTier> CompteTiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Destination> Destinations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteArrive> SiteArrives { get; set; }

        public virtual Societe Societe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ville> Villes { get; set; }
    }
}
