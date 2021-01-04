using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class RedevanceEtatiqueRequest
	{
		[Required]
		public int  PortID { get; set; }
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public string  Intitule { get; set; }
		public double  TriAffic { get; set; }
	}
}
