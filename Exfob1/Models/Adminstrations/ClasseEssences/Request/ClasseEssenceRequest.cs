using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClasseEssenceRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
	}
}
