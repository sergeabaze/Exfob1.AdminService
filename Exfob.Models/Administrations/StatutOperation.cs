namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("StatutOperation")]
    public partial class StatutOperation
    {
        public int StatutOperationID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }
    }
}
