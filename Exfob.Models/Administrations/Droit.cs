namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Droit")]
    public partial class Droit
    {
        public int DroitID { get; set; }

        public int ModuleID { get; set; }

        public int ProfilID { get; set; }

        public bool Ecriture { get; set; }

        public bool Lecture { get; set; }

        public bool Modifier { get; set; }

        public bool Suppression { get; set; }

        public bool Impression { get; set; }

        public virtual Module Module { get; set; }

        public virtual Profil Profil { get; set; }
    }
}
