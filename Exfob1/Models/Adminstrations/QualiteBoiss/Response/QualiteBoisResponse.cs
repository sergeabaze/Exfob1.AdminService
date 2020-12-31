using System;
namespace Exfob1.Models.Adminstrations
{
	public  class QualiteBoisReponse
	{

		public int  QualiteBoisID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  ProduitID { get; set; }
		public string  CodeQualite { get; set; }
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
