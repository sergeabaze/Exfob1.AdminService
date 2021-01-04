using System;
namespace Exfob1.Models.Adminstrations
{
	public  class SocieteReponse
	{

		public int  SocieteID { get; set; }
		public double  SiegeID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public string  Description { get; set; }
		public string  BoitePostale { get; set; }
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
		public bool  EstPeriodeCloture { get; set; }
	}
}
