using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SocieteRequest
	{
		[Required]
		public double  SiegeID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public string  Description { get; set; }
		[Required]
		public string  BoitePostale { get; set; }
		[Required]
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
		[Required]
		public bool  EstPeriodeCloture { get; set; }
	}
}
