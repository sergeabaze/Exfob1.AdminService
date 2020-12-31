using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class AcconierRequest
	{
		[Required]
		public string  Nom { get; set; }
		public string  Localisation { get; set; }
		public int  SiteOperationID { get; set; }
	}
}
