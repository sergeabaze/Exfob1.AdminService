using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TarifIHCRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public int  EssenceID { get; set; }
		[Required]
		public int  ProduitID { get; set; }
		[Required]
		public int  QualiteIHCID { get; set; }
		[Required]
		public float  PrixM3Prix { get; set; }
		public float  AncienPrixM3 { get; set; }
		public DateTime  DateAncienPrixm3 { get; set; }
		public DateTime  DatePrixM3 { get; set; }
	}
}
