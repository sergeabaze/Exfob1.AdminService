using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class EquipeRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  TypeEquipeID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
	}
}
