namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("TypeLongueur")]
    public partial class TypeLongueur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeLongueur()
        {
            CodePlaquettes = new HashSet<CodePlaquette>();
        }

        public int TypeLongueurID { get; set; }

        public int SiteOperationID { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodePlaquette> CodePlaquettes { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
