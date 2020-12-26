namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SousTraitance")]
    public partial class SousTraitance
    {
        public int SousTraitanceID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(20)]
        public string Intitule { get; set; }

        [StringLength(30)]
        public string SigleTrait { get; set; }

        [StringLength(2)]
        public string InfoTrait { get; set; }

        [StringLength(2)]
        public string CodeTransp { get; set; }

        [StringLength(1)]
        public string SousFacture { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
