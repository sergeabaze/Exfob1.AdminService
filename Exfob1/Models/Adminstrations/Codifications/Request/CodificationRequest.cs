using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CodificationRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public string  QualiteCode { get; set; }
		public string  ClasseCode { get; set; }
	}
}
