using System.Collections.Generic;

namespace Exfob.Models.CustomModels
{
    public  class ProfileAuthorizerLoginModel
    {
        public int ProfilAutoriseID { get; set; }
        public string Libelle { get; set; }
        public List<DroitsAuthorizerLoginModel> DroitsAuthoriser { get; set; }
        
    }
}
