namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientContact")]
    public partial class ClientContact
    {
        public int ClientContactID { get; set; }

        public int ClientID { get; set; }

        public int ClientAdresseID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string NomContact { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        public bool? EstDefaut { get; set; }

        public virtual Client Client { get; set; }

        public virtual ClientAdresse ClientAdresse { get; set; }
    }
}
