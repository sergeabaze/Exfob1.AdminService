namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ContratFournisseur")]
    public partial class ContratFournisseur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContratFournisseur()
        {
            Chantiers = new HashSet<Chantier>();
        }

        public int FournisseurID { get; set; }

        public int SiteOperationID { get; set; }

        [StringLength(50)]
        public string NumeroAgrement { get; set; }

        public bool Responsable { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime Datefin { get; set; }

        public int ContratFournisseurID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chantier> Chantiers { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
