namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RedevanceEtatique")]
    public partial class RedevanceEtatique
    {
        public int RedevanceEtatiqueID { get; set; }

        public int PortID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(30)]
        public string Intitule { get; set; }

        public short? TriAffic { get; set; }

        public virtual Port Port { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
