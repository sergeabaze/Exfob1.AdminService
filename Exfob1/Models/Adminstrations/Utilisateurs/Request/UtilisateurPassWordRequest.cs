using Exfob1.Communs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Request
{
    public class UtilisateurPassWordRequest
    {
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string NewPassWord { get; set; }
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string MisejourPar { get; set; }
        
    }
}
