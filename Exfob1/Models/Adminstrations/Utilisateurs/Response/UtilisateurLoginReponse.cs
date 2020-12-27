using System;
using System.Collections.Generic;
using System.Text;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
   public  class UtilisateurLoginReponse
    {
        public int UtilisateurID { get; set; }
        public int SiteOperationID { get; set; }
        public int ProfilID { get; set; }
        public int LangueID { get; set; }
        public string Nom { get; set; }
        public string LoginUtilisateur { get; set; }
        public string Email { get; set; }
        public bool? EstActif { get; set; }
        public LangueLoginReponse Langue { get; set; }
        public ProfileLoginReponse Profile { get; set; }
        public SiteOperationLoginReponse SiteOperation { get; set; }
        public List<SiteOperationsAuthorizerLoginReponse> SiteOperationsAuthorises { get; set; }
    }
}
