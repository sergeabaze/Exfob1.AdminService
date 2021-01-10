using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class EssenceRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  ClasseEssenceID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  CategorieEssenceID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		public string  NomScientifique { get; set; }
		public string  CodeMesurage { get; set; }
		public double  DiamExpeditionOfficielle { get; set; }
		public string  MesurageAubier { get; set; }
		public bool  CodeActif { get; set; }
		public string  NomSnt { get; set; }
		public string  CodeCubagePlein { get; set; }
		public string  CodeCubageCom { get; set; }
		public string  CodeStat { get; set; }
		public string  CodeCde { get; set; }
		public string  CodeIhc { get; set; }
		public string  Aupdate { get; set; }
		public float  RendementProduitRC { get; set; }
		public string  EtatIc { get; set; }
		public float  RendementProduitRC1 { get; set; }
		public float  SeuilLongueurEntreeScie { get; set; }
		public float  PrixFob { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
	}
}
