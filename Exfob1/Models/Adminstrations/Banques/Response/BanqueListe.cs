using System;
namespace Exfob1.Models.Adminstrations
{
	public  class BanqueListe
	{
		public int  BanqueID { get; set; }
		public int  SocieteID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public string  Sigle { get; set; }
		public string  CodeGuichet { get; set; }
		public string  Iban { get; set; }
		public string  Swift { get; set; }
		public string  Domiciliation { get; set; }
	}
}
