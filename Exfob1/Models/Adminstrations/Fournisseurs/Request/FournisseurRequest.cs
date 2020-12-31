using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class FournisseurRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  TypeFournisseurID { get; set; }
		[Required]
		public string  Code { get; set; }
		public string  Designation { get; set; }
		public string  Adresse1 { get; set; }
		public string  Adresse2 { get; set; }
		public string  BoitePostal { get; set; }
		public string  Telephone1 { get; set; }
		public string  Telephone2 { get; set; }
		public string  Email { get; set; }
	}
}
