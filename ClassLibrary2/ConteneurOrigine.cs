namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConteneurOrigine")]
    public partial class ConteneurOrigine
    {
        [Key]
        public int ContenaireOrigineID { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }
    }
}
