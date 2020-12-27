namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class SiteOperationLoginReponse
    {
        public int SiteOperationID { get; set; }
        public short? SiegeID { get; set; }
        public int? NatureSiteID { get; set; }
        public string Adresse { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public SiegeLoginReponse Siege { get; set; }
        public SocieteLoginReponse Societe { get; set; }
    }
}
