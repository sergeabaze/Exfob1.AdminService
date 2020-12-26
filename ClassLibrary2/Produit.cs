namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            DensiteBois = new HashSet<DensiteBois>();
            QualiteBois = new HashSet<QualiteBois>();
            TarifIHCs = new HashSet<TarifIHC>();
        }

        public int ProduitID { get; set; }

        public int SocieteID { get; set; }

        public int SousFamilleID { get; set; }

        [Required]
        [StringLength(20)]
        public string CodeProduit { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string TypeQualite { get; set; }

        [StringLength(50)]
        public string TypeGroupe { get; set; }

        [Required]
        [StringLength(10)]
        public string CodeActivite { get; set; }

        [Required]
        [StringLength(50)]
        public string CodePlaque { get; set; }

        [StringLength(50)]
        public string PostAff { get; set; }

        [Required]
        [StringLength(50)]
        public string CodeSig { get; set; }

        [StringLength(50)]
        public string SDKDF { get; set; }

        [StringLength(50)]
        public string Unites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DensiteBois> DensiteBois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QualiteBois> QualiteBois { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarifIHC> TarifIHCs { get; set; }
    }
}
