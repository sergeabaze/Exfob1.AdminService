using Exfob1.Communs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Request
{
    public class UtilisateurActivationRequest
    {
        public bool  EstActif { get; set; }

        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string MisejourPar { get; set; }
    }
}
