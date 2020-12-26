namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CodePlaquette")]
    public partial class CodePlaquette
    {
        public int CodePlaquetteID { get; set; }

        public int SiteOperationID { get; set; }

        public int QualiteBoisID { get; set; }

        public int SciesID { get; set; }

        public int TypeLongueurID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(30)]
        public string CodePlaq1 { get; set; }

        [Required]
        [StringLength(10)]
        public string CodeIhc { get; set; }

        [Required]
        [StringLength(50)]
        public string PrixVenteLocale { get; set; }

        [Required]
        [StringLength(50)]
        public string PosAffic { get; set; }

        [Required]
        [StringLength(50)]
        public string LongueurRecuperation { get; set; }

        public virtual CodePlaquette CodePlaquette1 { get; set; }

        public virtual CodePlaquette CodePlaquette2 { get; set; }

        public virtual CodePlaquette CodePlaquette11 { get; set; }

        public virtual CodePlaquette CodePlaquette3 { get; set; }

        public virtual Scy Scy { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual QualiteBois QualiteBois { get; set; }

        public virtual TypeLongueur TypeLongueur { get; set; }
    }
}
