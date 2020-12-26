namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Siege")]
    public partial class Siege
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siege()
        {
            Clients = new HashSet<Client>();
            Societes = new HashSet<Societe>();
        }

        public short SiegeID { get; set; }

        public short? GroupeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Pays { get; set; }

        [StringLength(50)]
        public string Ville { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }

        public virtual Groupe Groupe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Societe> Societes { get; set; }
    }
}
