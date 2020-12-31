using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ModePaiementRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public string  Intitule { get; set; }
	}
}
