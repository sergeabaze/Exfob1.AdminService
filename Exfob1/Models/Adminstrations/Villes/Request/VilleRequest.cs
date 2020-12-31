using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class VilleRequest
	{
		[Required]
		public double  PaysID { get; set; }
		[Required]
		public string  Code { get; set; }
		public string  NomVille { get; set; }
	}
}
