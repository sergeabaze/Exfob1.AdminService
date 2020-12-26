namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class CompteTier
    {
        [Key]
        public int CompteTiersID { get; set; }

        public int? SocieteID { get; set; }

        public short? PaysID { get; set; }

        [StringLength(13)]
        public string NumeroCompte { get; set; }

        [StringLength(13)]
        public string NumeroPrinc { get; set; }

        public short? Type { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Ville { get; set; }

        [StringLength(20)]
        public string CodePostal { get; set; }

        [StringLength(20)]
        public string BoiteNumero { get; set; }

        [StringLength(20)]
        public string CtNumero { get; set; }

        public virtual Pays Pay { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
