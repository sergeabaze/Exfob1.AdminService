namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Utilisateur")]
    public partial class Utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilisateur()
        {
            SiteAutorises = new HashSet<SiteAutorise>();
        }

        public int UtilisateurID { get; set; }

        public int? SiteOperationID { get; set; }

        public int ProfilID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginUtilisateur { get; set; }

        [Required]
        [StringLength(50)]
        public string MotPasseHash { get; set; }

        [StringLength(50)]
        public string SelMotdePasse { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Matricule { get; set; }

        [StringLength(30)]
        public string Fonction { get; set; }

        public bool? EstActif { get; set; }

        public int? LangueID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateConnection { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateMisejour { get; set; }

        [Required]
        [StringLength(50)]
        public string CreerPar { get; set; }

        [StringLength(50)]
        public string MiseJourPar { get; set; }

        public virtual Langue Langue { get; set; }

        public virtual Profil Profil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteAutorise> SiteAutorises { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
