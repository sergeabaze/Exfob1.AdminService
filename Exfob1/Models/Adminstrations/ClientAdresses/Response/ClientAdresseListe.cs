using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientAdresseListe
	{
		public int  ClientAdresseID { get; set; }
		public int  ClientID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public string  Email { get; set; }
		public string  Telephone { get; set; }
	}
}
