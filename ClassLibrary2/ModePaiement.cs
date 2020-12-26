namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModePaiement")]
    public partial class ModePaiement
    {
        public int ModePaiementID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(50)]
        public string Intitule { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
