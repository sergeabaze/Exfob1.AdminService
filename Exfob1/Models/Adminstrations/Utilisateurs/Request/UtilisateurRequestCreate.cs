using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Request
{
    public   class UtilisateurRequestCreate
    {
      
        
        public int? SiegeID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
        public int ProfilID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
        public int LangueID { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string Nom { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string LoginUtilisateur { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string SelMotdePasse { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string Email { get; set; }
        public string Matricule { get; set; }
        public string Fonction { get; set; }
        public bool EstActif { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string CreerPar { get; set; }
    }
}
