namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Equipe")]
    public partial class Equipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipe()
        {
            AffecterEquipes = new HashSet<AffecterEquipe>();
            EquipeOperateurs = new HashSet<EquipeOperateur>();
            Rotations = new HashSet<Rotation>();
            Scies = new HashSet<Scie>();
        }

        public int EquipeID { get; set; }

        public int SiteOperationID { get; set; }

        public int TypeEquipeID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Libelle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AffecterEquipe> AffecterEquipes { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }

        public virtual TypeEquipe TypeEquipe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipeOperateur> EquipeOperateurs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rotation> Rotations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Scie> Scies { get; set; }
    }
}
