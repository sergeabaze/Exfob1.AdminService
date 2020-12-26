namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("PileGrume")]
    public partial class PileGrume
    {
        public int PileGrumeID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        public int SiteOperationID { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
