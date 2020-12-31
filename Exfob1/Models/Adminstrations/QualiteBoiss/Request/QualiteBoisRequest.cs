using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class QualiteBoisRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  ProduitID { get; set; }
		[Required]
		public string  CodeQualite { get; set; }
		[Required]
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
