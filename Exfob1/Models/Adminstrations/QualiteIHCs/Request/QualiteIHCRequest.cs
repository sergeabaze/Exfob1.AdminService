using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class QualiteIHCRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeQualite { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public string  CodeMercuriale { get; set; }
		public bool  CodeActivite { get; set; }
		public string  CodePlaquette { get; set; }
		public string  CodePlaquette1 { get; set; }
		public string  CodeIhc { get; set; }
		public float  PrixVenteLocale { get; set; }
		public string  PosAffic { get; set; }
		public float  LongueurRecuperation { get; set; }
		public string  ObservationsQualiteIHC { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  SousFamilleID { get; set; }
	}
}
