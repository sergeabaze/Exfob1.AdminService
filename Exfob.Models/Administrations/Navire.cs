namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Navire")]
    public partial class Navire
    {
        public int NavireID { get; set; }

        public int SocieteMaritimeID { get; set; }

        public int LoadingNavireID { get; set; }

        [Required]
        [StringLength(20)]
        public string CodeNavire { get; set; }

        [StringLength(50)]
        public string NomNavire { get; set; }
    }
}
