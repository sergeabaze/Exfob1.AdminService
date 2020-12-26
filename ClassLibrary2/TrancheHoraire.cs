namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrancheHoraire")]
    public partial class TrancheHoraire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrancheHoraire()
        {
            AffecterEquipes = new HashSet<AffecterEquipe>();
            Rotations = new HashSet<Rotation>();
        }

        public int TrancheHoraireID { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime Datefin { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AffecterEquipe> AffecterEquipes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rotation> Rotations { get; set; }
    }
}
