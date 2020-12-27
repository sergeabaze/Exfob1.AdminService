using System.Collections.Generic;

namespace Exfob.Models.CustomModels
{
    public  class ProfileLoginModel
    {
        public int ProfilID { get; set; }
        public string Libelle { get; set; }
        public List<DroitsLoginModel> Droits { get; set; }
    }
}
