using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class LieuTransitRequest
	{
		[Required]
		public int  SiteOperattionID { get; set; }
		[Required]
		public int  PortID { get; set; }
		public string  TypeSiteParc { get; set; }
		public string  Libelle { get; set; }
	}
}
