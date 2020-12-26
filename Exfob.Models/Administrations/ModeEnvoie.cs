namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ModeEnvoie")]
    public partial class ModeEnvoie
    {
        public int ModeEnvoieID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
