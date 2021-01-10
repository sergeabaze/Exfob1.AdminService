using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SectionAnalytiqueRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public double  NAnalyse { get; set; }
		public string  SectionAnalytiqueGb { get; set; }
	}
}
