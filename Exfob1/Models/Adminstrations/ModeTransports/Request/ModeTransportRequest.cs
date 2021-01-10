using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ModeTransportRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		public string  Libelle { get; set; }
	}
}
