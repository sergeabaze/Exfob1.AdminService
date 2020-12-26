namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Destination")]
    public partial class Destination
    {
        public int DestinationID { get; set; }

        public short PaysID { get; set; }

        [Required]
        [StringLength(25)]
        public string Libelle { get; set; }

        public short? Phyto { get; set; }

        public short? Co { get; set; }

        public short? Eur1 { get; set; }

        public virtual Pays Pay { get; set; }
    }
}
