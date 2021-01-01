using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class AffecterEquipeRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  TrancheHoraireID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  OperateurID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  EquipeID { get; set; }
		public bool  EstChefEquipe { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateOperation { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  EstResponsable { get; set; }
	}
}
