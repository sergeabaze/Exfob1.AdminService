using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SiegeRequest
	{
		public double  GroupeID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public string  Adresse { get; set; }
		public string  Pays { get; set; }
		public string  Ville { get; set; }
	}
}
