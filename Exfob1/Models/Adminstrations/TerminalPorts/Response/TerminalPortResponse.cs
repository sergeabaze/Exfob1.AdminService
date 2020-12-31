using System;
namespace Exfob1.Models.Adminstrations
{
	public  class TerminalPortReponse
	{

		public int  TerminalPortID { get; set; }
		public int  PortID { get; set; }
		public int  SiteOperationID { get; set; }
		public string  Nom { get; set; }
		public double  TriAffic { get; set; }
	}
}
