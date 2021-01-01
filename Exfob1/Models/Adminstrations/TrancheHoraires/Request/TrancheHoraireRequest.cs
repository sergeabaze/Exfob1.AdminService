using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TrancheHoraireRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateDebut { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  Datefin { get; set; }
		public string  Libelle { get; set; }
	}
}
