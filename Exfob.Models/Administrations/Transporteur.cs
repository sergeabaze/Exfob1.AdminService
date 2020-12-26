namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Transporteur")]
    public partial class Transporteur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transporteur()
        {
            MoyenTransports = new HashSet<MoyenTransport>();
        }

        public int TransporteurID { get; set; }

        public int? SiteOperationID { get; set; }

        public int? ModeTransportID { get; set; }

        public int? ComptabiliteID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(30)]
        public string NomTransporteur { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Responsable { get; set; }

        [StringLength(13)]
        public string Comptabilite1 { get; set; }

        [StringLength(13)]
        public string Comptabilite2 { get; set; }

        public virtual Comptabilite Comptabilite { get; set; }

        public virtual ModeTransport ModeTransport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MoyenTransport> MoyenTransports { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
