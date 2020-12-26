namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("LoadingNavire")]
    public partial class LoadingNavire
    {
        public int LoadingNavireID { get; set; }

        [StringLength(50)]
        public string LoadingChargement { get; set; }
    }
}
