namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DroitAutorise")]
    public partial class DroitAutorise
    {
        public int DroitAutoriseID { get; set; }

        public int ProfilAutoriseID { get; set; }

        public int ModuleID { get; set; }

        public bool Ecriture { get; set; }

        public bool Lecture { get; set; }

        public bool Modifier { get; set; }

        public bool Suppression { get; set; }

        public bool Impression { get; set; }

        public virtual Module Module { get; set; }

        public virtual ProfilAutorise ProfilAutorise { get; set; }
    }
}
