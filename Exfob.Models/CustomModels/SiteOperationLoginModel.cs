namespace Exfob.Models.CustomModels
{
    public  class SiteOperationLoginModel
    {
        public int SiteOperationID { get; set; }
        public short? SiegeID { get; set; }
        public int? NatureSiteID { get; set; }
        public string Adresse { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public SiegeLoginModel Siege { get; set; }
        public SocieteLoginModel Societe { get; set; }
    }
}
