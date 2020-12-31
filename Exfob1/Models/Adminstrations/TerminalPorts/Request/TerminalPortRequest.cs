using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TerminalPortRequest
	{
		[Required]
		public int  PortID { get; set; }
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public string  Nom { get; set; }
		public double  TriAffic { get; set; }
	}
}
