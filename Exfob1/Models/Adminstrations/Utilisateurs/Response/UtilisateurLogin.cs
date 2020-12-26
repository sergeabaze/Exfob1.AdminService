using System;
using System.Collections.Generic;
using System.Text;

namespace Exfob1.Models.Adminstrations.Utilisateurs.Response
{
   public  class UtilisateurLogin
    {
        public int UtilisateurID { get; set; }
        public string Nom { get; set; }
        public string SiteOperation { get; set; }
        public string Email { get; set; }
      //  public bool Success { get; set; }
       // public Utilisateur Utilisateur { get; set; }
       // public string LibelleMessageFr { get; set; }
        //public List<Utilisateur> Utilisateurs { get; set; }
       // public MessageReponse Message { get; set; }
    }
}
