using System.Collections.Generic;

namespace Exfob.Models.CustomModels
{
    public  class SiteAutoriseForListe
    {
        public int SiteAutoriseID { get; set; }
        public int ProfilAutoriseID { get; set; }
        public string  ProfilAutorise { get; set; }
        public string  SiteOperation { get; set; }
        public IEnumerable<DroitAutoriseForListe> Droits { get; set; }
        
    }
}
