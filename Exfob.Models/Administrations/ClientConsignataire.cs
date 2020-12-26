namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ClientConsignataire")]
    public partial class ClientConsignataire
    {
        public int ClientConsignataireID { get; set; }

        public int? MaterielID { get; set; }

        public int ClientID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string NomConsignataire { get; set; }

        public virtual Client Client { get; set; }

        public virtual Materiel Materiel { get; set; }
    }
}
