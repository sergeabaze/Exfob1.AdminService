namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PeriodeCloture")]
    public partial class PeriodeCloture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PeriodeCloture()
        {
            ObjetDeControles = new HashSet<ObjetDeControle>();
        }

        [Key]
        public int PeriodeID { get; set; }

        public int SocieteID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        public bool EstPeriodeCourante { get; set; }

        public bool EstPeriodeCloture { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        [Required]
        [StringLength(30)]
        public string CreerPar { get; set; }

        public DateTime DateCreation { get; set; }

        [StringLength(30)]
        public string ModifierPar { get; set; }

        public DateTime? DateModification { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjetDeControle> ObjetDeControles { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
