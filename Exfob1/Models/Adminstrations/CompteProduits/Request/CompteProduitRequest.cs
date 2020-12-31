using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CompteProduitRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		public string  CodeJournal { get; set; }
		public string  CompteGeneral { get; set; }
		public string  CompteTiers { get; set; }
		public string  CompteProduit { get; set; }
		public string  CompteAnalytique { get; set; }
		public string  CodSig { get; set; }
		public string  LibelleEcriture { get; set; }
		public bool  TaxeTVA { get; set; }
		public bool  TaxeCa { get; set; }
		public bool  TaxeAsdi { get; set; }
		public bool  TaxeDigenaf { get; set; }
		public string  TypeFacture { get; set; }
	}
}
