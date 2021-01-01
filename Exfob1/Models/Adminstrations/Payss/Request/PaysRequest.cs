using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PaysRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodePays { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  NomPays { get; set; }
		public string  CodePostal { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
	}
}
