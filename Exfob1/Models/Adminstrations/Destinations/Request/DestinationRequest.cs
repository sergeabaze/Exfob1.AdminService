using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class DestinationRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public double  PaysID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public double  Phyto { get; set; }
		public double  Co { get; set; }
		public double  Eur1 { get; set; }
	}
}
