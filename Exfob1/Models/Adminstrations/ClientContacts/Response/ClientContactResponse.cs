using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientContactReponse
	{

		public int  ClientContactID { get; set; }
		public int  ClientID { get; set; }
		public int  ClientAdresseID { get; set; }
		public string  Code { get; set; }
		public string  NomContact { get; set; }
		public string  Email { get; set; }
		public string  Telephone { get; set; }
		public bool  EstDefaut { get; set; }
	}
}
