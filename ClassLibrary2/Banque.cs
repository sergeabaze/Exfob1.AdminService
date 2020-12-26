namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banque")]
    public partial class Banque
    {
        public int BanqueID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(15)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(20)]
        public string Sigle { get; set; }

        [Required]
        [StringLength(20)]
        public string CodeGuichet { get; set; }

        [Required]
        [StringLength(50)]
        public string Iban { get; set; }

        [StringLength(20)]
        public string Swift { get; set; }

        [Required]
        [StringLength(100)]
        public string Domiciliation { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
