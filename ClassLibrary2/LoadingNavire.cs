namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoadingNavire")]
    public partial class LoadingNavire
    {
        public int LoadingNavireID { get; set; }

        [StringLength(50)]
        public string LoadingChargement { get; set; }
    }
}
