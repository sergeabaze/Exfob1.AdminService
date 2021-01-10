using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ContratFournisseurReponse
	{

		public int  FournisseurID { get; set; }
		public int  SiteOperationID { get; set; }
		public string  NumeroAgrement { get; set; }
		public bool  Responsable { get; set; }
		public DateTime  DateDebut { get; set; }
		public DateTime  Datefin { get; set; }
		public int  ContratFournisseurID { get; set; }
	}
}
