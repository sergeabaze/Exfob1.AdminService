using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations.Langues.Request
{
    public  class LangueEdit: LangueRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
        public int LangueID { get; set; }
    }
}
