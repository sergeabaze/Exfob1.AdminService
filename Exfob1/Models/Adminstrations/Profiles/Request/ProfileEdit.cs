using Exfob1.Communs;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exfob1.Models.Adminstrations
{
    public  class ProfileEdit: ProfileRequest
    {
        [Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
        public int ProfilID { get; set; }
       
    }
}
