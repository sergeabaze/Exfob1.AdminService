namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Operateur")]
    public partial class Operateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operateur()
        {
            AffecterEquipes = new HashSet<AffecterEquipe>();
            EquipeOperateurs = new HashSet<EquipeOperateur>();
        }

        public int OperateurID { get; set; }

        public int SiteOperationID { get; set; }

        public int TypeOperateurID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }

        public bool? EstResponsable { get; set; }

        public int? OperateurGB3ID { get; set; }

        public int? OperateurGBID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AffecterEquipe> AffecterEquipes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipeOperateur> EquipeOperateurs { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual TypeOperateur TypeOperateur { get; set; }
    }
}
