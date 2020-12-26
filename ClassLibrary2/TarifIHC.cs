namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarifIHC")]
    public partial class TarifIHC
    {
        public int TarifIHCID { get; set; }

        public int SocieteID { get; set; }

        public int EssenceID { get; set; }

        public int ProduitID { get; set; }

        public int QualiteIHCID { get; set; }

        public float PrixM3Prix { get; set; }

        public float? AncienPrixM3 { get; set; }

        public DateTime? DateAncienPrixm3 { get; set; }

        public DateTime? DatePrixM3 { get; set; }

        public virtual Essence Essence { get; set; }

        public virtual Produit Produit { get; set; }

        public virtual QualiteIHC QualiteIHC { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
