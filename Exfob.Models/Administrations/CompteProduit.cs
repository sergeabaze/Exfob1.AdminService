namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("CompteProduit")]
    public partial class CompteProduit
    {
        public int CompteProduitID { get; set; }

        public int SocieteID { get; set; }

        [StringLength(6)]
        public string CodeJournal { get; set; }

        [StringLength(13)]
        public string CompteGeneral { get; set; }

        [StringLength(13)]
        public string CompteTiers { get; set; }

        [Column("CompteProduit")]
        [StringLength(13)]
        public string CompteProduit1 { get; set; }

        [StringLength(13)]
        public string CompteAnalytique { get; set; }

        [StringLength(5)]
        public string CodSig { get; set; }

        [StringLength(20)]
        public string LibelleEcriture { get; set; }

        public bool? TaxeTVA { get; set; }

        public bool? TaxeCa { get; set; }

        public bool? TaxeAsdi { get; set; }

        public bool? TaxeDigenaf { get; set; }

        [StringLength(2)]
        public string TypeFacture { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
