namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class SocieteLoginReponse
    {
        public int SocieteID { get; set; }
        public short SiegeID { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public bool EstPeriodeCloture { get; set; }
    }
}
