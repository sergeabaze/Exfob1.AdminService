using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class GroupeRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public string  Adresse { get; set; }
		public string  Ville { get; set; }
	}
}
