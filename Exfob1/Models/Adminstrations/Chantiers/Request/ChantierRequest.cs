using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ChantierRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		public string  CodeChantier { get; set; }
		public string  Libelle { get; set; }
		public string  GroupeAppart { get; set; }
		public string  CodeActivite { get; set; }
		public string  SeqBil { get; set; }
		public bool  Actif { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateCreation { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CreerPar { get; set; }
		public DateTime  DateModification { get; set; }
		public string  MisejourPar { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  ContratFournisseurID { get; set; }
	}
}
