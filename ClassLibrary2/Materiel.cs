namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Materiel")]
    public partial class Materiel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materiel()
        {
            ClientConsignataires = new HashSet<ClientConsignataire>();
        }

        public int MaterielID { get; set; }

        public int SiteOperationID { get; set; }

        public int TypeMaterielID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Libelle { get; set; }

        public int? SousTraitanceID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientConsignataire> ClientConsignataires { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual TypeMateriel TypeMateriel { get; set; }
    }
}
