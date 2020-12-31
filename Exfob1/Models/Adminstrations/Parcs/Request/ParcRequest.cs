using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ParcRequest
	{
		[Required]
		public int  SiteOperattionID { get; set; }
		[Required]
		public int  NatureParcID { get; set; }
		[Required]
		public string  CodeParc { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public bool  CodeVolume { get; set; }
		[Required]
		public string  CodeArbre { get; set; }
		[Required]
		public string  CodeStockSechoir { get; set; }
		public string  CodeParcBois { get; set; }
		public int  LieuTransitID { get; set; }
	}
}
