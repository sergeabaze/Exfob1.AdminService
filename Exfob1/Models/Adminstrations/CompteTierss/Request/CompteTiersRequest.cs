using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CompteTiersRequest
	{
		public int  SocieteID { get; set; }
		public double  PaysID { get; set; }
		public string  NumeroCompte { get; set; }
		public string  NumeroPrinc { get; set; }
		public double  Type { get; set; }
		public string  Adresse { get; set; }
		public string  Ville { get; set; }
		public string  CodePostal { get; set; }
		public string  BoiteNumero { get; set; }
		public string  CtNumero { get; set; }
	}
}
