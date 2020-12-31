using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientContactRequest
	{
		[Required]
		public int  ClientID { get; set; }
		[Required]
		public int  ClientAdresseID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  NomContact { get; set; }
		public string  Email { get; set; }
		public string  Telephone { get; set; }
		public bool  EstDefaut { get; set; }
	}
}
