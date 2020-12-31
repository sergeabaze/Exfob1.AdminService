using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CodePlaquetteRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  QualiteBoisID { get; set; }
		[Required]
		public int  SciesID { get; set; }
		[Required]
		public int  TypeLongueurID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public string  CodePlaq1 { get; set; }
		[Required]
		public string  CodeIhc { get; set; }
		[Required]
		public string  PrixVenteLocale { get; set; }
		[Required]
		public string  PosAffic { get; set; }
		[Required]
		public string  LongueurRecuperation { get; set; }
	}
}
