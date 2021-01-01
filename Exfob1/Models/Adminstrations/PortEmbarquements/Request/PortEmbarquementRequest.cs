using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PortEmbarquementRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  PortEmbraquementID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		public string  Libelle { get; set; }
		public string  Sigle { get; set; }
	}
}
