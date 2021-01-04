using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PaysRequest
	{
		[Required]
		public string  CodePays { get; set; }
		[Required]
		public string  NomPays { get; set; }
		public string  CodePostal { get; set; }
		public int  SocieteID { get; set; }
	}
}
