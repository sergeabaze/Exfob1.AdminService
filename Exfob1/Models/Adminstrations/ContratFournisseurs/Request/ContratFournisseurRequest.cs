using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ContratFournisseurRequest
	{
		[Required]
		public int  FournisseurID { get; set; }
		[Required]
		public int  SiteOperationID { get; set; }
		public string  NumeroAgrement { get; set; }
		[Required]
		public bool  Responsable { get; set; }
		[Required]
		public DateTime  DateDebut { get; set; }
		[Required]
		public DateTime  Datefin { get; set; }
	}
}
