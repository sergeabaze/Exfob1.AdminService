namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Societe")]
    public partial class Societe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Societe()
        {
            Banques = new HashSet<Banque>();
            CompteBanques = new HashSet<CompteBanque>();
            CompteProduits = new HashSet<CompteProduit>();
            CompteTiers = new HashSet<CompteTier>();
            Essences = new HashSet<Essence>();
            ListeServiceVentes = new HashSet<ListeServiceVente>();
            ModeEnvoies = new HashSet<ModeEnvoie>();
            Pays = new HashSet<Pays>();
            PeriodeClotures = new HashSet<PeriodeCloture>();
            Ports = new HashSet<Port>();
            Scies = new HashSet<Scie>();
            SiteArrives = new HashSet<SiteArrive>();
            SiteOperations = new HashSet<SiteOperation>();
            //SiteOperations1 = new HashSet<SiteOperation>();
            SocieteMaritimes = new HashSet<SocieteMaritime>();
            TablesOperations = new HashSet<TablesOperation>();
            TarifIHCs = new HashSet<TarifIHC>();
        }

        public int SocieteID { get; set; }

        public short SiegeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string BoitePostale { get; set; }

        [Required]
        [StringLength(100)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Ville { get; set; }

        [StringLength(50)]
        public string NatureActivite { get; set; }

        [StringLength(50)]
        public string Regime { get; set; }

        [StringLength(50)]
        public string Pw { get; set; }

        [StringLength(50)]
        public string Fsc { get; set; }

        [StringLength(50)]
        public string Tltv { get; set; }

        [StringLength(50)]
        public string NumIdentite { get; set; }

        [StringLength(50)]
        public string LDevise { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreation { get; set; }

        [StringLength(50)]
        public string NumeroCompte { get; set; }

        public bool EstPeriodeCloture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Banque> Banques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompteBanque> CompteBanques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompteProduit> CompteProduits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompteTier> CompteTiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essence> Essences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ListeServiceVente> ListeServiceVentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModeEnvoie> ModeEnvoies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pays> Pays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PeriodeCloture> PeriodeClotures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Port> Ports { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Scie> Scies { get; set; }

        public virtual Siege Siege { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteArrive> SiteArrives { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteOperation> SiteOperations { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SiteOperation> SiteOperations1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SocieteMaritime> SocieteMaritimes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TablesOperation> TablesOperations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarifIHC> TarifIHCs { get; set; }
    }
}
