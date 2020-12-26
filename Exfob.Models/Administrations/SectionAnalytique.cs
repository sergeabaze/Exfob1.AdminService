namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SectionAnalytique")]
    public partial class SectionAnalytique
    {
        public int SectionAnalytiqueID { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }

        public short? NAnalyse { get; set; }

        [StringLength(50)]
        public string SectionAnalytiqueGb { get; set; }
    }
}
