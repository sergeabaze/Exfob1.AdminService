namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompteBanque")]
    public partial class CompteBanque
    {
        public int CompteBanqueID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroCompte { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
