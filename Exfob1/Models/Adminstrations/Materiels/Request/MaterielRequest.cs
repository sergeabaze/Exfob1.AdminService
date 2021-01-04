using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class MaterielRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  TypeMaterielID { get; set; }
		[Required]
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public int  SousTraitanceID { get; set; }
	}
}
