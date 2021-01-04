using System;
namespace Exfob1.Models.Adminstrations
{
	public  class QualiteIHCListe
	{
		public int  QualiteIHCID { get; set; }
		public string  CodeQualite { get; set; }
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
		public int  SousFamilleID { get; set; }
	}
}
