using System;
using System.Collections.Generic;
using Exfob.Models.Administration;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
    public class UtilisateurReponse
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

        public  Langue Langue { get; set; }

       public  Profil Profil { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       // public  List<SiteAutorise> SiteAutorises { get; set; }

        public  SiteOperation SiteOperation { get; set; }
    }
   /* public class UtilisateurEditReponse
    {
        public Utilisateur Utilisateur { get; set; }
    }

    public class UtilisateurPagedReponse
    {
        public UtilisateurPagedReponse()
        {
            Utilisateurs = new List<Utilisateur>();
        }
        public List<Utilisateur> Utilisateurs { get; set; }
    }
    public class UtilisateurCreationReponse
    {
        public int UtilisateurId { get; set; }
    }

    public class UtilisateurLoginReponse
    {
    }*/
}
