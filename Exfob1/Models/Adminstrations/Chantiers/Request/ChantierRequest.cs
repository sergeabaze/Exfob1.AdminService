using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ChantierRequest
	{
		public int  SiteOperationID { get; set; }
		public string  CodeChantier { get; set; }
		public string  Libelle { get; set; }
		public string  GroupeAppart { get; set; }
		public string  CodeActivite { get; set; }
		public string  SeqBil { get; set; }
		public bool  Actif { get; set; }
		[Required]
		public DateTime  DateCreation { get; set; }
		[Required]
		public string  CreerPar { get; set; }
		public DateTime  DateModification { get; set; }
		public string  MisejourPar { get; set; }
		[Required]
		public int  ContratFournisseurID { get; set; }
	}
}
