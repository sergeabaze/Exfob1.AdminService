using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PortEmbarquementRequest
	{
		[Required]
		public int  PortEmbraquementID { get; set; }
		public int  SiteOperationID { get; set; }
		public string  Libelle { get; set; }
		public string  Sigle { get; set; }
	}
}
