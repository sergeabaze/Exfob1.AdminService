namespace Exfob.Models.CustomModels
{
    public  class DroitAutoriseForListe
    {
        public int DroitAutoriseID { get; set; }

        public int ProfilAutoriseID { get; set; }

        public int ModuleID { get; set; }

        public bool Ecriture { get; set; }

        public bool Lecture { get; set; }

        public bool Modifier { get; set; }

        public bool Suppression { get; set; }

        public bool Impression { get; set; }

        public string ModuleLibelle { get; set; }
    }
}
