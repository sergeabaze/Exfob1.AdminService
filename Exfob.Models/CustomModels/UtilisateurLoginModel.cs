using System.Collections.Generic;

namespace Exfob.Models.CustomModels
{
   public  class UtilisateurLoginModel
    {
        public int UtilisateurID { get; set; }
        public int SiteOperationID { get; set; }
        public int ProfilID { get; set; }
        public int LangueID { get; set; }
        public string Nom { get; set; }
        public string LoginUtilisateur { get; set; }
        public string Email { get; set; }
        public bool? EstActif { get; set; }
        public LangueLoginModel Langue { get; set; }
        public ProfileLoginModel Profile { get; set; }
        public SiteOperationLoginModel SiteOperation { get; set; }
        public List<SiteOperationsAuthorizerLoginModel> SiteOperationsAuthorises { get; set; }

    }
}
