namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TerminalPort")]
    public partial class TerminalPort
    {
        public int TerminalPortID { get; set; }

        public int PortID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(30)]
        public string Nom { get; set; }

        public short? TriAffic { get; set; }

        public virtual Port Port { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
