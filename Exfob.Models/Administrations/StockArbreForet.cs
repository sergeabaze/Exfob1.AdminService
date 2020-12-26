namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("StockArbreForet")]
    public partial class StockArbreForet
    {
        public int StockArbreForetID { get; set; }

        public int TrackingID { get; set; }

        public int TronconnageParcID { get; set; }

        public int NatureMouvementID { get; set; }

        public int CategorieBoisID { get; set; }

        public int MotifID { get; set; }

        [StringLength(2)]
        public string SequenceNumeroForet { get; set; }

        public int? NumeroForestier { get; set; }

        [StringLength(2)]
        public string SequenceNumeroForet2 { get; set; }

        public int? DiametreGrosBoutBille1 { get; set; }

        public int? DiametreGrosBoutBille2 { get; set; }

        public int? DiametrePetitBoutBille1 { get; set; }

        public int? DiametrePetitBoutBille2 { get; set; }

        public int? DiametreMoyenneBille { get; set; }

        public float? LongueurBille { get; set; }

        public float? VolumeBille { get; set; }

        [StringLength(50)]
        public string Observation { get; set; }

        public DateTime? DateSortie { get; set; }

        [StringLength(6)]
        public string NumeroParc { get; set; }

        [StringLength(50)]
        public string CreerPar { get; set; }

        public DateTime? DateCreation { get; set; }

        [StringLength(30)]
        public string MiseAjourPar { get; set; }

        public DateTime? DateModification { get; set; }

        public virtual CategorieBois CategorieBois { get; set; }

        public virtual Motif Motif { get; set; }

        public virtual NatureMouvement NatureMouvement { get; set; }
    }
}
