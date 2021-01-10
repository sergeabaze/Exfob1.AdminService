using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PeriodeClotureRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  PeriodeID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  EstPeriodeCourante { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  EstPeriodeCloture { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateDebut { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateFin { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CreerPar { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public DateTime  DateCreation { get; set; }
		public string  ModifierPar { get; set; }
		public DateTime  DateModification { get; set; }
	}
}
