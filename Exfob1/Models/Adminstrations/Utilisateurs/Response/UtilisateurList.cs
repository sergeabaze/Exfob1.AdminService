using System;
using System.Collections.Generic;
using System.Text;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
   public  class UtilisateurList
    {
        public int UtilisateurID { get; set; }
        public string Nom { get; set; }
        public string SiteOperation { get; set; }
        public string Email { get; set; }
        public string Matricule { get; set; }
        public string profile { get; set; }
        public bool? EstActif { get; set; }
        public string  Langue { get; set; }

    }
}
