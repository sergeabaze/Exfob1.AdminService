namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Essence")]
    public partial class Essence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Essence()
        {
            DensiteBois = new HashSet<DensiteBois>();
            TarifIHCs = new HashSet<TarifIHC>();
        }

        public int EssenceID { get; set; }

        public int ClasseEssenceID { get; set; }

        public int SocieteID { get; set; }

        public int CategorieEssenceID { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string NomScientifique { get; set; }

        [StringLength(1)]
        public string CodeMesurage { get; set; }

        public short? DiamExpeditionOfficielle { get; set; }

        [StringLength(1)]
        public string MesurageAubier { get; set; }

        public bool? CodeActif { get; set; }

        [StringLength(3)]
        public string NomSnt { get; set; }

        [StringLength(1)]
        public string CodeCubagePlein { get; set; }

        [StringLength(1)]
        public string CodeCubageCom { get; set; }

        [StringLength(1)]
        public string CodeStat { get; set; }

        [StringLength(1)]
        public string CodeCde { get; set; }

        [StringLength(3)]
        public string CodeIhc { get; set; }

        [StringLength(2)]
        public string Aupdate { get; set; }

        public float? RendementProduitRC { get; set; }

        [StringLength(1)]
        public string EtatIc { get; set; }

        public float? RendementProduitRC1 { get; set; }

        public float? SeuilLongueurEntreeScie { get; set; }

        public float? PrixFob { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public virtual CategorieEssence CategorieEssence { get; set; }

        public virtual ClasseEssence ClasseEssence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DensiteBois> DensiteBois { get; set; }

        public virtual Societe Societe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarifIHC> TarifIHCs { get; set; }
    }
}
