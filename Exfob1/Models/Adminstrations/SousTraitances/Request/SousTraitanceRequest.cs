using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SousTraitanceRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Intitule { get; set; }
		public string  SigleTrait { get; set; }
		public string  InfoTrait { get; set; }
		public string  CodeTransp { get; set; }
		public string  SousFacture { get; set; }
	}
}
