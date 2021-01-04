using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class GroupeRequest
	{
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public string  Adresse { get; set; }
		public string  Ville { get; set; }
	}
}
