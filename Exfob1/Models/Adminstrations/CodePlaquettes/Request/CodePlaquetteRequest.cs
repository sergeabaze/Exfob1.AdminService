using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CodePlaquetteRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  QualiteBoisID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SciesID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  TypeLongueurID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodePlaq1 { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeIhc { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  PrixVenteLocale { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  PosAffic { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  LongueurRecuperation { get; set; }
	}
}
