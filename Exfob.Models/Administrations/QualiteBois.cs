namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class QualiteBois
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QualiteBois()
        {
            CodePlaquettes = new HashSet<CodePlaquette>();
        }

        public int QualiteBoisID { get; set; }

        public int SiteOperationID { get; set; }

        public int ProduitID { get; set; }

        [Required]
        [StringLength(30)]
        public string CodeQualite { get; set; }

        [Required]
        [StringLength(150)]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string CodeMercuriale { get; set; }

        [StringLength(50)]
        public string CodeActivite { get; set; }

        [StringLength(50)]
        public string CodePlaq1 { get; set; }

        [StringLength(50)]
        public string CodeIhc { get; set; }

        public float? PrixVenteLocale { get; set; }

        [StringLength(50)]
        public string PosAffic { get; set; }

        [StringLength(50)]
        public string LongueurRecuperation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodePlaquette> CodePlaquettes { get; set; }

        public virtual Produit Produit { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
