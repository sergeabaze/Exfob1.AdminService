using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CompteBanqueRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  NumeroCompte { get; set; }
	}
}
