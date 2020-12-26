namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Scy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Scy()
        {
            CodePlaquettes = new HashSet<CodePlaquette>();
            Rotations = new HashSet<Rotation>();
        }

        [Key]
        public int SciesID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(25)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(2)]
        public string CodeNature { get; set; }

        [StringLength(2)]
        public string Sigle { get; set; }

        [Required]
        [StringLength(1)]
        public string CodeProduction { get; set; }

        public short? OrdreOperation { get; set; }

        public bool? OrdreActivite { get; set; }

        [StringLength(3)]
        public string ScieOrg { get; set; }

        [StringLength(25)]
        public string FamilleProduction { get; set; }

        [StringLength(25)]
        public string ScieProduit { get; set; }

        public int? EquipeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodePlaquette> CodePlaquettes { get; set; }

        public virtual Equipe Equipe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rotation> Rotations { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
