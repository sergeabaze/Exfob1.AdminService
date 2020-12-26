namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SocieteMaritime")]
    public partial class SocieteMaritime
    {
        public int SocieteMaritimeID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(50)]
        public string NomSociete { get; set; }

        [StringLength(50)]
        public string ServiceContrat { get; set; }

        [StringLength(50)]
        public string Mention { get; set; }

        public short? DelaisAttenteAccostage { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
