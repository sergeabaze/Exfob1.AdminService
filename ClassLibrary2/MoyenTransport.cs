namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MoyenTransport")]
    public partial class MoyenTransport
    {
        public int MoyenTransportID { get; set; }

        public int SiteOperationID { get; set; }

        public int TransporteurtID { get; set; }

        [StringLength(20)]
        public string NumeroTracteur { get; set; }

        [StringLength(20)]
        public string NumeroRemorque { get; set; }

        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(50)]
        public string Chauffeur { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual Transporteur Transporteur { get; set; }
    }
}
