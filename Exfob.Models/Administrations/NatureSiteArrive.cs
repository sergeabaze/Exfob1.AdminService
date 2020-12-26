namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("NatureSiteArrive")]
    public partial class NatureSiteArrive
    {
        public int NatureSiteArriveID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }
    }
}
