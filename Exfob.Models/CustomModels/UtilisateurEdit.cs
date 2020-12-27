using System.Collections.Generic;

namespace Exfob.Models.CustomModels
{
    public  class UtilisateurEdit
    {
        public Administration.Utilisateur Utilisateur { get; set; }
        public List<Administration.Profil> Profiles { get; set; }
        public List<Administration.Langue> Langues { get; set; }
        public List<SiteOperationForListe> SiteOperations { get; set; }
    }
}
