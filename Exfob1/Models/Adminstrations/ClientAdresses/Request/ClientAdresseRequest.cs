using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientAdresseRequest
	{
		[Required]
		public int  ClientID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public string  Email { get; set; }
		public string  Telephone { get; set; }
	}
}
