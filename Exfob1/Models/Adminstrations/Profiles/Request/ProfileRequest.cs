using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations.Profiles.Request
{
    public  class ProfileRequest
    {
        [Required(ErrorMessage = MessageValidations.Erreur100)]
        public string Libelle { get; set; }
    }
}
