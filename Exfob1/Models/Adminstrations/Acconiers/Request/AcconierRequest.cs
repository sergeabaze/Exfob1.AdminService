using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class AcconierRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Nom { get; set; }
		public string  Localisation { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
	}
}
