namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Chantier")]
    public partial class Chantier
    {
        public int ChantierID { get; set; }

        public int? SiteOperationID { get; set; }

        [StringLength(25)]
        public string CodeChantier { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string GroupeAppart { get; set; }

        [StringLength(25)]
        public string CodeActivite { get; set; }

        [StringLength(25)]
        public string SeqBil { get; set; }

        public bool? Actif { get; set; }

        public DateTime DateCreation { get; set; }

        [Required]
        [StringLength(50)]
        public string CreerPar { get; set; }

        public DateTime? DateModification { get; set; }

        [StringLength(50)]
        public string MisejourPar { get; set; }

        public int ContratFournisseurID { get; set; }

        public virtual ContratFournisseur ContratFournisseur { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
