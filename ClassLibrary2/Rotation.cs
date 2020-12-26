namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rotation")]
    public partial class Rotation
    {
        public int RotationID { get; set; }

        public int SiteOperationID { get; set; }

        public int EquipeID { get; set; }

        public int TrancheHoraireID { get; set; }

        public int SciesID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        public DateTime? DateCreation { get; set; }

        public DateTime? DateModification { get; set; }

        public virtual Equipe Equipe { get; set; }

        public virtual Scy Scy { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual TrancheHoraire TrancheHoraire { get; set; }
    }
}
