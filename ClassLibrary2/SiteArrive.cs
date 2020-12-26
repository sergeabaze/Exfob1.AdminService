namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteArrive")]
    public partial class SiteArrive
    {
        public int SiteArriveID { get; set; }

        public short PaysID { get; set; }

        public int NatureSiteID { get; set; }

        public int PortID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(20)]
        public string CodePort { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Aactif { get; set; }

        [StringLength(50)]
        public string Phyto { get; set; }

        [StringLength(50)]
        public string Co { get; set; }

        [StringLength(50)]
        public string Eur1 { get; set; }

        public virtual NatureSite NatureSite { get; set; }

        public virtual Pay Pay { get; set; }

        public virtual Port Port { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
