namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("QualiteIHC")]
    public partial class QualiteIHC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QualiteIHC()
        {
            TarifIHCs = new HashSet<TarifIHC>();
        }

        public int QualiteIHCID { get; set; }

        [Required]
        [StringLength(2)]
        public string CodeQualite { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string CodeMercuriale { get; set; }

        public bool? CodeActivite { get; set; }

        [StringLength(2)]
        public string CodePlaquette { get; set; }

        [StringLength(2)]
        public string CodePlaquette1 { get; set; }

        [StringLength(2)]
        public string CodeIhc { get; set; }

        public float? PrixVenteLocale { get; set; }

        [StringLength(4)]
        public string PosAffic { get; set; }

        public float? LongueurRecuperation { get; set; }

        [StringLength(50)]
        public string ObservationsQualiteIHC { get; set; }

        public int? SousFamilleID { get; set; }

        public virtual SousFamille SousFamille { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TarifIHC> TarifIHCs { get; set; }
    }
}
