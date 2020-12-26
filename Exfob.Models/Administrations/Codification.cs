namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Codification")]
    public partial class Codification
    {
        public int CodificationID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [StringLength(50)]
        public string QualiteCode { get; set; }

        [StringLength(50)]
        public string ClasseCode { get; set; }
    }
}
