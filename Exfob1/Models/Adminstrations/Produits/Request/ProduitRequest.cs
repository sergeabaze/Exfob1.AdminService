using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ProduitRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SousFamilleID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeProduit { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public string  TypeQualite { get; set; }
		public string  TypeGroupe { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeActivite { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodePlaque { get; set; }
		public string  PostAff { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeSig { get; set; }
		public string  SDKDF { get; set; }
		public string  Unites { get; set; }
	}
}
