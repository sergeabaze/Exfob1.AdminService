using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class LamelleChoixRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public string  LibelleChoix { get; set; }
	}
}
