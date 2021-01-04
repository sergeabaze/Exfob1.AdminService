using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ParcReponse
	{

		public int  ParcID { get; set; }
		public int  SiteOperattionID { get; set; }
		public int  NatureParcID { get; set; }
		public string  CodeParc { get; set; }
		public string  Libelle { get; set; }
		public bool  CodeVolume { get; set; }
		public string  CodeArbre { get; set; }
		public string  CodeStockSechoir { get; set; }
		public string  CodeParcBois { get; set; }
		public int  LieuTransitID { get; set; }
	}
}
