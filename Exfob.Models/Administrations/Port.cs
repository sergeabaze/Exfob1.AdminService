namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Port")]
    public partial class Port
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Port()
        {
            LieuTransits = new HashSet<LieuTransit>();
            RedevanceEtatiques = new HashSet<RedevanceEtatique>();
            TerminalPorts = new HashSet<TerminalPort>();
            Sepbcs = new HashSet<Sepbc>();
            SiteArrives = new HashSet<SiteArrive>();
        }

        public int PortID { get; set; }

        public int SocieteID { get; set; }

        public int NaturePortID { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(25)]
        public string Numerodestination { get; set; }

        public bool EstActif { get; set; }

        public int? Phyto { get; set; }

        public int? Co { get; set; }

        public int? Eur1 { get; set; }

        public int? PaysID { get; set; }

        public int? ParcID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LieuTransit> LieuTransits { get; set; }

        public virtual NaturePort NaturePort { get; set; }

        public virtual Parc Parc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RedevanceEtatique> RedevanceEtatiques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerminalPort> TerminalPorts { get; set; }

        public virtual Societe Societe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepbc> Sepbcs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteArrive> SiteArrives { get; set; }
    }
}
