using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class FamilleRequest
	{
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
	}
}
