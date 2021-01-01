using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SciesRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeNature { get; set; }
		public string  Sigle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeProduction { get; set; }
		public double  OrdreOperation { get; set; }
		public bool  OrdreActivite { get; set; }
		public string  ScieOrg { get; set; }
		public string  FamilleProduction { get; set; }
		public string  ScieProduit { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  EquipeID { get; set; }
	}
}
