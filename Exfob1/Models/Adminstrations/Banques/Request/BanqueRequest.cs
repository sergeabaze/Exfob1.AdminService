using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class BanqueRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Sigle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeGuichet { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Iban { get; set; }
		public string  Swift { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Domiciliation { get; set; }
	}
}
