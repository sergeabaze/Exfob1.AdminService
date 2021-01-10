using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Request
{
    public  class UtilisateurLoginEdit
    {

        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string Nomutilisateur { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
       // [Required(ErrorMessageResourceName = "Erreur100", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Motpasse { get; set; }
    }
}
