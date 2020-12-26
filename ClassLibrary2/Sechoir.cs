namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sechoir")]
    public partial class Sechoir
    {
        public int SechoirID { get; set; }

        public int SiteOperationID { get; set; }

        public int Capacite { get; set; }

        [Required]
        [StringLength(20)]
        public string LibelleChambre { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
