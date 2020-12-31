using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClasseEssenceRequest
	{
		[Required]
		public string  Libelle { get; set; }
	}
}
