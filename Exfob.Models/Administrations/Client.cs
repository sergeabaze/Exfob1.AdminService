namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            ClientAdresses = new HashSet<ClientAdresse>();
            ClientConsignataires = new HashSet<ClientConsignataire>();
            ClientContacts = new HashSet<ClientContact>();
        }

        public int ClientID { get; set; }

        public int? SiteOperationID { get; set; }

        public short? SiegeID { get; set; }

        public int TypeclientID { get; set; }

        public short PaysID { get; set; }

        public int VilleID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Nomclient { get; set; }

        [StringLength(20)]
        public string Telephone1 { get; set; }

        [StringLength(20)]
        public string Telephone2 { get; set; }

        [StringLength(20)]
        public string Faxe1 { get; set; }

        [StringLength(20)]
        public string Faxe2 { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Observation { get; set; }

        [StringLength(20)]
        public string EorNumber { get; set; }

        public virtual Pays Pay { get; set; }

        public virtual Siege Siege { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual TypeClient TypeClient { get; set; }

        public virtual Ville Ville { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientAdresse> ClientAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientConsignataire> ClientConsignataires { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientContact> ClientContacts { get; set; }
    }
}
