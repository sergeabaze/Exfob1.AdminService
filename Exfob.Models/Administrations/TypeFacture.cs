namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TypeFacture")]
    public partial class TypeFacture
    {
        public int TypeFactureID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(30)]
        public string Libelle { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
