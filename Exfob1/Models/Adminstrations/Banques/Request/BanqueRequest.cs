using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class BanqueRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public string  Sigle { get; set; }
		[Required]
		public string  CodeGuichet { get; set; }
		[Required]
		public string  Iban { get; set; }
		public string  Swift { get; set; }
		[Required]
		public string  Domiciliation { get; set; }
	}
}
