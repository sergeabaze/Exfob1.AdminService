using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ProduitRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public int  SousFamilleID { get; set; }
		[Required]
		public string  CodeProduit { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public string  TypeQualite { get; set; }
		public string  TypeGroupe { get; set; }
		[Required]
		public string  CodeActivite { get; set; }
		[Required]
		public string  CodePlaque { get; set; }
		public string  PostAff { get; set; }
		[Required]
		public string  CodeSig { get; set; }
		public string  SDKDF { get; set; }
		public string  Unites { get; set; }
	}
}
