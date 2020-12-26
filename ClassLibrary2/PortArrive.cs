namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PortArrive")]
    public partial class PortArrive
    {
        public int PortArriveID { get; set; }

        public int SocieteID { get; set; }

        public int SiteArriveID { get; set; }

        [Required]
        [StringLength(255)]
        public string Libelle { get; set; }
    }
}
