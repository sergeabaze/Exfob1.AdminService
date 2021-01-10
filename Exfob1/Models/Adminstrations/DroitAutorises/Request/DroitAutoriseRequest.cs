using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class DroitAutoriseRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  ProfilAutoriseID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  ModuleID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  Ecriture { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  Lecture { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  Modifier { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  Suppression { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  Impression { get; set; }
	}
}
