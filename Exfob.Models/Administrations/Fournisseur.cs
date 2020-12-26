namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Fournisseur")]
    public partial class Fournisseur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fournisseur()
        {
            ContratFournisseurs = new HashSet<ContratFournisseur>();
        }

        public int FournisseurID { get; set; }

        public int SiteOperationID { get; set; }

        public int TypeFournisseurID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [StringLength(50)]
        public string Adresse1 { get; set; }

        [StringLength(50)]
        public string Adresse2 { get; set; }

        [StringLength(50)]
        public string BoitePostal { get; set; }

        [StringLength(50)]
        public string Telephone1 { get; set; }

        [StringLength(50)]
        public string Telephone2 { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContratFournisseur> ContratFournisseurs { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual TypeFournisseur TypeFournisseur { get; set; }
    }
}
