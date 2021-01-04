using System;
namespace Exfob1.Models.Adminstrations
{
	public  class CodePlaquetteReponse
	{

		public int  CodePlaquetteID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  QualiteBoisID { get; set; }
		public int  SciesID { get; set; }
		public int  TypeLongueurID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public string  CodePlaq1 { get; set; }
		public string  CodeIhc { get; set; }
		public string  PrixVenteLocale { get; set; }
		public string  PosAffic { get; set; }
		public string  LongueurRecuperation { get; set; }
	}
}
