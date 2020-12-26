namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TypeoperationControle")]
    public partial class TypeoperationControle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeoperationControle()
        {
            ObjetDeControles = new HashSet<ObjetDeControle>();
        }

        public int TypeOperationControleID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjetDeControle> ObjetDeControles { get; set; }
    }
}
