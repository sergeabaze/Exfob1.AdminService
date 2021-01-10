using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SocieteRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public double  SiegeID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Code { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Description { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  BoitePostale { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Adresse { get; set; }
		public string  Ville { get; set; }
		public string  NatureActivite { get; set; }
		public string  Regime { get; set; }
		public string  Pw { get; set; }
		public string  Fsc { get; set; }
		public string  Tltv { get; set; }
		public string  NumIdentite { get; set; }
		public string  LDevise { get; set; }
		public byte[]  Logo { get; set; }
		public DateTime  DateCreation { get; set; }
		public string  NumeroCompte { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  EstPeriodeCloture { get; set; }
	}
}
