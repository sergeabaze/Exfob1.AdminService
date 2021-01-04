using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ChantierListe
	{
		public int  ChantierID { get; set; }
		public int  SiteOperationID { get; set; }
		public string  CodeChantier { get; set; }
		public string  Libelle { get; set; }
		public string  GroupeAppart { get; set; }
		public string  CodeActivite { get; set; }
		public string  SeqBil { get; set; }
		public bool  Actif { get; set; }
		public DateTime  DateCreation { get; set; }
		public string  CreerPar { get; set; }
		public DateTime  DateModification { get; set; }
		public string  MisejourPar { get; set; }
		public int  ContratFournisseurID { get; set; }
	}
}
