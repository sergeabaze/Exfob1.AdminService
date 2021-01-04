using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ModuleRequest
	{
		[Required]
		public string  Libelle { get; set; }
		public int  ModuleParentID { get; set; }
	}
}
