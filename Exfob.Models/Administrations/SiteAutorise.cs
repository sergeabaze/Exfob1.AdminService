namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SiteAutorise")]
    public partial class SiteAutorise
    {
        public int SiteAutoriseID { get; set; }

        public int SiteOperationID { get; set; }

        public int UtilisateurID { get; set; }

        public int ProfilAutoriseID { get; set; }

        public virtual ProfilAutorise ProfilAutorise { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }

        public virtual SiteOperation SiteOperation { get; set; }
    }
}
