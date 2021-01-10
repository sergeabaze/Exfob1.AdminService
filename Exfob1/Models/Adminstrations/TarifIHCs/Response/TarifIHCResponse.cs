using System;
namespace Exfob1.Models.Adminstrations
{
	public  class TarifIHCReponse
	{

		public int  TarifIHCID { get; set; }
		public int  SocieteID { get; set; }
		public int  EssenceID { get; set; }
		public int  ProduitID { get; set; }
		public int  QualiteIHCID { get; set; }
		public float  PrixM3Prix { get; set; }
		public float  AncienPrixM3 { get; set; }
		public DateTime  DateAncienPrixm3 { get; set; }
		public DateTime  DatePrixM3 { get; set; }
	}
}
