using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SechoirRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  Capacite { get; set; }
		[Required]
		public string  LibelleChambre { get; set; }
	}
}
