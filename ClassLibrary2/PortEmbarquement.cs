namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PortEmbarquement")]
    public partial class PortEmbarquement
    {
        [Key]
        public int PortEmbraquementID { get; set; }

        public int? SiteOperationID { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(20)]
        public string Sigle { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual SiteOperation SiteOperation1 { get; set; }
    }
}
