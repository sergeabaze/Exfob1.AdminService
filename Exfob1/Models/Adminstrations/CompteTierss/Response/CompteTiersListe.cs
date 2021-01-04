using System;
namespace Exfob1.Models.Adminstrations
{
	public  class CompteTiersListe
	{
		public int  CompteTiersID { get; set; }
		public int  SocieteID { get; set; }
		public double  PaysID { get; set; }
		public string  NumeroCompte { get; set; }
		public string  NumeroPrinc { get; set; }
		public double  Type { get; set; }
		public string  Adresse { get; set; }
		public string  Ville { get; set; }
		public string  CodePostal { get; set; }
		public string  BoiteNumero { get; set; }
		public string  CtNumero { get; set; }
	}
}
