namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesOperation")]
    public partial class TablesOperation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablesOperation()
        {
            ObjetDeControles = new HashSet<ObjetDeControle>();
        }

        [Key]
        public int TablesID { get; set; }

        public int? SocieteID { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjetDeControle> ObjetDeControles { get; set; }

        public virtual Societe Societe { get; set; }
    }
}
