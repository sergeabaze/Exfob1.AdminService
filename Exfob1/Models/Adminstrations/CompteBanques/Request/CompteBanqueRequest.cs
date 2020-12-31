using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CompteBanqueRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  NumeroCompte { get; set; }
	}
}
