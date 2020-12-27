using System.Collections.Generic;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class ProfileLoginReponse
    {
        public int ProfilID { get; set; }
        public string Libelle { get; set; }
        public List<DroitsLoginReponse> Droits { get; set; }
    }
}
