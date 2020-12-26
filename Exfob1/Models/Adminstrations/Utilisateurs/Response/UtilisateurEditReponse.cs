using System;
using System.Collections.Generic;
using System.Text;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
   public  class UtilisateurEditReponse
    {
        public int UtilisateurID { get; set; }

        public int? SiteOperationID { get; set; }

        public int ProfilID { get; set; }

        public string Nom { get; set; }

        public string LoginUtilisateur { get; set; }

        public string MotPasseHash { get; set; }


        public string SelMotdePasse { get; set; }


        public string Email { get; set; }


        public string Matricule { get; set; }


        public string Fonction { get; set; }

        public bool? EstActif { get; set; }

        public int? LangueID { get; set; }


        public DateTime? DateConnection { get; set; }


        public DateTime DateCreation { get; set; }


        public DateTime? DateMisejour { get; set; }


        public string CreerPar { get; set; }


        public string MiseJourPar { get; set; }
    }
}
