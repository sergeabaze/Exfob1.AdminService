namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Acconier")]
    public partial class Acconier
    {
        public int AcconierID { get; set; }

        [Required]
        [StringLength(40)]
        public string Nom { get; set; }

        [StringLength(15)]
        public string Localisation { get; set; }

        public int? SiteOperationID { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
