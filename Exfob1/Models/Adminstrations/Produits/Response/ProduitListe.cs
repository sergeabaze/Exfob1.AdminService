using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ProduitListe
	{
		public int  ProduitID { get; set; }
		public int  SocieteID { get; set; }
		public int  SousFamilleID { get; set; }
		public string  CodeProduit { get; set; }
		public string  Libelle { get; set; }
		public string  TypeQualite { get; set; }
		public string  TypeGroupe { get; set; }
		public string  CodeActivite { get; set; }
		public string  CodePlaque { get; set; }
		public string  PostAff { get; set; }
		public string  CodeSig { get; set; }
		public string  SDKDF { get; set; }
		public string  Unites { get; set; }
	}
}
