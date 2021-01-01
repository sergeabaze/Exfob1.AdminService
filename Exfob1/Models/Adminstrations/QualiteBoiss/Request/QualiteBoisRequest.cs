using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class QualiteBoisRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  ProduitID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeQualite { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public string  CodeMercuriale { get; set; }
		public string  CodeActivite { get; set; }
		public string  CodePlaq1 { get; set; }
		public string  CodeIhc { get; set; }
		public float  PrixVenteLocale { get; set; }
		public string  PosAffic { get; set; }
		public string  LongueurRecuperation { get; set; }
	}
}
