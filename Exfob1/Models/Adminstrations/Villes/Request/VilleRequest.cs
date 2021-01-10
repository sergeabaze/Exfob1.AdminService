using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class VilleRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public double  PaysID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		public string  NomVille { get; set; }
	}
}
