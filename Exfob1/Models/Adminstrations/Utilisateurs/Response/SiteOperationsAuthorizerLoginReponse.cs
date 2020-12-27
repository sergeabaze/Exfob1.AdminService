namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class SiteOperationsAuthorizerLoginReponse
    {
        public int SiteAutoriseID { get; set; }
        public int SiteOperationID { get; set; }
        public int ProfilAutoriseID { get; set; }
        public int LangueID { get; set; }
        public string ProfilAutorise { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Adresse { get; set; }
        public ProfileAuthorizerLoginReponse Profile { get; set; }
    }
}
