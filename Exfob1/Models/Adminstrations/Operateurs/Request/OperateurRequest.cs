using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class OperateurRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  TypeOperateurID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public bool  EstResponsable { get; set; }
		public int  OperateurGB3ID { get; set; }
		public int  OperateurGBID { get; set; }
	}
}
