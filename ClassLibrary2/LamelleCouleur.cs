namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LamelleCouleur")]
    public partial class LamelleCouleur
    {
        public int LamelleCouleurID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(30)]
        public string Intitule { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
