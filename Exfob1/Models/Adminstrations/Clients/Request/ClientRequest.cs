using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientRequest
	{
		public int  SiteOperationID { get; set; }
		public double  SiegeID { get; set; }
		[Required]
		public int  TypeclientID { get; set; }
		[Required]
		public double  PaysID { get; set; }
		[Required]
		public int  VilleID { get; set; }
		public string  Code { get; set; }
		public string  Nomclient { get; set; }
		public string  Telephone1 { get; set; }
		public string  Telephone2 { get; set; }
		public string  Faxe1 { get; set; }
		public string  Faxe2 { get; set; }
		public string  Email { get; set; }
		public string  Observation { get; set; }
		public string  EorNumber { get; set; }
	}
}
