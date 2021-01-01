using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ContratFournisseurRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  FournisseurID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		public string  NumeroAgrement { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  Responsable { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateDebut { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  Datefin { get; set; }
	}
}
