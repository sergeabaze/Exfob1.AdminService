using System.Collections.Generic;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class ProfileAuthorizerLoginReponse
    {
        public int ProfilAutoriseID { get; set; }
        public string Libelle { get; set; }
        public List<DroitsAuthorizerLoginReponse> DroitsAuthoriser { get; set; }
    }
}
