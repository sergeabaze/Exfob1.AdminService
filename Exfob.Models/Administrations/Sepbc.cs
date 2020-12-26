namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Sepbc")]
    public partial class Sepbc
    {
        public int SepbcID { get; set; }

        public int? PortID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        public virtual Port Port { get; set; }

       // public virtual Sepbc Sepbc1 { get; set; }

       // public virtual Sepbc Sepbc2 { get; set; }
    }
}
