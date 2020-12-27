namespace Exfob.Models.CustomModels
{
    public  class SiteOperationsAuthorizerLoginModel
    {
        public int SiteAutoriseID { get; set; }
        public int SiteOperationID { get; set; }
        public int ProfilAutoriseID { get; set; }
       
        public string ProfilAutorise { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string Adresse { get; set; }
        public ProfileAuthorizerLoginModel Profile { get; set; }
    }
}
