namespace Exfob.Models.CustomModels
{
    public  class DroitsForListe
    {
        public int DroitID { get; set; }

        public int ModuleID { get; set; }

        public int ProfilID { get; set; }

        public bool Ecriture { get; set; }

        public bool Lecture { get; set; }

        public bool Modifier { get; set; }

        public bool Suppression { get; set; }

        public bool Impression { get; set; }

        public string Module { get; set; }
    }
}
